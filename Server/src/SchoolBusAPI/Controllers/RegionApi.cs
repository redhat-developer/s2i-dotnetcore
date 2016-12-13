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
    public class RegionApiController : Controller
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a controller and set the database context
        /// </summary>

        public RegionApiController(DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific region</remarks>
        /// <param name="regionId">Id of Regions to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{region-id}")]
        [SwaggerOperation("RegionsRegionIdGet")]
        [SwaggerResponse(200, type: typeof(Region))]
        public virtual IActionResult RegionsRegionIdGet([FromRoute]int regionId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Region>(exampleJson)
            : default(Region);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of LocalAreas for a given region</remarks>
        /// <param name="regionId">Id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{region-id}/localareas")]
        [SwaggerOperation("RegionsRegionIdLocalareasGet")]
        [SwaggerResponse(200, type: typeof(List<LocalArea>))]
        public virtual IActionResult RegionsRegionIdLocalareasGet([FromRoute]int regionId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<LocalArea>>(exampleJson)
            : default(List<LocalArea>);
            return new ObjectResult(example);
        }
    }
}
