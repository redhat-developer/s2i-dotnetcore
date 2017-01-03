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
using SchoolBusAPI.ViewModels;
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
        /// <param name="items"></param>
        /// <response code="201">NotificationEvents created</response>
        [HttpPost]
        [Route("/api/notificationevents/bulk")]
        [SwaggerOperation("NotificationeventsBulkPost")]
        public virtual IActionResult NotificationeventsBulkPost([FromBody]NotificationEvent[] items)
        {
            return this._service.NotificationeventsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/notificationevents")]
        [SwaggerOperation("NotificationeventsGet")]
        [SwaggerResponse(200, type: typeof(List<NotificationEvent>))]
        public virtual IActionResult NotificationeventsGet()
        {
            return this._service.NotificationeventsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpDelete]
        [Route("/api/notificationevents/{id}")]
        [SwaggerOperation("NotificationeventsIdDelete")]
        public virtual IActionResult NotificationeventsIdDelete([FromRoute]int id)
        {
            return this._service.NotificationeventsIdDeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpGet]
        [Route("/api/notificationevents/{id}")]
        [SwaggerOperation("NotificationeventsIdGet")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult NotificationeventsIdGet([FromRoute]int id)
        {
            return this._service.NotificationeventsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        [HttpPut]
        [Route("/api/notificationevents/{id}")]
        [SwaggerOperation("NotificationeventsIdPut")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult NotificationeventsIdPut([FromRoute]int id, [FromBody]NotificationEvent item)
        {
            return this._service.NotificationeventsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">NotificationEvent created</response>
        [HttpPost]
        [Route("/api/notificationevents")]
        [SwaggerOperation("NotificationeventsPost")]
        [SwaggerResponse(200, type: typeof(NotificationEvent))]
        public virtual IActionResult NotificationeventsPost([FromBody]NotificationEvent item)
        {
            return this._service.NotificationeventsPostAsync(item);
        }
    }
}
