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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Mappings;

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
        public UserApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of users</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult UsersBulkPostAsync(User[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (User item in items)
            {
                _context.Users.Add(item);
            }

            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all users</remarks>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersGetAsync()
        {
            var result = _context.Users.Select(x => x.ToViewModel()).ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a user</remarks>
        /// <param name="id">id of User to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdDeletePostAsync(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }
            // remove any user role associations.            
            var toRemove = _context.UserRoles.Where(x => x.User.Id == id ).ToList();
            toRemove.ForEach(x => _context.UserRoles.Remove(x));
            
            _context.Users.Remove(user);
            _context.SaveChanges();
            return new ObjectResult(user.ToViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s favourites of a given context type</remarks>
        /// <param name="id">id of User to fetch favorites for</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdFavouritesGetAsync(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }
            // TODO adjust UserFavourites model such that we can query to find a user's favourites.
            // var result = _context.UserFavourites.Select(x => x.x.ToViewModel()).ToList();
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
        public virtual IActionResult UsersIdGetAsync(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }
            return new ObjectResult(user.ToViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all groups that a user is a member of</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdGroupsGetAsync(int id)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the active set of groups for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdGroupsPutAsync(int id, GroupMembership[] items)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a user to groups</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdGroupsPostAsync(int id, GroupMembership[] items)
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
        public virtual IActionResult UsersIdNotificationsGetAsync(int id)
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
        public virtual IActionResult UsersIdPermissionsGetAsync(int id)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdPutAsync(int id, UserViewModel item)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            user.Active = item.Active;
            user.Email = item.Email;
            user.GivenName = item.GivenName;
            user.Initials = item.Initials;
            user.Surname = item.Surname;

            // Save changes
            _context.Users.Update(user);
            _context.SaveChanges();
            return new ObjectResult(user.ToViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the roles for a user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdRolesGetAsync(int id)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a role to a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="201">Role created for user</response>
        public virtual IActionResult UsersIdRolesPostAsync(int id, UserRoleViewModel item)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the roles for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersIdRolesPutAsync(int id, UserRoleViewModel[] items)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="item"></param>
        /// <response code="201">User created</response>
        public virtual IActionResult UsersPostAsync(User item)
        {            
            // Save changes
            _context.Users.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
