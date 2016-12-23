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
    public class SchoolBusAttachmentApiService : ISchoolBusAttachmentApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusAttachmentApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusAttachments created</response>

        public virtual IActionResult SchoolbusattachmentsBulkPostAsync (SchoolBusAttachment[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusAttachment item in items)
            {
                _context.SchoolBusAttachments.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusattachmentsGetAsync ()        
        {
            var result = _context.SchoolBusAttachments.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>

        public virtual IActionResult SchoolbusattachmentsIdDeleteAsync (int id)        
        {
            var exists = _context.SchoolBusAttachments.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusAttachments.First(a => a.Id == id);
                _context.SchoolBusAttachments.Remove(item);
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
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>

        public virtual IActionResult SchoolbusattachmentsIdGetAsync (int id)        
        {
            var exists = _context.SchoolBusAttachments.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusAttachments.First(a => a.Id == id);            
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
        
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>

        public virtual IActionResult SchoolbusattachmentsIdPutAsync (int id, SchoolBusAttachment body)        
        {
            var exists = _context.SchoolBusAttachments.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusAttachments.First(a => a.Id == id);
                item.ExternalFileName = body.ExternalFileName;
                item.InternalFileName = body.InternalFileName;
                item.SchoolBus = body.SchoolBus;                
                _context.SchoolBusAttachments.Update(item);
                // Save the changes
                _context.SaveChanges();
                return new StatusCodeResult(200);
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
        /// <response code="201">SchoolBusAttachment created</response>

        public virtual IActionResult SchoolbusattachmentsPostAsync (SchoolBusAttachment body)        
        {
            _context.SchoolBusAttachments.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
       
    }
}
