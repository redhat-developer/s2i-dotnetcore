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
    public partial class SchoolDistrictApiController : Controller
    {
        private readonly ISchoolDistrictApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolDistrictApiController(ISchoolDistrictApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of school districts.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/schooldistricts/bulk")]
        [SwaggerOperation("SchooldistrictsBulkPost")]
        public virtual IActionResult SchooldistrictsBulkPost([FromBody]SchoolDistrict[] items)
        {
            return this._service.SchooldistrictsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available schooldistricts</remarks>
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
        /// <remarks>Deletes a School District</remarks>
        /// <param name="id">id of School District to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
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
        /// <remarks>Returns a specific school district</remarks>
        /// <param name="id">id of School Districts to fetch</param>
        /// <response code="200">OK</response>
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
        /// <remarks>Updates a school district</remarks>
        /// <param name="id">id of School District to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
        [HttpPut]
        [Route("/api/schooldistricts/{id}")]
        [SwaggerOperation("SchooldistrictsIdPut")]
        public virtual IActionResult SchooldistrictsIdPut([FromRoute]int id, [FromBody]SchoolDistrict item)
        {
            return this._service.SchooldistrictsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a school district</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/schooldistricts")]
        [SwaggerOperation("SchooldistrictsPost")]
        [SwaggerResponse(200, type: typeof(List<SchoolDistrict>))]
        public virtual IActionResult SchooldistrictsPost([FromBody]SchoolDistrict item)
        {
            return this._service.SchooldistrictsPostAsync(item);
        }
    }
}
