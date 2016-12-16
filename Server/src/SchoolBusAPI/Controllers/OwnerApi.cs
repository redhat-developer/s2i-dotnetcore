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
    public partial class OwnerApiController : Controller
    {
        private readonly IOwnerApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public OwnerApiController(IOwnerApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns list of available FavouriteContextTypes</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/favouritecontexttypes")]
        [SwaggerOperation("FavouritecontexttypesGet")]
        [SwaggerResponse(200, type: typeof(List<FavouriteContextType>))]
        public virtual IActionResult FavouritecontexttypesGet()
        { 
            return this._service.FavouritecontexttypesGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular Owner</remarks>
        /// <param name="id">id of Owner to fetch attachments for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owners/{id}/attachments")]
        [SwaggerOperation("OwnersIdAttachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerAttachments>))]
        public virtual IActionResult OwnersIdAttachmentsGet([FromRoute]int id)
        { 
            return this._service.OwnersIdAttachmentsGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular Owner</remarks>
        /// <param name="id">id of Owner to fetch contact address for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owners/{id}/contactaddresses")]
        [SwaggerOperation("OwnersIdContactaddressesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerContactAddress>))]
        public virtual IActionResult OwnersIdContactaddressesGet([FromRoute]int id)
        { 
            return this._service.OwnersIdContactaddressesGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns phone contacts for a particular Owner</remarks>
        /// <param name="id">id of Owner to fetch contact phone for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owners/{id}/contactphones")]
        [SwaggerOperation("OwnersIdContactphonesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerContactPhone>))]
        public virtual IActionResult OwnersIdContactphonesGet([FromRoute]int id)
        { 
            return this._service.OwnersIdContactphonesGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a particular Owner</remarks>
        /// <param name="id">id of Owner to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owners/{id}")]
        [SwaggerOperation("OwnersIdGet")]
        [SwaggerResponse(200, type: typeof(List<Owner>))]
        public virtual IActionResult OwnersIdGet([FromRoute]int id)
        { 
            return this._service.OwnersIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular Owner</remarks>
        /// <param name="id">id of Owner to fetch notes for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/owners/{id}/notes")]
        [SwaggerOperation("OwnersIdNotesGet")]
        [SwaggerResponse(200, type: typeof(List<OwnerNotes>))]
        public virtual IActionResult OwnersIdNotesGet([FromRoute]int id)
        { 
            return this._service.OwnersIdNotesGetAsync(id);
        }
    }
}
