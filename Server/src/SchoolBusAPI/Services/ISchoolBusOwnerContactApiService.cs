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
    public interface ISchoolBusOwnerContactApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerContacts created</response>        

        IActionResult SchoolbusownercontactsBulkPostAsync (SchoolBusOwnerContact[] body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerContact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>        

        IActionResult SchoolbusownercontactsIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>        

        IActionResult SchoolbusownercontactsIdGetAsync (int id);        
        
        /// <summary>
        /// Add a Contact
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownercontactsPostAsync(SchoolBusOwnerContact body);

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>        

        IActionResult SchoolbusownercontactsIdPutAsync(int id, SchoolBusOwnerContact body);

    }
}
