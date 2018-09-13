namespace MonitoR.Configurator
{
    partial class OptionForm
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
            this.txtToEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFromEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLogDebug = new System.Windows.Forms.CheckBox();
            this.cbLogInfo = new System.Windows.Forms.CheckBox();
            this.cbLogWarn = new System.Windows.Forms.CheckBox();
            this.cbLogError = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbEmailUseSSL = new System.Windows.Forms.CheckBox();
            this.txtEmailPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmailUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmailPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmailServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btSendTestEmail = new System.Windows.Forms.Button();
            this.cbUseHtmlMessage = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmailTemplateSubject = new System.Windows.Forms.TextBox();
            this.txtEmailTemplateBody = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtEmailTemplateBody);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtEmailTemplateSubject);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbUseHtmlMessage);
            this.groupBox1.Controls.Add(this.txtToEmail);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtFromEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbLogDebug);
            this.groupBox1.Controls.Add(this.cbLogInfo);
            this.groupBox1.Controls.Add(this.cbLogWarn);
            this.groupBox1.Controls.Add(this.cbLogError);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbEmailUseSSL);
            this.groupBox1.Controls.Add(this.txtEmailPassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtEmailUsername);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEmailPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmailServerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(613, 498);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // txtToEmail
            // 
            this.txtToEmail.Location = new System.Drawing.Point(189, 96);
            this.txtToEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.Size = new System.Drawing.Size(400, 22);
            this.txtToEmail.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 100);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "To Email : ";
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.Location = new System.Drawing.Point(189, 65);
            this.txtFromEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(400, 22);
            this.txtFromEmail.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "From Email : ";
            // 
            // cbLogDebug
            // 
            this.cbLogDebug.AutoSize = true;
            this.cbLogDebug.Location = new System.Drawing.Point(468, 463);
            this.cbLogDebug.Margin = new System.Windows.Forms.Padding(4);
            this.cbLogDebug.Name = "cbLogDebug";
            this.cbLogDebug.Size = new System.Drawing.Size(100, 21);
            this.cbLogDebug.TabIndex = 13;
            this.cbLogDebug.Text = "Log Debug";
            this.cbLogDebug.UseVisualStyleBackColor = true;
            // 
            // cbLogInfo
            // 
            this.cbLogInfo.AutoSize = true;
            this.cbLogInfo.Location = new System.Drawing.Point(331, 463);
            this.cbLogInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cbLogInfo.Name = "cbLogInfo";
            this.cbLogInfo.Size = new System.Drawing.Size(81, 21);
            this.cbLogInfo.TabIndex = 12;
            this.cbLogInfo.Text = "Log Info";
            this.cbLogInfo.UseVisualStyleBackColor = true;
            // 
            // cbLogWarn
            // 
            this.cbLogWarn.AutoSize = true;
            this.cbLogWarn.Location = new System.Drawing.Point(197, 463);
            this.cbLogWarn.Margin = new System.Windows.Forms.Padding(4);
            this.cbLogWarn.Name = "cbLogWarn";
            this.cbLogWarn.Size = new System.Drawing.Size(92, 21);
            this.cbLogWarn.TabIndex = 11;
            this.cbLogWarn.Text = "Log Warn";
            this.cbLogWarn.UseVisualStyleBackColor = true;
            // 
            // cbLogError
            // 
            this.cbLogError.AutoSize = true;
            this.cbLogError.Location = new System.Drawing.Point(69, 463);
            this.cbLogError.Margin = new System.Windows.Forms.Padding(4);
            this.cbLogError.Name = "cbLogError";
            this.cbLogError.Size = new System.Drawing.Size(90, 21);
            this.cbLogError.TabIndex = 10;
            this.cbLogError.Text = "Log Error";
            this.cbLogError.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 437);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Log Settings";
            // 
            // cbEmailUseSSL
            // 
            this.cbEmailUseSSL.AutoSize = true;
            this.cbEmailUseSSL.Location = new System.Drawing.Point(57, 262);
            this.cbEmailUseSSL.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmailUseSSL.Name = "cbEmailUseSSL";
            this.cbEmailUseSSL.Size = new System.Drawing.Size(85, 21);
            this.cbEmailUseSSL.TabIndex = 6;
            this.cbEmailUseSSL.Text = "Use SSL";
            this.cbEmailUseSSL.UseVisualStyleBackColor = true;
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(189, 224);
            this.txtEmailPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.Size = new System.Drawing.Size(248, 22);
            this.txtEmailPassword.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 260);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password : ";
            // 
            // txtEmailUsername
            // 
            this.txtEmailUsername.Location = new System.Drawing.Point(189, 192);
            this.txtEmailUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailUsername.Name = "txtEmailUsername";
            this.txtEmailUsername.Size = new System.Drawing.Size(248, 22);
            this.txtEmailUsername.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "User Name : ";
            // 
            // txtEmailPort
            // 
            this.txtEmailPort.Location = new System.Drawing.Point(189, 160);
            this.txtEmailPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailPort.Name = "txtEmailPort";
            this.txtEmailPort.Size = new System.Drawing.Size(69, 22);
            this.txtEmailPort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port  : ";
            // 
            // txtEmailServerName
            // 
            this.txtEmailServerName.Location = new System.Drawing.Point(189, 128);
            this.txtEmailServerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailServerName.Name = "txtEmailServerName";
            this.txtEmailServerName.Size = new System.Drawing.Size(400, 22);
            this.txtEmailServerName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Name : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email Settings";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(408, 553);
            this.btOk.Margin = new System.Windows.Forms.Padding(4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(100, 28);
            this.btOk.TabIndex = 15;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(532, 553);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 16;
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
            this.label4.Size = new System.Drawing.Size(645, 32);
            this.label4.TabIndex = 33;
            this.label4.Text = "Options";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSendTestEmail
            // 
            this.btSendTestEmail.Location = new System.Drawing.Point(19, 553);
            this.btSendTestEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btSendTestEmail.Name = "btSendTestEmail";
            this.btSendTestEmail.Size = new System.Drawing.Size(140, 28);
            this.btSendTestEmail.TabIndex = 14;
            this.btSendTestEmail.Text = "Send Test Email";
            this.btSendTestEmail.UseVisualStyleBackColor = true;
            this.btSendTestEmail.Click += new System.EventHandler(this.btSendTestEmail_Click);
            // 
            // cbUseHtmlMessage
            // 
            this.cbUseHtmlMessage.AutoSize = true;
            this.cbUseHtmlMessage.Location = new System.Drawing.Point(189, 262);
            this.cbUseHtmlMessage.Margin = new System.Windows.Forms.Padding(4);
            this.cbUseHtmlMessage.Name = "cbUseHtmlMessage";
            this.cbUseHtmlMessage.Size = new System.Drawing.Size(148, 21);
            this.cbUseHtmlMessage.TabIndex = 7;
            this.cbUseHtmlMessage.Text = "Use Html Message";
            this.cbUseHtmlMessage.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 296);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Subject : ";
            // 
            // txtEmailTemplateSubject
            // 
            this.txtEmailTemplateSubject.Location = new System.Drawing.Point(189, 296);
            this.txtEmailTemplateSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailTemplateSubject.Name = "txtEmailTemplateSubject";
            this.txtEmailTemplateSubject.Size = new System.Drawing.Size(400, 22);
            this.txtEmailTemplateSubject.TabIndex = 8;
            // 
            // txtEmailTemplateBody
            // 
            this.txtEmailTemplateBody.Location = new System.Drawing.Point(189, 326);
            this.txtEmailTemplateBody.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailTemplateBody.Multiline = true;
            this.txtEmailTemplateBody.Name = "txtEmailTemplateBody";
            this.txtEmailTemplateBody.Size = new System.Drawing.Size(400, 99);
            this.txtEmailTemplateBody.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 329);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Body : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 229);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 17);
            this.label12.TabIndex = 25;
            this.label12.Text = "Password : ";
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 592);
            this.Controls.Add(this.btSendTestEmail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbLogError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbEmailUseSSL;
        private System.Windows.Forms.TextBox txtEmailPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmailUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmailPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmailServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbLogWarn;
        private System.Windows.Forms.CheckBox cbLogDebug;
        private System.Windows.Forms.CheckBox cbLogInfo;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtToEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btSendTestEmail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmailTemplateBody;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmailTemplateSubject;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbUseHtmlMessage;
    }
}