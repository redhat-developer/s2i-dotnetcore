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
    public class SchoolBusAttachmentApiService : ISchoolBusAttachmentApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusAttachments created</response>

        public virtual IActionResult SchoolbusattachmentsBulkPostAsync (List<SchoolBusAttachment> body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusattachmentsGetAsync ()        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>

        public virtual IActionResult SchoolbusattachmentsIdDeleteAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>

        public virtual IActionResult SchoolbusattachmentsIdGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>

        public virtual IActionResult SchoolbusattachmentsIdPutAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusAttachment created</response>

        public virtual IActionResult SchoolbusattachmentsPostAsync (SchoolBusAttachment body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>

        public virtual IActionResult SchoolbushistoriesIdGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
    }
}
