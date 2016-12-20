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
        [Route("/api/notfications/bulk")]
        [SwaggerOperation("NotficationsBulkPost")]
        public virtual void NotficationsBulkPost([FromBody]List<Notification> body)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/notfications")]
        [SwaggerOperation("NotficationsGet")]
        [SwaggerResponse(200, type: typeof(List<Notification>))]
        public virtual IActionResult NotficationsGet()
        { 
            return this._service.NotficationsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpDelete]
        [Route("/api/notfications/{id}")]
        [SwaggerOperation("NotficationsIdDelete")]
        public virtual void NotficationsIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpGet]
        [Route("/api/notfications/{id}")]
        [SwaggerOperation("NotficationsIdGet")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult NotficationsIdGet([FromRoute]int id)
        { 
            return this._service.NotficationsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpPut]
        [Route("/api/notfications/{id}")]
        [SwaggerOperation("NotficationsIdPut")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult NotficationsIdPut([FromRoute]int id)
        { 
            return this._service.NotficationsIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Notification created</response>
        [HttpPost]
        [Route("/api/notfications")]
        [SwaggerOperation("NotficationsPost")]
        [SwaggerResponse(200, type: typeof(Notification))]
        public virtual IActionResult NotficationsPost([FromBody]Notification body)
        { 
            return this._service.NotficationsPostAsync(body);
        }
    }
}
