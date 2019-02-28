using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["SendGrid_API_Key"]);

            SendGridMessage message = new SendGridMessage();

            message.SetFrom("noreply@binarytreenursery.com");
            message.AddTo(email);
            message.SetSubject(subject);
            message.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(message);
        }
    }
}
