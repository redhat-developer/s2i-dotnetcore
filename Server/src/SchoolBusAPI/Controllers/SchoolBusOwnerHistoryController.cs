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
    public partial class SchoolBusOwnerHistoryController : Controller
    {
        private readonly ISchoolBusOwnerHistoryService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusOwnerHistoryController(ISchoolBusOwnerHistoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerHistory created</response>
        [HttpPost]
        [Route("/api/schoolbusownerhistory/bulk")]
        [SwaggerOperation("SchoolbusownerhistoryBulkPost")]
        public virtual IActionResult SchoolbusownerhistoryBulkPost([FromBody]SchoolBusOwnerHistory[] items)
        {
            return this._service.SchoolbusownerhistoryBulkPostAsync(items);
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
        [HttpPost]
        [Route("/api/schoolbusownerhistory/{id}/delete")]
        [SwaggerOperation("SchoolbusownerhistoryIdDeletePost")]
        public virtual IActionResult SchoolbusownerhistoryIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusownerhistoryIdDeletePostAsync(id);
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
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerHistory))]
        public virtual IActionResult SchoolbusownerhistoryIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusownerhistoryIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>
        [HttpPut]
        [Route("/api/schoolbusownerhistory/{id}")]
        [SwaggerOperation("SchoolbusownerhistoryIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerHistory))]
        public virtual IActionResult SchoolbusownerhistoryIdPut([FromRoute]int id, [FromBody]SchoolBusOwnerHistory item)
        {
            return this._service.SchoolbusownerhistoryIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwnerHistory created</response>
        [HttpPost]
        [Route("/api/schoolbusownerhistory")]
        [SwaggerOperation("SchoolbusownerhistoryPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerHistory))]
        public virtual IActionResult SchoolbusownerhistoryPost([FromBody]SchoolBusOwnerHistory item)
        {
            return this._service.SchoolbusownerhistoryPostAsync(item);
        }
    }
}
