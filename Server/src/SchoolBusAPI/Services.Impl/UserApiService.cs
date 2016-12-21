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
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class UserApiService : IUserApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public UserApiService (DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add many users
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public IActionResult UsersBulkPostAsync(User[] items)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get the currently logged in user</remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult UsersCurrentGetAsync ()        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all users</remarks>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersGetAsync ()        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a user</remarks>
        /// <param name="id">id of User to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdDeleteAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s favourites of a given context type</remarks>
        /// <param name="id">id of User to fetch favorites for</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdFavouritesGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns data for a particular user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all groups that a user is a member of</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdGroupsGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the active set of groups for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdGroupsPutAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s notifications</remarks>
        /// <param name="id">id of User to fetch notifications for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult UsersIdNotificationGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the set of permissions for a user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdPermissionsGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdPutAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the roles for a user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdRolesGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a role to a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="body"></param>
        /// <response code="201">Role created for user</response>

        public virtual IActionResult UsersIdRolesPostAsync (int id, UserRole body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the roles for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>

        public virtual IActionResult UsersIdRolesPutAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="body"></param>
        /// <response code="201">User created</response>

        public virtual IActionResult UsersPostAsync (User body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
    }
}
