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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class InspectionApiService : IInspectionApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public InspectionApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Inspections created</response>
        public virtual IActionResult InspectionsBulkPostAsync(Inspection[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Inspection item in items)
            {
                _context.Inspections.Add(item);
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult InspectionsGetAsync()
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
        public virtual IActionResult InspectionsIdDeleteAsync(int id)
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
        public virtual IActionResult InspectionsIdGetAsync(int id)
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
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        public virtual IActionResult InspectionsIdPutAsync(int id, Inspection item)
        {
            // TODO Fix PUT operations
            var exists = _context.Inspections.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.Inspections.First(a => a.Id == id);
                if (dbItem != null)
                {
                    _context.Inspections.Update(dbItem);
                    // Save the changes
                    _context.SaveChanges();
                }
                return new ObjectResult(dbItem);
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
        public virtual IActionResult InspectionsPostAsync(Inspection item)
        {
            _context.Inspections.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }         
    }
}
