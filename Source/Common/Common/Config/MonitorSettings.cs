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
            ClearAndAddNewItems(this.HttpSensors,monitorSettings.HttpSensors);
            ClearAndAddNewItems(this.FtpSensors, monitorSettings.FtpSensors);
            ClearAndAddNewItems(this.DrivespaceSensors, monitorSettings.DrivespaceSensors);
            ClearAndAddNewItems(this.FolderSizeSensors, monitorSettings.FolderSizeSensors);
            ClearAndAddNewItems(this.FileSizeSensors, monitorSettings.FileSizeSensors);
            ClearAndAddNewItems(this.CpuSensors, monitorSettings.CpuSensors);
            ClearAndAddNewItems(this.RamSensors, monitorSettings.RamSensors);
            ClearAndAddNewItems(this.ServiceSensors, monitorSettings.ServiceSensors);
            ClearAndAddNewItems(this.ProcessSensors, monitorSettings.ProcessSensors);
            ClearAndAddNewItems(this.SqlConnectionSensors, monitorSettings.SqlConnectionSensors);
            ClearAndAddNewItems(this.IISApplicationPoolSensors, monitorSettings.IISApplicationPoolSensors);
            ClearAndAddNewItems(this.IISWebsiteSensors, monitorSettings.IISWebsiteSensors);
            ClearAndAddNewItems(this.PingSensors, monitorSettings.PingSensors);
        }

        public List<ISensor> GetAllSensors()
        {
            var result = new List<ISensor>();
            result.AddRange(this.HttpSensors);
            result.AddRange(this.FtpSensors);
            result.AddRange(this.DrivespaceSensors);
            result.AddRange(this.FolderSizeSensors);
            result.AddRange(this.FileSizeSensors);
            result.AddRange(this.CpuSensors);
            result.AddRange(this.RamSensors);
            result.AddRange(this.ServiceSensors);
            result.AddRange(this.ProcessSensors);
            result.AddRange(this.SqlConnectionSensors);
            result.AddRange(this.IISApplicationPoolSensors);
            result.AddRange(this.IISWebsiteSensors);
            result.AddRange(this.PingSensors);
            return result;
        }

}


}
