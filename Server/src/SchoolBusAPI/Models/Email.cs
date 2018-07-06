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
        /// <param name="mailFrom">email address of sender</param>
        /// <param name="mailTo">email address of receiver</param>
        /// <param name="mailCc">email cc</param>
        /// <param name="subject">email subject</param>
        /// <param name="body">email body</param>
        public Email(string mailFrom, string mailTo, string mailCc, string subject, string body)
        {
            this.mailFrom = mailFrom;
            this.mailTo = mailTo;
            this.mailCc = mailCc;
            this.subject = subject;
            this.body = body;
        }

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
    }
}
