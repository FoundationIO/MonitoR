using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System;
using Microsoft.Web.Administration;
using System.Threading;

namespace MonitoR.Common.Sensors
{
#pragma warning disable S101 // Types should be named in camel case
    public class IISApplicationPoolSensor : BaseSensor
#pragma warning restore S101 // Types should be named in camel case
    {
        public IISApplicationPoolSensor()
        {
            SensorType = SensorType.IISApplicationPool;
        }
        public List<string> ApplicationPools { get; set; } = new List<string>();

        public bool RestartIfStopped { get; set; }

        public int DelayForRecheckingStatus { get; set; }

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            try
            {
                var manager = ServerManager.OpenRemote(System.Environment.MachineName);

                foreach (var currentApppPool in ApplicationPools)
                {
                    var found = false;
                    ApplicationPool appAppPool = null;
                    foreach (var iisAppPool in manager.ApplicationPools)
                    {
                        if (iisAppPool.Name == currentApppPool)
                        {
                            appAppPool = iisAppPool;
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        if (appAppPool.State != ObjectState.Started)
                        {
                            if (RestartIfStopped)
                            {
                                appAppPool.Start();
                                Thread.Sleep(DelayForRecheckingStatus);
                                if (appAppPool.State == ObjectState.Started)
                                {
                                    if (appAppPool.State != ObjectState.Started)
                                    {
                                        errorList.AppendLine($"The Application Pool - {currentApppPool} was down and subsequent restart attempt failed.");
                                    }
                                    else
                                    {
                                        errorList.AppendLine($"Application Pool - {currentApppPool} was down and subsequent restart fixed it.");
                                    }
                                }
                            }
                            errorList.AppendLine($"Application Pool - {currentApppPool} is down");
                        }
                    }
                    else
                    {
                        errorList.AppendLine($"Application Pool - {currentApppPool} is not found");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, $"Unexpected error when checking IIS Application Pool status");
                errorList.AppendLine($"Unexpected error when checking IIS Application Pool status");
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

            if (DelayForRecheckingStatus < 0)
                return ReturnValue.False("Delay For Rechecking Status should not be less than 0");

            if (ApplicationPools == null || ApplicationPools.Count == 0)
                return ReturnValue.False("You need to select atleast one application pool to check");

            return ReturnValue.True();
        }
    }

}
