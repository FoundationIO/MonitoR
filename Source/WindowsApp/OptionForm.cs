using MonitoR.Common.Infrastructure;
using MonitoR.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoR.Configurator
{
    public partial class OptionForm : Form
    {
        private readonly IAppConfig config;
        private readonly ILog log;

        public OptionForm(IAppConfig config, ILog log)
        {
            this.config = config;
            this.log = log;
            InitializeComponent();
            InitCustomCode();
            UpdateUIFromData();
        }

        private void InitCustomCode()
        {
            txtFromEmail.Focus();
        }

        public void UpdateDataFromUI()
        {
            config.LogDebug = cbLogDebug.Checked;
            config.LogError = cbLogError.Checked;
            config.LogInfo = cbLogInfo.Checked;
            config.LogWarn = cbLogWarn.Checked;
            config.EmailServerSettings.FromEmail = txtFromEmail.Text.Trim();
            config.EmailServerSettings.ToEmail = txtToEmail.Text.Trim();
            config.EmailServerSettings.Server = txtEmailServerName.Text.Trim();
            config.EmailServerSettings.Port = SafeUtils.Int(txtEmailPort.Text.Trim());
            config.EmailServerSettings.UserName = txtEmailUsername.Text.Trim();
            config.EmailServerSettings.Password = txtEmailPassword.Text.Trim();
            config.EmailServerSettings.UseSSL = cbEmailUseSSL.Checked;
            config.EmailServerSettings.UseHtmlMail = cbUseHtmlMessage.Checked;
            config.EmailTemplateSettings.DefaultSubject = txtEmailTemplateSubject.Text;
            config.EmailTemplateSettings.DefaultTextBody = txtEmailTemplateBody.Text;
            config.EmailTemplateSettings.DefaultHtmlBody = txtEmailTemplateBody.Text;
        }

        public void UpdateUIFromData()
        {
            cbLogDebug.Checked = config.LogDebug;
            cbLogError.Checked = config.LogError;
            cbLogInfo.Checked = config.LogInfo;
            cbLogWarn.Checked = config.LogWarn;
            txtFromEmail.Text = config.EmailServerSettings.FromEmail?.Trim();
            txtToEmail.Text = config.EmailServerSettings.ToEmail?.Trim();
            txtEmailServerName.Text = config.EmailServerSettings.Server?.Trim();
            txtEmailPort.Text = config.EmailServerSettings.Port.ToString();
            txtEmailUsername.Text = config.EmailServerSettings.UserName?.Trim();
            txtEmailPassword.Text = config.EmailServerSettings.Password?.Trim();
            cbEmailUseSSL.Checked = config.EmailServerSettings.UseSSL;
            cbUseHtmlMessage.Checked = config.EmailServerSettings.UseHtmlMail;
            txtEmailTemplateSubject.Text = config.EmailTemplateSettings.DefaultSubject;
            txtEmailTemplateBody.Text = config.EmailTemplateSettings.DefaultTextBody;
        }

        private bool IsValid()
        {
            if(txtFromEmail.Text.IsTrimmedStringNullOrEmpty())
            {
                MessageBox.Show("From Email should not be empty");
                return false;
            }

            if (!ValidationUtils.IsEmailValid(txtFromEmail.Text.Trim()))
            {
                MessageBox.Show("From Email is not valid");
                return false;
            }

            if (txtToEmail.Text.IsTrimmedStringNullOrEmpty())
            {
                MessageBox.Show("To Email should not be empty");
                return false;
            }

            if (!ValidationUtils.IsEmailValid(txtToEmail.Text.Trim()))
            {
                MessageBox.Show("To Email is not valid");
                return false;
            }

            if (txtEmailServerName.Text.IsTrimmedStringNullOrEmpty())
            {
                MessageBox.Show("Email Server should not be empty");
                return false;
            }

            if (SafeUtils.Int(txtEmailPort.Text) == 0)
            {
                MessageBox.Show("Email Port should be  greater than Zero");
                return false;
            }

            if (txtEmailUsername.Text.IsTrimmedStringNullOrEmpty())
            {
                MessageBox.Show("Email Usename should not be empty");
                return false;
            }

            if (txtEmailPassword.Text.IsTrimmedStringNullOrEmpty())
            {
                MessageBox.Show("Email Password should not be empty");
                return false;
            }

            if (txtEmailTemplateSubject.Text.IsTrimmedStringNullOrEmpty())
            {
                MessageBox.Show("Email Template Subject should not be empty");
                return false;
            }

            if (txtEmailTemplateBody.Text.IsTrimmedStringNullOrEmpty())
            {
                MessageBox.Show("Email Template Body should not be empty");
                return false;
            }

            return true;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btSendTestEmail_Click(object sender, EventArgs e)
        {
            try
            {
                EmailUtils.SendMail(txtFromEmail.Text.Trim(),
                                    txtToEmail.Text.Trim(),
                                    "Test email from MonitorR",
                                    cbUseHtmlMessage.Checked,
                                    cbUseHtmlMessage.Checked ? "<html><b>Test html email from MonitorR</b></html>" : "Test email from MonitorR",
                                    txtEmailServerName.Text.Trim(),
                                    SafeUtils.Int(txtEmailPort.Text.Trim()),
                                    txtEmailUsername.Text.Trim(),
                                    txtEmailPassword.Text.Trim(),
                                    cbEmailUseSSL.Checked,
                                    10);

                MessageBox.Show($"Successfully sent the mail to {txtToEmail.Text}");
            }
            catch (Exception ex)
            {
                log.Error(ex, $"Unable to send email to - {txtToEmail.Text}");
                MessageBox.Show($"Unable to send email to - {txtToEmail.Text} \n\n Exception : \n" + ex.RecursivelyGetExceptionMessage());
            }
        }
    }
}
