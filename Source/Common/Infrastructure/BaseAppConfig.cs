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
            this.LogTrace = itemFromFile.LogTrace;
            this.LogDebug = itemFromFile.LogDebug;
            this.LogInfo = itemFromFile.LogInfo;
            this.LogWarn = itemFromFile.LogWarn;
            this.LogError = itemFromFile.LogError;

            this.RemoteStatus = itemFromFile.RemoteStatus;
            if (this.RemoteStatus == null)
            {
                this.RemoteStatus = new RemoteStatusSettings();
            }

            this.EmailServerSettings = itemFromFile.EmailServerSettings;
            if(this.EmailServerSettings == null)
            {
                this.EmailServerSettings = new EmailServerSettings();
            }

            this.EmailTemplateSettings = itemFromFile.EmailTemplateSettings;
            if (this.EmailTemplateSettings == null)
            {
                this.EmailTemplateSettings = new EmailTemplateSettings();
            }

            if(this.EmailTemplateSettings.DefaultSubject.IsTrimmedStringNullOrEmpty())
            {
                this.EmailTemplateSettings.DefaultSubject = DefaultEmailTemplateText.Subject;
            }

            if (this.EmailTemplateSettings.DefaultTextBody.IsTrimmedStringNullOrEmpty())
            {                
                this.EmailTemplateSettings.DefaultTextBody = DefaultEmailTemplateText.TextBody;
            }

            if (this.EmailTemplateSettings.DefaultHtmlBody.IsTrimmedStringNullOrEmpty())
            {
                this.EmailTemplateSettings.DefaultHtmlBody = DefaultEmailTemplateText.HtmlBody;
            }

        }

    }
}
