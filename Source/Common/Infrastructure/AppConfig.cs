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
                this.Update(appSettingsFromFile);
            }
        }

        public string GetMonitorSettingsFile()
        {
            return GetConfigFileName("MonitorSensorSettings.json");
        }

        public string GetAppSettingsFile()
        {
            return GetConfigFileName("ServiceMonitorApplicationConfiguration.json");
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
                    this.Update(itemFromFile);
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

        public string GetConfigFileName(string fileName)
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

        public bool AddOrRemoveMonitor(bool isAdd,ISensor iSensor)
        {
            switch (iSensor.SensorType)
            {
                case SensorType.Cpu:
                    {
                        var sensor = iSensor as CpuSensor;
                        if (isAdd)
                            MonitorSettings.CpuSensors.Add(sensor);
                        else
                            MonitorSettings.CpuSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.Http:
                    {
                        if (isAdd)
                            MonitorSettings.HttpSensors.Add(iSensor as HttpSensor);
                        else
                            MonitorSettings.HttpSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.Ftp:
                    {
                        if (isAdd)
                            MonitorSettings.FtpSensors.Add(iSensor as FtpSensor);
                        else
                            MonitorSettings.FtpSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.Drivespace:
                    {
                        if (isAdd)
                            MonitorSettings.DrivespaceSensors.Add(iSensor as DriveSpaceSensor);
                        else
                            MonitorSettings.DrivespaceSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.FolderSize:
                    {
                        if (isAdd)
                            MonitorSettings.FolderSizeSensors.Add(iSensor as FolderSizeSensor);
                        else
                            MonitorSettings.FolderSizeSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.FileSize:
                    {
                        if (isAdd)
                            MonitorSettings.FileSizeSensors.Add(iSensor as FileSizeSensor);
                        else
                            MonitorSettings.FileSizeSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.Ram:
                    {
                        if (isAdd)
                            MonitorSettings.RamSensors.Add(iSensor as RamSensor);
                        else
                            MonitorSettings.RamSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.Service:
                    {
                        if (isAdd)
                            MonitorSettings.ServiceSensors.Add(iSensor as ServiceSensor);
                        else
                            MonitorSettings.ServiceSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.Process:
                    {
                        if (isAdd)
                            MonitorSettings.ProcessSensors.Add(iSensor as ProcessSensor);
                        else
                            MonitorSettings.ProcessSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.SqlConnection:
                    {
                        if (isAdd)
                            MonitorSettings.SqlConnectionSensors.Add(iSensor as SqlConnectionSensor);
                        else
                            MonitorSettings.SqlConnectionSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.IISApplicationPool:
                    {
                        if (isAdd)
                            MonitorSettings.IISApplicationPoolSensors.Add(iSensor as IISApplicationPoolSensor);
                        else
                            MonitorSettings.IISApplicationPoolSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.IISWebsite:
                    {
                        if (isAdd)
                            MonitorSettings.IISWebsiteSensors.Add(iSensor as IISWebsiteSensor);
                        else
                            MonitorSettings.IISWebsiteSensors.RemoveAll(x=> x.Id == iSensor.Id);
                        break;
                    }
                case SensorType.Ping:
                    {
                        if (isAdd)
                            MonitorSettings.PingSensors.Add(iSensor as PingSensor);
                        else
                            MonitorSettings.PingSensors.RemoveAll(x => x.Id == iSensor.Id);
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            return true;
        }


    }
}
