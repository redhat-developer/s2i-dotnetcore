/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Services;
using SchoolBusAPI.Authorization;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public RoleController(IRoleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Role created</response>
        [HttpPost]
        [Route("/api/rolepermissions/bulk")]
        [RequiresPermission(Permissions.RoleWrite)]
        public virtual IActionResult RolepermissionsBulkPost([FromBody]RolePermission[] items)
        {
            return this._service.RolepermissionsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Role created</response>
        [HttpPost]
        [Route("/api/roles/bulk")]
        [RequiresPermission(Permissions.RoleWrite)]
        public virtual IActionResult RolesBulkPost([FromBody]Role[] items)
        {
            return this._service.RolesBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles")]
        [RequiresPermission(Permissions.RoleRead)]
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
        [RequiresPermission(Permissions.RoleWrite)]
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
        [RequiresPermission(Permissions.RoleRead)]
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
        [RequiresPermission(Permissions.RoleRead)]
        public virtual IActionResult RolesIdPermissionsGet([FromRoute]int id)
        {
            return this._service.RolesIdPermissionsGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a permissions to a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPost]
        [Route("/api/roles/{id}/permissions")]
        [RequiresPermission(Permissions.RoleWrite)]
        public virtual IActionResult RolesIdPermissionsPost([FromRoute]int id, [FromBody]PermissionViewModel item)
        {
            return this._service.RolesIdPermissionsPostAsync(id, item);
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
        [RequiresPermission(Permissions.RoleWrite)]
        public virtual IActionResult RolesIdPermissionsPut([FromRoute]int id, [FromBody]PermissionViewModel[] items)
        {
            return this._service.RolesIdPermissionsPutAsync(id, items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPut]
        [Route("/api/roles/{id}")]
        [RequiresPermission(Permissions.RoleWrite)]
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
        [RequiresPermission(Permissions.UserRead)]
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
        [RequiresPermission(Permissions.UserWrite)]
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
        [RequiresPermission(Permissions.RoleWrite)]
        public virtual IActionResult RolesPost([FromBody]RoleViewModel item)
        {
            return this._service.RolesPostAsync(item);
        }
    }
}
