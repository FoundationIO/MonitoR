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

namespace MonitoR.Configurator
{
    public partial class MainForm : Form
    {
        IAppConfig appConfig;
        ILog log;
        bool newFeatureEnabled = false;

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

            AddMenuItem("Cpu sensor", this.CpuSensorToolStripMenuItem_Click);
            AddMenuItem("Ram sensor", this.RamSensorToolStripMenuItem_Click);
            AddMenuItem("Drive space sensor", this.DrivespaceSensorToolStripMenuItem_Click);

            if (newFeatureEnabled)
            {
                AddMenuItem("File size sensor", this.FileSizeSensorToolStripMenuItem1_Click);
                AddMenuItem("Folder size sensor", this.FolderSizeSensorToolStripMenuItem1_Click);
                AddMenuItem("Ftp sensor", this.FtpSensorToolStripMenuItem_Click);
            }

            AddMenuItem("Http sensor",this.HttpSensorToolStripMenuItem_Click);
            AddMenuItem("Service sensor", this.ServiceSensorToolStripMenuItem_Click);

            if (newFeatureEnabled)
            {
                
                AddMenuItem("Process sensor", this.ProcessSensorToolStripMenuItem_Click);
                AddMenuItem("Sql Connection sensor", this.SqlConnectionSensorToolStripMenuItem_Click);
                AddMenuItem("IIS Application Pool sensor", this.IISApplicationPoolSensorToolStripMenuItem_Click);
                AddMenuItem("IIS Website sensor", this.IISWebsiteSensorToolStripMenuItem_Click);
                AddMenuItem("Ping sensor", this.PingSensorToolStripMenuItem_Click);
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

            UpdateSensorList(appConfig.MonitorSettings.HttpSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.FtpSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.DrivespaceSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.FolderSizeSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.FileSizeSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.CpuSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.RamSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.ServiceSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.ProcessSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.SqlConnectionSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.IISApplicationPoolSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.IISWebsiteSensors.ToList<ISensor>());
            UpdateSensorList(appConfig.MonitorSettings.PingSensors.ToList<ISensor>());
        }

        private void UpdateSensorList(List<ISensor> sensorList)
        {
            foreach (var item in sensorList)
            {
                var lvItem = lvSensorList.Items.Add(item.SensorType.ToString());
                lvItem.Checked = item.Enabled;
                lvItem.SubItems.Add(item.Name);
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
            this.saveFileDialog.FileName = "";
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            appConfig.SaveMonitorSettings(this.saveFileDialog.FileName);
        }

        private void ImportConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.FileName = "";
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            appConfig.LoadMonitorSettings(this.openFileDialog.FileName);
            appConfig.SaveMonitorSettings();

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
            if (File.Exists(appConfig.GetAppSettingsFile()) == false)
            {
                MessageBox.Show("Application Option file does not exists yet.");
                return;
            }

            Process.Start("explorer.exe", Path.GetDirectoryName(appConfig.GetAppSettingsFile()));
        }

        private void OpenMonitorSettingsLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(appConfig.GetAppSettingsFile()) == false)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application ?", "Close confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void openLogFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(appConfig.GetLogFolderPath()) == false || 
                Directory.EnumerateFiles(appConfig.GetLogFolderPath()).Any() == false)
            {
                MessageBox.Show("No log are created so far");
                return;
            }

            Process.Start("explorer.exe", appConfig.GetLogFolderPath());

        }

        private void tmrServiceStatusCheck_Tick(object sender, EventArgs e)
        {
            var processList = Process.GetProcessesByName("MonitoR.WindowsService");
            if (processList.Any())
            {
                toolStripServiceStatusLabel.Text = "Status : Monitor Service is running";
                toolStripServiceStatusLabel.ForeColor = Color.Green;
            }
            else
            {
                toolStripServiceStatusLabel.Text = "Status : Monitor Service is not running";
                toolStripServiceStatusLabel.BackColor = Color.PaleVioletRed;
            }
        }
    }
}
