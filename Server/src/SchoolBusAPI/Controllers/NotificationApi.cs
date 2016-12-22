/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
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
        
        /// <param name="body"></param>
        /// <response code="201">Notifications created</response>
        [HttpPost]
        [Route("/api/notifications/bulk")]
        [SwaggerOperation("notificationsBulkPost")]
        public virtual IActionResult notificationsBulkPost([FromBody] Notification[] body)
        {
            return this._service.notificationsBulkPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/notifications")]
        [SwaggerOperation("notificationsGet")]
        [SwaggerResponse(200, type: typeof(List<Notification>))]
        public virtual IActionResult notificationsGet()
        { 
            return this._service.notificationsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpDelete]
        [Route("/api/notifications/{id}")]
        [SwaggerOperation("notificationsIdDelete")]
        public virtual IActionResult notificationsIdDelete([FromRoute]int id)
        {
            return this._service.notificationsIdDeleteAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpGet]
        [Route("/api/notifications/{id}")]
        [SwaggerOperation("notificationsIdGet")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult notificationsIdGet([FromRoute]int id)
        { 
            return this._service.notificationsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpPut]
        [Route("/api/notifications/{id}")]
        [SwaggerOperation("notificationsIdPut")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult notificationsIdPut([FromRoute]int id, [FromBody] Notification body)
        { 
            return this._service.notificationsIdPutAsync(id, body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Notification created</response>
        [HttpPost]
        [Route("/api/notifications")]
        [SwaggerOperation("notificationsPost")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult notificationsPost([FromBody]Notification body)
        { 
            return this._service.notificationsPostAsync(body);
        }
    }
}
