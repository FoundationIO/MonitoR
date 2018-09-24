namespace MonitoR.Configurator.SensorForms
{
    partial class FileSizeSensorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSizeSensorForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cklbDrives = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.cbNotifyByEmail = new System.Windows.Forms.CheckBox();
            this.ntxtCheckEveryTime = new System.Windows.Forms.NumericUpDown();
            this.cmbTimeType = new System.Windows.Forms.ComboBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ntxtFileSizeExceedValue = new System.Windows.Forms.NumericUpDown();
            this.ntxtNotifyAfterFailureTimes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSizeUnit = new System.Windows.Forms.ComboBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddItem = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCheckEveryTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtFileSizeExceedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtNotifyAfterFailureTimes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "db_register16_h.bmp");
            this.imageList1.Images.SetKeyName(1, "db_unregister16_h.bmp");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Files to check :";
            // 
            // cklbDrives
            // 
            this.cklbDrives.FormattingEnabled = true;
            this.cklbDrives.Location = new System.Drawing.Point(20, 187);
            this.cklbDrives.Name = "cklbDrives";
            this.cklbDrives.Size = new System.Drawing.Size(421, 82);
            this.cklbDrives.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(341, 20);
            this.txtName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Name";
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(20, 338);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 10;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // cbNotifyByEmail
            // 
            this.cbNotifyByEmail.AutoSize = true;
            this.cbNotifyByEmail.Location = new System.Drawing.Point(20, 298);
            this.cbNotifyByEmail.Name = "cbNotifyByEmail";
            this.cbNotifyByEmail.Size = new System.Drawing.Size(95, 17);
            this.cbNotifyByEmail.TabIndex = 9;
            this.cbNotifyByEmail.Text = "Notify by Email";
            this.cbNotifyByEmail.UseVisualStyleBackColor = true;
            // 
            // ntxtCheckEveryTime
            // 
            this.ntxtCheckEveryTime.Location = new System.Drawing.Point(100, 56);
            this.ntxtCheckEveryTime.Name = "ntxtCheckEveryTime";
            this.ntxtCheckEveryTime.Size = new System.Drawing.Size(57, 20);
            this.ntxtCheckEveryTime.TabIndex = 1;
            // 
            // cmbTimeType
            // 
            this.cmbTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeType.FormattingEnabled = true;
            this.cmbTimeType.Items.AddRange(new object[] {
            "secs",
            "mins",
            "hours",
            "days"});
            this.cmbTimeType.Location = new System.Drawing.Point(163, 56);
            this.cmbTimeType.Name = "cmbTimeType";
            this.cmbTimeType.Size = new System.Drawing.Size(65, 21);
            this.cmbTimeType.TabIndex = 2;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(304, 436);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 11;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(397, 436);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 12;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(484, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "File Size Sensor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Alert when File size usage exceeds ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Check every";
            // 
            // ntxtFileSizeExceedValue
            // 
            this.ntxtFileSizeExceedValue.Location = new System.Drawing.Point(198, 132);
            this.ntxtFileSizeExceedValue.Name = "ntxtFileSizeExceedValue";
            this.ntxtFileSizeExceedValue.Size = new System.Drawing.Size(57, 20);
            this.ntxtFileSizeExceedValue.TabIndex = 4;
            // 
            // ntxtNotifyAfterFailureTimes
            // 
            this.ntxtNotifyAfterFailureTimes.Location = new System.Drawing.Point(100, 92);
            this.ntxtNotifyAfterFailureTimes.Name = "ntxtNotifyAfterFailureTimes";
            this.ntxtNotifyAfterFailureTimes.Size = new System.Drawing.Size(57, 20);
            this.ntxtNotifyAfterFailureTimes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Notify after ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "continous failures";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSizeUnit);
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.btAddItem);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cklbDrives);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbEnabled);
            this.groupBox1.Controls.Add(this.cbNotifyByEmail);
            this.groupBox1.Controls.Add(this.ntxtCheckEveryTime);
            this.groupBox1.Controls.Add(this.cmbTimeType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ntxtFileSizeExceedValue);
            this.groupBox1.Controls.Add(this.ntxtNotifyAfterFailureTimes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 372);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // cbSizeUnit
            // 
            this.cbSizeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSizeUnit.FormattingEnabled = true;
            this.cbSizeUnit.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB",
            "TB"});
            this.cbSizeUnit.Location = new System.Drawing.Point(261, 131);
            this.cbSizeUnit.Name = "cbSizeUnit";
            this.cbSizeUnit.Size = new System.Drawing.Size(65, 21);
            this.cbSizeUnit.TabIndex = 5;
            // 
            // btDelete
            // 
            this.btDelete.ImageIndex = 1;
            this.btDelete.ImageList = this.imageList1;
            this.btDelete.Location = new System.Drawing.Point(398, 287);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(43, 23);
            this.btDelete.TabIndex = 8;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.BtDelete_Click);
            // 
            // btAddItem
            // 
            this.btAddItem.ImageIndex = 0;
            this.btAddItem.ImageList = this.imageList1;
            this.btAddItem.Location = new System.Drawing.Point(349, 287);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(43, 23);
            this.btAddItem.TabIndex = 7;
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.BtAddItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileSizeSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSizeSensorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Size Sensor";
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCheckEveryTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtFileSizeExceedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtNotifyAfterFailureTimes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox cklbDrives;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.CheckBox cbNotifyByEmail;
        private System.Windows.Forms.NumericUpDown ntxtCheckEveryTime;
        private System.Windows.Forms.ComboBox cmbTimeType;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ntxtFileSizeExceedValue;
        private System.Windows.Forms.NumericUpDown ntxtNotifyAfterFailureTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbSizeUnit;
    }
}