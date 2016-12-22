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
    public partial class NotificationEventApiController : Controller
    {
        private readonly INotificationEventApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public NotificationEventApiController(INotificationEventApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">NotificationEvents created</response>
        [HttpPost]
        [Route("/api/notificationevents/bulk")]
        [SwaggerOperation("notificationeventsBulkPost")]
        public virtual IActionResult notificationeventsBulkPost([FromBody] NotificationEvent[] body)
        {
            return this._service.notificationeventsBulkPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/notificationevents")]
        [SwaggerOperation("notificationeventsGet")]
        [SwaggerResponse(200, type: typeof(List<NotificationEvent>))]
        public virtual IActionResult notificationeventsGet()
        { 
            return this._service.notificationeventsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpDelete]
        [Route("/api/notificationevents/{id}")]
        [SwaggerOperation("notificationeventsIdDelete")]
        public virtual IActionResult notificationeventsIdDelete([FromRoute]int id)
        {
            return this._service.notificationeventsIdDeleteAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpGet]
        [Route("/api/notificationevents/{id}")]
        [SwaggerOperation("notificationeventsIdGet")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult notificationeventsIdGet([FromRoute]int id)
        { 
            return this._service.notificationeventsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpPut]
        [Route("/api/notificationevents/{id}")]
        [SwaggerOperation("notificationeventsIdPut")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult notificationeventsIdPut([FromRoute]int id, [FromBody] NotificationEvent body)
        { 
            return this._service.notificationeventsIdPutAsync(id, body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">NotificationEvent created</response>
        [HttpPost]
        [Route("/api/notificationevents")]
        [SwaggerOperation("notificationeventsPost")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult notificationeventsPost([FromBody]NotificationEvent body)
        { 
            return this._service.notificationeventsPostAsync(body);
        }
    }
}
