using System.Net.Mail;
using System.Net;

namespace CV.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("grisha.kutyanski@gmail.com", "wyxxqpnqxcprftwv")
            };

            return client.SendMailAsync(
                new MailMessage(from: "grisha.kutyanski@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
