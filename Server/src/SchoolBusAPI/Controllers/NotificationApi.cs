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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NotificationApiController : Controller
    {
        private readonly INotificationApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public NotificationApiController(INotificationApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Notifications created</response>
        [HttpPost]
        [Route("/api/notifications/bulk")]
        [SwaggerOperation("NotificationsBulkPost")]
        public virtual IActionResult NotificationsBulkPost([FromBody]Notification[] items)
        {
            return this._service.NotificationsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/notifications")]
        [SwaggerOperation("NotificationsGet")]
        [SwaggerResponse(200, type: typeof(List<Notification>))]
        public virtual IActionResult NotificationsGet()
        {
            return this._service.NotificationsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpPost]
        [Route("/api/notifications/{id}/delete")]
        [SwaggerOperation("NotificationsIdDeletePost")]
        public virtual IActionResult NotificationsIdDeletePost([FromRoute]int id)
        {
            return this._service.NotificationsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpGet]
        [Route("/api/notifications/{id}")]
        [SwaggerOperation("NotificationsIdGet")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult NotificationsIdGet([FromRoute]int id)
        {
            return this._service.NotificationsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpPut]
        [Route("/api/notifications/{id}")]
        [SwaggerOperation("NotificationsIdPut")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult NotificationsIdPut([FromRoute]int id, [FromBody]Notification item)
        {
            return this._service.NotificationsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Notification created</response>
        [HttpPost]
        [Route("/api/notifications")]
        [SwaggerOperation("NotificationsPost")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult NotificationsPost([FromBody]Notification item)
        {
            return this._service.NotificationsPostAsync(item);
        }
    }
}
