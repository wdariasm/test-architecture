using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Models.Mail;

namespace TicketManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> mailSetting)
        {
            emailSettings = mailSetting.Value;
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
            var result = await client.SendEmailAsync(sendRequest);
            return result.HttpStatusCode == HttpStatusCode.OK;
        }
    }
}
