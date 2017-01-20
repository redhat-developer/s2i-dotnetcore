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
    public partial class GroupController : Controller
    {
        private readonly IGroupService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public GroupController(IGroupService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Group created</response>
        [HttpPost]
        [Route("/api/groups/bulk")]
        [SwaggerOperation("GroupsBulkPost")]
        public virtual IActionResult GroupsBulkPost([FromBody]Group[] items)
        {
            return this._service.GroupsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/groups")]
        [SwaggerOperation("GroupsGet")]
        [SwaggerResponse(200, type: typeof(List<Group>))]
        public virtual IActionResult GroupsGet()
        {
            return this._service.GroupsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        [HttpPost]
        [Route("/api/groups/{id}/delete")]
        [SwaggerOperation("GroupsIdDeletePost")]
        public virtual IActionResult GroupsIdDeletePost([FromRoute]int id)
        {
            return this._service.GroupsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        [HttpGet]
        [Route("/api/groups/{id}")]
        [SwaggerOperation("GroupsIdGet")]
        [SwaggerResponse(200, type: typeof(Group))]
        public virtual IActionResult GroupsIdGet([FromRoute]int id)
        {
            return this._service.GroupsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        [HttpPut]
        [Route("/api/groups/{id}")]
        [SwaggerOperation("GroupsIdPut")]
        [SwaggerResponse(200, type: typeof(Group))]
        public virtual IActionResult GroupsIdPut([FromRoute]int id, [FromBody]Group item)
        {
            return this._service.GroupsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Group created</response>
        [HttpPost]
        [Route("/api/groups")]
        [SwaggerOperation("GroupsPost")]
        [SwaggerResponse(200, type: typeof(Group))]
        public virtual IActionResult GroupsPost([FromBody]Group item)
        {
            return this._service.GroupsPostAsync(item);
        }
    }
}
