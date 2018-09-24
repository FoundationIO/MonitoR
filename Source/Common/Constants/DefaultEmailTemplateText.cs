using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Constants
{
    public static class DefaultEmailTemplateText
    {
        public const string Subject = "[{{MessagePrefix}}] [{{MachineName}}] {{ SensorType }} - {{SensorName}} failed";
        public const string TextBody = "Error occured in [{{MachineName}}] for {{ SensorType }} - {{SensorName}} \n\n {{SensorAllErrorMessage }}";
        public const string HtmlBody = "<html> <body> <b>Error occured </b> in [{{MachineName}}] for {{ SensorType }} - <b>{{SensorName}}</b> - {{SensorAllErrorMessage}} </body> </html>";
        public const string MessagePrefix = "MonitoR";
        public const string MessageSuffix = "";
    }
}
