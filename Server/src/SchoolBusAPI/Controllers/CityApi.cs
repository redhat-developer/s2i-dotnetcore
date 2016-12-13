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
    public class CityApiController : Controller
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a controller and set the database context
        /// </summary>

        public CityApiController(DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of cities for a given region</remarks>
        /// <param name="regionId">Id of Region to fetch Cities for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{region-id}/cities")]
        [SwaggerOperation("RegionsRegionIdCitiesGet")]
        [SwaggerResponse(200, type: typeof(List<City>))]
        public virtual IActionResult RegionsRegionIdCitiesGet([FromRoute]int regionId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<City>>(exampleJson)
            : default(List<City>);
            return new ObjectResult(example);
        }
    }
}
