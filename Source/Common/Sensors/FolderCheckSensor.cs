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
    public class FolderCheckSensor : BaseSensor
    {
        public FolderCheckSensor()
        {
            SensorType = SensorType.FolderCheck;
        }

        public List<string> Folders { get; set; } = new List<string>();

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var errorList = new StringBuilder();

            foreach(var folder in Folders)
            {
                try
                {
                    var di = new DirectoryInfo(folder);
                    if (!di.Exists)
                    {
                        errorList.AppendLine($"Folder {folder} does not exists");
                    }
                }
                catch (Exception ex)
                {
                    errorList.AppendLine($"Folder {folder} is not accesible - {ex.RecursivelyGetExceptionMessage()}");
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

            if (Folders == null || Folders.Count == 0)
                return ReturnValue.False("You need to select atleast one drive to check");

            return ReturnValue.True();
        }
    }
}
