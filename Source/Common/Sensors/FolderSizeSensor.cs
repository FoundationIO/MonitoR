using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MonitoR.Common.Utilities;

namespace MonitoR.Common.Sensors
{
    public class FolderSizeSensor : BaseSensor
    {
        public FolderSizeSensor()
        {
            SensorType = SensorType.FolderSize;
        }

        public int SizeToCheckInMB { get; set; } = 1024;
        public bool IgnoreIfFolderDoesNotExist { get; set; } = false;

        public List<string> Folders { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();
            
            foreach(var folder in Folders)
            {
                if (Directory.Exists(folder) == false)
                {
                    if (IgnoreIfFolderDoesNotExist == false)
                        errorList.AppendLine($"Folder {folder} does not exists");
                    continue;
                }

                var folderSize = FileUtils.DirSize(folder);
                if (folderSize > SizeToCheckInMB)
                    errorList.AppendLine($"Folder {folder} has disk space {folderSize} and it exceeds  {SizeToCheckInMB}");
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

            if (Folders == null || Folders.Count == 0)
                return ReturnValue.False("You need to select atleast one drive to check");

            return ReturnValue.True();
        }
    }


}
