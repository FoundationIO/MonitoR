using MonitoR.Common.Common;
using MonitoR.Common.Common.Config;
using MonitoR.Common.Constants;
using MonitoR.Common.Sensors;
using MonitoR.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Infrastructure
{
    public class BaseAppConfig
    {
        public bool LogTrace { get; set; } = false;
        public bool LogDebug { get; set; } = false;
        public bool LogInfo { get; set; } = false;
        public bool LogWarn { get; set; } = true;
        public bool LogError { get; set; } = true;

        public RemoteStatusSettings RemoteStatus { get; set; } = new RemoteStatusSettings();
        public EmailServerSettings EmailServerSettings { get; set; } = new EmailServerSettings();
        public EmailTemplateSettings EmailTemplateSettings { get; set; } = new EmailTemplateSettings();

        public BaseAppConfig()
        {
        }

        public void Update(BaseAppConfig itemFromFile)
        {
            LogTrace = itemFromFile.LogTrace;
            LogDebug = itemFromFile.LogDebug;
            LogInfo = itemFromFile.LogInfo;
            LogWarn = itemFromFile.LogWarn;
            LogError = itemFromFile.LogError;

            RemoteStatus = itemFromFile.RemoteStatus ?? new RemoteStatusSettings();

            EmailServerSettings = itemFromFile.EmailServerSettings ?? new EmailServerSettings();
            EmailTemplateSettings = itemFromFile.EmailTemplateSettings ?? new EmailTemplateSettings();

            if (EmailTemplateSettings.DefaultSubject.IsTrimmedStringNullOrEmpty())
            {
                EmailTemplateSettings.DefaultSubject = DefaultEmailTemplateText.Subject;
            }

            if (EmailTemplateSettings.DefaultTextBody.IsTrimmedStringNullOrEmpty())
            {
                EmailTemplateSettings.DefaultTextBody = DefaultEmailTemplateText.TextBody;
            }

            if (EmailTemplateSettings.DefaultHtmlBody.IsTrimmedStringNullOrEmpty())
            {
                EmailTemplateSettings.DefaultHtmlBody = DefaultEmailTemplateText.HtmlBody;
            }
        }
    }
}
