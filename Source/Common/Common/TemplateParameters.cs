using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Common
{
    public class TemplateParameters
    {
        public string MachineName { get; set; }
        public string MessagePrefix { get; set; }
        public string MessageSuffix { get; set; }
        public List<string> ErrorMessageList { get; set; }
        public string SensorAllErrorMessage { get; set; }
        public string SensorName {get;set;}
        public string SensorId { get; set; }
        public string SensorType { get; set; }
    }
}
