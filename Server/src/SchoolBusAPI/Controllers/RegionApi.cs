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
        [Route("/api/regions")]
        [SwaggerOperation("RegionsGet")]
        [SwaggerResponse(200, type: typeof(Region))]
        public virtual IActionResult RegionsGet()
        {
            var results = _context.Regions.ToList();            
            return new ObjectResult(results);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create regions</remarks>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/regions")]
        [SwaggerOperation("RegionsCreate")]
        [SwaggerResponse(200, type: typeof(Region))]
        public virtual IActionResult RegionsCreate([FromBody] Region item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.Regions.Add(item);
            return CreatedAtRoute("GetRegions", new {id = item.Id}, item);            
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
            // get a specific region.
            var result = _context.Regions.First(a => a.Id == regionId);            
            return new ObjectResult(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create regions</remarks>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/regions/{region-id}")]
        [SwaggerOperation("RegionsUpdate")]
        [SwaggerResponse(200, type: typeof(Region))]
        public virtual IActionResult RegionsUpdate(int region_id, [FromBody] Region item)
        {
            if (item == null || item.Id != region_id)
            {
                return BadRequest();
            }

            var region = _context.Regions.Find(region_id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regions.Update(item);
            return new NoContentResult();            
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
            // get a specific region.
            var result = _context.LocalAreas.All(a => a.Region.Id == regionId);
            return new ObjectResult(result);            
        }
    }
}
