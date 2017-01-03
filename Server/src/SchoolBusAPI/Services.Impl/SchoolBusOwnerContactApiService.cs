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
    public class SchoolBusOwnerContactApiService : ISchoolBusOwnerContactApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerContactApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerContacts created</response>
        public virtual IActionResult SchoolbusownercontactsBulkPostAsync(SchoolBusOwnerContact[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwnerContact item in items)
            {
                _context.SchoolBusOwnerContacts.Add(item);
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownercontactsGetAsync()
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerContact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        public virtual IActionResult SchoolbusownercontactsIdDeleteAsync(int id)
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
        public virtual IActionResult SchoolbusownercontactsIdGetAsync(int id)
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
        /// <param name="id">id of SchoolBusOwnerContact to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerContact not found</response>
        public virtual IActionResult SchoolbusownercontactsIdPutAsync(int id, SchoolBusOwnerContact item)
        {
            var exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.SchoolBusOwnerContacts.First(a => a.Id == id);
                if (dbItem != null)
                {
                    dbItem.SchoolBusOwner = item.SchoolBusOwner;                    
                    _context.SchoolBusOwnerContacts.Update(dbItem);
                    // Save the changes
                    _context.SaveChanges();
                }
                return new ObjectResult(dbItem);
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
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwnerContact created</response>
        public virtual IActionResult SchoolbusownercontactsPostAsync(SchoolBusOwnerContact item)
        {
            _context.SchoolBusOwnerContacts.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
