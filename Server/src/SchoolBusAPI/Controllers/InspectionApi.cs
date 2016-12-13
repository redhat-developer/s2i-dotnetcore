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
    public class InspectionApiController : Controller
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a controller and set the database context
        /// </summary>

        public InspectionApiController(DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        [HttpGet]
        [Route("/api/inspections")]
        [SwaggerOperation("InspectionsGet")]
        [SwaggerResponse(200, type: typeof(List<Inspection>))]
        public virtual IActionResult InspectionsGet()
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Inspection>>(exampleJson)
            : default(List<Inspection>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="schoolbusId">Id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{schoolbus-id}/inspections")]
        [SwaggerOperation("InspectionsGet_0")]
        [SwaggerResponse(200, type: typeof(List<Inspection>))]
        public virtual IActionResult InspectionsGet_0([FromRoute]int schoolbusId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Inspection>>(exampleJson)
            : default(List<Inspection>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="inspectionId">Id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        [HttpGet]
        [Route("/api/inspections/{inspection-id}")]
        [SwaggerOperation("InspectionsInspectionIdGet")]
        [SwaggerResponse(200, type: typeof(Inspection))]
        public virtual IActionResult InspectionsInspectionIdGet([FromRoute]int inspectionId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Inspection>(exampleJson)
            : default(Inspection);
            return new ObjectResult(example);
        }
    }
}
