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
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GroupApiController : Controller
    {
        private readonly IGroupApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public GroupApiController(IGroupApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of groups</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/groups")]
        [SwaggerOperation("GroupsGet")]
        [SwaggerResponse(200, type: typeof(List<GroupViewModel>))]
        public virtual IActionResult GroupsGet()
        {
            return this._service.GroupsGetAsync();
        }
    }
}
