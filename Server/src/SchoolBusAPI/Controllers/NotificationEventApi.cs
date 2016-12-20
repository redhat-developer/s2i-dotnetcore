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
        [Route("/api/notficationevents/bulk")]
        [SwaggerOperation("NotficationeventsBulkPost")]
        public virtual IActionResult NotficationeventsBulkPost([FromBody] NotificationEvent[] body)
        {
            return this._service.NotficationeventsBulkPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/notficationevents")]
        [SwaggerOperation("NotficationeventsGet")]
        [SwaggerResponse(200, type: typeof(List<NotificationEvent>))]
        public virtual IActionResult NotficationeventsGet()
        { 
            return this._service.NotficationeventsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpDelete]
        [Route("/api/notficationevents/{id}")]
        [SwaggerOperation("NotficationeventsIdDelete")]
        public virtual void NotficationeventsIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpGet]
        [Route("/api/notficationevents/{id}")]
        [SwaggerOperation("NotficationeventsIdGet")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult NotficationeventsIdGet([FromRoute]int id)
        { 
            return this._service.NotficationeventsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpPut]
        [Route("/api/notficationevents/{id}")]
        [SwaggerOperation("NotficationeventsIdPut")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult NotficationeventsIdPut([FromRoute]int id)
        { 
            return this._service.NotficationeventsIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">NotificationEvent created</response>
        [HttpPost]
        [Route("/api/notficationevents")]
        [SwaggerOperation("NotficationeventsPost")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult NotficationeventsPost([FromBody]NotificationEvent body)
        { 
            return this._service.NotficationeventsPostAsync(body);
        }
    }
}
