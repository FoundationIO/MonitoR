using MonitoR.Common.Common;

namespace MonitoR.Common.Service
{
    public interface IEmailService
    {
        ReturnValue SendMail(string subject, string textBody, string htmlBody);
    }
}