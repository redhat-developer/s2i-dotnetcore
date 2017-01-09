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
    public class ServiceAreaApiService : IServiceAreaApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public ServiceAreaApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of districts.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasBulkPostAsync(ServiceArea[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (ServiceArea item in items)
            {
                _context.ServiceAreas.Add(item);
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available districts</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasGetAsync()
        {
            var result = _context.ServiceAreas.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a Service Area</remarks>
        /// <param name="id">id of Service Area to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Service Area not found</response>
        public virtual IActionResult ServiceareasIdDeletePostAsync(int id)
        {
            var exists = _context.ServiceAreas.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.ServiceAreas.First(a => a.Id == id);
                if (item != null)
                {
                    _context.ServiceAreas.Remove(item);
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
        /// <remarks>Returns a specific Service Area</remarks>
        /// <param name="id">id of Service Area to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasIdGetAsync(int id)
        {
            var exists = _context.ServiceAreas.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.ServiceAreas.First(a => a.Id == id);
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
        /// <remarks>Updates a Service Area</remarks>
        /// <param name="id">id of Service Area to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Service Area not found</response>
        public virtual IActionResult ServiceareasIdPutAsync(int id, ServiceArea body)
        {
            var exists = _context.ServiceAreas.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.ServiceAreas.Update(body);
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
        /// <remarks>Adds a Service Area</remarks>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasPostAsync(ServiceArea body)
        {
            _context.ServiceAreas.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
