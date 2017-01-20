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
    public partial class SchoolBusOwnerContactController : Controller
    {
        private readonly ISchoolBusOwnerContactService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusOwnerContactController(ISchoolBusOwnerContactService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerContact created</response>
        [HttpPost]
        [Route("/api/schoolbusownercontacts/bulk")]
        [SwaggerOperation("SchoolbusownercontactsBulkPost")]
        public virtual IActionResult SchoolbusownercontactsBulkPost([FromBody]SchoolBusOwnerContact[] items)
        {
            return this._service.SchoolbusownercontactsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownercontacts")]
        [SwaggerOperation("SchoolbusownercontactsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerContact>))]
        public virtual IActionResult SchoolbusownercontactsGet()
        {
            return this._service.SchoolbusownercontactsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownercontacts/{id}/contactaddresses")]
        [SwaggerOperation("SchoolbusownercontactsIdContactaddressesGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerContactAddress>))]
        public virtual IActionResult SchoolbusownercontactsIdContactaddressesGet([FromRoute]int id)
        {
            return this._service.SchoolbusownercontactsIdContactaddressesGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownercontacts/{id}/contactphones")]
        [SwaggerOperation("SchoolbusownercontactsIdContactphonesGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerContactPhone>))]
        public virtual IActionResult SchoolbusownercontactsIdContactphonesGet([FromRoute]int id)
        {
            return this._service.SchoolbusownercontactsIdContactphonesGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerContact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpPost]
        [Route("/api/schoolbusownercontacts/{id}/delete")]
        [SwaggerOperation("SchoolbusownercontactsIdDeletePost")]
        public virtual IActionResult SchoolbusownercontactsIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusownercontactsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpGet]
        [Route("/api/schoolbusownercontacts/{id}")]
        [SwaggerOperation("SchoolbusownercontactsIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerContact))]
        public virtual IActionResult SchoolbusownercontactsIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusownercontactsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        [HttpPut]
        [Route("/api/schoolbusownercontacts/{id}")]
        [SwaggerOperation("SchoolbusownercontactsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerContact))]
        public virtual IActionResult SchoolbusownercontactsIdPut([FromRoute]int id, [FromBody]SchoolBusOwnerContact item)
        {
            return this._service.SchoolbusownercontactsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwnerContact created</response>
        [HttpPost]
        [Route("/api/schoolbusownercontacts")]
        [SwaggerOperation("SchoolbusownercontactsPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerContact))]
        public virtual IActionResult SchoolbusownercontactsPost([FromBody]SchoolBusOwnerContact item)
        {
            return this._service.SchoolbusownercontactsPostAsync(item);
        }
    }
}
