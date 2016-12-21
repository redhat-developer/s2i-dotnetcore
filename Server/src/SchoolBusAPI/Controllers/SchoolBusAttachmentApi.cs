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
    public partial class SchoolBusAttachmentApiController : Controller
    {
        private readonly ISchoolBusAttachmentApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public SchoolBusAttachmentApiController(ISchoolBusAttachmentApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusAttachments created</response>
        [HttpPost]
        [Route("/api/schoolbusattachments/bulk")]
        [SwaggerOperation("SchoolbusattachmentsBulkPost")]
        public virtual IActionResult SchoolbusattachmentsBulkPost([FromBody] SchoolBusAttachment[] body)
        {
            return this._service.SchoolbusattachmentsBulkPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusattachments")]
        [SwaggerOperation("SchoolbusattachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusAttachment>))]
        public virtual IActionResult SchoolbusattachmentsGet()
        { 
            return this._service.SchoolbusattachmentsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        [HttpDelete]
        [Route("/api/schoolbusattachments/{id}")]
        [SwaggerOperation("SchoolbusattachmentsIdDelete")]
        public virtual void SchoolbusattachmentsIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        [HttpGet]
        [Route("/api/schoolbusattachments/{id}")]
        [SwaggerOperation("SchoolbusattachmentsIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusAttachment))]
        public virtual IActionResult SchoolbusattachmentsIdGet([FromRoute]int id)
        { 
            return this._service.SchoolbusattachmentsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        [HttpPut]
        [Route("/api/schoolbusattachments/{id}")]
        [SwaggerOperation("SchoolbusattachmentsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusAttachment))]
        public virtual IActionResult SchoolbusattachmentsIdPut([FromRoute]int id)
        { 
            return this._service.SchoolbusattachmentsIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusAttachment created</response>
        [HttpPost]
        [Route("/api/schoolbusattachments")]
        [SwaggerOperation("SchoolbusattachmentsPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusAttachment))]
        public virtual IActionResult SchoolbusattachmentsPost([FromBody]SchoolBusAttachment body)
        { 
            return this._service.SchoolbusattachmentsPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>
        [HttpGet]
        [Route("/api/schoolbushistories/{id}")]
        [SwaggerOperation("SchoolbushistoriesIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusAttachment))]
        public virtual IActionResult SchoolbushistoriesIdGet([FromRoute]int id)
        { 
            return this._service.SchoolbushistoriesIdGetAsync(id);
        }
    }
}
