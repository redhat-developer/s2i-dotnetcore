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
    public partial class InspectionApiController : Controller
    {
        private readonly IInspectionApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public InspectionApiController(IInspectionApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Inspections created</response>
        [HttpPost]
        [Route("/api/inspections/bulk")]
        [SwaggerOperation("InspectionsBulkPost")]
        public virtual IActionResult InspectionsBulkPost([FromBody] Inspection[] body)
        {
            return this._service.InspectionsBulkPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/inspections")]
        [SwaggerOperation("InspectionsGet")]
        [SwaggerResponse(200, type: typeof(List<Inspection>))]
        public virtual IActionResult InspectionsGet()
        { 
            return this._service.InspectionsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Inspection to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        [HttpDelete]
        [Route("/api/inspections/{id}")]
        [SwaggerOperation("InspectionsIdDelete")]
        public virtual IActionResult InspectionsIdDelete([FromRoute]int id)
        {
            return this._service.InspectionsIdDeleteAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        [HttpGet]
        [Route("/api/inspections/{id}")]
        [SwaggerOperation("InspectionsIdGet")]
        [SwaggerResponse(200, type: typeof(Inspection))]
        public virtual IActionResult InspectionsIdGet([FromRoute]int id)
        { 
            return this._service.InspectionsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        [HttpPut]
        [Route("/api/inspections/{id}")]
        [SwaggerOperation("InspectionsIdPut")]
        [SwaggerResponse(200, type: typeof(Inspection))]
        public virtual IActionResult InspectionsIdPut([FromRoute]int id)
        { 
            return this._service.InspectionsIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Inspection created</response>
        [HttpPost]
        [Route("/api/inspections")]
        [SwaggerOperation("InspectionsPost")]
        [SwaggerResponse(200, type: typeof(Inspection))]
        public virtual IActionResult InspectionsPost([FromBody]Inspection body)
        { 
            return this._service.InspectionsPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
                
    }
}
