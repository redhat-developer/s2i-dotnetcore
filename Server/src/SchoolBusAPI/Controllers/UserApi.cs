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
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public partial class UserApiController : Controller
    {
        private readonly IUserApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public UserApiController(IUserApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of users</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/users/bulk")]
        [SwaggerOperation("UsersBulkPost")]
        [SwaggerResponse(200, type: typeof(User))]
        public virtual IActionResult UsersBulkPost([FromBody]User[] items)
        { 
            return this._service.UsersBulkPostAsync(items);
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all users</remarks>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users")]
        [SwaggerOperation("UsersGet")]
        [SwaggerResponse(200, type: typeof(List<User>))]
        public virtual IActionResult UsersGet()
        { 
            return this._service.UsersGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a user</remarks>
        /// <param name="id">id of User to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpDelete]
        [Route("/api/users/{id}")]
        [SwaggerOperation("UsersIdDelete")]
        public virtual void UsersIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s favourites of a given context type</remarks>
        /// <param name="id">id of User to fetch favorites for</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users/{id}/favourites")]
        [SwaggerOperation("UsersIdFavouritesGet")]
        [SwaggerResponse(200, type: typeof(List<UserFavourite>))]
        public virtual IActionResult UsersIdFavouritesGet([FromRoute]int id)
        { 
            return this._service.UsersIdFavouritesGetAsync(id);
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
        [SwaggerOperation("UsersIdGet")]
        [SwaggerResponse(200, type: typeof(User))]
        public virtual IActionResult UsersIdGet([FromRoute]int id)
        { 
            return this._service.UsersIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all groups that a user is a member of</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users/{id}/groups")]
        [SwaggerOperation("UsersIdGroupsGet")]
        [SwaggerResponse(200, type: typeof(List<GroupMembership>))]
        public virtual IActionResult UsersIdGroupsGet([FromRoute]int id)
        { 
            return this._service.UsersIdGroupsGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the active set of groups for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpPut]
        [Route("/api/users/{id}/groups")]
        [SwaggerOperation("UsersIdGroupsPut")]
        [SwaggerResponse(200, type: typeof(List<GroupMembership>))]
        public virtual IActionResult UsersIdGroupsPut([FromRoute]int id)
        { 
            return this._service.UsersIdGroupsPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s notifications</remarks>
        /// <param name="id">id of User to fetch notifications for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/users/{id}/notification")]
        [SwaggerOperation("UsersIdNotificationGet")]
        [SwaggerResponse(200, type: typeof(List<Notification>))]
        public virtual IActionResult UsersIdNotificationGet([FromRoute]int id)
        { 
            return this._service.UsersIdNotificationGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the set of permissions for a user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users/{id}/permissions")]
        [SwaggerOperation("UsersIdPermissionsGet")]
        [SwaggerResponse(200, type: typeof(List<Permission>))]
        public virtual IActionResult UsersIdPermissionsGet([FromRoute]int id)
        { 
            return this._service.UsersIdPermissionsGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpPut]
        [Route("/api/users/{id}")]
        [SwaggerOperation("UsersIdPut")]
        [SwaggerResponse(200, type: typeof(User))]
        public virtual IActionResult UsersIdPut([FromRoute]int id)
        { 
            return this._service.UsersIdPutAsync(id);
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
        [SwaggerOperation("UsersIdRolesGet")]
        [SwaggerResponse(200, type: typeof(List<UserRole>))]
        public virtual IActionResult UsersIdRolesGet([FromRoute]int id)
        { 
            return this._service.UsersIdRolesGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a role to a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="body"></param>
        /// <response code="201">Role created for user</response>
        [HttpPost]
        [Route("/api/users/{id}/roles")]
        [SwaggerOperation("UsersIdRolesPost")]
        [SwaggerResponse(200, type: typeof(UserRole))]
        public virtual IActionResult UsersIdRolesPost([FromRoute]int id, [FromBody]UserRole body)
        { 
            return this._service.UsersIdRolesPostAsync(id, body);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the roles for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpPut]
        [Route("/api/users/{id}/roles")]
        [SwaggerOperation("UsersIdRolesPut")]
        [SwaggerResponse(200, type: typeof(List<UserRole>))]
        public virtual IActionResult UsersIdRolesPut([FromRoute]int id)
        { 
            return this._service.UsersIdRolesPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="body"></param>
        /// <response code="201">User created</response>
        [HttpPost]
        [Route("/api/users")]
        [SwaggerOperation("UsersPost")]
        [SwaggerResponse(200, type: typeof(User))]
        public virtual IActionResult UsersPost([FromBody]User body)
        { 
            return this._service.UsersPostAsync(body);
        }
    }
}
