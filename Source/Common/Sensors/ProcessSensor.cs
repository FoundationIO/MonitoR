using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonitoR.Common.Sensors
{
    public class ProcessSensor : BaseSensor
    {
        public ProcessSensor()
        {
            SensorType = SensorType.Process;
        }
        public List<string> Executables { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            var processlist = Process.GetProcesses();
            foreach (var exe in Executables)
            {
                foreach (var theprocess in processlist)
                {
                    if (theprocess.ProcessName.ToUpper().EndsWith(exe.ToUpper()))
                    {
                        break;
                    }
                    errorList.AppendLine($"Process {exe} is not running");
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

            if (Executables == null || Executables.Count == 0)
                return ReturnValue.False("You need to have atleast one executable to check");

            return ReturnValue.True();
        }
    }


}
