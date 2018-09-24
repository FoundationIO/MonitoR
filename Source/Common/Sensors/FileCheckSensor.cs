using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MonitoR.Common.Utilities;
using System;

namespace MonitoR.Common.Sensors
{
    public class FileCheckSensor : BaseSensor
    {
        public FileCheckSensor()
        {
            SensorType = SensorType.FileCheck;
        }

        public int SizeToCheckInMB { get; set; } = 1024;
        public bool IgnoreIfFileDoesNotExist { get; set; } = false;

        public List<string> Files { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            foreach(var file in Files)
            {
                try
                {
                    var fi = new FileInfo(file);
                    if (!fi.Exists)
                    {
                        errorList.AppendLine($"File {file} does not exists");
                    }
                }
                catch (Exception ex)
                {
                    errorList.AppendLine($"File {file} is not accesible - {ex.RecursivelyGetExceptionMessage()}");
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

            if (Files == null || Files.Count == 0)
                return ReturnValue.False("You need to select atleast one file to check");

            return ReturnValue.True();
        }
    }
}
