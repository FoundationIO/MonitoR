using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using MonitoR.Common.Utilities;

namespace MonitoR.Common.Sensors
{
    public class HttpSensor : BaseSensor
    {
        public HttpSensor()
        {
            SensorType = SensorType.Http;
        }

        public List<string> Urls { get; set; } = new List<string>();
        public int DefaultTimeoutInSec { get; set; } = 10;
        public string RequestMethod { get; set; }
        public string Body { get; set; }
        public List<string> RequestHeaders { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            foreach (var url in Urls)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = DefaultTimeoutInSec * 1000;
                    request.Method = RequestMethod;
                    request.Accept = "*/*";
                    request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                            errorList.AppendLine($"Sensor - {Name} ({Id}) with Url - {url} returned status code =  {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex, $"Sensor - {Name} ({Id}) - Error connecting to Url - {url} - Error - {ex.Message}");
                    errorList.AppendLine($"Sensor - {Name} ({Id}) - Error connecting to Url - {url} - Error - {ex.Message}");
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

            if(RequestMethod == null)
                return ReturnValue.False("Http Method should be specified");

            if (!(RequestMethod.CaseIgnoreEquals("HEAD") || RequestMethod.CaseIgnoreEquals("GET") || RequestMethod.CaseIgnoreEquals("POST")))
                return ReturnValue.False("Only HEAD, GET and POST operations are allowed");

            if (Urls == null || Urls.Count == 0)
                return ReturnValue.False("You need to select atleast one url to check");

            return ReturnValue.True();
        }
    }
}
