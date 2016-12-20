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
            this._context = context;
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
        /// <remarks>Returns a user&#39;s notifications</remarks>
        /// <param name="id">id of User to fetch notifications for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult UsersIdNotificationGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
    }
}
