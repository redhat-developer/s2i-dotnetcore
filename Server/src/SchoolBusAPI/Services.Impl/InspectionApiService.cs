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


        public IActionResult InspectionsGetAsync()
        {
            return new ObjectResult("");
        }

        public IActionResult InspectionsIdGetAsync(int id)
        {
            return new ObjectResult("");
        }

        public IActionResult SchoolbusIdInspectionsGetAsync(int id)
        {
            return new ObjectResult("");
        }        
    }
}


