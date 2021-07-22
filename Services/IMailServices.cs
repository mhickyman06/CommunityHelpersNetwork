//using MailKit.Net.Smtp;
//using MailKit.Security;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Logging;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;

namespace HelpersNetwork.Services
{

    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<MailService> logger;
        private readonly IWebHostEnvironment hostingEnvironment;
        static string[] Scopes = { GmailService.Scope.GmailReadonly };

        public MailService(IOptions<MailSettings> mailSettings,
            ILogger<MailService> logger,
            IWebHostEnvironment hostingEnvironment)
        {
            this._mailSettings = mailSettings.Value;
            this.logger = logger;
            this.hostingEnvironment = hostingEnvironment;
        }

        [System.Obsolete]
        public async Task SendEmailAsync(MailRequest mailRequest)
        {


            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
           
            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<p style='color:black;'>{0}</p>",mailRequest.Body) };

            if (mailRequest.Attachments != null && mailRequest.Attachments.Any())
            {
                byte[] filbytes;
                foreach (var attachments in mailRequest.Attachments)
                {                  

                    using (var ms = new MemoryStream())
                    {
                        attachments.CopyTo(ms);
                        filbytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachments.FileName, filbytes, ContentType.Parse(attachments.ContentType));
                }
            }
            email.Body = bodyBuilder.ToMessageBody();
            using var smtp = new SmtpClient();

            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
}