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
    public partial class SchoolBusOwnerHistoryApiController : Controller
    {
        private readonly ISchoolBusOwnerHistoryApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public SchoolBusOwnerHistoryApiController(ISchoolBusOwnerHistoryApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerHistories created</response>
        [HttpPost]
        [Route("/api/schoolbusownerhistory/bulk")]
        [SwaggerOperation("SchoolbusownerhistoryBulkPost")]
        public virtual void SchoolbusownerhistoryBulkPost([FromBody]List<SchoolBusOwnerHistory> body)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownerhistory")]
        [SwaggerOperation("SchoolbusownerhistoryGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerHistory>))]
        public virtual IActionResult SchoolbusownerhistoryGet()
        { 
            return this._service.SchoolbusownerhistoryGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>
        [HttpDelete]
        [Route("/api/schoolbusownerhistory/{id}")]
        [SwaggerOperation("SchoolbusownerhistoryIdDelete")]
        public virtual void SchoolbusownerhistoryIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>
        [HttpGet]
        [Route("/api/schoolbusownerhistory/{id}")]
        [SwaggerOperation("SchoolbusownerhistoryIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerAttachment))]
        public virtual IActionResult SchoolbusownerhistoryIdGet([FromRoute]int id)
        { 
            return this._service.SchoolbusownerhistoryIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>
        [HttpPut]
        [Route("/api/schoolbusownerhistory/{id}")]
        [SwaggerOperation("SchoolbusownerhistoryIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerHistory))]
        public virtual IActionResult SchoolbusownerhistoryIdPut([FromRoute]int id)
        { 
            return this._service.SchoolbusownerhistoryIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerHistory created</response>
        [HttpPost]
        [Route("/api/schoolbusownerhistory")]
        [SwaggerOperation("SchoolbusownerhistoryPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerHistory))]
        public virtual IActionResult SchoolbusownerhistoryPost([FromBody]SchoolBusOwnerHistory body)
        { 
            return this._service.SchoolbusownerhistoryPostAsync(body);
        }
    }
}
