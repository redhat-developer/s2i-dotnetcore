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
    public partial class RoleApiController : Controller
    {
        private readonly IRoleApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public RoleApiController(IRoleApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Permissions created</response>
        [HttpPost]
        [Route("/api/roles/bulk")]
        [SwaggerOperation("RolesBulkPost")]
        public virtual IActionResult RolesBulkPost([FromBody]Role[] items)
        {
            return this._service.RolesBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of roles</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles")]
        [SwaggerOperation("RolesGet")]
        [SwaggerResponse(200, type: typeof(List<RoleViewModel>))]
        public virtual IActionResult RolesGet()
        {
            return this._service.RolesGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPost]
        [Route("/api/roles/{id}/delete")]
        [SwaggerOperation("RolesIdDeletePost")]
        public virtual IActionResult RolesIdDeletePost([FromRoute]int id)
        {
            return this._service.RolesIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpGet]
        [Route("/api/roles/{id}")]
        [SwaggerOperation("RolesIdGet")]
        [SwaggerResponse(200, type: typeof(RoleViewModel))]
        public virtual IActionResult RolesIdGet([FromRoute]int id)
        {
            return this._service.RolesIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the permissions for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles/{id}/permissions")]
        [SwaggerOperation("RolesIdPermissionsGet")]
        [SwaggerResponse(200, type: typeof(List<PermissionViewModel>))]
        public virtual IActionResult RolesIdPermissionsGet([FromRoute]int id)
        {
            return this._service.RolesIdPermissionsGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a permissions to a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPost]
        [Route("/api/roles/{id}/permissions")]
        [SwaggerOperation("RolesIdPermissionsPost")]
        [SwaggerResponse(200, type: typeof(List<Permission>))]
        public virtual IActionResult RolesIdPermissionsPost([FromRoute]int id, [FromBody]Permission[] items)
        {
            return this._service.RolesIdPermissionsPostAsync(id, items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the permissions for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPut]
        [Route("/api/roles/{id}/permissions")]
        [SwaggerOperation("RolesIdPermissionsPut")]
        [SwaggerResponse(200, type: typeof(List<PermissionViewModel>))]
        public virtual IActionResult RolesIdPermissionsPut([FromRoute]int id, [FromBody]Permission[] items)
        {
            return this._service.RolesIdPermissionsPutAsync(id, items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPut]
        [Route("/api/roles/{id}")]
        [SwaggerOperation("RolesIdPut")]
        [SwaggerResponse(200, type: typeof(RoleViewModel))]
        public virtual IActionResult RolesIdPut([FromRoute]int id, [FromBody]RoleViewModel item)
        {
            return this._service.RolesIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Gets all the users for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles/{id}/users")]
        [SwaggerOperation("RolesIdUsersGet")]
        [SwaggerResponse(200, type: typeof(List<UserRoleViewModel>))]
        public virtual IActionResult RolesIdUsersGet([FromRoute]int id)
        {
            return this._service.RolesIdUsersGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the users for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPut]
        [Route("/api/roles/{id}/users")]
        [SwaggerOperation("RolesIdUsersPut")]
        [SwaggerResponse(200, type: typeof(List<UserRoleViewModel>))]
        public virtual IActionResult RolesIdUsersPut([FromRoute]int id, [FromBody]UserRoleViewModel[] items)
        {
            return this._service.RolesIdUsersPutAsync(id, items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Role created</response>
        [HttpPost]
        [Route("/api/roles")]
        [SwaggerOperation("RolesPost")]
        [SwaggerResponse(200, type: typeof(RoleViewModel))]
        public virtual IActionResult RolesPost([FromBody]RoleViewModel item)
        {
            return this._service.RolesPostAsync(item);
        }
    }
}
