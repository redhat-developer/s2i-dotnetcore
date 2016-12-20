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
    public interface ISchoolBusOwnerHistoryApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerHistories created</response>        

        IActionResult SchoolbusownerhistoryBulkPostAsync (List<SchoolBusOwnerHistory> body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownerhistoryGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>        

        IActionResult SchoolbusownerhistoryIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>        

        IActionResult SchoolbusownerhistoryIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>        

        IActionResult SchoolbusownerhistoryIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerHistory created</response>        

        IActionResult SchoolbusownerhistoryPostAsync (SchoolBusOwnerHistory body);        
        
    }
}
