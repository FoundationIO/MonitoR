using MonitoR.Configurator.Components;

namespace MonitoR.Configurator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripServiceStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.openLogFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMonitorSettingsLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.clearLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSensorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSensorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewJobStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AddToolbarMenuItem = new System.Windows.Forms.ToolStripSplitButton();
            this.cpuSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivespaceSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSizeSensorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCheckSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderSizeSensorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderCheckSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ftpSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iISApplicationPoolSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iISWebsiteSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ramSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlConnectionSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolbarMenuItem = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolbarMenuItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolbarMenuItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutToolbarMenuItem = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tmrServiceStatusCheck = new System.Windows.Forms.Timer(this.components);
            this.lvSensorList = new MonitoR.Configurator.Components.NoDoubleClickAutoCheckListview();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripServiceStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(753, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripServiceStatusLabel
            // 
            this.toolStripServiceStatusLabel.Name = "toolStripServiceStatusLabel";
            this.toolStripServiceStatusLabel.Size = new System.Drawing.Size(738, 17);
            this.toolStripServiceStatusLabel.Spring = true;
            this.toolStripServiceStatusLabel.Text = "Service Status : Unknown";
            this.toolStripServiceStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sensorToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importConfigurationToolStripMenuItem,
            this.exportConfigurationToolStripMenuItem,
            this.toolStripSeparator6,
            this.openLogFolderToolStripMenuItem,
            this.openSettingsToolStripMenuItem,
            this.openMonitorSettingsLocationToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.logsToolStripMenuItem.Text = "File";
            // 
            // importConfigurationToolStripMenuItem
            // 
            this.importConfigurationToolStripMenuItem.Name = "importConfigurationToolStripMenuItem";
            this.importConfigurationToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.importConfigurationToolStripMenuItem.Text = "Import Configuration";
            this.importConfigurationToolStripMenuItem.Click += new System.EventHandler(this.ImportConfigurationToolStripMenuItem_Click);
            // 
            // exportConfigurationToolStripMenuItem
            // 
            this.exportConfigurationToolStripMenuItem.Name = "exportConfigurationToolStripMenuItem";
            this.exportConfigurationToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exportConfigurationToolStripMenuItem.Text = "Export Configuration";
            this.exportConfigurationToolStripMenuItem.Click += new System.EventHandler(this.ExportConfigurationToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(240, 6);
            // 
            // openLogFolderToolStripMenuItem
            // 
            this.openLogFolderToolStripMenuItem.Name = "openLogFolderToolStripMenuItem";
            this.openLogFolderToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.openLogFolderToolStripMenuItem.Text = "Open Log Folder";
            this.openLogFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenLogFolderToolStripMenuItem_Click);
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.openSettingsToolStripMenuItem.Text = "Open Option File Location";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.OpenSettingsToolStripMenuItem_Click);
            // 
            // openMonitorSettingsLocationToolStripMenuItem
            // 
            this.openMonitorSettingsLocationToolStripMenuItem.Name = "openMonitorSettingsLocationToolStripMenuItem";
            this.openMonitorSettingsLocationToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.openMonitorSettingsLocationToolStripMenuItem.Text = "Open Monitor Settings Location";
            this.openMonitorSettingsLocationToolStripMenuItem.Click += new System.EventHandler(this.OpenMonitorSettingsLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripSeparator5,
            this.clearLogsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            this.toolStripSeparator5.Visible = false;
            // 
            // clearLogsToolStripMenuItem
            // 
            this.clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
            this.clearLogsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.clearLogsToolStripMenuItem.Text = "Clear Logs";
            this.clearLogsToolStripMenuItem.Visible = false;
            // 
            // sensorToolStripMenuItem
            // 
            this.sensorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSensorMenuItem,
            this.EditSensorToolStripMenuItem,
            this.DeleteSensorToolStripMenuItem});
            this.sensorToolStripMenuItem.Name = "sensorToolStripMenuItem";
            this.sensorToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.sensorToolStripMenuItem.Text = "Sensor";
            // 
            // addSensorMenuItem
            // 
            this.addSensorMenuItem.Name = "addSensorMenuItem";
            this.addSensorMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addSensorMenuItem.Text = "Add New Sensor";
            // 
            // EditSensorToolStripMenuItem
            // 
            this.EditSensorToolStripMenuItem.Name = "EditSensorToolStripMenuItem";
            this.EditSensorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.EditSensorToolStripMenuItem.Text = "Edit Sensor";
            this.EditSensorToolStripMenuItem.Click += new System.EventHandler(this.LvSensorList_DoubleClick);
            // 
            // DeleteSensorToolStripMenuItem
            // 
            this.DeleteSensorToolStripMenuItem.Name = "DeleteSensorToolStripMenuItem";
            this.DeleteSensorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.DeleteSensorToolStripMenuItem.Text = "Delete Sensor";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSensorsToolStripMenuItem,
            this.viewLogsToolStripMenuItem,
            this.viewJobStatusToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Visible = false;
            // 
            // viewSensorsToolStripMenuItem
            // 
            this.viewSensorsToolStripMenuItem.Name = "viewSensorsToolStripMenuItem";
            this.viewSensorsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewSensorsToolStripMenuItem.Text = "View Sensors";
            // 
            // viewLogsToolStripMenuItem
            // 
            this.viewLogsToolStripMenuItem.Name = "viewLogsToolStripMenuItem";
            this.viewLogsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewLogsToolStripMenuItem.Text = "View Logs";
            // 
            // viewJobStatusToolStripMenuItem
            // 
            this.viewJobStatusToolStripMenuItem.Name = "viewJobStatusToolStripMenuItem";
            this.viewJobStatusToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewJobStatusToolStripMenuItem.Text = "View Job Status";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton8,
            this.toolStripSeparator4,
            this.AddToolbarMenuItem,
            this.EditToolbarMenuItem,
            this.DeleteToolbarMenuItem,
            this.toolStripSeparator1,
            this.OptionsToolbarMenuItem,
            this.toolStripSeparator3,
            this.AboutToolbarMenuItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(753, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 28);
            this.toolStripLabel1.Text = "View";
            this.toolStripLabel1.Visible = false;
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripButton8.Items.AddRange(new object[] {
            "Sensors",
            "Logs",
            "Job Status"});
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(150, 31);
            this.toolStripButton8.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            this.toolStripSeparator4.Visible = false;
            // 
            // AddToolbarMenuItem
            // 
            this.AddToolbarMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolbarMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cpuSensorToolStripMenuItem,
            this.drivespaceSensorToolStripMenuItem,
            this.fileSizeSensorToolStripMenuItem1,
            this.fileCheckSensorToolStripMenuItem,
            this.folderSizeSensorToolStripMenuItem1,
            this.folderCheckSensorToolStripMenuItem,
            this.ftpSensorToolStripMenuItem,
            this.httpSensorToolStripMenuItem,
            this.iISApplicationPoolSensorToolStripMenuItem,
            this.iISWebsiteSensorToolStripMenuItem,
            this.pingSensorToolStripMenuItem,
            this.processSensorToolStripMenuItem,
            this.ramSensorToolStripMenuItem,
            this.serviceSensorToolStripMenuItem,
            this.sqlConnectionSensorToolStripMenuItem});
            this.AddToolbarMenuItem.Image = global::MonitoR.Configurator.Properties.Resources.db_register24_h;
            this.AddToolbarMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolbarMenuItem.Name = "AddToolbarMenuItem";
            this.AddToolbarMenuItem.Size = new System.Drawing.Size(40, 28);
            this.AddToolbarMenuItem.Text = "toolStripButton1";
            this.AddToolbarMenuItem.ToolTipText = "Add new sensor";
            // 
            // cpuSensorToolStripMenuItem
            // 
            this.cpuSensorToolStripMenuItem.Name = "cpuSensorToolStripMenuItem";
            this.cpuSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.cpuSensorToolStripMenuItem.Text = "Cpu sensor";
            this.cpuSensorToolStripMenuItem.Click += new System.EventHandler(this.CpuSensorToolStripMenuItem_Click);
            // 
            // drivespaceSensorToolStripMenuItem
            // 
            this.drivespaceSensorToolStripMenuItem.Name = "drivespaceSensorToolStripMenuItem";
            this.drivespaceSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.drivespaceSensorToolStripMenuItem.Text = "Drivespace sensor";
            this.drivespaceSensorToolStripMenuItem.Click += new System.EventHandler(this.DrivespaceSensorToolStripMenuItem_Click);
            // 
            // fileSizeSensorToolStripMenuItem1
            // 
            this.fileSizeSensorToolStripMenuItem1.Name = "fileSizeSensorToolStripMenuItem1";
            this.fileSizeSensorToolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            this.fileSizeSensorToolStripMenuItem1.Text = "File size sensor";
            this.fileSizeSensorToolStripMenuItem1.Click += new System.EventHandler(this.FileSizeSensorToolStripMenuItem1_Click);
            // 
            // fileCheckSensorToolStripMenuItem
            // 
            this.fileCheckSensorToolStripMenuItem.Name = "fileCheckSensorToolStripMenuItem";
            this.fileCheckSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.fileCheckSensorToolStripMenuItem.Text = "File check sensor";
            this.fileCheckSensorToolStripMenuItem.Click += new System.EventHandler(this.FileCheckSensorToolStripMenuItem_Click);
            // 
            // folderSizeSensorToolStripMenuItem1
            // 
            this.folderSizeSensorToolStripMenuItem1.Name = "folderSizeSensorToolStripMenuItem1";
            this.folderSizeSensorToolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            this.folderSizeSensorToolStripMenuItem1.Text = "Folder size sensor";
            this.folderSizeSensorToolStripMenuItem1.Click += new System.EventHandler(this.FolderSizeSensorToolStripMenuItem1_Click);
            // 
            // folderCheckSensorToolStripMenuItem
            // 
            this.folderCheckSensorToolStripMenuItem.Name = "folderCheckSensorToolStripMenuItem";
            this.folderCheckSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.folderCheckSensorToolStripMenuItem.Text = "Folder check sensor";
            this.folderCheckSensorToolStripMenuItem.Click += new System.EventHandler(this.FolderCheckSensorToolStripMenuItem_Click);
            // 
            // ftpSensorToolStripMenuItem
            // 
            this.ftpSensorToolStripMenuItem.Name = "ftpSensorToolStripMenuItem";
            this.ftpSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.ftpSensorToolStripMenuItem.Text = "Ftp sensor";
            this.ftpSensorToolStripMenuItem.Click += new System.EventHandler(this.FtpSensorToolStripMenuItem_Click);
            // 
            // httpSensorToolStripMenuItem
            // 
            this.httpSensorToolStripMenuItem.Name = "httpSensorToolStripMenuItem";
            this.httpSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.httpSensorToolStripMenuItem.Text = "Http sensor";
            this.httpSensorToolStripMenuItem.Click += new System.EventHandler(this.HttpSensorToolStripMenuItem_Click);
            // 
            // iISApplicationPoolSensorToolStripMenuItem
            // 
            this.iISApplicationPoolSensorToolStripMenuItem.Name = "iISApplicationPoolSensorToolStripMenuItem";
            this.iISApplicationPoolSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.iISApplicationPoolSensorToolStripMenuItem.Text = "IIS Application Pool sensor";
            this.iISApplicationPoolSensorToolStripMenuItem.Click += new System.EventHandler(this.IISApplicationPoolSensorToolStripMenuItem_Click);
            // 
            // iISWebsiteSensorToolStripMenuItem
            // 
            this.iISWebsiteSensorToolStripMenuItem.Name = "iISWebsiteSensorToolStripMenuItem";
            this.iISWebsiteSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.iISWebsiteSensorToolStripMenuItem.Text = "IIS Website sensor";
            this.iISWebsiteSensorToolStripMenuItem.Click += new System.EventHandler(this.IISWebsiteSensorToolStripMenuItem_Click);
            // 
            // pingSensorToolStripMenuItem
            // 
            this.pingSensorToolStripMenuItem.Name = "pingSensorToolStripMenuItem";
            this.pingSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.pingSensorToolStripMenuItem.Text = "Ping sensor";
            this.pingSensorToolStripMenuItem.Click += new System.EventHandler(this.PingSensorToolStripMenuItem_Click_1);
            // 
            // processSensorToolStripMenuItem
            // 
            this.processSensorToolStripMenuItem.Name = "processSensorToolStripMenuItem";
            this.processSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.processSensorToolStripMenuItem.Text = "Process sensor";
            this.processSensorToolStripMenuItem.Click += new System.EventHandler(this.ProcessSensorToolStripMenuItem_Click);
            // 
            // ramSensorToolStripMenuItem
            // 
            this.ramSensorToolStripMenuItem.Name = "ramSensorToolStripMenuItem";
            this.ramSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.ramSensorToolStripMenuItem.Text = "Ram sensor";
            this.ramSensorToolStripMenuItem.Click += new System.EventHandler(this.RamSensorToolStripMenuItem_Click);
            // 
            // serviceSensorToolStripMenuItem
            // 
            this.serviceSensorToolStripMenuItem.Name = "serviceSensorToolStripMenuItem";
            this.serviceSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.serviceSensorToolStripMenuItem.Text = "Service sensor";
            this.serviceSensorToolStripMenuItem.Click += new System.EventHandler(this.ServiceSensorToolStripMenuItem_Click);
            // 
            // sqlConnectionSensorToolStripMenuItem
            // 
            this.sqlConnectionSensorToolStripMenuItem.Name = "sqlConnectionSensorToolStripMenuItem";
            this.sqlConnectionSensorToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sqlConnectionSensorToolStripMenuItem.Text = "Sql Connection sensor";
            this.sqlConnectionSensorToolStripMenuItem.Click += new System.EventHandler(this.SqlConnectionSensorToolStripMenuItem_Click);
            // 
            // EditToolbarMenuItem
            // 
            this.EditToolbarMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolbarMenuItem.Image = global::MonitoR.Configurator.Properties.Resources.db_settings24_h;
            this.EditToolbarMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolbarMenuItem.Name = "EditToolbarMenuItem";
            this.EditToolbarMenuItem.Size = new System.Drawing.Size(28, 28);
            this.EditToolbarMenuItem.Text = "toolStripButton3";
            this.EditToolbarMenuItem.ToolTipText = "Edit selected sensor";
            this.EditToolbarMenuItem.Click += new System.EventHandler(this.EditToolbarMenuItem_Click);
            // 
            // DeleteToolbarMenuItem
            // 
            this.DeleteToolbarMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteToolbarMenuItem.Image = global::MonitoR.Configurator.Properties.Resources.db_unregister24_h;
            this.DeleteToolbarMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolbarMenuItem.Name = "DeleteToolbarMenuItem";
            this.DeleteToolbarMenuItem.Size = new System.Drawing.Size(28, 28);
            this.DeleteToolbarMenuItem.Text = "toolStripButton2";
            this.DeleteToolbarMenuItem.ToolTipText = "Delete selected sensor";
            this.DeleteToolbarMenuItem.Click += new System.EventHandler(this.DeleteToolbarMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // OptionsToolbarMenuItem
            // 
            this.OptionsToolbarMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OptionsToolbarMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OptionsToolbarMenuItem.Image")));
            this.OptionsToolbarMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptionsToolbarMenuItem.Name = "OptionsToolbarMenuItem";
            this.OptionsToolbarMenuItem.Size = new System.Drawing.Size(28, 28);
            this.OptionsToolbarMenuItem.Text = "Options";
            this.OptionsToolbarMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // AboutToolbarMenuItem
            // 
            this.AboutToolbarMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutToolbarMenuItem.Image = global::MonitoR.Configurator.Properties.Resources.group_user24_h;
            this.AboutToolbarMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutToolbarMenuItem.Name = "AboutToolbarMenuItem";
            this.AboutToolbarMenuItem.Size = new System.Drawing.Size(28, 28);
            this.AboutToolbarMenuItem.Text = "About";
            this.AboutToolbarMenuItem.ToolTipText = "About";
            this.AboutToolbarMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "Monitor Settings Files | *.json|All Files|*.*";
            this.saveFileDialog.Title = "Export Sensor Settings";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Monitor Settings Files | *.json|All Files|*.*";
            this.openFileDialog.Title = "Import Sensor Settings";
            // 
            // tmrServiceStatusCheck
            // 
            this.tmrServiceStatusCheck.Enabled = true;
            this.tmrServiceStatusCheck.Tick += new System.EventHandler(this.TmrServiceStatusCheck_Tick);
            // 
            // lvSensorList
            // 
            this.lvSensorList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSensorList.CheckBoxes = true;
            this.lvSensorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvSensorList.FullRowSelect = true;
            this.lvSensorList.HideSelection = false;
            this.lvSensorList.Location = new System.Drawing.Point(0, 58);
            this.lvSensorList.Name = "lvSensorList";
            this.lvSensorList.Size = new System.Drawing.Size(753, 390);
            this.lvSensorList.TabIndex = 0;
            this.lvSensorList.UseCompatibleStateImageBehavior = false;
            this.lvSensorList.View = System.Windows.Forms.View.Details;
            this.lvSensorList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LvSensorList_ItemSelectionChanged);
            this.lvSensorList.SelectedIndexChanged += new System.EventHandler(this.LvSensorList_SelectedIndexChanged);
            this.lvSensorList.DoubleClick += new System.EventHandler(this.EditToolbarMenuItem_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sensor Type";
            this.columnHeader1.Width = 124;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 225;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Details";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Run";
            this.columnHeader4.Width = 175;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 473);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lvSensorList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitoR - Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NoDoubleClickAutoCheckListview lvSensorList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSensorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DeleteToolbarMenuItem;
        private System.Windows.Forms.ToolStripButton EditToolbarMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AboutToolbarMenuItem;
        private System.Windows.Forms.ToolStripSplitButton AddToolbarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMonitorSettingsLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewJobStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem clearLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSensorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem importConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem cpuSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem httpSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivespaceSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderSizeSensorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileSizeSensorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ramSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlConnectionSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iISApplicationPoolSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iISWebsiteSensorToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem ftpSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton OptionsToolbarMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripServiceStatusLabel;
        private System.Windows.Forms.Timer tmrServiceStatusCheck;
        private System.Windows.Forms.ToolStripMenuItem fileCheckSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderCheckSensorToolStripMenuItem;
    }
}

