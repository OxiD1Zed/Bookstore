using System.Net.Mail;
using System.Net;

namespace Bookstore.common.domain
{
    public class SmtpSendler
    {
        private readonly SmtpClient _smtpClient;

        public SmtpSendler() 
        {
            _smtpClient = new SmtpClient();
            _smtpClient.Credentials = new NetworkCredential();
            _smtpClient.Host = "smtp.mail.ru";
            _smtpClient.Port = 2525;//587; 
            _smtpClient.EnableSsl = true;
        }

        public void Send(string title, string message, string email) 
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress();
            mail.To.Add(new MailAddress(email));
            mail.Subject = title;
            mail.Body = message;
            _smtpClient.Send(mail);
        }
    }
}
