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
    public class SchoolBusApiService : ISchoolBusApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new school bus
        /// </summary>
        /// <remarks>The Location response-header field is used to redirect the recipient to a location other than the Request-URI for completion of the request or identification of a new resource. For 201 (Created) responses, the Location is that of the new resource which was created by the request.    The field value consists of a single absolute URI. </remarks>
        /// <param name="body"></param>
        /// <response code="201">SchoolBus created</response>
        public virtual IActionResult AddBusAsync(SchoolBus body)
        {
            string exampleJson = null;

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SchoolBus>(exampleJson)
            : default(SchoolBus);
            return new ObjectResult(example);
        }

        /// <summary>
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="schoolbusId">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        public virtual IActionResult FindBusByIdAsync(int id)
        {
            var result = _context.SchoolBuss.First(a => a.Id == id);
            return new ObjectResult(result);
        }

        /// <summary>
        /// Returns a collection of school buses
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult GetAllBusesAsync()
        {
            var result = _context.SchoolBuss;
            return new ObjectResult(result);
        }

        public virtual IActionResult SchoolbusesIdAttachmentsGetAsync(int id)
        {
            var result = _context.SchoolBusAttachments.All(a => a.SchoolBus.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult SchoolbusesIdCcwdataGetAsync(int id)
        {
            var result = "";
            // need to fix CCWDatas so it relates to the bus.
//            var result = _context.CCWDatas.First(a => a.SchoolBus.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult SchoolbusesIdHistoryGetAsync(int id)
        {
            var result = _context.SchoolBusHistorys.All(a => a.SchoolBus.Id == id);
            return new ObjectResult(result);            
        }
        public virtual IActionResult SchoolbusesIdNotesGetAsync(int id)
        {
            var result = _context.SchoolBusNotes.All(a => a.SchoolBus.Id == id);
            return new ObjectResult(result);
        }
    }
}
