using MonitoR.Common.Common;
using MonitoR.Common.Common.Config;
using MonitoR.Common.Sensors;

namespace MonitoR.Common.Infrastructure
{
    public interface IAppConfig
    {
        bool LogDebug { get; set; }
        bool LogError { get; set; }
        bool LogInfo { get; set; }
        bool LogWarn { get; set; }
        EmailServerSettings EmailServerSettings { get; set; }

        string GetAppSettingsFile();
        string GetMonitorSettingsFile();
        string GetLogFolderPath();
        string GetOrCreateHistoryDbPath();
        string GetConfigFilePathFromKnownFolders(string fileName);

        bool SaveAppSettings();
        bool SaveAppSettings(string fileName);
        bool LoadAppSettings();
        bool LoadAppSettings(string fileName);

        bool SaveMonitorSettings();
        bool SaveMonitorSettings(string fileName);
        bool LoadMonitorSettings();
        bool LoadMonitorSettings(string fileName);
        MonitorSettings MonitorSettings { get; set; }

        bool AddMonitor(ISensor iSensor);
        bool RemoveMonitor(ISensor iSensor);

        EmailTemplateSettings EmailTemplateSettings { get; set; }
    }
}