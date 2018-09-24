using FluentScheduler;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using MonitoR.Common.Sensors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonitoR.Common.Service;
using MonitoR.Common.Constants;

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
            AddJobs(settings.GetAllSensors());
        }

        private void AddJobs(List<ISensor> sensors)
        {
            if (sensors == null || sensors.Count == 0)
            {
                log.Info("No jobs available for scheduling");
                return;
            }

            foreach (var sensor in sensors)
            {
                if (sensor == null)
                    continue;

                if (!sensor.Enabled)
                {
                    log.Info($"Ignore diabled Job - {sensor.Name} ({sensor.SensorType}) ( {sensor.Id}) - " + sensor.GetDetails());
                    continue;
                }

                log.Info($"Scheduling Job - {sensor.Name} ({sensor.SensorType}) ( {sensor.Id}) - " + sensor.GetDetails());
                Schedule(() => new SensorJob(sensor, appConfig, log, emailService)).ToRunNow().AndEvery(sensor.IntervalType.CheckIntervalInSeconds(sensor.CheckInterval)).Seconds();
            }
        }
    }
}
