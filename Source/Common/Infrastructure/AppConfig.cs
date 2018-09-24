using MonitoR.Common.Common;
using MonitoR.Common.Common.Config;
using MonitoR.Common.Sensors;
using MonitoR.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace MonitoR.Common.Infrastructure
{
    public class AppConfig : BaseAppConfig, IAppConfig
    {
        public MonitorSettings MonitorSettings { get; set; } = new MonitorSettings();

        public AppConfig()
        {
            LoadMonitorSettings();

            var appSettingFile = GetAppSettingsFile();

            if (File.Exists(appSettingFile))
            {
                var appSettingsFromFile = JsonUtils.Deserialize<BaseAppConfig>(File.ReadAllText(appSettingFile));
                Update(appSettingsFromFile);
            }
        }

        public string GetMonitorSettingsFile()
        {
            return GetConfigFilePathFromKnownFolders("MonitorSensorSettings.json");
        }

        public string GetAppSettingsFile()
        {
            return GetConfigFilePathFromKnownFolders("ServiceMonitorApplicationConfiguration.json");
        }

        public bool SaveAppSettings()
        {
            return SaveAppSettings(GetAppSettingsFile());
        }

        public bool SaveAppSettings(string fileName)
        {
            var optionSettingFile = fileName;
            var bConfig = new BaseAppConfig();
            bConfig.Update(this);
            File.WriteAllText(optionSettingFile, JsonUtils.Serialize<BaseAppConfig>(bConfig));
            return true;
        }

        public bool LoadAppSettings()
        {
            return LoadAppSettings(GetAppSettingsFile());
        }

        public bool LoadAppSettings(string fileName)
        {
            if (File.Exists(fileName))
            {
                var itemFromFile = JsonUtils.Deserialize<BaseAppConfig>(File.ReadAllText(fileName));
                if (itemFromFile != null)
                    Update(itemFromFile);
            }
            return true;
        }

        public bool SaveMonitorSettings()
        {
            return SaveMonitorSettings(GetMonitorSettingsFile());
        }

        public bool SaveMonitorSettings(string fileName)
        {
            var sensorSettingFile = fileName;
            File.WriteAllText(sensorSettingFile, JsonUtils.Serialize<MonitorSettings>(MonitorSettings));
            return true;
        }

        public bool LoadMonitorSettings()
        {
            return LoadMonitorSettings(GetMonitorSettingsFile());
        }

        public bool LoadMonitorSettings(string fileName)
        {
            if (File.Exists(fileName))
            {
                var itemFromFile = JsonUtils.Deserialize<MonitorSettings>(File.ReadAllText(fileName));
                if (itemFromFile != null)
                    MonitorSettings.Add(itemFromFile);
            }
            return true;
        }

        public string GetLogFolderPath()
        {
            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            var path = Path.Combine(commonpath, "MonitoR", "logs");
            return path;
        }

        public string GetOrCreateHistoryDbPath()
        {
            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            var path = Path.Combine(commonpath, "MonitoR", "history.lite-db");
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return path;
        }

        public string GetConfigFilePathFromKnownFolders(string fileName)
        {
            var pathSections = new List<string> { "Configuration", fileName };
            foreach (var idx in Enumerable.Range(0, 10))
            {
                var path1 = FileUtils.Combine(Directory.GetCurrentDirectory(), pathSections.ToArray());
                if (File.Exists(path1))
                {
                    return path1;
                }
                pathSections.Insert(0, "..");
            }

            pathSections = new List<string> { fileName };
            foreach (var idx in Enumerable.Range(0, 10))
            {
                var path1 = FileUtils.Combine(Directory.GetCurrentDirectory(), pathSections.ToArray());
                if (File.Exists(path1))
                {
                    return path1;
                }
                pathSections.Insert(0, "..");
            }

            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            var path = Path.Combine(commonpath, "MonitoR",fileName);
            return path;
        }

        public bool AddMonitor(ISensor iSensor)
        {
            return AddOrRemoveMonitor(true, iSensor);
        }

        public bool RemoveMonitor(ISensor iSensor)
        {
            return AddOrRemoveMonitor(false, iSensor);
        }

        public bool AddOrRemoveMonitorInternal<T>(List<T> lst,bool isAdd, ISensor iSensor) where T : class , ISensor
        {
            if (!(iSensor is T sensor))
                return false;

            if (isAdd)
            {
                lst.Add(sensor);
            }
            else
            {
                lst.RemoveAll(x => x.Id == iSensor.Id);
            }

            return true;
        }

        public bool AddOrRemoveMonitor(bool isAdd,ISensor iSensor)
        {
            switch (iSensor.SensorType)
            {
                case SensorType.Cpu:
                    {
                        return AddOrRemoveMonitorInternal<CpuSensor>(MonitorSettings.CpuSensors, isAdd, iSensor);
                    }
                case SensorType.Http:
                    {
                        return AddOrRemoveMonitorInternal<HttpSensor>(MonitorSettings.HttpSensors, isAdd, iSensor);
                    }
                case SensorType.Ftp:
                    {
                        return AddOrRemoveMonitorInternal<FtpSensor>(MonitorSettings.FtpSensors, isAdd, iSensor);
                    }
                case SensorType.Drivespace:
                    {
                        return AddOrRemoveMonitorInternal<DriveSpaceSensor>(MonitorSettings.DrivespaceSensors, isAdd, iSensor);
                    }
                case SensorType.FolderSize:
                    {
                        return AddOrRemoveMonitorInternal<FolderSizeSensor>(MonitorSettings.FolderSizeSensors, isAdd, iSensor);
                    }
                case SensorType.FileSize:
                    {
                        return AddOrRemoveMonitorInternal<FileSizeSensor>(MonitorSettings.FileSizeSensors, isAdd, iSensor);
                    }
                case SensorType.FolderCheck:
                    {
                        return AddOrRemoveMonitorInternal<FolderCheckSensor>(MonitorSettings.FolderCheckSensors, isAdd, iSensor);
                    }
                case SensorType.FileCheck:
                    {
                        return AddOrRemoveMonitorInternal<FileCheckSensor>(MonitorSettings.FileCheckSensors, isAdd, iSensor);
                    }
                case SensorType.Ram:
                    {
                        return AddOrRemoveMonitorInternal<RamSensor>(MonitorSettings.RamSensors, isAdd, iSensor);
                    }
                case SensorType.Service:
                    {
                        return AddOrRemoveMonitorInternal<ServiceSensor>(MonitorSettings.ServiceSensors, isAdd, iSensor);
                    }
                case SensorType.Process:
                    {
                        return AddOrRemoveMonitorInternal<ProcessSensor>(MonitorSettings.ProcessSensors, isAdd, iSensor);
                    }
                case SensorType.SqlConnection:
                    {
                        return AddOrRemoveMonitorInternal<SqlConnectionSensor>(MonitorSettings.SqlConnectionSensors, isAdd, iSensor);
                    }
                case SensorType.IISApplicationPool:
                    {
                        return AddOrRemoveMonitorInternal<IISApplicationPoolSensor>(MonitorSettings.IISApplicationPoolSensors, isAdd, iSensor);
                    }
                case SensorType.IISWebsite:
                    {
                        return AddOrRemoveMonitorInternal<IISWebsiteSensor>(MonitorSettings.IISWebsiteSensors, isAdd, iSensor);
                    }
                case SensorType.Ping:
                    {
                        return AddOrRemoveMonitorInternal<PingSensor>(MonitorSettings.PingSensors, isAdd, iSensor);
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
