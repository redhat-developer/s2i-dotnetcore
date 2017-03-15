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
    public partial class SchoolDistrictController : Controller
    {
        private readonly ISchoolDistrictService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolDistrictController(ISchoolDistrictService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolDistrict created</response>
        [HttpPost]
        [Route("/api/schooldistricts/bulk")]
        [SwaggerOperation("SchooldistrictsBulkPost")]
        [RequiresPermission(Permission.ADMIN)]
        public virtual IActionResult SchooldistrictsBulkPost([FromBody]SchoolDistrict[] items)
        {
            return this._service.SchooldistrictsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schooldistricts")]
        [SwaggerOperation("SchooldistrictsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolDistrict>))]
        public virtual IActionResult SchooldistrictsGet()
        {
            return this._service.SchooldistrictsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolDistrict to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolDistrict not found</response>
        [HttpPost]
        [Route("/api/schooldistricts/{id}/delete")]
        [SwaggerOperation("SchooldistrictsIdDeletePost")]
        public virtual IActionResult SchooldistrictsIdDeletePost([FromRoute]int id)
        {
            return this._service.SchooldistrictsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolDistrict to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolDistrict not found</response>
        [HttpGet]
        [Route("/api/schooldistricts/{id}")]
        [SwaggerOperation("SchooldistrictsIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolDistrict))]
        public virtual IActionResult SchooldistrictsIdGet([FromRoute]int id)
        {
            return this._service.SchooldistrictsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolDistrict to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolDistrict not found</response>
        [HttpPut]
        [Route("/api/schooldistricts/{id}")]
        [SwaggerOperation("SchooldistrictsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolDistrict))]
        public virtual IActionResult SchooldistrictsIdPut([FromRoute]int id, [FromBody]SchoolDistrict item)
        {
            return this._service.SchooldistrictsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolDistrict created</response>
        [HttpPost]
        [Route("/api/schooldistricts")]
        [SwaggerOperation("SchooldistrictsPost")]
        [SwaggerResponse(200, type: typeof(SchoolDistrict))]
        public virtual IActionResult SchooldistrictsPost([FromBody]SchoolDistrict item)
        {
            return this._service.SchooldistrictsPostAsync(item);
        }
    }
}
