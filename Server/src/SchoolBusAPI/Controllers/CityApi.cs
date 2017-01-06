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
    public partial class CityApiController : Controller
    {
        private readonly ICityApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public CityApiController(ICityApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of cities</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/cities/bulk")]
        [SwaggerOperation("CitiesBulkPost")]
        public virtual IActionResult CitiesBulkPost([FromBody]City[] items)
        {
            return this._service.CitiesBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of cities</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/cities")]
        [SwaggerOperation("CitiesGet")]
        [SwaggerResponse(200, type: typeof(List<City>))]
        public virtual IActionResult CitiesGet()
        {
            return this._service.CitiesGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a City</remarks>
        /// <param name="id">id of City to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">City not found</response>
        [HttpPost]
        [Route("/api/cities/{id}/delete")]
        [SwaggerOperation("CitiesIdDeletePost")]
        public virtual IActionResult CitiesIdDeletePost([FromRoute]int id)
        {
            return this._service.CitiesIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific City by ID</remarks>
        /// <param name="id">id of City to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/cities/{id}")]
        [SwaggerOperation("CitiesIdGet")]
        [SwaggerResponse(200, type: typeof(City))]
        public virtual IActionResult CitiesIdGet([FromRoute]int id)
        {
            return this._service.CitiesIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a City</remarks>
        /// <param name="id">id of City to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">City not found</response>
        [HttpPut]
        [Route("/api/cities/{id}")]
        [SwaggerOperation("CitiesIdPut")]
        public virtual IActionResult CitiesIdPut([FromRoute]int id, [FromBody]City item)
        {
            return this._service.CitiesIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a City</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/cities")]
        [SwaggerOperation("CitiesPost")]
        [SwaggerResponse(200, type: typeof(List<City>))]
        public virtual IActionResult CitiesPost([FromBody]City item)
        {
            return this._service.CitiesPostAsync(item);
        }
    }
}
