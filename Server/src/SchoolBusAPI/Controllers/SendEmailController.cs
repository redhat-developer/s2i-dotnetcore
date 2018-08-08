/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Authorization;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{   /// <summary>
    /// 
    /// </summary>
    public class SendEmailController : Controller
    {
        private readonly IEmailService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        /// <param name="service"></param>
        public SendEmailController(IEmailService service)
        {
            _service = service;
        }

        /// <summary>
        /// Controller of sending email Api request
        /// </summary>
        /// <Permission>Users with login permission in the system can send email</Permission>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/schoolbuses/email")]
        [RequiresPermission(Permission.LOGIN)]
        public virtual IActionResult EmailSend([FromBody]Email mail)
        {
            return this._service.EmailSend(mail);
        }
    }
}