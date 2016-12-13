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

namespace SchoolBusAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusApiController : Controller
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a controller and set the database context
        /// </summary>

        public SchoolBusApiController(DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbus/{id}/attachments")]
        [SwaggerOperation("SchoolbusIdAttachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusAttachment>))]
        public virtual IActionResult SchoolbusIdAttachmentsGet([FromRoute]int id)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<SchoolBusAttachment>>(exampleJson)
            : default(List<SchoolBusAttachment>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbus/{id}/ccwdata")]
        [SwaggerOperation("SchoolbusIdCcwdataGet")]
        [SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult SchoolbusIdCcwdataGet([FromRoute]int id)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<CCWData>(exampleJson)
            : default(CCWData);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific SchoolBus object</remarks>
        /// <param name="id">id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbus/{id}")]
        [SwaggerOperation("SchoolbusIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBus))]
        public virtual IActionResult SchoolbusIdGet([FromRoute]int id)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SchoolBus>(exampleJson)
            : default(SchoolBus);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch SchoolBusHistory for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbus/{id}/history")]
        [SwaggerOperation("SchoolbusIdHistoryGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusHistory>))]
        public virtual IActionResult SchoolbusIdHistoryGet([FromRoute]int id)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<SchoolBusHistory>>(exampleJson)
            : default(List<SchoolBusHistory>);
            return new ObjectResult(example);
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
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<SchoolBusNote>>(exampleJson)
            : default(List<SchoolBusNote>);
            return new ObjectResult(example);
        }
    }
}
