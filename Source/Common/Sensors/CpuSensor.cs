using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace MonitoR.Common.Sensors
{
    public class CpuSensor : BaseSensor
    {
        public CpuSensor()
        {
            SensorType = SensorType.Cpu;
        }

        public int PercentToCheck { get; set; } = 90;

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var cpuPercent = MiniDiagnostics.Performance.CpuCurrentUsage();                          
            if (cpuPercent > PercentToCheck)
                return ReturnValue.False($"CPU usage percentage is {cpuPercent} and it exceeds {PercentToCheck}");
            else
                return ReturnValue.True();
        }

        public override ReturnValue IsValid(List<ISensor> allSensors)
        {
            var result = base.IsValid(allSensors);

            if (result == null || result.Result == false)
                return result;

            if (PercentToCheck <= 0)
                return ReturnValue.False("Percent To Check should not be less than 1");

            if (PercentToCheck > 100)
                return ReturnValue.False("Percent To Check should not be greater than 100");

            return ReturnValue.True();
        }
    }


}
