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
    public class SchoolBusNoteApiService : ISchoolBusNoteApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusNoteApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusNotes created</response>
        public virtual IActionResult SchoolbusnotesBulkPostAsync(SchoolBusNote[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusNote item in items)
            {
                _context.SchoolBusNotes.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusnotesGetAsync()
        {
            var result = _context.Inspections.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusNote to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        public virtual IActionResult SchoolbusnotesIdDeleteAsync(int id)
        {
            var exists = _context.SchoolBusNotes.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusNotes.First(a => a.Id == id);            
                _context.SchoolBusNotes.Remove(item);
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
        /// <param name="id">id of SchoolBusNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        public virtual IActionResult SchoolbusnotesIdGetAsync(int id)
        {
            var exists = _context.SchoolBusNotes.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusNotes.First(a => a.Id == id);
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
        /// <param name="id">id of SchoolBusNote to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        public virtual IActionResult SchoolbusnotesIdPutAsync(int id, SchoolBusNote item)
        {
            var exists = _context.SchoolBusNotes.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.SchoolBusNotes.First(a => a.Id == id);
                dbItem.Expired = item.Expired;
                dbItem.SchoolBus = item.SchoolBus;
                dbItem.Value = item.Value;                               
                _context.SchoolBusNotes.Update(dbItem);
                // Save the changes
                _context.SaveChanges();            
                return new ObjectResult(dbItem);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusNote created</response>
        public virtual IActionResult SchoolbusnotesPostAsync(SchoolBusNote item)
        {
            _context.SchoolBusNotes.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
