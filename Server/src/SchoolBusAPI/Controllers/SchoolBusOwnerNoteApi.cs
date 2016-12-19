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
    public partial class SchoolBusOwnerNoteApiController : Controller
    {
        private readonly ISchoolBusOwnerNoteApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public SchoolBusOwnerNoteApiController(ISchoolBusOwnerNoteApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerNotes created</response>
        [HttpPost]
        [Route("/api/schoolbusownernotes/bulk")]
        [SwaggerOperation("SchoolbusownernotesBulkPost")]
        public virtual void SchoolbusownernotesBulkPost([FromBody]List<SchoolBusOwnerNote> body)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownernotes")]
        [SwaggerOperation("SchoolbusownernotesGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerNote>))]
        public virtual IActionResult SchoolbusownernotesGet()
        { 
            return this._service.SchoolbusownernotesGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerNote to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        [HttpDelete]
        [Route("/api/schoolbusownernotes/{id}")]
        [SwaggerOperation("SchoolbusownernotesIdDelete")]
        public virtual void SchoolbusownernotesIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        [HttpGet]
        [Route("/api/schoolbusownernotes/{id}")]
        [SwaggerOperation("SchoolbusownernotesIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerNote))]
        public virtual IActionResult SchoolbusownernotesIdGet([FromRoute]int id)
        { 
            return this._service.SchoolbusownernotesIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        [HttpPut]
        [Route("/api/schoolbusownernotes/{id}")]
        [SwaggerOperation("SchoolbusownernotesIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerNote))]
        public virtual IActionResult SchoolbusownernotesIdPut([FromRoute]int id)
        { 
            return this._service.SchoolbusownernotesIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerNote created</response>
        [HttpPost]
        [Route("/api/schoolbusownernotes")]
        [SwaggerOperation("SchoolbusownernotesPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerNote))]
        public virtual IActionResult SchoolbusownernotesPost([FromBody]SchoolBusOwnerNote body)
        { 
            return this._service.SchoolbusownernotesPostAsync(body);
        }
    }
}
