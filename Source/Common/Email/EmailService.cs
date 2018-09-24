using MonitoR.Common.Common;
using MonitoR.Common.Infrastructure;
using MonitoR.Common.Utilities;
using System;

namespace MonitoR.Common.Service
{
    public class EmailService : IEmailService
    {
        private readonly IAppConfig appConfig;
        private readonly ILog log;

        public EmailService(IAppConfig appConfig, ILog log)
        {
            this.appConfig = appConfig;
            this.log = log;
        }

        public ReturnValue SendMail(string subject, string textBody, string htmlBody)
        {
            ReturnValue result;
            try
            {
                EmailUtils.SendMail(appConfig.EmailServerSettings.FromEmail,
                                    appConfig.EmailServerSettings.ToEmail,
                                    subject,
                                    appConfig.EmailServerSettings.UseHtmlMail,
                                    appConfig.EmailServerSettings.UseHtmlMail ? htmlBody : textBody,
                                    appConfig.EmailServerSettings.Server,
                                    appConfig.EmailServerSettings.Port,
                                    appConfig.EmailServerSettings.UserName,
                                    appConfig.EmailServerSettings.Password,
                                    appConfig.EmailServerSettings.UseSSL,
                                    appConfig.EmailServerSettings.TimeoutInSec);
                result = ReturnValue.True();
            }
            catch(Exception ex)
            {
                log.Error(ex, $"Unable to send email to - {appConfig.EmailServerSettings.ToEmail}");
                result = ReturnValue.False($"Unable to send email to - {appConfig.EmailServerSettings.ToEmail}");
            }
            return result;
        }
    }
}
