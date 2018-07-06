using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolBusAPI.Services;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Create a email service
        /// </summary>
        /// <param name="configuration"></param>
        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">email object get from front-end</param>
        /// <returns></returns>
        public virtual IActionResult EmailSend(Email email)
        {
            if (email == null)
            {
                return new BadRequestResult();
            }
            else
            {
                char[] delimiterChars= { ' ',',',';' };
                string fromAddressTitle = "School Bus Inspection System";
                string SmtpServer = Configuration["SMTP_SERVER"];
                int SmtpPort = int.Parse(Configuration["SMTP_PORT"]);
                string emailTo = email.mailTo.ToString();
                string[] emails = emailTo.Split(delimiterChars);
                string mailCc = email.mailCc.ToString();
                string[] ccs = mailCc.Split(delimiterChars);
                string emailFrom = email.mailFrom.ToString();
                string subject = email.subject.ToString();
                string body = email.body.ToString();
                try
                {
                    var emailMessage = new MimeMessage();

                    emailMessage.From.Add(new MailboxAddress(fromAddressTitle, emailFrom)); //add from address
                    foreach (var mailTo in emails)//add to addresses
                    {
                        if (mailTo != string.Empty)
                        {
                            emailMessage.To.Add(new MailboxAddress(mailTo));
                        }
                    }

                    foreach (var cc in ccs)//add ccs
                    {
                        if (cc != string.Empty)
                        {
                            emailMessage.Cc.Add(new MailboxAddress(cc));
                        }
                    }

                    emailMessage.Subject = subject;
                    emailMessage.Body = new TextPart("plain") { Text = body };

                    SmtpClient client = new SmtpClient();

                    try
                    {
                        client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => {
                            Console.WriteLine("sender: {0}",sender);
                            Console.WriteLine("Certificate: {0}", certificate);
                            Console.WriteLine("chain: {0}", chain);
                            Console.WriteLine("sslPolicyErrors: {0}", sslPolicyErrors);
                            return true;
                        };
                        client.Connect(SmtpServer, SmtpPort, false);
                    }
                    catch (SmtpCommandException ex)
                    {
                        throw ex;
                    }
                    
                    client.Send(emailMessage);
                    client.Disconnect(true);
                    
                    return new StatusCodeResult(200);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
