using MonitoR.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Utilities
{
    public static class EmailUtils
    {
        public static void SendMail(string fromEmail, string toEmail, string subject, bool isHtmlMessage, string body, string server, int port, string userName, string password, bool useSSL, int timeoutInSec)
        {
            var mail = new MailMessage(fromEmail, toEmail)
            {
                IsBodyHtml = isHtmlMessage,
                Subject = subject,
                Body = body
            };

            using (var client = new SmtpClient
            {
                Timeout = timeoutInSec * 1000,
                Port = port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = useSSL,
                Credentials = new System.Net.NetworkCredential(userName, password),
                Host = server})
                {
                    client.Send(mail);
                }
        }
    }
}
