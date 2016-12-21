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


namespace SchoolBusAPI.Services
{ 
    /// <summary>
    /// 
    /// </summary>
    public interface IRoleApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of roles</remarks>
        /// <response code="200">OK</response>        

        IActionResult RolesGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Role to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>        

        IActionResult RolesIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>        

        IActionResult RolesIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the permissions for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>        

        IActionResult RolesIdPermissionsGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the permissions for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>        

        IActionResult RolesIdPermissionsPutAsync (int id, List<Permission> body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Role to update</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>        

        IActionResult RolesIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the users for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>        

        IActionResult RolesIdUsersGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the users for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>        

        IActionResult RolesIdUsersPutAsync (int id, List<User> body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Role created</response>        

        IActionResult RolesPostAsync (Role body);        
        
    }
}
