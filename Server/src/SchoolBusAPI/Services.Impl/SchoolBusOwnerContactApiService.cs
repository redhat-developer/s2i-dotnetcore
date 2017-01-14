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
    public class SchoolBusOwnerContactApiService : ISchoolBusOwnerContactApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerContactApiService (DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerContacts created</response>

        public virtual IActionResult SchoolbusownercontactsBulkPostAsync (SchoolBusOwnerContact[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwnerContact item in items)
            {                
                var exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.SchoolBusOwnerContacts.Update(item);
                }
                else
                {
                    _context.SchoolBusOwnerContacts.Add(item);
                }                
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwnerContact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>

        public virtual IActionResult SchoolbusownercontactsIdDeletePostAsync (int id)        
        {
            var exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusOwnerContacts.First(a => a.Id == id);
                if (item != null)
                {
                    _context.SchoolBusOwnerContacts.Remove(item);
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
        
        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>

        public virtual IActionResult SchoolbusownercontactsIdGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerContacts.First(a => a.Id == id);
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
        public virtual IActionResult SchoolbusownercontactsGetAsync()
        {
            var result = _context.SchoolBusOwnerContacts.ToList();
            return new ObjectResult(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>
        public IActionResult SchoolbusownercontactsIdContactaddressesGetAsync(int id)
        {
            var exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerContacts.First(a => a.Id == id);
                return new ObjectResult(result.SchoolBusOwnerContactAddresses.ToList());
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
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>
        public IActionResult SchoolbusownercontactsIdContactphonesGetAsync(int id)
        {
            var exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerContacts.First(a => a.Id == id);
                return new ObjectResult(result.SchoolBusOwnerContactAddresses.ToList());
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

        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>

        public virtual IActionResult SchoolbusownercontactsIdPutAsync (int id, SchoolBusOwnerContact body)        
        {
            var exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.SchoolBusOwnerContacts.Update(body);
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
        public virtual IActionResult SchoolbusownercontactsPostAsync(SchoolBusOwnerContact body)
        {
            _context.SchoolBusOwnerContacts.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
