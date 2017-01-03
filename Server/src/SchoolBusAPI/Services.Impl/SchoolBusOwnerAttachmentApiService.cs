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
    public class SchoolBusOwnerAttachmentApiService : ISchoolBusOwnerAttachmentApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerAttachmentApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerAttachments created</response>
        public virtual IActionResult SchoolbusownerattachmentsBulkPostAsync(SchoolBusOwnerAttachment[] items)
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
        public virtual IActionResult SchoolbusownerattachmentsGetAsync()
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
        public virtual IActionResult SchoolbusownerattachmentsIdDeleteAsync(int id)
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
        public virtual IActionResult SchoolbusownerattachmentsIdGetAsync(int id)
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
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        public virtual IActionResult SchoolbusownerattachmentsIdPutAsync(int id, SchoolBusOwnerAttachment item)
        {
            var exists = _context.SchoolBusOwnerAttachments.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.SchoolBusOwnerAttachments.First(a => a.Id == id);
                dbItem.SchoolBusOwner = item.SchoolBusOwner;                            
                _context.SchoolBusOwnerAttachments.Update(dbItem);
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
        /// <response code="201">SchoolBusOwnerAttachment created</response>
        public virtual IActionResult SchoolbusownerattachmentsPostAsync(SchoolBusOwnerAttachment item)
        {
            _context.SchoolBusOwnerAttachments.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
