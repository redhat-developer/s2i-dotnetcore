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
    public interface ISchoolBusHistoryApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusHistories created</response>        

        IActionResult SchoolbushistoriesBulkPostAsync (SchoolBusHistory[] body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult SchoolbushistoriesGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusHistory to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>        

        IActionResult SchoolbushistoriesIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>        

        IActionResult SchoolbushistoriesIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusHistory created</response>        

        IActionResult SchoolbushistoriesPostAsync (SchoolBusHistory body);        
        
    }
}
