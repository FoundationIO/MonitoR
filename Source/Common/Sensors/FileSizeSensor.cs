using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MonitoR.Common.Utilities;

namespace MonitoR.Common.Sensors
{
    public class FileSizeSensor : BaseSensor
    {
        public FileSizeSensor()
        {
            SensorType = SensorType.FileSize;
        }

        public int SizeToCheckInMB { get; set; } = 1024;
        public bool IgnoreIfFileDoesNotExist { get; set; } = false;

        public List<string> Files { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();
            
            foreach(var file in Files)
            {
                if (!File.Exists(file))
                {
                    if (IgnoreIfFileDoesNotExist == false)
                        errorList.AppendLine($"File {file} does not exists");
                    continue;
                }

                var fileSize = FileUtils.FileSize(file);
                if (fileSize > SizeToCheckInMB)
                    errorList.AppendLine($"File {file} is of size {fileSize} and it exceeds  {SizeToCheckInMB}");
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

            if (SizeToCheckInMB <= 0)
                return ReturnValue.False("Size should not be less than 1");

            if (Files == null || Files.Count == 0)
                return ReturnValue.False("You need to select atleast one file to check");

            return ReturnValue.True();
        }

    }


}
