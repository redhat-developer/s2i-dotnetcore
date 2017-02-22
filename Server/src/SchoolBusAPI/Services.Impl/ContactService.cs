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
    public class ContactService : IContactService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public ContactService (DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="items"></param>
        /// <response code="201">Contacts created</response>

        public virtual IActionResult ContactsBulkPostAsync (Contact[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Contact item in items)
            {                
                var exists = _context.Contacts.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Contacts.Update(item);
                }
                else
                {
                    _context.Contacts.Add(item);
                }                
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of Contact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>

        public virtual IActionResult ContactsIdDeletePostAsync (int id)        
        {
            var exists = _context.Contacts.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Contacts.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Contacts.Remove(item);
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
        
        /// <param name="id">id of Contact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>

        public virtual IActionResult ContactsIdGetAsync (int id)        
        {
            var exists = _context.Contacts.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Contacts.First(a => a.Id == id);
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
        /// <response code="200">OK</response>
        public virtual IActionResult ContactsGetAsync()
        {
            var result = _context.Contacts.ToList();
            return new ObjectResult(result);
        }

        
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Contact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>

        public virtual IActionResult ContactsIdPutAsync (int id, Contact body)        
        {
            var exists = _context.Contacts.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Contacts.Update(body);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public virtual IActionResult ContactsPostAsync(Contact body)
        {
            _context.Contacts.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
