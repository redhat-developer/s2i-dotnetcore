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
    public partial class SchoolBusOwnerAttachmentApiController : Controller
    {
        private readonly ISchoolBusOwnerAttachmentApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public SchoolBusOwnerAttachmentApiController(ISchoolBusOwnerAttachmentApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerAttachments created</response>
        [HttpPost]
        [Route("/api/schoolbusownerattachments/bulk")]
        [SwaggerOperation("SchoolbusownerattachmentsBulkPost")]
        public virtual void SchoolbusownerattachmentsBulkPost([FromBody]List<SchoolBusOwnerAttachment> body)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownerattachments")]
        [SwaggerOperation("SchoolbusownerattachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerAttachment>))]
        public virtual IActionResult SchoolbusownerattachmentsGet()
        { 
            return this._service.SchoolbusownerattachmentsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        [HttpDelete]
        [Route("/api/schoolbusownerattachments/{id}")]
        [SwaggerOperation("SchoolbusownerattachmentsIdDelete")]
        public virtual void SchoolbusownerattachmentsIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        [HttpGet]
        [Route("/api/schoolbusownerattachments/{id}")]
        [SwaggerOperation("SchoolbusownerattachmentsIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerAttachment))]
        public virtual IActionResult SchoolbusownerattachmentsIdGet([FromRoute]int id)
        { 
            return this._service.SchoolbusownerattachmentsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        [HttpPut]
        [Route("/api/schoolbusownerattachments/{id}")]
        [SwaggerOperation("SchoolbusownerattachmentsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerAttachment))]
        public virtual IActionResult SchoolbusownerattachmentsIdPut([FromRoute]int id)
        { 
            return this._service.SchoolbusownerattachmentsIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerAttachment created</response>
        [HttpPost]
        [Route("/api/schoolbusownerattachments")]
        [SwaggerOperation("SchoolbusownerattachmentsPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerAttachment))]
        public virtual IActionResult SchoolbusownerattachmentsPost([FromBody]SchoolBusOwnerAttachment body)
        { 
            return this._service.SchoolbusownerattachmentsPostAsync(body);
        }
    }
}
