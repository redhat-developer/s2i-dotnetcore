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
    public class HistoryService : IHistoryService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public HistoryService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerHistories created</response>

        public virtual IActionResult HistoriesBulkPostAsync (History[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (History item in items)
            {
                _context.Historys.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult HistoriesGetAsync()        
        {
            var result = _context.Historys.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of History to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>

        public virtual IActionResult HistoriesIdDeletePostAsync(int id)        
        {
            var exists = _context.Historys.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Historys.First(a => a.Id == id);
                _context.Historys.Remove(item);
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
        
        /// <param name="id">id of History to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>

        public virtual IActionResult HistoriesIdGetAsync(int id)        
        {
            var exists = _context.Historys.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Historys.First(a => a.Id == id);
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
        
        /// <param name="id">id of History to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>

        public virtual IActionResult HistoriesIdPutAsync(int id, History body )        
        {
            var exists = _context.Historys.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Historys.Update(body);               
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
        /// <response code="201">History created</response>

        public virtual IActionResult HistoriesPostAsync(History body)        
        {
            _context.Historys.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
