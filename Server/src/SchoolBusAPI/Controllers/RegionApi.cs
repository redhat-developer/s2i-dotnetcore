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
        /// <remarks>Adds a number of regions.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/regions/bulk")]
        [SwaggerOperation("RegionsBulkPost")]
        public virtual IActionResult RegionsBulkPost([FromBody]Region[] items)
        {
            return this._service.RegionsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available regions</remarks>
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
        /// <remarks>Deletes a region</remarks>
        /// <param name="id">id of Region to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        [HttpPost]
        [Route("/api/regions/{id}/delete")]
        [SwaggerOperation("RegionsIdDeletePost")]
        public virtual IActionResult RegionsIdDeletePost([FromRoute]int id)
        {
            return this._service.RegionsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the districts for a specific region</remarks>
        /// <param name="id">id of Region for which to fetch the Districts</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{id}/districts")]
        [SwaggerOperation("RegionsIdDistrictsGet")]
        [SwaggerResponse(200, type: typeof(List<District>))]
        public virtual IActionResult RegionsIdDistrictsGet([FromRoute]int id)
        {
            return this._service.RegionsIdDistrictsGetAsync(id);
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
        /// <remarks>Updates a region</remarks>
        /// <param name="id">id of Region to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        [HttpPut]
        [Route("/api/regions/{id}")]
        [SwaggerOperation("RegionsIdPut")]
        public virtual IActionResult RegionsIdPut([FromRoute]int id, [FromBody]Region item)
        {
            return this._service.RegionsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a region</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/regions")]
        [SwaggerOperation("RegionsPost")]
        [SwaggerResponse(200, type: typeof(List<Region>))]
        public virtual IActionResult RegionsPost([FromBody]Region item)
        {
            return this._service.RegionsPostAsync(item);
        }
    }
}
