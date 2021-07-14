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


            //UserCredential credential;

            //using (var stream =
            //  new FileStream("Credentials.json", FileMode.Open, FileAccess.Read))
            //{
              
            //    string credPath = "token.json";
            //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //       GoogleClientSecrets.Load(stream).Secrets,
            //        Scopes,
            //        "user",
            //        CancellationToken.None,
            //        new FileDataStore(credPath, true)).Result;
            //    logger.LogInformation("Credential file saved to: " + credPath);
            //}

            //var service = new GmailService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = "CommunityHelpersNetwork",
            //});

            // Define parameters of request.
            //UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            // List labels.
            //IList<Label> labels = request.Execute().Labels;
            //Console.WriteLine("Labels:");
            //if (labels != null && labels.Count > 0)
            //{
            //    foreach (var labelItem in labels)
            //    {
            //        Console.WriteLine("{0}", labelItem.Name);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No labels found.");
            //}
            //Console.Read();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            //var builder = new BodyBuilder();
            //builder.HtmlBody = mailRequest.Body;
            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<p style='color:black;'>{0}</p>",mailRequest.Body) };

            if (mailRequest.Attachments != null && mailRequest.Attachments.Any())
            {
                byte[] filbytes;
                foreach (var attachments in mailRequest.Attachments)
                {

                    //string filename = ContentDispositionHeaderValue.Parse(attachments.ContentDisposition).FileName.Trim('"');
                    //filename = this.EnsureCorrectFilename(filename);

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