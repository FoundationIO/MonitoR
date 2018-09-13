using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Job;
using SimpleInjector;
using MonitoR.Common.Utilities;
using System.ServiceProcess;
using MonitoR.Common.Service;

namespace MonitoR.WindowsService
{
    public static class Program
    {
        static readonly Container container;
        static Program()
        {
            container = new Container();
            container.RegisterSingleton<IAppConfig, AppConfig>();
            container.RegisterSingleton<ILog, Log>();
            container.RegisterSingleton<IEmailService, EmailService>();
            container.Verify();
        }

        static void Main()
        {
            var log = container.GetInstance<ILog>();
            var program = new ServiceProgram(container.GetInstance<IAppConfig>(), log, container.GetInstance<IEmailService>());

            if (Environment.UserInteractive)
            {
                log.Info("Running the monitor in console mode...");
                program.StartJob();
                log.Info("Press a key to exit");
                Console.ReadKey();
            }
            else
            {
                var ServicesToRun = new ServiceBase[]
                {
                    program
                };
                try
                {
                    ServiceBase.Run(ServicesToRun);
                }
                catch (Exception ex)
                {
                    log.Error(ex, "Error when running the service");
                    throw;
                }
            }

            program.Dispose();
        }
    }
}
