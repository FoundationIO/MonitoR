namespace MonitoR.Configurator.SensorForms
{
    partial class CpuSensorForm
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
            this.cbNotifyByEmail = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ntxtCpuUsageExceedValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ntxtNotifyAfterFailureTimes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTimeType = new System.Windows.Forms.ComboBox();
            this.ntxtCheckEveryTime = new System.Windows.Forms.NumericUpDown();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCpuUsageExceedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtNotifyAfterFailureTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCheckEveryTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbNotifyByEmail
            // 
            this.cbNotifyByEmail.AutoSize = true;
            this.cbNotifyByEmail.Location = new System.Drawing.Point(20, 298);
            this.cbNotifyByEmail.Name = "cbNotifyByEmail";
            this.cbNotifyByEmail.Size = new System.Drawing.Size(95, 17);
            this.cbNotifyByEmail.TabIndex = 5;
            this.cbNotifyByEmail.Text = "Notify by Email";
            this.cbNotifyByEmail.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Alert when Cpu usage exceeds ";
            // 
            // ntxtCpuUsageExceedValue
            // 
            this.ntxtCpuUsageExceedValue.Location = new System.Drawing.Point(180, 132);
            this.ntxtCpuUsageExceedValue.Name = "ntxtCpuUsageExceedValue";
            this.ntxtCpuUsageExceedValue.Size = new System.Drawing.Size(57, 20);
            this.ntxtCpuUsageExceedValue.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(484, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cpu Sensor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Notify after ";
            // 
            // ntxtNotifyAfterFailureTimes
            // 
            this.ntxtNotifyAfterFailureTimes.Location = new System.Drawing.Point(100, 92);
            this.ntxtNotifyAfterFailureTimes.Name = "ntxtNotifyAfterFailureTimes";
            this.ntxtNotifyAfterFailureTimes.Size = new System.Drawing.Size(57, 20);
            this.ntxtNotifyAfterFailureTimes.TabIndex = 3;
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
            // cmbTimeType
            // 
            this.cmbTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeType.FormattingEnabled = true;
            this.cmbTimeType.Items.AddRange(new object[] {
            "secs",
            "mins",
            "hours"});
            this.cmbTimeType.Location = new System.Drawing.Point(163, 56);
            this.cmbTimeType.Name = "cmbTimeType";
            this.cmbTimeType.Size = new System.Drawing.Size(65, 21);
            this.cmbTimeType.TabIndex = 2;
            // 
            // ntxtCheckEveryTime
            // 
            this.ntxtCheckEveryTime.Location = new System.Drawing.Point(100, 56);
            this.ntxtCheckEveryTime.Name = "ntxtCheckEveryTime";
            this.ntxtCheckEveryTime.Size = new System.Drawing.Size(57, 20);
            this.ntxtCheckEveryTime.TabIndex = 1;
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(20, 336);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 6;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(304, 427);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 7;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(397, 427);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(341, 20);
            this.txtName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbEnabled);
            this.groupBox1.Controls.Add(this.cbNotifyByEmail);
            this.groupBox1.Controls.Add(this.ntxtCheckEveryTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTimeType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ntxtCpuUsageExceedValue);
            this.groupBox1.Controls.Add(this.ntxtNotifyAfterFailureTimes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 372);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // CpuSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CpuSensorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cpu Sensor";
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCpuUsageExceedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtNotifyAfterFailureTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCheckEveryTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNotifyByEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ntxtCpuUsageExceedValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ntxtNotifyAfterFailureTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTimeType;
        private System.Windows.Forms.NumericUpDown ntxtCheckEveryTime;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}