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
    public interface ISchoolBusAttachmentApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusAttachments created</response>        

        IActionResult SchoolbusattachmentsBulkPostAsync (SchoolBusAttachment [] body );        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult SchoolbusattachmentsGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>        

        IActionResult SchoolbusattachmentsIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>        

        IActionResult SchoolbusattachmentsIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>        

        IActionResult SchoolbusattachmentsIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusAttachment created</response>        

        IActionResult SchoolbusattachmentsPostAsync (SchoolBusAttachment body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>        

        IActionResult SchoolbushistoriesIdGetAsync (int id);        
        
    }
}
