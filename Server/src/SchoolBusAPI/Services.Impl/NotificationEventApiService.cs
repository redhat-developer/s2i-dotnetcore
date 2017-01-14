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
    public class NotificationEventApiService : INotificationEventApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public NotificationEventApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="items"></param>
        /// <response code="201">NotificationEvents created</response>

        public virtual IActionResult NotificationeventsBulkPostAsync (NotificationEvent[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (NotificationEvent item in items)
            {
                _context.NotificationEvents.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult NotificationeventsGetAsync ()        
        {
            var result = _context.NotificationEvents.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>

        public virtual IActionResult NotificationeventsIdDeletePostAsync (int id)        
        {
            var exists = _context.NotificationEvents.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.NotificationEvents.First(a => a.Id == id);
                _context.NotificationEvents.Remove(item);
                // Save the changes
                _context.SaveChanges();                
                return new ObjectResult(item);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>

        public virtual IActionResult NotificationeventsIdGetAsync (int id)        
        {
            var exists = _context.NotificationEvents.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.NotificationEvents.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>

        public virtual IActionResult NotificationeventsIdPutAsync (int id, NotificationEvent body)        
        {
            var exists = _context.NotificationEvents.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {                                
                _context.NotificationEvents.Update(body);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(body);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">NotificationEvent created</response>

        public virtual IActionResult NotificationeventsPostAsync (NotificationEvent body)        
        {
            _context.NotificationEvents.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
