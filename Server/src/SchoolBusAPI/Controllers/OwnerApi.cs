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

namespace SchoolBusAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class OwnerApiController : Controller
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a controller and set the database context
        /// </summary>

        public OwnerApiController(DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns list of available FavoriteContextTypes</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/favoritecontexttypes")]
        [SwaggerOperation("FavoritecontexttypesGet")]
        [SwaggerResponse(200, type: typeof(List<FavoriteContextType>))]
        public virtual IActionResult FavoritecontexttypesGet()
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<FavoriteContextType>>(exampleJson)
            : default(List<FavoriteContextType>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular Owner</remarks>
        /// <param name="ownerId">Id of Owner to fetch contact address for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{owner-id}/contactaddresses")]
        [SwaggerOperation("OwnerOwnerIdContactaddressesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerContactAddress>))]
        public virtual IActionResult OwnerOwnerIdContactaddressesGet([FromRoute]int ownerId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<OwnerContactAddress>>(exampleJson)
            : default(List<OwnerContactAddress>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns phone contacts for a particular Owner</remarks>
        /// <param name="ownerId">Id of Owner to fetch contact phone for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{owner-id}/contactphones")]
        [SwaggerOperation("OwnerOwnerIdContactphonesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerContactPhone>))]
        public virtual IActionResult OwnerOwnerIdContactphonesGet([FromRoute]int ownerId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<OwnerContactPhone>>(exampleJson)
            : default(List<OwnerContactPhone>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a particular Owner</remarks>
        /// <param name="ownerId">Id of Owner to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{owner-id}")]
        [SwaggerOperation("OwnerOwnerIdGet")]
        [SwaggerResponse(200, type: typeof(List<Owner>))]
        public virtual IActionResult OwnerOwnerIdGet([FromRoute]int ownerId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Owner>>(exampleJson)
            : default(List<Owner>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular Owner</remarks>
        /// <param name="ownerId">Id of Owner to fetch notes for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{owner-id}/notes")]
        [SwaggerOperation("OwnerOwnerIdNotesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerNotes>))]
        public virtual IActionResult OwnerOwnerIdNotesGet([FromRoute]int ownerId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<OwnerNotes>>(exampleJson)
            : default(List<OwnerNotes>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="schoolbusId">Id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbus/{schoolbus-id}/ccwdata")]
        [SwaggerOperation("SchoolbusSchoolbusIdCcwdataGet")]
        [SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult SchoolbusSchoolbusIdCcwdataGet([FromRoute]int schoolbusId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<CCWData>(exampleJson)
            : default(CCWData);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s favorites of a given context type</remarks>
        /// <param name="userId">Id of User to fetch favorites for</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/users/{user-id}/favorites")]
        [SwaggerOperation("UsersUserIdFavoritesGet")]
        [SwaggerResponse(200, type: typeof(List<UserFavorite>))]
        public virtual IActionResult UsersUserIdFavoritesGet([FromRoute]int userId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<UserFavorite>>(exampleJson)
            : default(List<UserFavorite>);
            return new ObjectResult(example);
        }
    }
}
