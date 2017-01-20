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
    public class InspectionService : IInspectionService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public InspectionService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">Inspections created</response>

        public virtual IActionResult InspectionsBulkPostAsync (Inspection[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Inspection item in items)
            {               
                // adjust the user
                if (item.Inspector != null)
                {
                    int user_id = item.Inspector.Id;
                    bool user_exists = _context.Users.Any(a => a.Id == user_id);
                    if (user_exists)
                    {
                        User user = _context.Users.First(a => a.Id == user_id);
                        item.Inspector = user;
                    }
                    else
                    {
                        item.Inspector = null;
                    }
                }
                // adjust the schoolbus
                if (item.SchoolBus != null)
                {
                    int schoolbus_id = item.SchoolBus.Id;
                    bool schoolbus_exists = _context.SchoolBuss.Any(a => a.Id == schoolbus_id);
                    if (schoolbus_exists)
                    {
                        SchoolBus schoolbus = _context.SchoolBuss.First(a => a.Id == schoolbus_id);
                        item.SchoolBus = schoolbus;
                    }
                    else
                    {
                        item.SchoolBus = null;
                    }
                }
                bool exists = _context.Inspections.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Inspections.Update(item);
                }
                else
                {
                    // Inspection has a special field, createdDate which is set to now.
                    item.CreatedDate = DateTime.Now;
                    _context.Inspections.Add(item);
                }                
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult InspectionsGetAsync ()        
        {
            var result = _context.Inspections.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Inspection to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>

        public virtual IActionResult InspectionsIdDeletePostAsync (int id)        
        {
            var exists = _context.Inspections.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Inspections.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Inspections.Remove(item);
                    // Save the changes
                    _context.SaveChanges();
                }            
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
        
        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>

        public virtual IActionResult InspectionsIdGetAsync (int id)        
        {
            var exists = _context.Inspections.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Inspections.First(a => a.Id == id);
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
        
        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>

        public virtual IActionResult InspectionsIdPutAsync (int id, Inspection item)        
        {
            // adjust the user
            if (item.Inspector != null)
            {
                int user_id = item.Inspector.Id;
                bool user_exists = _context.Users.Any(a => a.Id == user_id);
                if (user_exists)
                {
                    User user = _context.Users.First(a => a.Id == user_id);
                    item.Inspector = user;
                }
                else
                {
                    item.Inspector = null;
                }
            }
            // adjust the schoolbus
            if (item.SchoolBus != null)
            {
                int schoolbus_id = item.SchoolBus.Id;
                bool schoolbus_exists = _context.SchoolBuss.Any(a => a.Id == schoolbus_id);
                if (schoolbus_exists)
                {
                    SchoolBus schoolbus = _context.SchoolBuss.First(a => a.Id == schoolbus_id);
                    item.SchoolBus = schoolbus;
                }
                else
                {
                    item.SchoolBus = null;
                }
            }

            var exists = _context.Inspections.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.Inspections.Update(item);
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

        /// <param name="item"></param>
        /// <response code="201">Inspection created</response>

        public virtual IActionResult InspectionsPostAsync (Inspection item)        
        {
            // adjust the user
            if (item.Inspector != null)
            {
                int user_id = item.Inspector.Id;
                bool user_exists = _context.Users.Any(a => a.Id == user_id);
                if (user_exists)
                {
                    User user = _context.Users.First(a => a.Id == user_id);
                    item.Inspector = user;
                }
                else
                {
                    item.Inspector = null;
                }
            }
            // adjust the schoolbus
            if (item.SchoolBus != null)
            {
                int schoolbus_id = item.SchoolBus.Id;
                bool schoolbus_exists = _context.SchoolBuss.Any(a => a.Id == schoolbus_id);
                if (schoolbus_exists)
                {
                    SchoolBus schoolbus = _context.SchoolBuss.First(a => a.Id == schoolbus_id);
                    item.SchoolBus = schoolbus;
                }
                else
                {
                    item.SchoolBus = null;
                }
            }


            var exists = _context.Inspections.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.Inspections.Update(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                // Inspection has a special field, createdDate which is set to now.
                item.CreatedDate = DateTime.Now;
                _context.Inspections.Add(item);
            }
                        
            _context.SaveChanges();
            return new ObjectResult(item);
        }         
    }
}
