namespace MonitoR.Common.Notification
{
    public class EmailNotification
    {
        public string Name { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string ServerName { get; set; }
        public string ServerUserName { get; set; }
        public string ServerUserPassword { get; set; }
        public int ServerPortNumber { get; set; }
    }

}
