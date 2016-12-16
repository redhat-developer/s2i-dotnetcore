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
            return this._service.UsersIdFavouritesGetAsync([FromRoute]int id);
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
            return this._service.UsersIdGetAsync([FromRoute]int id);
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
        [SwaggerResponse(200, type: typeof(List<UserNotifications>))]
        public virtual IActionResult UsersIdNotificationGet([FromRoute]int id)
        { 
            return this._service.UsersIdNotificationGetAsync([FromRoute]int id);
        }
    }
}
