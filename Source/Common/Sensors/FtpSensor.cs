using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace MonitoR.Common.Sensors
{
    public class FtpSensor : BaseSensor
    {
        public FtpSensor()
        {
            SensorType = SensorType.Ftp;
        }

        public List<string> Servers { get; set; } = new List<string>();
        public int DefaultTimeoutInSec { get; set; } = 0;
        public string RequestMethod { get; set; }
        public string Body { get; set; }
        public List<string> RequestHeaders { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            foreach (var server in Servers)
            {
                var request = (FtpWebRequest)WebRequest.Create(server);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential("username", "password");
                request.Timeout = DefaultTimeoutInSec * 1000;

                try
                {
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        var isSucess = response.StatusCode == FtpStatusCode.CommandOK;
                        if (!isSucess)
                            errorList.AppendLine($"StatusCode =  {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex, $"Error connecting to Ftp Server - {server} - Error - {ex.Message}");
                    errorList.AppendLine($"Error connecting to Ftp Server - {server} - Error - {ex.Message}");
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

            if (!(RequestMethod == "HEAD" || RequestMethod == "GET" || RequestMethod == "POST"))
                return ReturnValue.False("Only HEAD, GET and POST operations are allowed");

            if (Servers == null || Servers.Count == 0)
                return ReturnValue.False("You need to select atleast one drive to check");

            return ReturnValue.True();
        }
    }
}
