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
    public partial class SchoolBusOwnerNoteController : Controller
    {
        private readonly ISchoolBusOwnerNoteService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusOwnerNoteController(ISchoolBusOwnerNoteService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerNote created</response>
        [HttpPost]
        [Route("/api/schoolbusownernotes/bulk")]
        [SwaggerOperation("SchoolbusownernotesBulkPost")]
        public virtual IActionResult SchoolbusownernotesBulkPost([FromBody]SchoolBusOwnerNote[] items)
        {
            return this._service.SchoolbusownernotesBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownernotes")]
        [SwaggerOperation("SchoolbusownernotesGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerNote>))]
        public virtual IActionResult SchoolbusownernotesGet()
        {
            return this._service.SchoolbusownernotesGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerNote to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        [HttpPost]
        [Route("/api/schoolbusownernotes/{id}/delete")]
        [SwaggerOperation("SchoolbusownernotesIdDeletePost")]
        public virtual IActionResult SchoolbusownernotesIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusownernotesIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        [HttpGet]
        [Route("/api/schoolbusownernotes/{id}")]
        [SwaggerOperation("SchoolbusownernotesIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerNote))]
        public virtual IActionResult SchoolbusownernotesIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusownernotesIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        [HttpPut]
        [Route("/api/schoolbusownernotes/{id}")]
        [SwaggerOperation("SchoolbusownernotesIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerNote))]
        public virtual IActionResult SchoolbusownernotesIdPut([FromRoute]int id, [FromBody]SchoolBusOwnerNote item)
        {
            return this._service.SchoolbusownernotesIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwnerNote created</response>
        [HttpPost]
        [Route("/api/schoolbusownernotes")]
        [SwaggerOperation("SchoolbusownernotesPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerNote))]
        public virtual IActionResult SchoolbusownernotesPost([FromBody]SchoolBusOwnerNote item)
        {
            return this._service.SchoolbusownernotesPostAsync(item);
        }
    }
}
