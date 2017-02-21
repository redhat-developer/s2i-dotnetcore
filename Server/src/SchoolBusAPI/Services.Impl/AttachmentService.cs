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
using System.Net.Http;
using Microsoft.Net.Http.Headers;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class AttachmentService : IAttachmentService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public AttachmentService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="items"></param>
        /// <response code="201">Attachments created</response>

        public virtual IActionResult AttachmentsBulkPostAsync (Attachment[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Attachment item in items)
            {
                _context.Attachments.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult AttachmentsGetAsync ()        
        {
            var result = _context.Attachments.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Attachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>

        public virtual IActionResult AttachmentsIdDeletePostAsync (int id)        
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Attachments.First(a => a.Id == id);                
                _context.Attachments.Remove(item);
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
        /// Returns the binary file component of an attachment
        /// </summary>
        /// <param name="id">Attachment Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found in system</response>
        public virtual IActionResult AttachmentsIdDownloadGetAsync(int id)
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists)
            {
                var attachment = _context.Attachments.First(a => a.Id == id);
                // 
                // MOTI has requested that files be stored in the database.
                //                                           
                var result = new FileContentResult(attachment.FileContents, "application/octet-stream");
                result.FileDownloadName = attachment.FileName;
                
                return result;
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Attachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>

        public virtual IActionResult AttachmentsIdGetAsync (int id)        
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Attachments.First(a => a.Id == id);
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
        
        /// <param name="id">id of Attachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>

        public virtual IActionResult AttachmentsIdPutAsync (int id, Attachment body)        
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Attachments.Update(body);
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
        /// <response code="201">Attachment created</response>

        public virtual IActionResult AttachmentsPostAsync (Attachment body)        
        {
            _context.Attachments.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
