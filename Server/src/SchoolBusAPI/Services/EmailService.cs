using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        IActionResult EmailSend([FromBody]Email mail);
    }
}
