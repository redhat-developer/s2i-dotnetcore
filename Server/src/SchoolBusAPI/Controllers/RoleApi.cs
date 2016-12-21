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
    public partial class RoleApiController : Controller
    {
        private readonly IRoleApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>

        public RoleApiController(IRoleApiService service)
        {
            _service = service;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of roles</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles")]
        [SwaggerOperation("RolesGet")]
        [SwaggerResponse(200, type: typeof(List<Role>))]
        public virtual IActionResult RolesGet()
        { 
            return this._service.RolesGetAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Role to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpDelete]
        [Route("/api/roles/{id}")]
        [SwaggerOperation("RolesIdDelete")]
        public virtual void RolesIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpGet]
        [Route("/api/roles/{id}")]
        [SwaggerOperation("RolesIdGet")]
        [SwaggerResponse(200, type: typeof(Role))]
        public virtual IActionResult RolesIdGet([FromRoute]int id)
        { 
            return this._service.RolesIdGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the permissions for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles/{id}/permissions")]
        [SwaggerOperation("RolesIdPermissionsGet")]
        [SwaggerResponse(200, type: typeof(List<Permission>))]
        public virtual IActionResult RolesIdPermissionsGet([FromRoute]int id)
        { 
            return this._service.RolesIdPermissionsGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the permissions for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPut]
        [Route("/api/roles/{id}/permissions")]
        [SwaggerOperation("RolesIdPermissionsPut")]
        [SwaggerResponse(200, type: typeof(List<Permission>))]
        public virtual IActionResult RolesIdPermissionsPut([FromRoute]int id, [FromBody]List<Permission> body)
        { 
            return this._service.RolesIdPermissionsPutAsync(id, body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Role to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPut]
        [Route("/api/roles/{id}")]
        [SwaggerOperation("RolesIdPut")]
        [SwaggerResponse(200, type: typeof(Role))]
        public virtual IActionResult RolesIdPut([FromRoute]int id)
        { 
            return this._service.RolesIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the users for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/roles/{id}/users")]
        [SwaggerOperation("RolesIdUsersGet")]
        [SwaggerResponse(200, type: typeof(List<User>))]
        public virtual IActionResult RolesIdUsersGet([FromRoute]int id)
        { 
            return this._service.RolesIdUsersGetAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the users for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        [HttpPut]
        [Route("/api/roles/{id}/users")]
        [SwaggerOperation("RolesIdUsersPut")]
        [SwaggerResponse(200, type: typeof(List<User>))]
        public virtual IActionResult RolesIdUsersPut([FromRoute]int id, [FromBody]List<User> body)
        { 
            return this._service.RolesIdUsersPutAsync(id, body);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Role created</response>
        [HttpPost]
        [Route("/api/roles")]
        [SwaggerOperation("RolesPost")]
        [SwaggerResponse(200, type: typeof(Role))]
        public virtual IActionResult RolesPost([FromBody]Role body)
        { 
            return this._service.RolesPostAsync(body);
        }
    }
}
