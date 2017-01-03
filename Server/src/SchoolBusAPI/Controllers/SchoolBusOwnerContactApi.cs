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
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerContacts created</response>
        [HttpPost]
        [Route("/api/schoolbusownercontacts/bulk")]
        [SwaggerOperation("SchoolbusownercontactsBulkPost")]
        public virtual IActionResult SchoolbusownercontactsBulkPost([FromBody]SchoolBusOwnerContact[] items)
        {
            return this._service.SchoolbusownercontactsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownercontacts")]
        [SwaggerOperation("SchoolbusownercontactsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerContact>))]
        public virtual IActionResult SchoolbusownercontactsGet()
        {
            return this._service.SchoolbusownercontactsGetAsync();
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
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpPut]
        [Route("/api/schoolbusownercontacts/{id}")]
        [SwaggerOperation("SchoolbusownercontactsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerContact))]
        public virtual IActionResult SchoolbusownercontactsIdPut([FromRoute]int id, [FromBody]SchoolBusOwnerContact item)
        {
            return this._service.SchoolbusownercontactsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwnerContact created</response>
        [HttpPost]
        [Route("/api/schoolbusownercontacts")]
        [SwaggerOperation("SchoolbusownercontactsPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerContact))]
        public virtual IActionResult SchoolbusownercontactsPost([FromBody]SchoolBusOwnerContact item)
        {
            return this._service.SchoolbusownercontactsPostAsync(item);
        }
    }
}
