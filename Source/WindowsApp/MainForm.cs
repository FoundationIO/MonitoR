using MonitoR.Common.Common;
using MonitoR.Common.Constants;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Sensors;
using MonitoR.Configurator.SensorForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitoR.Common.Utilities;

namespace MonitoR.Configurator
{
    public partial class MainForm : Form
    {
        private readonly IAppConfig appConfig;
        private readonly ILog log;
        private readonly bool newFeatureEnabled = false;

        public MainForm(IAppConfig appConfig, ILog log)
        {
            this.appConfig = appConfig;
            this.log = log;
            InitializeComponent();
            CustomUIInit();
            LoadMonitorSensors();
        }

        private void CustomUIInit()
        {
            AddToolbarMenuItem.MouseHover += (s, e) => AddToolbarMenuItem.ShowDropDown();

            addSensorMenuItem.DropDownItems.Clear();
            AddToolbarMenuItem.DropDownItems.Clear();

            AddMenuItem("Cpu sensor", CpuSensorToolStripMenuItem_Click);
            AddMenuItem("Ram sensor", RamSensorToolStripMenuItem_Click);
            AddMenuItem("Drive space sensor", DrivespaceSensorToolStripMenuItem_Click);

            AddMenuItem("File check sensor", FileCheckSensorToolStripMenuItem_Click);
            AddMenuItem("Folder check sensor", FolderCheckSensorToolStripMenuItem_Click);

            AddMenuItem("File size sensor", FileSizeSensorToolStripMenuItem1_Click);
            AddMenuItem("Folder size sensor", FolderSizeSensorToolStripMenuItem1_Click);

            AddMenuItem("Http sensor",HttpSensorToolStripMenuItem_Click);

            if (newFeatureEnabled)
            {
                AddMenuItem("Ftp sensor", FtpSensorToolStripMenuItem_Click);
            }

            AddMenuItem("Service sensor", ServiceSensorToolStripMenuItem_Click);
            AddMenuItem("Process sensor", ProcessSensorToolStripMenuItem_Click);

            if (newFeatureEnabled)
            {
                AddMenuItem("Sql Connection sensor", SqlConnectionSensorToolStripMenuItem_Click);
                AddMenuItem("IIS Application Pool sensor", IISApplicationPoolSensorToolStripMenuItem_Click);
                AddMenuItem("IIS Website sensor", IISWebsiteSensorToolStripMenuItem_Click);
                AddMenuItem("Ping sensor", PingSensorToolStripMenuItem_Click);
            }

            LvSensorList_ItemSelectionChanged(lvSensorList, null);
        }

        private void AddMenuItem(string text, EventHandler eventHandler)
        {
            var item = addSensorMenuItem.DropDownItems.Add(text);
            item.Click += eventHandler;

            item = AddToolbarMenuItem.DropDownItems.Add(text);
            item.Click += eventHandler;
        }

        private void LoadMonitorSensors()
        {
            lvSensorList.Items.Clear();
            UpdateSensorList(appConfig.MonitorSettings.GetAllSensors());
        }

        private void UpdateSensorList(List<ISensor> sensorList)
        {
            foreach (var item in sensorList)
            {
                var lvItem = lvSensorList.Items.Add(item.SensorType.ToString());
                lvItem.Checked = item.Enabled;
                lvItem.SubItems.Add(item.Name);
                lvItem.SubItems.Add(item.GetDetails());
                lvItem.Tag = item;
            }
        }

        private void LvSensorList_DoubleClick(object sender, EventArgs e)
        {
            // Method intentionally left empty.
        }

        private void AddSensor(ISensor iSensor)
        {
            AddOrEditEditSensor(CrudType.Add, iSensor);
        }

        private void EditSensor(ISensor iSensor)
        {
            AddOrEditEditSensor(CrudType.Edit, iSensor);
        }

        private void AddOrEditEditSensor(CrudType crudType, ISensor iSensor)
        {
            switch (iSensor.SensorType)
            {
                case SensorType.Cpu:
                    {
                        var sensor = iSensor as CpuSensor;
                        using (var dlg = new CpuSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.Http:
                    {
                        var sensor = iSensor as HttpSensor;
                        using (var dlg = new HttpSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.Ftp:
                    {
                        var sensor = iSensor as FtpSensor;
                        using (var dlg = new FtpSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.Drivespace:
                    {
                        var sensor = iSensor as DriveSpaceSensor;
                        using (var dlg = new DriveSpaceSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.FolderSize:
                    {
                        var sensor = iSensor as FolderSizeSensor;
                        using (var dlg = new FolderSizeSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.FolderCheck:
                    {
                        var sensor = iSensor as FolderCheckSensor;
                        using (var dlg = new FolderCheckSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.FileSize:
                    {
                        var sensor = iSensor as FileSizeSensor;
                        using (var dlg = new FileSizeSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.FileCheck:
                    {
                        var sensor = iSensor as FileCheckSensor;
                        using (var dlg = new FileCheckSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.Ram:
                    {
                        var sensor = iSensor as RamSensor;
                        using (var dlg = new RamSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.Service:
                    {
                        var sensor = iSensor as ServiceSensor;
                        using (var dlg = new ServiceSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.Process:
                    {
                        var sensor = iSensor as ProcessSensor;
                        using (var dlg = new ProcessSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.SqlConnection:
                    {
                        var sensor = iSensor as SqlConnectionSensor;
                        using (var dlg = new SqlConnectionSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.IISApplicationPool:
                    {
                        var sensor = iSensor as IISApplicationPoolSensor;
                        using (var dlg = new IISApplicationPoolSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.IISWebsite:
                    {
                        var sensor = iSensor as IISWebsiteSensor;
                        using (var dlg = new IISWebsiteSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                case SensorType.Ping:
                    {
                        var sensor = iSensor as PingSensor;
                        using (var dlg = new PingSensorForm(crudType, sensor, appConfig.MonitorSettings.GetAllSensors()))
                        {
                            if (dlg.ShowDialog(this) != DialogResult.OK)
                                return;
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Unable to determine the Sensor Type");
                        return;
                    }
            }

            if (crudType == CrudType.Add)
                appConfig.AddMonitor(iSensor);

            appConfig.SaveMonitorSettings();
            LoadMonitorSensors();
        }

        private void ExportConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                appConfig.SaveMonitorSettings(saveFileDialog.FileName);
                MessageBox.Show($"Successfully exported the sensor settings to file - {saveFileDialog.FileName}");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error when exporting sensor settings to file - {saveFileDialog.FileName} \n {ex.RecursivelyGetExceptionMessage()}" );
                log.Error(ex,$"Error when exporting sensor settings to file - {saveFileDialog.FileName}");
            }
        }

        private void ImportConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                appConfig.LoadMonitorSettings(openFileDialog.FileName);
                appConfig.SaveMonitorSettings();
                MessageBox.Show($"Successfully imported the sensor settings from file - {openFileDialog.FileName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when importing the sensor settings to file - {openFileDialog.FileName} \n {ex.RecursivelyGetExceptionMessage()}");
                log.Error(ex, $"Error when importing sensor settings to file - {openFileDialog.FileName}");
            }

            LoadMonitorSensors();
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var optionForm = new OptionForm(appConfig, log))
            {
                if (optionForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                optionForm.UpdateDataFromUI();
                appConfig.SaveAppSettings();
            }
        }

        private void OpenSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(appConfig.GetAppSettingsFile()))
            {
                MessageBox.Show("Application Option file does not exists yet.");
                return;
            }

            Process.Start("explorer.exe", Path.GetDirectoryName(appConfig.GetAppSettingsFile()));
        }

        private void OpenMonitorSettingsLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(appConfig.GetAppSettingsFile()))
            {
                MessageBox.Show("Monitor settings file does not exists yet.");
                return;
            }

            Process.Start("explorer.exe", Path.GetDirectoryName(appConfig.GetMonitorSettingsFile()));
        }

        private void CpuSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.CpuSensor());
        }

        private void HttpSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.HttpSensor());
        }

        private void DrivespaceSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.DriveSpaceSensor());
        }

        private void FolderSizeSensorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.FolderSizeSensor());
        }

        private void FileSizeSensorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.FileSizeSensor());
        }

        private void RamSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.RamSensor());
        }

        private void ServiceSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.ServiceSensor());
        }

        private void ProcessSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.ProcessSensor());
        }

        private void SqlConnectionSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.SqlConnectionSensor());
        }

        private void IISApplicationPoolSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.IISApplicationPoolSensor());
        }

        private void IISWebsiteSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.IISWebsiteSensor());
        }

        private void PingSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.PingSensor());
        }

        private void FtpSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.FtpSensor());
        }

        private void PingSensorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.PingSensor());
        }

        private void EditToolbarMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSensorList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Select an item and click edit menu item again.");
                return;
            }

            if (lvSensorList.SelectedItems[0].Tag is ISensor iSensor)
            {
                EditSensor(iSensor);
            }
        }

        private void DeleteToolbarMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSensorList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Select an item and click edit menu item again.");
                return;
            }
            if (MessageBox.Show("Do you want to delete the selected sensor", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            var sensor = (lvSensorList.SelectedItems[0].Tag as ISensor);
            appConfig.RemoveMonitor(sensor);
            lvSensorList.Items.Remove(lvSensorList.SelectedItems[0]);
            appConfig.SaveMonitorSettings();
        }

        private void LvSensorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Method intentionally left empty.
        }

        private void LvSensorList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EditToolbarMenuItem.Enabled = (lvSensorList.SelectedItems.Count > 0);
            DeleteToolbarMenuItem.Enabled = EditToolbarMenuItem.Enabled;
            EditSensorToolStripMenuItem.Enabled = EditToolbarMenuItem.Enabled;
            DeleteSensorToolStripMenuItem.Enabled = EditToolbarMenuItem.Enabled;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(this);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Do you want to close the application ?", "Close confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes;
        }

        private void OpenLogFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(appConfig.GetLogFolderPath())
                || !Directory.EnumerateFiles(appConfig.GetLogFolderPath()).Any())
            {
                MessageBox.Show("No log are created so far");
                return;
            }

            Process.Start("explorer.exe", appConfig.GetLogFolderPath());
        }

        private void TmrServiceStatusCheck_Tick(object sender, EventArgs e)
        {
            var processList = Process.GetProcessesByName("MonitoR.WindowsService");
            if (processList.Length > 0)
            {
                toolStripServiceStatusLabel.Text = "Status : Monitor Service is running";
                toolStripServiceStatusLabel.ForeColor = Color.Green;
                toolStripServiceStatusLabel.BackColor = statusStrip1.BackColor;
            }
            else
            {
                toolStripServiceStatusLabel.Text = "Status : Monitor Service is not running";
                toolStripServiceStatusLabel.BackColor = Color.PaleVioletRed;
                toolStripServiceStatusLabel.ForeColor = Color.Black;
            }
        }

        private void FileCheckSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.FileCheckSensor());
        }

        private void FolderCheckSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSensor(new Common.Sensors.FolderCheckSensor());
        }
    }
}
