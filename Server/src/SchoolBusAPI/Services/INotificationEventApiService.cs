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
    public interface INotificationEventApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">NotificationEvents created</response>        

        IActionResult NotficationeventsBulkPostAsync (NotificationEvent[] body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult NotficationeventsGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>        

        IActionResult NotficationeventsIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>        

        IActionResult NotficationeventsIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>        

        IActionResult NotficationeventsIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">NotificationEvent created</response>        

        IActionResult NotficationeventsPostAsync (NotificationEvent body);        
        
    }
}
