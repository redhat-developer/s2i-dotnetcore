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
    public partial class SchoolBusApiController : Controller
    {
        private readonly ISchoolBusApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public SchoolBusApiController(ISchoolBusApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// Creates a new school bus
        /// </summary>
        /// <remarks>The Location response-header field is used to redirect the recipient to a location other than the Request-URI for completion of the request or identification of a new resource. For 201 (Created) responses, the Location is that of the new resource which was created by the request.    The field value consists of a single absolute URI. </remarks>
        /// <param name="body"></param>
        /// <response code="201">SchoolBus created</response>
        [HttpPost]
        [Route("/api/schoolbuses")]
        [SwaggerOperation("AddBus")]
        [SwaggerResponse(200, type: typeof(SchoolBus))]
        public virtual IActionResult AddBus([FromBody]SchoolBus body)
        { 
            return this._service.AddBusAsync(body);
        }
        /// <summary>
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}")]
        [SwaggerOperation("FindBusById")]
        [SwaggerResponse(200, type: typeof(SchoolBus))]
        public virtual IActionResult FindBusById([FromRoute]int id)
        { 
            return this._service.FindBusByIdAsync(id);
        }
        /// <summary>
        /// Returns a collection of school buses
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses")]
        [SwaggerOperation("GetAllBuses")]
        [SwaggerResponse(200, type: typeof(List<SchoolBus>))]
        public virtual IActionResult GetAllBuses()
        { 
            return this._service.GetAllBusesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/attachments")]
        [SwaggerOperation("SchoolbusesIdAttachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusAttachment>))]
        public virtual IActionResult SchoolbusesIdAttachmentsGet([FromRoute]int id)
        { 
            return this._service.SchoolbusesIdAttachmentsGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/ccwdata")]
        [SwaggerOperation("SchoolbusesIdCcwdataGet")]
        [SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult SchoolbusesIdCcwdataGet([FromRoute]int id)
        { 
            return this._service.SchoolbusesIdCcwdataGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch SchoolBusHistory for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/history")]
        [SwaggerOperation("SchoolbusesIdHistoryGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusHistory>))]
        public virtual IActionResult SchoolbusesIdHistoryGet([FromRoute]int id)
        { 
            return this._service.SchoolbusesIdHistoryGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/notes")]
        [SwaggerOperation("SchoolbusesIdNotesGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusNote>))]
        public virtual IActionResult SchoolbusesIdNotesGet([FromRoute]int id)
        { 
            return this._service.SchoolbusesIdNotesGetAsync(id);
        }
    }
}
