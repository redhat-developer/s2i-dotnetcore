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
    public interface ICurrentUserApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get the details for the currently logged in user</remarks>
        /// <response code="200">OK</response>        

        IActionResult UsersCurrentGetAsync ();        
        
    }
}
