using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Linq;

namespace MonitoR.Common.Sensors
{
    public class ServiceSensor : BaseSensor
    {
        public ServiceSensor()
        {
            SensorType = SensorType.Service;
        }
        public List<string> Services { get; set; } = new List<string>();
        public bool RestartIfStopped { get; set; }

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            var services = ServiceController.GetServices();
            foreach (var service in Services)
            {
                if (services.FirstOrDefault(x=> x.ServiceName.ToUpper().Equals(service.ToUpper())) == null )
                {
                    errorList.AppendLine($"Service {service} is not installed");
                    continue;
                }

                foreach (ServiceController systemService in services)
                {
                    if (systemService.ServiceName.ToUpper().Equals(service.ToUpper()) == false)
                    {
                        continue;
                    }

                    if (!(systemService.Status == ServiceControllerStatus.Running || systemService.Status == ServiceControllerStatus.StartPending))
                    {
                        if (RestartIfStopped)
                        {
                            systemService.Start();
                            systemService.WaitForStatus(ServiceControllerStatus.Running, new System.TimeSpan(0, 0, 10)); // wait for 10 secs and see if the service is up and running
                            if (!(systemService.Status == ServiceControllerStatus.Running || systemService.Status == ServiceControllerStatus.StartPending))
                            {
                                errorList.AppendLine($"Service {service} is not running and start by the monitor is failed");
                            }
                            else
                            {
                                errorList.AppendLine($"Service {service} is not running and it is started by the monitor");
                            }
                        }
                        else
                        {
                            errorList.AppendLine($"Service {service} is not running");
                        }
                    }
                }
            }

            if (errorList.Length == 0)
                return ReturnValue.True();
            else
                return ReturnValue.False(errorList.ToString());
        }

        public override ReturnValue IsValid(List<ISensor> allSensors)
        {
            var result = base.IsValid(allSensors);

            if (result == null || result.Result == false)
                return result;

            if (Services == null || Services.Count == 0)
                return ReturnValue.False("You need to select atleast one service to check");

            return ReturnValue.True();
        }
    }


}
