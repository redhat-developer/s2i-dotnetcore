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
        /// 
        /// </summary>

        /// <param name="body"></param>
        /// <response code="201">Inspections created</response>        

        public IActionResult InspectionsBulkPostAsync(List<Inspection> body)
        {
            return new ObjectResult("");
        }

        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// Returns all inspections.
        /// </summary>
        /// <returns></returns>
        public IActionResult InspectionsGetAsync()
        {
            var result = _context.Inspections.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Inspection to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>        

        public IActionResult InspectionsIdDeleteAsync(int id)
        {
            return new ObjectResult("");
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>        

        public IActionResult InspectionsIdGetAsync(int id)
        {
            var result = _context.Inspections.First(a => a.Id == id);
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>        

        public IActionResult InspectionsIdPutAsync(int id)
        {
            return new ObjectResult("");
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="body"></param>
        /// <response code="201">Inspection created</response>        

        public IActionResult InspectionsPostAsync(Inspection body)
        {
            return new ObjectResult("");
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>        

        public IActionResult SchoolbusIdInspectionsGetAsync(int id)
        {
            var result = _context.Inspections.All(a => a.Id == id);
            return new ObjectResult(result);
        }        
    }
}


