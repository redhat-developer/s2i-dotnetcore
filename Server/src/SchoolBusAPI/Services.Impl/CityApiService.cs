/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
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
    public class CityApiService : ICityApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public CityApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of cities</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult CitiesBulkPostAsync(City[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (City item in items)
            {
                _context.Cities.Add(item);
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of cities</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult CitiesGetAsync()
        {
            var result = _context.Cities.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a City</remarks>
        /// <param name="id">id of City to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">City not found</response>
        public virtual IActionResult CitiesIdDeletePostAsync(int id)
        {
            var exists = _context.Cities.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Cities.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Cities.Remove(item);
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
        /// <remarks>Returns a specific City by ID</remarks>
        /// <param name="id">id of City to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult CitiesIdGetAsync(int id)
        {
            var exists = _context.Cities.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Cities.First(a => a.Id == id);
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
        /// <remarks>Updates a City</remarks>
        /// <param name="id">id of City to update</param>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        /// <response code="404">City not found</response>
        public virtual IActionResult CitiesIdPutAsync(int id, City body)
        {
            var exists = _context.Cities.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Cities.Update(body);
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
        /// <remarks>Adds a City</remarks>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult CitiesPostAsync(City body)
        {
            _context.Cities.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
