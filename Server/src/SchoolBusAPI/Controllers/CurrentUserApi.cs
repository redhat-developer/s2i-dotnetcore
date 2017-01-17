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
    public partial class CurrentUserApiController : Controller
    {
        private readonly ICurrentUserApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public CurrentUserApiController(ICurrentUserApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Removes all of the current user&#39;s favourites</remarks>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("/api/users/current/favourites/delete")]
        [SwaggerOperation("UsersCurrentFavouritesDeletePost")]
        public virtual IActionResult UsersCurrentFavouritesDeletePost()
        {
            return this._service.UsersCurrentFavouritesDeletePostAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new favourite for the current user</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        [HttpPost]
        [Route("/api/users/current/favourites")]
        [SwaggerOperation("UsersCurrentFavouritesPost")]
        [SwaggerResponse(200, type: typeof(UserFavourite))]
        public virtual IActionResult UsersCurrentFavouritesPost([FromBody]UserFavourite item)
        {
            return this._service.UsersCurrentFavouritesPostAsync(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a favourite</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        [HttpPut]
        [Route("/api/users/current/favourites")]
        [SwaggerOperation("UsersCurrentFavouritesPut")]
        [SwaggerResponse(200, type: typeof(UserFavourite))]
        public virtual IActionResult UsersCurrentFavouritesPut([FromBody]UserFavourite item)
        {
            return this._service.UsersCurrentFavouritesPutAsync(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s favourites of a given type.  If type is empty, returns all.</remarks>
        /// <param name="type">type of favourite to return</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users/current/favourites/{type}")]
        [SwaggerOperation("UsersCurrentFavouritesTypeGet")]
        [SwaggerResponse(200, type: typeof(List<UserFavourite>))]
        public virtual IActionResult UsersCurrentFavouritesTypeGet([FromRoute]string type)
        {
            return this._service.UsersCurrentFavouritesTypeGetAsync(type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get the currently logged in user</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/users/current")]
        [SwaggerOperation("UsersCurrentGet")]
        [SwaggerResponse(200, type: typeof(CurrentUserViewModel))]
        public virtual IActionResult UsersCurrentGet()
        {
            return this._service.UsersCurrentGetAsync();
        }
    }
}
