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
    public interface ISchoolBusOwnerNoteApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerNotes created</response>        

        IActionResult SchoolbusownernotesBulkPostAsync (SchoolBusOwnerNote[] body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownernotesGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerNote to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>        

        IActionResult SchoolbusownernotesIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>        

        IActionResult SchoolbusownernotesIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>        

        IActionResult SchoolbusownernotesIdPutAsync (int id, SchoolBusOwnerNote body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerNote created</response>        

        IActionResult SchoolbusownernotesPostAsync (SchoolBusOwnerNote body);        
        
    }
}
