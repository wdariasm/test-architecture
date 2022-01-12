using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;
using Microsoft.Extensions.Logging;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Models.Mail;

namespace TicketManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> mailSetting, ILogger<EmailService> logger)
        {
            _emailSettings = mailSetting.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var sendRequest = new SendEmailRequest
            {
                Destination = new Destination
                {
                    ToAddresses = new List<string> {email.To}
                },
                Content = new EmailContent
                {
                    Simple = new Message
                    {
                        Subject = new Content{Data = email.Subject, Charset = "UTF-8"},
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Data = "",
                                Charset = "UTF-8"
                            }
                        }
                    }
                }
                
            };

            using var client = new AmazonSimpleEmailServiceV2Client();
            _logger.LogInformation("Email sent");
            var result = await client.SendEmailAsync(sendRequest);
            if (result.HttpStatusCode == HttpStatusCode.OK)
                return true;

            _logger.LogError("Email sending failed");
            return false;
        }
    }
}
