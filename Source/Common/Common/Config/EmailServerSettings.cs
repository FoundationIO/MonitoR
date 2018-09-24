namespace MonitoR.Common.Common.Config
{
    public class EmailServerSettings
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
        public int TimeoutInSec { get; set; } = 10;
        public bool UseHtmlMail { get; set; }
    }
}
