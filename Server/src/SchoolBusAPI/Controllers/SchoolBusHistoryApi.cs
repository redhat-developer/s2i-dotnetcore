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
    public partial class SchoolBusHistoryApiController : Controller
    {
        private readonly ISchoolBusHistoryApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusHistoryApiController(ISchoolBusHistoryApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusHistories created</response>
        [HttpPost]
        [Route("/api/schoolbushistories/bulk")]
        [SwaggerOperation("SchoolbushistoriesBulkPost")]
        public virtual IActionResult SchoolbushistoriesBulkPost([FromBody]SchoolBusHistory[] items)
        {
            return this._service.SchoolbushistoriesBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbushistories")]
        [SwaggerOperation("SchoolbushistoriesGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusHistory>))]
        public virtual IActionResult SchoolbushistoriesGet()
        {
            return this._service.SchoolbushistoriesGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusHistory to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>
        [HttpPost]
        [Route("/api/schoolbushistories/{id}/delete")]
        [SwaggerOperation("SchoolbushistoriesIdDeletePost")]
        public virtual IActionResult SchoolbushistoriesIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbushistoriesIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>
        [HttpGet]
        [Route("/api/schoolbushistories/{id}")]
        [SwaggerOperation("SchoolbushistoriesIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusHistory))]
        public virtual IActionResult SchoolbushistoriesIdGet([FromRoute]int id)
        {
            return this._service.SchoolbushistoriesIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>
        [HttpPut]
        [Route("/api/schoolbushistories/{id}")]
        [SwaggerOperation("SchoolbushistoriesIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusHistory))]
        public virtual IActionResult SchoolbushistoriesIdPut([FromRoute]int id, [FromBody]SchoolBusHistory item)
        {
            return this._service.SchoolbushistoriesIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusHistory created</response>
        [HttpPost]
        [Route("/api/schoolbushistories")]
        [SwaggerOperation("SchoolbushistoriesPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusHistory))]
        public virtual IActionResult SchoolbushistoriesPost([FromBody]SchoolBusHistory item)
        {
            return this._service.SchoolbushistoriesPostAsync(item);
        }
    }
}
