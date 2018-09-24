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
    public class FolderSizeSensor : BaseSensor
    {
        public FolderSizeSensor()
        {
            SensorType = SensorType.FolderSize;
        }

        public int SizeToCheck { get; set; } = 10;
        public SizeUnitType SizeToCheckUnit { get; set; } = SizeUnitType.MB;
        public bool IgnoreIfFolderDoesNotExist { get; set; } = false;

        public List<string> Folders { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            foreach(var folder in Folders)
            {
                try
                {
                    var di = new DirectoryInfo(folder);
                    if ((!di.Exists) && (!IgnoreIfFolderDoesNotExist))
                    {
                        errorList.AppendLine($"Folder {folder} does not exists");
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    if (!IgnoreIfFolderDoesNotExist)
                    {
                        errorList.AppendLine($"Folder {folder} is not accesible - {ex.RecursivelyGetExceptionMessage()}");
                    }
                    continue;
                }

                var folderSize = FileUtils.DirSize(folder);

                var folderSizeInSizeUnit =  SizeToCheckUnit.ToSizeUnitValue(folderSize);
                if (folderSizeInSizeUnit > SizeToCheck)
                {
                    errorList.AppendLine($"Folder {folder} is of size {folderSizeInSizeUnit} {SizeToCheckUnit} and it exceeds  {SizeToCheck} {SizeToCheckUnit}");
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
            {
                return result;
            }

            if (SizeToCheck <= 0)
                return ReturnValue.False("Size should not be less than 1");

            if (SizeToCheck >= 1024)
                return ReturnValue.False("Size should not be less than 1024");

            if (Folders == null || Folders.Count == 0)
                return ReturnValue.False("You need to select atleast one folder to check");

            return ReturnValue.True();
        }
    }
}
