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
    public class SchoolBusOwnerApiService : ISchoolBusOwnerApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerApiService(DbAppContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns list of available FavouriteContextTypes</remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult FavouritecontexttypesGetAsync ()        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwners created</response>

        public virtual IActionResult SchoolbusownersBulkPostAsync (List<SchoolBusOwner> body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersGetAsync ()        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdAttachmentsGetAsync (int id)        
        {
            var result = _context.SchoolBusOwnerAttachments.All(a => a.SchoolBusOwner.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdContactaddressesGetAsync (int id)        
        {
            var result = _context.SchoolBusOwnerContactAddresss.All(a => a.SchoolBusOwnerContact.SchoolBusOwner.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdContactphonesGetAsync (int id)        
        {
            var result = _context.SchoolBusOwnerContactPhones.All(a => a.SchoolBusOwnerContact.SchoolBusOwner.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>

        public virtual IActionResult SchoolbusownersIdDeleteAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdGetAsync (int id)        
        {
            var result = _context.SchoolBusOwners.First(a => a.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdNotesGetAsync (int id)        
        {
            var result = _context.SchoolBusOwnerNotes.All(a => a.SchoolBusOwner.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>

        public virtual IActionResult SchoolbusownersIdPutAsync (int id)        
        {
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwner created</response>

        public virtual IActionResult SchoolbusownersPostAsync (SchoolBusOwner body)        
        {
            var result = "";
            return new ObjectResult(result);
        }
    }
}
