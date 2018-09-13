using FluentScheduler;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using MonitoR.Common.Sensors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonitoR.Common.Service;

namespace MonitoR.Common.Job
{

    public class JobRegistry : Registry
    {
        private readonly IAppConfig appConfig;
        private readonly ILog log;
        private readonly IEmailService emailService;

        public JobRegistry(IAppConfig appConfig, ILog log, IEmailService emailService)
        {            
            var settings = appConfig.MonitorSettings;
            this.appConfig = appConfig;
            this.log = log;
            this.emailService = emailService;

            if (settings == null)
                return;

            NonReentrantAsDefault();
            AddJob<HttpSensor>(settings.HttpSensors);
            AddJob<FtpSensor>(settings.FtpSensors);
            AddJob<DriveSpaceSensor>(settings.DrivespaceSensors);
            AddJob<FolderSizeSensor>(settings.FolderSizeSensors);
            AddJob<FileSizeSensor>(settings.FileSizeSensors);
            AddJob<CpuSensor>(settings.CpuSensors);
            AddJob<RamSensor>(settings.RamSensors);
            AddJob<ServiceSensor>(settings.ServiceSensors);
            AddJob<ProcessSensor>(settings.ProcessSensors);
            AddJob<SqlConnectionSensor>(settings.SqlConnectionSensors);
            AddJob<IISApplicationPoolSensor>(settings.IISApplicationPoolSensors);
            AddJob<IISWebsiteSensor>(settings.IISWebsiteSensors);
            AddJob<PingSensor>(settings.PingSensors);
        }

        private void AddJob<T>(List<T> sensors) where T : BaseSensor
        {
            if (sensors == null)
                return;

            foreach (var sensor in sensors)
            {
                if (!sensor.Enabled)
                    continue;

                Schedule(() => new SensorJob(sensor, appConfig, log, emailService)).ToRunNow().AndEvery(sensor.CheckInterval).Seconds();
            }

        }
    }


}
