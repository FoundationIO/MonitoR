using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MonitoR.Common.Utilities;

namespace MonitoR.Common.Sensors
{
    public class DriveSpaceSensor : BaseSensor
    {
        public DriveSpaceSensor()
        {
            SensorType = SensorType.Drivespace;
        }

        public int PercentToCheck { get; set; } = 90;

        public List<string> Drives { get; set; } = new List<string>();

        public bool CheckAllDrives { get; set; }

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var drivesToCheck = new List<string>();
            if (CheckAllDrives)
            {
                foreach(var driveInfo in DriveInfo.GetDrives())
                {
                    if (driveInfo.DriveType != DriveType.Fixed)
                        continue;
                    drivesToCheck.Add(driveInfo.Name);
                }
            }
            else
            {
                drivesToCheck.AddRange(Drives);
            }

            var errorList = new StringBuilder();

            foreach (var drive in drivesToCheck)
            {
                var dInfo = new DriveInfo(drive);
                var disksFreeSacePercent = (( (dInfo.AvailableFreeSpace * 1.0) / (dInfo.TotalSize * 1.0)) * 100);
                var diskOccupiedSpacePercent = (double)100 - disksFreeSacePercent;
                if (diskOccupiedSpacePercent > PercentToCheck)
                {
                    errorList.AppendLine($"Drive {drive} is occupied {diskOccupiedSpacePercent}% and it exceeds {PercentToCheck}% limit (available disk space - {FileUtils.FileSizeBytesToReadableValue((ulong)dInfo.AvailableFreeSpace)})");
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

            if (PercentToCheck <= 0)
                return ReturnValue.False("Percent To Check should not be less than 1");

            if (PercentToCheck > 100)
                return ReturnValue.False("Percent To Check should not be greater than 100");

            if (Drives == null || Drives.Count == 0)
                return ReturnValue.False("You need to select atleast one drive to check");

            return ReturnValue.True();
        }
    }
}
