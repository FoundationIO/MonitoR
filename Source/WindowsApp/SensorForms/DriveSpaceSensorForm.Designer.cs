﻿namespace MonitoR.Configurator.SensorForms
{
    partial class DriveSpaceSensorForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cklbDrives = new System.Windows.Forms.CheckedListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.cbNotifyByEmail = new System.Windows.Forms.CheckBox();
            this.ntxtCheckEveryTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTimeType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ntxtDiskUsageExceedValue = new System.Windows.Forms.NumericUpDown();
            this.ntxtNotifyAfterFailureTimes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCheckEveryTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtDiskUsageExceedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtNotifyAfterFailureTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cklbDrives);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbEnabled);
            this.groupBox1.Controls.Add(this.cbNotifyByEmail);
            this.groupBox1.Controls.Add(this.ntxtCheckEveryTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTimeType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ntxtDiskUsageExceedValue);
            this.groupBox1.Controls.Add(this.ntxtNotifyAfterFailureTimes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(613, 458);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 199);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Drives to check :";
            // 
            // cklbDrives
            // 
            this.cklbDrives.FormattingEnabled = true;
            this.cklbDrives.Location = new System.Drawing.Point(27, 230);
            this.cklbDrives.Margin = new System.Windows.Forms.Padding(4);
            this.cklbDrives.Name = "cklbDrives";
            this.cklbDrives.Size = new System.Drawing.Size(560, 106);
            this.cklbDrives.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(453, 22);
            this.txtName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Name";
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(27, 416);
            this.cbEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(82, 21);
            this.cbEnabled.TabIndex = 7;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // cbNotifyByEmail
            // 
            this.cbNotifyByEmail.AutoSize = true;
            this.cbNotifyByEmail.Location = new System.Drawing.Point(27, 367);
            this.cbNotifyByEmail.Margin = new System.Windows.Forms.Padding(4);
            this.cbNotifyByEmail.Name = "cbNotifyByEmail";
            this.cbNotifyByEmail.Size = new System.Drawing.Size(123, 21);
            this.cbNotifyByEmail.TabIndex = 6;
            this.cbNotifyByEmail.Text = "Notify by Email";
            this.cbNotifyByEmail.UseVisualStyleBackColor = true;
            // 
            // ntxtCheckEveryTime
            // 
            this.ntxtCheckEveryTime.Location = new System.Drawing.Point(133, 69);
            this.ntxtCheckEveryTime.Margin = new System.Windows.Forms.Padding(4);
            this.ntxtCheckEveryTime.Name = "ntxtCheckEveryTime";
            this.ntxtCheckEveryTime.Size = new System.Drawing.Size(76, 22);
            this.ntxtCheckEveryTime.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 167);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "%";
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
            this.cmbTimeType.Location = new System.Drawing.Point(217, 69);
            this.cmbTimeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTimeType.Name = "cmbTimeType";
            this.cmbTimeType.Size = new System.Drawing.Size(85, 24);
            this.cmbTimeType.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Alert when Disk space usage exceeds ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Check every";
            // 
            // ntxtDiskUsageExceedValue
            // 
            this.ntxtDiskUsageExceedValue.Location = new System.Drawing.Point(277, 162);
            this.ntxtDiskUsageExceedValue.Margin = new System.Windows.Forms.Padding(4);
            this.ntxtDiskUsageExceedValue.Name = "ntxtDiskUsageExceedValue";
            this.ntxtDiskUsageExceedValue.Size = new System.Drawing.Size(76, 22);
            this.ntxtDiskUsageExceedValue.TabIndex = 4;
            // 
            // ntxtNotifyAfterFailureTimes
            // 
            this.ntxtNotifyAfterFailureTimes.Location = new System.Drawing.Point(133, 113);
            this.ntxtNotifyAfterFailureTimes.Margin = new System.Windows.Forms.Padding(4);
            this.ntxtNotifyAfterFailureTimes.Name = "ntxtNotifyAfterFailureTimes";
            this.ntxtNotifyAfterFailureTimes.Size = new System.Drawing.Size(76, 22);
            this.ntxtNotifyAfterFailureTimes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Notify after ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "continous failures";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(405, 533);
            this.btOk.Margin = new System.Windows.Forms.Padding(4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(100, 28);
            this.btOk.TabIndex = 8;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(529, 533);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(645, 22);
            this.label4.TabIndex = 33;
            this.label4.Text = "Drive Space Sensor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DriveSizeSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 569);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriveSizeSensorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Drive Space Sensor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCheckEveryTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtDiskUsageExceedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtNotifyAfterFailureTimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.CheckBox cbNotifyByEmail;
        private System.Windows.Forms.NumericUpDown ntxtCheckEveryTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTimeType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ntxtDiskUsageExceedValue;
        private System.Windows.Forms.NumericUpDown ntxtNotifyAfterFailureTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox cklbDrives;
        private System.Windows.Forms.Label label8;
    }
}