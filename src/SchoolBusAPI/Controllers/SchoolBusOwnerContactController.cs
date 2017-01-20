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
    }
}
