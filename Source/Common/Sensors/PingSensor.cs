using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Net.NetworkInformation;
using System;

namespace MonitoR.Common.Sensors
{
    public class PingSensor : BaseSensor
    {
        public PingSensor()
        {
            SensorType = SensorType.Ping;
        }

        public List<string> Servers { get; set; } = new List<string>();
        public bool RestartIfStopped { get; set; }
        public int DefaultTimeoutInSec { get; set; } = 0;

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            foreach (var server in Servers)
            {
                try
                {
                    using (var ping = new Ping())
                    {
                        var pingResult = ping.Send(server, DefaultTimeoutInSec * 1000);
                        if (pingResult.Status != IPStatus.Success)
                        {
                            errorList.AppendLine($"Unable to ping the server - {server}.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    log.Error(ex,$"Unable to ping the server - {server}, unexcepted error happend.");
                    errorList.AppendLine($"Unable to ping the server - {server}, unexcepted error happend.");
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

            if (result?.Result != true)
                return result;

            if (DefaultTimeoutInSec < 0)
                return ReturnValue.False("DefaultTimeoutInSec should not be less than 0");

            if (Servers == null || Servers.Count == 0)
                return ReturnValue.False("You need to select atleast one drive to check");

            return ReturnValue.True();
        }
    }
}
