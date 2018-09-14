using FluentScheduler;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Job;
using MonitoR.Common.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitoR
{
    public class ServiceProgram : ServiceBase
    {
        private readonly ILog log;
        private readonly IAppConfig appConfig;
        private readonly IEmailService emailService;
        private Thread thrd;
        public ServiceProgram(IAppConfig appConfig, ILog log, IEmailService emailService)
        {
            this.log = log;
            this.appConfig = appConfig;
            this.emailService = emailService;

            CreateFileWatcher(this.appConfig.GetAppSettingsFile(),
                (object sender, FileSystemEventArgs e) =>
                {
                    log.Info("Reloading App settings because of the changes to file");
                    this.appConfig.LoadAppSettings();
                },
                (object sender, RenamedEventArgs e) =>
                {
                    log.Info("Reloading App settings because of the file rename");
                    this.appConfig.LoadAppSettings();
                });

            CreateFileWatcher(this.appConfig.GetMonitorSettingsFile(),
                (object sender, FileSystemEventArgs e) =>
                {
                    log.Info("Reloading Monitor details because of the changes to file");
                    appConfig.LoadMonitorSettings();
                    StartJob();
                },
                (object sender, RenamedEventArgs e) =>
                {
                    log.Info("Reloading Monitor details because of the file rename");
                    appConfig.LoadMonitorSettings();
                    StartJob();
                });
        }

        protected override void OnStart(string[] args)
        {
            log.Debug("OnStart method of Service called");
            thrd = new Thread(StartJob);
            thrd.Start();
        }

        protected override void OnStop()
        {
            log.Info($"Stopping:{ServiceName}Service");
            if(thrd != null)
                thrd.Abort();
            log.Info($"Service:{ServiceName} stopped");
        }

        public void StartJob()
        {
            JobManager.RemoveAllJobs();

            JobManager.JobStart += (start) =>
            {
            };

            JobManager.Initialize(new JobRegistry(appConfig,log, emailService));
        }

        public FileSystemWatcher CreateFileWatcher(string fullFileName, FileSystemEventHandler onFileChange, RenamedEventHandler onFileRename)
        {
            var fileDir = Path.GetDirectoryName(fullFileName);
            if (Directory.Exists(fileDir) == false)
            {
                try
                {
                    Directory.CreateDirectory(fileDir);
                }
                catch(Exception ex)
                {
                    throw new Exception("Unable to create the configuration path", ex);
                }
            }

            var watcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(fullFileName),
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = Path.GetFileName(fullFileName)
            };

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(onFileChange);
            watcher.Created += new FileSystemEventHandler(onFileChange);
            watcher.Deleted += new FileSystemEventHandler(onFileChange);
            watcher.Renamed += new RenamedEventHandler(onFileRename);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            return watcher;
        }

    }
}
