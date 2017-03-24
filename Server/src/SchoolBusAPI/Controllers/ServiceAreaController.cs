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
using SchoolBusAPI.Authorization;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ServiceAreaController : Controller
    {
        private readonly IServiceAreaService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public ServiceAreaController(IServiceAreaService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">ServiceArea created</response>
        [HttpPost]
        [Route("/api/serviceareas/bulk")]
        [SwaggerOperation("ServiceareasBulkPost")]
        [RequiresPermission(Permission.ADMIN)]
        public virtual IActionResult ServiceareasBulkPost([FromBody]ServiceArea[] items)
        {
            return this._service.ServiceareasBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// <param name="id">id of ServiceArea to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">ServiceArea not found</response>
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
        /// <param name="id">id of ServiceArea to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">ServiceArea not found</response>
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
        /// <param name="id">id of ServiceArea to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">ServiceArea not found</response>
        [HttpPut]
        [Route("/api/serviceareas/{id}")]
        [SwaggerOperation("ServiceareasIdPut")]
        [SwaggerResponse(200, type: typeof(ServiceArea))]
        public virtual IActionResult ServiceareasIdPut([FromRoute]int id, [FromBody]ServiceArea item)
        {
            return this._service.ServiceareasIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">ServiceArea created</response>
        [HttpPost]
        [Route("/api/serviceareas")]
        [SwaggerOperation("ServiceareasPost")]
        [SwaggerResponse(200, type: typeof(ServiceArea))]
        public virtual IActionResult ServiceareasPost([FromBody]ServiceArea item)
        {
            return this._service.ServiceareasPostAsync(item);
        }
    }
}
