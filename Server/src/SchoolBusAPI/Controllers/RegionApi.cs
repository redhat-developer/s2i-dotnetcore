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
    public partial class RegionApiController : Controller
    {
        private readonly IRegionApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public RegionApiController(IRegionApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of regions for a given province</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions")]
        [SwaggerOperation("RegionsGet")]
        [SwaggerResponse(200, type: typeof(List<Region>))]
        public virtual IActionResult RegionsGet()
        { 
            return this._service.RegionsGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of cities for a given region</remarks>
        /// <param name="id">id of Region to fetch Cities for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{id}/cities")]
        [SwaggerOperation("RegionsIdCitiesGet")]
        [SwaggerResponse(200, type: typeof(List<City>))]
        public virtual IActionResult RegionsIdCitiesGet([FromRoute]int id)
        { 
            return this._service.RegionsIdCitiesGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific region</remarks>
        /// <param name="id">id of Regions to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{id}")]
        [SwaggerOperation("RegionsIdGet")]
        [SwaggerResponse(200, type: typeof(Region))]
        public virtual IActionResult RegionsIdGet([FromRoute]int id)
        { 
            return this._service.RegionsIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of LocalAreas for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{id}/localareas")]
        [SwaggerOperation("RegionsIdLocalareasGet")]
        [SwaggerResponse(200, type: typeof(List<LocalArea>))]
        public virtual IActionResult RegionsIdLocalareasGet([FromRoute]int id)
        { 
            return this._service.RegionsIdLocalareasGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of regions.</remarks>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/regions")]
        [SwaggerOperation("RegionsPost")]
        [SwaggerResponse(200, type: typeof(List<Region>))]
        public virtual IActionResult RegionsPost()
        { 
            return this._service.RegionsPostAsync();
        }
    }
}
