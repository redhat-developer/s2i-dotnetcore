/*
 * REST API Documentation for Schoolbus
 *
 * This project is to replace the existing permitting and inspection scheduling functionality in AVIS  such that the mainframe application can be retired. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;
using Newtonsoft.Json;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class InspectionApiService : IInspectionApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public InspectionApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all inspections.
        /// </summary>
        /// <returns></returns>
        public IActionResult InspectionsGetAsync()
        {
            var result = _context.Inspections;
            return new ObjectResult(result);
        }

        /// <summary>
        /// Returns an inspection
        /// </summary>
        /// <param name="id">Inspection id</param>
        /// <returns></returns>
        public IActionResult InspectionsIdGetAsync(int id)
        {
            var result = _context.Inspections.First(a => a.Id == id);
            return new ObjectResult(result);
        }

        /// <summary>
        /// Returns all inspections for a given SchoolBus.
        /// </summary>
        /// <param name="id">The SchoolBus id</param>
        /// <returns></returns>
        public IActionResult SchoolbusIdInspectionsGetAsync(int id)
        {
            var result = _context.Inspections.All(a => a.SchoolBus.Id == id);
            return new ObjectResult(result);
        }        
    }
}


