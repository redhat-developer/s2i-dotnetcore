using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// email object
    /// </summary>
    public class Email
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailSent">see if email sent successfully</param>
        /// <param name="mailFrom">email address of sender</param>
        /// <param name="mailTo">email address of receiver</param>
        /// <param name="mailCc">email cc</param>
        /// <param name="subject">email subject</param>
        /// <param name="body">email body</param>
        /// <param name="errorInfo">error information when send email fail</param>
        /// <param name="userName">name of user that sending the email</param>
        public Email(bool mailSent, string mailFrom, string mailTo, string mailCc, string subject, string body, string errorInfo, string userName)
        {
            this.mailSent = false;
            this.mailFrom = mailFrom;
            this.mailTo = mailTo;
            this.mailCc = mailCc;
            this.subject = subject;
            this.body = body;
            this.errorInfo = "";
            this.userName = userName;
        }

        /// <summary>
        /// mailSent get set
        /// </summary>
        public bool mailSent { get; set; }
        /// <summary>
        /// mailFrom get set
        /// </summary>
        public string mailFrom { get; set; }
        /// <summary>
        /// mailTo get set
        /// </summary>
        public string mailTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mailCc { get; set; }
        /// <summary>
        /// subject get set
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// body get set
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// error information get set
        /// </summary>
        public string errorInfo { get; set; }
        /// <summary>
        /// name of user who sending email
        /// </summary>
        public string userName { get; set; }
    }
}
