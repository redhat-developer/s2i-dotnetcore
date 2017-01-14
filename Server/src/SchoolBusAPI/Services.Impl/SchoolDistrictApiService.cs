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
    public class SchoolDistrictApiService : ISchoolDistrictApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolDistrictApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of SchoolDistricts for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchooldistrictsIdGetAsync (int id)        
        {
            var result = _context.SchoolDistricts.Where(a => a.Id == id);
            return new ObjectResult(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of school districts.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchooldistrictsBulkPostAsync(SchoolDistrict[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolDistrict item in items)
            {                
                var exists = _context.SchoolDistricts.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.SchoolDistricts.Update(item);
                }
                else
                {
                    _context.SchoolDistricts.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available schooldistricts</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult SchooldistrictsGetAsync()
        {
            var result = _context.SchoolDistricts.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a School District</remarks>
        /// <param name="id">id of School District to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
        public virtual IActionResult SchooldistrictsIdDeletePostAsync(int id)
        {
            var exists = _context.SchoolDistricts.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolDistricts.First(a => a.Id == id);
                if (item != null)
                {
                    _context.SchoolDistricts.Remove(item);
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
        /// <remarks>Updates a school district</remarks>
        /// <param name="id">id of School District to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
        public virtual IActionResult SchooldistrictsIdPutAsync(int id, SchoolDistrict item)
        {
            var exists = _context.SchoolDistricts.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.SchoolDistricts.Update(item);
                // Save the changes
                _context.SaveChanges();
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
        /// <remarks>Adds a school district</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchooldistrictsPostAsync(SchoolDistrict item)
        {
            _context.SchoolDistricts.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
