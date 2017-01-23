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
    public class NoteService : INoteService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public NoteService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="items"></param>
        /// <response code="201">Notes created</response>

        public virtual IActionResult NotesBulkPostAsync (Note[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Note item in items)
            {
                _context.Notes.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult NotesGetAsync ()        
        {
            var result = _context.Notes.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Note to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>

        public virtual IActionResult NotesIdDeletePostAsync (int id)        
        {
            var exists = _context.Notes.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Notes.First(a => a.Id == id);            
                _context.Notes.Remove(item);
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
        
        /// <param name="id">id of Note to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>

        public virtual IActionResult NotesIdGetAsync (int id)        
        {
            var exists = _context.Notes.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Notes.First(a => a.Id == id);
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
        
        /// <param name="id">id of Note to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Note not found</response>

        public virtual IActionResult NotesIdPutAsync (int id, Note body)        
        {
            var exists = _context.Notes.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Notes.Update(body);
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
        /// <response code="201">Note created</response>

        public virtual IActionResult NotesPostAsync (Note body)        
        {
            _context.Notes.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
