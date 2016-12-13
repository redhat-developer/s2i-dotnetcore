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
        /// <remarks>Returns attachments for a particular Owner</remarks>
        /// <param name="id">id of Owner to fetch attachments for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{id}/attachments")]
        [SwaggerOperation("OwnerIdAttachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerAttachments>))]
        public virtual IActionResult OwnerIdAttachmentsGet([FromRoute]int id)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<OwnerAttachments>>(exampleJson)
            : default(List<OwnerAttachments>);
            return new ObjectResult(example);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular Owner</remarks>
        /// <param name="id">id of Owner to fetch contact address for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{id}/contactaddresses")]
        [SwaggerOperation("OwnerIdContactaddressesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerContactAddress>))]
        public virtual IActionResult OwnerIdContactaddressesGet([FromRoute]int id)
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
        /// <param name="id">id of Owner to fetch contact phone for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{id}/contactphones")]
        [SwaggerOperation("OwnerIdContactphonesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerContactPhone>))]
        public virtual IActionResult OwnerIdContactphonesGet([FromRoute]int id)
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
        /// <param name="id">id of Owner to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{id}")]
        [SwaggerOperation("OwnerIdGet")]
        [SwaggerResponse(200, type: typeof(List<Owner>))]
        public virtual IActionResult OwnerIdGet([FromRoute]int id)
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
        /// <param name="id">id of Owner to fetch notes for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owner/{id}/notes")]
        [SwaggerOperation("OwnerIdNotesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerNotes>))]
        public virtual IActionResult OwnerIdNotesGet([FromRoute]int id)
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
        /// <remarks>Returns a user&#39;s favorites of a given context type</remarks>
        /// <param name="id">id of User to fetch favorites for</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/api/user/{id}/favorites")]
        [SwaggerOperation("UserIdFavoritesGet")]
        [SwaggerResponse(200, type: typeof(List<UserFavorite>))]
        public virtual IActionResult UserIdFavoritesGet([FromRoute]int id)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<UserFavorite>>(exampleJson)
            : default(List<UserFavorite>);
            return new ObjectResult(example);
        }
    }
}
