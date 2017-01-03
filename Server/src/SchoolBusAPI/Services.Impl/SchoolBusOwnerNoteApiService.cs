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
    public class SchoolBusOwnerNoteApiService : ISchoolBusOwnerNoteApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerNoteApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerNotes created</response>
        public virtual IActionResult SchoolbusownernotesBulkPostAsync(SchoolBusOwnerNote[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwnerNote item in items)
            {
                _context.SchoolBusOwnerNotes.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownernotesGetAsync()
        {
            var result = _context.SchoolBusOwnerNotes.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerNote to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        public virtual IActionResult SchoolbusownernotesIdDeleteAsync(int id)
        {
            var exists = _context.SchoolBusOwnerNotes.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusOwnerNotes.First(a => a.Id == id);            
                _context.SchoolBusOwnerNotes.Remove(item);
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
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        public virtual IActionResult SchoolbusownernotesIdGetAsync(int id)
        {
            var exists = _context.SchoolBusOwnerNotes.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerNotes.First(a => a.Id == id);
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
        /// <param name="id">id of SchoolBusOwnerNote to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerNote not found</response>
        public virtual IActionResult SchoolbusownernotesIdPutAsync(int id, SchoolBusOwnerNote item)
        {
            var exists = _context.SchoolBusOwnerNotes.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.SchoolBusOwnerNotes.First(a => a.Id == id);
                dbItem.Expired = item.Expired;                                
                _context.SchoolBusOwnerNotes.Update(dbItem);
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
        /// <response code="201">SchoolBusOwnerNote created</response>
        public virtual IActionResult SchoolbusownernotesPostAsync(SchoolBusOwnerNote item)
        {
            _context.SchoolBusOwnerNotes.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
