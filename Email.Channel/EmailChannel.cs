using NotificationsHub.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationsHub.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;

namespace Email.Channel
{
    public class EmailChannel : IChannel
    {
        ILogger _logger = null;
        //public EmailChannel()
        //{

        //}
        public EmailChannel(ILogger logger)
        {
            _logger = logger;
        }
        public async Task Send(Message message, string ActivityId="")
        {
            try
            {
                _logger.Information($"{ActivityId} Email successfully sent ");
                var apiKey = "[API Key]";

                foreach(var recepient in message.to)
                {
                    var client = new SendGridClient(apiKey);
                    var msg = new SendGridMessage()
                    {
                        From = new EmailAddress(message.sender.email ?? "", message.sender.name ?? "Notifications Hub"),
                        Subject = message.header ?? "<no-subject>",
                        PlainTextContent = message.data.bodyText,
                        HtmlContent = $"<strong>{message.data.bodyText}</strong>"
                    };

                    msg.AddTo(new EmailAddress(recepient.email, recepient.name));
                    var response = await client.SendEmailAsync(msg);
                    _logger.Information($"{ActivityId} Email successfully sent ");
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString()) ;
            }

           
        }
    }
}
