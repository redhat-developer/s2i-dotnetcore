/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
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
    public partial class ServiceAreaApiController : Controller
    {
        private readonly IServiceAreaApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public ServiceAreaApiController(IServiceAreaApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available districts</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/serviceareas")]
        [SwaggerOperation("ServiceareasGet")]
        [SwaggerResponse(200, type: typeof(List<ServiceArea>))]
        public virtual IActionResult ServiceareasGet()
        {
            return this._service.ServiceareasGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a Service Area</remarks>
        /// <param name="id">id of Service Area to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Service Area not found</response>
        [HttpPost]
        [Route("/api/serviceareas/{id}/delete")]
        [SwaggerOperation("ServiceareasIdDeletePost")]
        public virtual IActionResult ServiceareasIdDeletePost([FromRoute]int id)
        {
            return this._service.ServiceareasIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific Service Area</remarks>
        /// <param name="id">id of Service Area to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/serviceareas/{id}")]
        [SwaggerOperation("ServiceareasIdGet")]
        [SwaggerResponse(200, type: typeof(ServiceArea))]
        public virtual IActionResult ServiceareasIdGet([FromRoute]int id)
        {
            return this._service.ServiceareasIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a Service Area</remarks>
        /// <param name="id">id of Service Area to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Service Area not found</response>
        [HttpPut]
        [Route("/api/serviceareas/{id}")]
        [SwaggerOperation("ServiceareasIdPut")]
        public virtual IActionResult ServiceareasIdPut([FromRoute]int id, [FromBody]ServiceArea item)
        {
            return this._service.ServiceareasIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a Service Area</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/serviceareas")]
        [SwaggerOperation("ServiceareasPost")]
        [SwaggerResponse(200, type: typeof(List<ServiceArea>))]
        public virtual IActionResult ServiceareasPost([FromBody]ServiceArea item)
        {
            return this._service.ServiceareasPostAsync(item);
        }
    }
}
