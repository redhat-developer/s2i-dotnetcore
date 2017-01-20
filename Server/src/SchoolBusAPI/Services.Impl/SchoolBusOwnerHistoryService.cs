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
    public class SchoolBusOwnerHistoryService : ISchoolBusOwnerHistoryService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerHistoryService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerHistories created</response>

        public virtual IActionResult SchoolbusownerhistoryBulkPostAsync (SchoolBusOwnerHistory[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwnerHistory item in items)
            {
                _context.SchoolBusOwnerHistorys.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownerhistoryGetAsync ()        
        {
            var result = _context.SchoolBusOwnerHistorys.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>

        public virtual IActionResult SchoolbusownerhistoryIdDeletePostAsync (int id)        
        {
            var exists = _context.SchoolBusOwnerHistorys.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusOwnerHistorys.First(a => a.Id == id);
                _context.SchoolBusOwnerHistorys.Remove(item);
                // Save the changes
                _context.SaveChanges();            
                return new ObjectResult(item);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>

        public virtual IActionResult SchoolbusownerhistoryIdGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwnerHistorys.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerHistorys.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerHistory not found</response>

        public virtual IActionResult SchoolbusownerhistoryIdPutAsync (int id, SchoolBusOwnerHistory body )        
        {
            var exists = _context.SchoolBusOwnerHistorys.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.SchoolBusOwnerHistorys.Update(body);               
                // Save the changes
                _context.SaveChanges();            
                return new ObjectResult(body);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwnerHistory created</response>

        public virtual IActionResult SchoolbusownerhistoryPostAsync (SchoolBusOwnerHistory body)        
        {
            _context.SchoolBusOwnerHistorys.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
