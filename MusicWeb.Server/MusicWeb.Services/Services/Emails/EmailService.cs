using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Emails
{
    public class EmailService : IEmailSender
    {
        private readonly ILogger _logger;
        private string _mail { get; set; }
        private string _password { get; set; }

        public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
        {
            _mail = configuration.GetValue<string>("EmailCreadentials:Mail");
            _password = configuration.GetValue<string>("EmailCreadentials:Password");
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await Execute(subject, message, email);
        }

        public async Task SendEmailAsync(List<string> emails, string subject, string message)
        {
            await Execute(subject, message, emails);
        }

        private async Task Execute(string subject, string message, string email)
        {
            try
            {
                _ = Task.Run(async () =>
                {
                    SmtpClient client = new()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new System.Net.NetworkCredential(_mail, _password)
                    };

                    MailMessage mail = new MailMessage(_mail, email);

                    mail.From = new MailAddress(_mail, "Prospero");
                    mail.Subject = subject;
                    mail.Body = message;

                    await client.SendMailAsync(mail);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Can not send email");
            }

            await Task.FromResult(0);
        }
        private async Task Execute(string subject, string message, List<string> emails)
        {
            try
            {
                _ = Task.Run(async () =>
                {
                    SmtpClient client = new()
                    {
                        Host = "ssl0.ovh.net",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new System.Net.NetworkCredential(_mail, _password)
                    };

                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress(_mail, "Prospero");
                    mail.Subject = subject;
                    mail.Body = message;

                    foreach (var email in emails)
                        mail.To.Add(email);

                    await client.SendMailAsync(mail);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Can not send email");
            }
        }
    }
}
