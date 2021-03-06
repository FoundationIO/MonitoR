﻿using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MonitoR.Common.Utilities;
using System;

namespace MonitoR.Common.Sensors
{
    public class FileSizeSensor : BaseSensor
    {
        public FileSizeSensor()
        {
            SensorType = SensorType.FileSize;
        }

        public int SizeToCheck { get; set; } = 1;
        public SizeUnitType SizeToCheckUnit { get; set; } = SizeUnitType.MB;
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
                    if ((!fi.Exists) && (!IgnoreIfFileDoesNotExist))
                    {
                        errorList.AppendLine($"File {file} does not exists");
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    if (!IgnoreIfFileDoesNotExist)
                    {
                        errorList.AppendLine($"File {file} is not accesible - {ex.RecursivelyGetExceptionMessage()}");
                    }
                    continue;
                }

                var fileSize = FileUtils.FileSize(file);

                var fileSizeInSizeUnit = SizeToCheckUnit.ToSizeUnitValue(fileSize);
                if (fileSizeInSizeUnit > SizeToCheck)
                {
                    errorList.AppendLine($"File {file} is of size {fileSizeInSizeUnit} {SizeToCheckUnit} and it exceeds  {SizeToCheck} {SizeToCheckUnit}");
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

            if (Files == null || Files.Count == 0)
                return ReturnValue.False("You need to select atleast one file to check");

            return ReturnValue.True();
        }
    }
}
