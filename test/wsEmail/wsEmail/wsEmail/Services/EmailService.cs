using System.Net;
using System.Net.Mail;

namespace wsEmail.Services
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(string to, string subject, string body)
        {
            var email = configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
            var port = configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            var smptClient = new SmtpClient() { Host = host, Port = port };
            smptClient.EnableSsl = true;
            smptClient.UseDefaultCredentials = false;

            smptClient.Credentials = new NetworkCredential(email, password);

            var message = new MailMessage(email!, to, subject, body);
            await smptClient.SendMailAsync(message);

        }
    }
}
