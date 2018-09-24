using MonitoR.Common.Sensors;
using System.Collections.Generic;

namespace MonitoR.Common.Common.Config
{
    public class MonitorSettings
    {
        public List<HttpSensor> HttpSensors { get; set; } = new List<HttpSensor>();
        public List<FtpSensor> FtpSensors { get; set; } = new List<FtpSensor>();
        public List<DriveSpaceSensor> DrivespaceSensors { get; set; } = new List<DriveSpaceSensor>();
        public List<FolderSizeSensor> FolderSizeSensors { get; set; } = new List<FolderSizeSensor>();
        public List<FileSizeSensor> FileSizeSensors { get; set; } = new List<FileSizeSensor>();
        public List<FolderCheckSensor> FolderCheckSensors { get; set; } = new List<FolderCheckSensor>();
        public List<FileCheckSensor> FileCheckSensors { get; set; } = new List<FileCheckSensor>();

        public List<CpuSensor> CpuSensors { get; set; } = new List<CpuSensor>();
        public List<RamSensor> RamSensors { get; set; } = new List<RamSensor>();
        public List<ServiceSensor> ServiceSensors { get; set; } = new List<ServiceSensor>();
        public List<ProcessSensor> ProcessSensors { get; set; } = new List<ProcessSensor>();
        public List<SqlConnectionSensor> SqlConnectionSensors { get; set; } = new List<SqlConnectionSensor>();
        public List<IISApplicationPoolSensor> IISApplicationPoolSensors { get; set; } = new List<IISApplicationPoolSensor>();
        public List<IISWebsiteSensor> IISWebsiteSensors { get; set; } = new List<IISWebsiteSensor>();
        public List<PingSensor> PingSensors { get; set; } = new List<PingSensor>();

        private static void ClearAndAddNewItems<T>(List<T> itemToUpdate, List<T> parameters)
        {
            if (itemToUpdate == null)
                return;

            if (parameters == null)
                return;

            itemToUpdate.Clear();
            itemToUpdate.AddRange(parameters);
        }

        public void Add(MonitorSettings monitorSettings)
        {
            ClearAndAddNewItems(HttpSensors,monitorSettings.HttpSensors);
            ClearAndAddNewItems(FtpSensors, monitorSettings.FtpSensors);
            ClearAndAddNewItems(DrivespaceSensors, monitorSettings.DrivespaceSensors);
            ClearAndAddNewItems(FolderSizeSensors, monitorSettings.FolderSizeSensors);
            ClearAndAddNewItems(FileSizeSensors, monitorSettings.FileSizeSensors);
            ClearAndAddNewItems(FolderCheckSensors, monitorSettings.FolderCheckSensors);
            ClearAndAddNewItems(FileCheckSensors, monitorSettings.FileCheckSensors);
            ClearAndAddNewItems(CpuSensors, monitorSettings.CpuSensors);
            ClearAndAddNewItems(RamSensors, monitorSettings.RamSensors);
            ClearAndAddNewItems(ServiceSensors, monitorSettings.ServiceSensors);
            ClearAndAddNewItems(ProcessSensors, monitorSettings.ProcessSensors);
            ClearAndAddNewItems(SqlConnectionSensors, monitorSettings.SqlConnectionSensors);
            ClearAndAddNewItems(IISApplicationPoolSensors, monitorSettings.IISApplicationPoolSensors);
            ClearAndAddNewItems(IISWebsiteSensors, monitorSettings.IISWebsiteSensors);
            ClearAndAddNewItems(PingSensors, monitorSettings.PingSensors);
        }

        public List<ISensor> GetAllSensors()
        {
            var result = new List<ISensor>();
            result.AddRange(HttpSensors);
            result.AddRange(FtpSensors);
            result.AddRange(DrivespaceSensors);
            result.AddRange(FolderSizeSensors);
            result.AddRange(FileSizeSensors);
            result.AddRange(FolderCheckSensors);
            result.AddRange(FileCheckSensors);
            result.AddRange(CpuSensors);
            result.AddRange(RamSensors);
            result.AddRange(ServiceSensors);
            result.AddRange(ProcessSensors);
            result.AddRange(SqlConnectionSensors);
            result.AddRange(IISApplicationPoolSensors);
            result.AddRange(IISWebsiteSensors);
            result.AddRange(PingSensors);
            return result;
        }
}
}
