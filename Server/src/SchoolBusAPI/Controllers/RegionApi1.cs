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
    public class RegionApiController1 : Controller
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
        /// <remarks>Returns a list of regions for a given province</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/region")]
        [SwaggerOperation("RegionGet")]
        [SwaggerResponse(200, type: typeof(List<Region>))]
        public virtual IActionResult RegionGet()
        {
            var results = _context.Regions.ToList();
            return new ObjectResult(results);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific region</remarks>
        /// <param name="id">id of Regions to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/region/{id}")]
        [SwaggerOperation("RegionIdGet")]
        [SwaggerResponse(200, type: typeof(Region))]
        public virtual IActionResult RegionIdGet([FromRoute]int id)
        {
            // get a specific region.
            var result = _context.Regions.First(a => a.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of LocalAreas for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/region/{id}/localareas")]
        [SwaggerOperation("RegionIdLocalareasGet")]
        [SwaggerResponse(200, type: typeof(List<LocalArea>))]
        public virtual IActionResult RegionIdLocalareasGet([FromRoute]int id)
        {
            var result = _context.LocalAreas.All(a => a.Region.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of regions.</remarks>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/region")]
        [SwaggerOperation("RegionPost")]
        [SwaggerResponse(200, type: typeof(List<Region>))]
        public virtual IActionResult RegionPost([FromBody] Region[] items)
        {
            // return this._regionService.RegionsCreate(item);

            if (items == null)
            {
                return BadRequest();
            }
            foreach (Region item in items)
            {               
                _context.Regions.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
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
            var result = _context.Citys.All(a => a.Region.Id == id);
            return new ObjectResult(result);
        }
    }
}
