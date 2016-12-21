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
    public interface IInspectionApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Inspections created</response>        

        IActionResult InspectionsBulkPostAsync (Inspection [] body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult InspectionsGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Inspection to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>        

        IActionResult InspectionsIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>        

        IActionResult InspectionsIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>        

        IActionResult InspectionsIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Inspection created</response>        

        IActionResult InspectionsPostAsync (Inspection body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>        

        IActionResult SchoolbusIdInspectionsGetAsync (int id);        
        
    }
}
