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
    public interface INotificationApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Notifications created</response>        

        IActionResult NotficationsBulkPostAsync (Notification[] body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult NotficationsGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>        

        IActionResult NotficationsIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>        

        IActionResult NotficationsIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>        

        IActionResult NotficationsIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Notification created</response>        

        IActionResult NotficationsPostAsync (Notification body);        
        
    }
}
