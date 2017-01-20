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
    public class SchoolBusOwnerAttachmentService : ISchoolBusOwnerAttachmentService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerAttachmentService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerAttachments created</response>

        public virtual IActionResult SchoolbusownerattachmentsBulkPostAsync (SchoolBusOwnerAttachment[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwnerAttachment item in items)
            {
                _context.SchoolBusOwnerAttachments.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownerattachmentsGetAsync ()        
        {
            var result = _context.SchoolBusOwnerAttachments.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>

        public virtual IActionResult SchoolbusownerattachmentsIdDeletePostAsync (int id)        
        {
            var exists = _context.SchoolBusOwnerAttachments.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusOwnerAttachments.First(a => a.Id == id);                
                _context.SchoolBusOwnerAttachments.Remove(item);
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
        
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>

        public virtual IActionResult SchoolbusownerattachmentsIdGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwnerAttachments.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerAttachments.First(a => a.Id == id);
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
        
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>

        public virtual IActionResult SchoolbusownerattachmentsIdPutAsync (int id, SchoolBusOwnerAttachment body)        
        {
            var exists = _context.SchoolBusOwnerAttachments.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.SchoolBusOwnerAttachments.Update(body);
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
        /// <response code="201">SchoolBusOwnerAttachment created</response>

        public virtual IActionResult SchoolbusownerattachmentsPostAsync (SchoolBusOwnerAttachment body)        
        {
            _context.SchoolBusOwnerAttachments.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
