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
    public partial class CCWDataController : Controller
    {
        private readonly ICCWDataService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public CCWDataController(ICCWDataService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">CCWData created</response>
        [HttpPost]
        [Route("/api/ccwdata/bulk")]
        [SwaggerOperation("CcwdataBulkPost")]
        public virtual IActionResult CcwdataBulkPost([FromBody]CCWData[] items)
        {
            return this._service.CcwdataBulkPostAsync(items);
        }

        /// <summary>
        /// fetches data from the ICBC CCW system, and constructs a CCWData object from that.  Note that it does not perform the insert of that data into the database, only provides JSON data suitable for insertion. If a CCWData record exists in the schoolbus database then the id field will match that record, however all other data will be from the ICBC CCW system.
        /// </summary>
        /// <param name="regi">Registration Number (also known as Serial)</param>
        /// <param name="vin">Vehicle Identification Number</param>
        /// <param name="plate">License Plate String</param>
        /// <response code="200">OK</response>
        /// <response code="404">Vehicle not found in CCW system</response>
        [HttpGet]
        [Route("/api/ccwdata/fetch")]
        [SwaggerOperation("CcwdataFetchGet")]
        [SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult CcwdataFetchGet([FromQuery]string regi, [FromQuery]string vin, [FromQuery]string plate)
        {
            return this._service.CcwdataFetchGetAsync(regi, vin, plate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/ccwdata")]
        [SwaggerOperation("CcwdataGet")]
        [SwaggerResponse(200, type: typeof(List<CCWData>))]
        public virtual IActionResult CcwdataGet()
        {
            return this._service.CcwdataGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        [HttpPost]
        [Route("/api/ccwdata/{id}/delete")]
        [SwaggerOperation("CcwdataIdDeletePost")]
        public virtual IActionResult CcwdataIdDeletePost([FromRoute]int id)
        {
            return this._service.CcwdataIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        [HttpGet]
        [Route("/api/ccwdata/{id}")]
        [SwaggerOperation("CcwdataIdGet")]
        [SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult CcwdataIdGet([FromRoute]int id)
        {
            return this._service.CcwdataIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        [HttpPut]
        [Route("/api/ccwdata/{id}")]
        [SwaggerOperation("CcwdataIdPut")]
        [SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult CcwdataIdPut([FromRoute]int id, [FromBody]CCWData item)
        {
            return this._service.CcwdataIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">CCWData created</response>
        [HttpPost]
        [Route("/api/ccwdata")]
        [SwaggerOperation("CcwdataPost")]
        [SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult CcwdataPost([FromBody]CCWData item)
        {
            return this._service.CcwdataPostAsync(item);
        }
    }
}
