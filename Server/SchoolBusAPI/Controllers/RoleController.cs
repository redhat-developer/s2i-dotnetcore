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
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles")]
        [RequiresPermission(Permissions.RoleRead)]
        public virtual IActionResult GetRoles(bool? includeExpired = false)
        {
            return this._service.GetRoles(includeExpired ?? false);
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
        public virtual IActionResult DeleteRole([FromRoute]int id)
        {
            return this._service.DeleteRole(id);
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
        public virtual IActionResult GetRole([FromRoute]int id)
        {
            return this._service.GetRole(id);
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
        public virtual IActionResult GetRolePermissions([FromRoute]int id)
        {
            return this._service.GetRolePermissions(id);
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
        public virtual IActionResult UpdateRolePermissions([FromRoute]int id, [FromBody]PermissionViewModel[] items)
        {
            return this._service.UpdateRolePermissions(id, items);
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
        public virtual IActionResult UpdateRole([FromRoute]int id, [FromBody]RoleViewModel item)
        {
            return this._service.UpdateRole(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Role created</response>
        [HttpPost]
        [Route("/api/roles")]
        [RequiresPermission(Permissions.RoleWrite)]
        public virtual IActionResult CreateRole([FromBody]RoleViewModel item)
        {
            return this._service.CreateRole(item);
        }
    }
}
