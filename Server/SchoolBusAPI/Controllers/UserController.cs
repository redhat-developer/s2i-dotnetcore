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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public UserController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all users</remarks>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users")]
        [RequiresPermission(Permissions.UserRead)]
        public IActionResult GetUsers()
        {
            return this._service.GetUsers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a user</remarks>
        /// <param name="id">id of User to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpPost]
        [Route("/api/users/{id}/delete")]
        [RequiresPermission(Permissions.UserWrite)]
        public virtual IActionResult DeleteUser([FromRoute]int id)
        {
            return this._service.DeleteUser(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns data for a particular user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users/{id}")]
        [RequiresPermission(Permissions.UserRead)]
        public virtual IActionResult GetUser([FromRoute]int id)
        {
            return this._service.GetUser(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpPut]
        [Route("/api/users/{id}")]
        [RequiresPermission(Permissions.UserWrite)]
        public virtual IActionResult UpdateUser([FromRoute]int id, [FromBody]UserViewModel item)
        {
            return this._service.UpdateUser(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="item"></param>
        /// <response code="201">User created</response>
        [HttpPost]
        [Route("/api/users")]
        [RequiresPermission(Permissions.UserWrite)]
        public virtual IActionResult CreateUser([FromBody] UserViewModel item)
        {
            return this._service.CreateUser(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the roles for a user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users/{id}/roles")]
        [RequiresPermission(Permissions.UserRead)]
        public virtual IActionResult GetUserRoles([FromRoute]int id)
        {
            return this._service.GetUserRoles(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a role to a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="201">Role created for user</response>
        [HttpPost]
        [Route("/api/users/{id}/roles")]
        [RequiresPermission(Permissions.UserWrite)]
        public virtual IActionResult CreateUserRole([FromRoute]int id, [FromBody]UserRoleViewModel item)
        {
            return this._service.CreateUserRole(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the role for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="userRoleId">id of User Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpPut]
        [Route("/api/users/{id}/roles/{userRoleId}")]
        [RequiresPermission(Permissions.UserWrite)]
        public virtual IActionResult UpdateUserRole([FromRoute]int id, [FromRoute]int userRoleId, [FromBody]UserRoleViewModel items)
        {
            return this._service.UpdateUserRole(id, userRoleId, items);
        }

        /// <summary>
        /// Searches Users
        /// </summary>
        /// <remarks>Used for the search users.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="surname"></param>
        /// <param name="includeInactive">True if Inactive users will be returned</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/users/search")]
        [RequiresPermission(Permissions.UserRead)]
        public virtual IActionResult SearchUsers([FromQuery]int?[] districts, [FromQuery]string surname, [FromQuery]bool? includeInactive)
        {
            return this._service.SearchUsers(districts, surname, includeInactive);
        }

        [HttpGet]
        [Route("/api/users/inspectors")]
        [RequiresPermission(Permissions.CodeRead)]
        public virtual IActionResult GetInspectors([FromQuery] bool? includeInactive)
        {
            return this._service.GetInspectors(includeInactive);
        }

    }
}
