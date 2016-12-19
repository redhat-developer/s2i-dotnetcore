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

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class NotificationApiService : INotificationApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Notifications created</response>

        public virtual IActionResult NotficationsBulkPostAsync (List<Notification> body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult NotficationsGetAsync ()        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>

        public virtual IActionResult NotficationsIdDeleteAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>

        public virtual IActionResult NotficationsIdGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>

        public virtual IActionResult NotficationsIdPutAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Notification created</response>

        public virtual IActionResult NotficationsPostAsync (Notification body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
    }
}
