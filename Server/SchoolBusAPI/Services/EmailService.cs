using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using System;
using MailKit.Net.Smtp;
using System.Net.Security;
using MimeKit;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// Interface of email service
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// send email
        /// </summary>
        /// <param name="mail">email object</param>
        /// <returns></returns>
        IActionResult EmailSend([FromBody] Email mail);
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmailService : ServiceBase, IEmailService
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<EmailService> _logger;

        /// <summary>
        /// Create a email service
        /// </summary>
        public EmailService(DbAppContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILogger<EmailService> logger) 
            : base(httpContextAccessor, context, mapper)
        {
            Configuration = configuration;
            _logger = logger;
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
                char[] delimiterChars = { ' ', ',', ';' };
                string SMTP_SERVER_SSL_TRUSTED_THUMBPRINT = Configuration["SMTP_SERVER_SSL_TRUSTED_THUMBPRINT"];

                string fromAddressTitle = email.userName.ToString();
                string SmtpServer = Configuration["SMTP_SERVER"];
                int SmtpPort = int.Parse(Configuration["SMTP_PORT"]);

                string emailTo = email.mailTo.ToString();
                string[] emails = emailTo.Split(delimiterChars);
                string mailCc = email.mailCc.ToString();
                string[] ccs = mailCc.Split(delimiterChars);

                string emailFrom = email.mailFrom.ToString().Trim();
                string subject = email.subject.ToString().Trim();
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
                    emailMessage.Body = new TextPart("html") { Text = body };

                    SmtpClient client = new SmtpClient();

                    try
                    {
                        client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                        {
                            _logger.LogInformation("Starting certificate validation.");
                            if (sslPolicyErrors == SslPolicyErrors.None)
                            {
                                _logger.LogInformation("Certificate valid");
                                return true;
                            }

                            if (chain.ChainElements == null || chain.ChainElements.Count == 0)
                            {
                                _logger.LogError("No certificates found in chain.");
                                return false;
                            }

                            return true;
                        };

                        client.CheckCertificateRevocation = false;
                        client.Connect(SmtpServer, SmtpPort, MailKit.Security.SecureSocketOptions.Auto);
                    }
                    catch (MailKit.Security.SslHandshakeException)
                    {
                        email.mailSent = false;
                        email.errorInfo = "Unable to process the SSL Certificate.  Certificate may be untrusted, or the server does not accept SSL.";
                        _logger.LogError($"Unable to process the SSL Certificate.  Certificate may be untrusted, or the server does not accept SSL.");
                        return new ObjectResult(email);
                    }
                    catch (Exception ex)
                    {
                        email.mailSent = false;
                        email.errorInfo = $"Unknown error occurred: ({ex.GetType().ToString()}) {ex.Message}.";
                        _logger.LogError($"Unknown error occurred: ({ex.GetType().ToString()}) {ex.Message}");
                        return new ObjectResult(email);
                    }

                    client.Send(emailMessage);
                    _logger.LogInformation("Email sent.");
                    client.Disconnect(true);

                    email.mailSent = true;
                    return new ObjectResult(email);
                }
                catch (Exception ex)
                {
                    email.mailSent = false;
                    email.errorInfo = $"Error: {ex.Message}.";
                    return new ObjectResult(email);
                }
            }
        }
    }
}
