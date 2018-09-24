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
    public class IISWebsiteSensor : BaseSensor
#pragma warning restore S101 // Types should be named in camel case
    {
        public IISWebsiteSensor()
        {
            SensorType = SensorType.IISWebsite;
        }

        public List<string> Websites { get; set; } = new List<string>();
        public bool RestartIfStopped { get; set; }
        public int DelayForRecheckingStatus { get; set; } = 5000;

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            try
            {
                var manager = ServerManager.OpenRemote(System.Environment.MachineName);

                foreach (var website in Websites)
                {
                    var found = false;
                    Site appSite = null;
                    foreach (var iisWebsite in manager.Sites)
                    {
                        if (iisWebsite.Name == website)
                        {
                            appSite = iisWebsite;
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        if (appSite.State != ObjectState.Started)
                        {
                            if (RestartIfStopped)
                            {
                                appSite.Start();
                                Thread.Sleep(DelayForRecheckingStatus);
                                if(appSite.State == ObjectState.Started)
                                {
                                    if (appSite.State != ObjectState.Started)
                                    {
                                        errorList.AppendLine($"{website} was down and subsequent restart attempt failed.");
                                    }
                                    else
                                    {
                                        errorList.AppendLine($"{website} was down and subsequent restart fixed it.");
                                    }
                                }
                            }
                            errorList.AppendLine($"{website} is down");
                        }
                    }
                    else
                    {
                        errorList.AppendLine($"{website} is not found");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex,$"Unexpected error when checking IIS Site status");
                errorList.AppendLine($"Unexpected error when checking IIS Site status");
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

            if (DelayForRecheckingStatus < 0)
                return ReturnValue.False("Delay For Rechecking Status should not be less than 0");

            if (Websites == null || Websites.Count == 0)
                return ReturnValue.False("You need to select atleast one drive to check");

            return ReturnValue.True();
        }
    }
}
