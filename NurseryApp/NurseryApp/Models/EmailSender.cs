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

        /// <summary>
        /// Constructor method that brings in configuration strings to be used by the EmailSender class
        /// </summary>
        /// <param name="configuration">Configuration strings from user secrets</param>
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Method that builds and sends and email from the given parameters. Uses SendGrid API to send emails.
        /// </summary>
        /// <param name="email">Email address to send email to</param>
        /// <param name="subject">Text that will appear in subject line</param>
        /// <param name="htmlMessage">Text that will appear in the body of the email</param>
        /// <returns>Email sent to target destination</returns>
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
