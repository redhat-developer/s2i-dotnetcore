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
    public class SchoolBusOwnerHistoryApiService : ISchoolBusOwnerHistoryApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerHistoryApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerHistories created</response>

        public virtual IActionResult SchoolbusownerhistoryBulkPostAsync (List<SchoolBusOwnerHistory> body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownerhistoryGetAsync ()        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>

        public virtual IActionResult SchoolbusownerhistoryIdDeleteAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>

        public virtual IActionResult SchoolbusownerhistoryIdGetAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>

        public virtual IActionResult SchoolbusownerhistoryIdPutAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerHistory created</response>

        public virtual IActionResult SchoolbusownerhistoryPostAsync (SchoolBusOwnerHistory body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
    }
}
