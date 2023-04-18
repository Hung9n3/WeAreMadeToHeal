using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using MailKit.Net.Smtp;
using System.Diagnostics;

namespace WeAreMadeToHeal.Helpers.Email
{
    public class EmailHelper
    {
        private readonly EmailConfig _emailConfig;
        private readonly ILogger<EmailConfig> _logger;

        public EmailHelper(EmailConfig emailConfig, ILogger<EmailConfig> logger)
        {
            _emailConfig = emailConfig;
            _logger = logger;
        }

        public async Task SendMail(string destination, string subject, string? body)
        {
            try
            {
                body ??= "<h1> Your following Categories have new Posts </h1>";
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_emailConfig.EmailUsername));
                email.To.Add(MailboxAddress.Parse(destination));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                using (var smtp = new SmtpClient())
                {
                    await smtp.ConnectAsync(_emailConfig.EmailHost, _emailConfig.Port, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(_emailConfig.EmailUsername, _emailConfig.AppPassword);
                    await smtp.SendAsync(email);
                    await smtp.DisconnectAsync(true);
                }

                _logger.LogInformation($"[Email Digest] Sending email ...\r\nFrom: {_emailConfig.EmailUsername}\r\nTo: {destination}\r\nSubject: {subject}\r\nBody: {body}");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error sending email: " + e);
                _logger.LogError("[Email Digest] Error sending email: \r\n" + JsonConvert.SerializeObject(e));
            }
        }

        public async Task SendMail(List<SendMailInfo> sendMailInfos)
        {
            foreach (var sendMailInfo in sendMailInfos)
            {
                await SendMail(sendMailInfo.Destination, sendMailInfo.Subject, sendMailInfo.Body);
            }
            _logger.LogInformation("[Email Digest] Completed email sending.");
        }
    }


    public class SendMailInfo
    {
        public string Destination { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public SendMailInfo(string destination, string subject, string body)
        {
            Destination = destination;
            Subject = subject;
            Body = body;
        }
    }

}
