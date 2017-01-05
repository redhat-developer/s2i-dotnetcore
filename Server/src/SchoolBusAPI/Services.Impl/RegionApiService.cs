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
    public class RegionApiService : IRegionApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public RegionApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of regions.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult RegionsBulkPostAsync(Region[] items)
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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available regions</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult RegionsGetAsync()
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
        public virtual IActionResult RegionsIdCitiesGetAsync(int id)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Cities.Where(a => a.Region.Id == id);
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
        /// <remarks>Deletes a region</remarks>
        /// <param name="id">id of Region to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        public virtual IActionResult RegionsIdDeleteAsync(int id)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Regions.First(a => a.Id == id);
                _context.Regions.Remove(item);
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
        /// <remarks>Returns a specific region</remarks>
        /// <param name="id">id of Regions to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult RegionsIdGetAsync(int id)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Regions.First(a => a.Id == id);
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
        /// <remarks>Returns a list of LocalAreas for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult RegionsIdServiceareasGetAsync(int id)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.ServiceAreas.Where(a => a.District.Id == id);
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
        /// <remarks>Updates a region</remarks>
        /// <param name="id">id of Region to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        public virtual IActionResult RegionsIdPutAsync(int id, Region item)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var region = _context.Regions.First(a => a.Id == id);
                // update data
                region.Name = item.Name;                
                _context.Entry(region).State = EntityState.Modified;
                // save the changes
                _context.SaveChanges();
                return new ObjectResult(region);
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
        /// <remarks>Adds a region</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult RegionsPostAsync(Region item)
        {
            _context.Regions.Add(item);        
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
