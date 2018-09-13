using MonitoR.Common.Common.Config;
using MonitoR.Common.Constants;

namespace MonitoR.Common.Infrastructure
{
    public class EmailTemplateSettings
    {
        public bool UseExternalTemplate { get; set; } = false;
        public string ExternalTemplateFile { get; set; } = "";
        public string DefaultSubject { get; set; } = DefaultEmailTemplateText.Subject;
        public string DefaultTextBody { get; set; } = DefaultEmailTemplateText.TextBody;
        public string DefaultHtmlBody { get; set; } =  DefaultEmailTemplateText.HtmlBody;
        public string MessagePrefix { get; set; } = DefaultEmailTemplateText.MessagePrefix;
        public string MessageSuffix { get; set; } = DefaultEmailTemplateText.MessageSuffix;

    }

}
