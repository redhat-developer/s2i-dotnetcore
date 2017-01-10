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
using Microsoft.EntityFrameworkCore;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusApiService : ISchoolBusApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// Creates a new school bus
        /// </summary>
        /// <remarks>The Location response-header field is used to redirect the recipient to a location other than the Request-URI for completion of the request or identification of a new resource. For 201 (Created) responses, the Location is that of the new resource which was created by the request.    The field value consists of a single absolute URI. </remarks>
        /// <param name="body"></param>
        /// <response code="201">SchoolBus created</response>

        public virtual IActionResult AddBusAsync (SchoolBus body)        
        {
            _context.SchoolBuss.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);            
        }
        /// <summary>
        /// Creates several school buses
        /// </summary>
        /// <remarks>Used for bulk creation of schoolbus records.</remarks>
        /// <param name="body"></param>
        /// <response code="201">SchoolBus items created</response>

        public virtual IActionResult AddSchoolBusBulkAsync (SchoolBus[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBus item in items)
            {
                var exists = _context.SchoolBuss.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.SchoolBuss.Update(item);
                }
                else
                {
                    _context.SchoolBuss.Add(item);
                }                
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>

        public virtual IActionResult FindBusByIdAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBuss.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// Returns a collection of school buses
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult GetAllBusesAsync ()        
        {
            var result = _context.SchoolBuss.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdAttachmentsGetAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusAttachments.Where(a => a.SchoolBus.Id == id);
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
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusesIdCcwdataGetAsync (int id)        
        {
            // TODO: need to fix the model for CCWData
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBus to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdDeletePostAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBuss.First(a => a.Id == id);
                if (item != null)
                {
                    _context.SchoolBuss.Remove(item);
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
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch SchoolBusHistory for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusesIdHistoryGetAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusHistorys.Where(a => a.SchoolBus.Id == id);
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
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdNotesGetAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusNotes.Where(a => a.SchoolBus.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// Updates a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>

        public virtual IActionResult SchoolbusesIdPutAsync (int id, SchoolBus body)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.SchoolBuss.Update(body);                
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

        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdInspectionsGetAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var items = _context.Inspections.Where(a => a.SchoolBus.Id == id);
                return new ObjectResult(items);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
    }
}
