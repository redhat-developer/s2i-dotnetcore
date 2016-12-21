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
    public class RegionApiService : IRegionApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public RegionApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of regions for a given province</remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsGetAsync ()        
        {
            var result = _context.Regions.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of cities for a given region</remarks>
        /// <param name="id">id of Region to fetch Cities for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsIdCitiesGetAsync (int id)        
        {
            var result = _context.Cities.All(a => a.Region.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific region</remarks>
        /// <param name="id">id of Regions to fetch</param>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsIdGetAsync (int id)        
        {
            var result = _context.Regions.First(a => a.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of LocalAreas for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsIdLocalareasGetAsync (int id)        
        {
            var result = _context.LocalAreas.All(a => a.Region.Id == id);
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a regions.</remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsPostAsync (Region [] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Region item in items)
            {
                _context.Regions.Add(item);
            }
            // Save the changes
            _context.SaveChanges();
            
            return new NoContentResult();
        }
    }
}
