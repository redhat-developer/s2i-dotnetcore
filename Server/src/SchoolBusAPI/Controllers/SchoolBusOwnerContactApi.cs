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
    public partial class SchoolBusOwnerContactApiController : Controller
    {
        private readonly ISchoolBusOwnerContactApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public SchoolBusOwnerContactApiController(ISchoolBusOwnerContactApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerContacts created</response>
        [HttpPost]
        [Route("/api/schoolbusownercontacts/bulk")]
        [SwaggerOperation("SchoolbusownercontactsBulkPost")]
        public virtual IActionResult SchoolbusownercontactsBulkPost([FromBody]SchoolBusOwnerContact[] body)
        {
            return this._service.SchoolbusownercontactsBulkPostAsync(body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerContact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpDelete]
        [Route("/api/schoolbusownercontacts/{id}")]
        [SwaggerOperation("SchoolbusownercontactsIdDelete")]
        public virtual IActionResult SchoolbusownercontactsIdDelete([FromRoute]int id)
        {
            return this._service.SchoolbusownercontactsIdDeleteAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpGet]
        [Route("/api/schoolbusownercontacts/{id}")]
        [SwaggerOperation("SchoolbusownercontactsIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerContact))]
        public virtual IActionResult SchoolbusownercontactsIdGet([FromRoute]int id)
        { 
            return this._service.SchoolbusownercontactsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpPut]
        [Route("/api/schoolbusownercontacts/{id}")]
        [SwaggerOperation("SchoolbusownercontactsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerContact))]
        public virtual IActionResult SchoolbusownercontactsIdPut([FromRoute]int id, [FromBody] SchoolBusOwnerContact body)
        { 
            return this._service.SchoolbusownercontactsIdPutAsync(id, body);
        }

        /// <param name="id">id of SchoolBusOwnerContact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpPost]
        [Route("/api/schoolbusownercontacts")]
        [SwaggerOperation("SchoolbusownercontactsPost")]
        public virtual IActionResult SchoolbusownercontactsPost([FromBody] SchoolBusOwnerContact body)
        {
            return this._service.SchoolbusownercontactsPostAsync(body);
        }
    }
}
