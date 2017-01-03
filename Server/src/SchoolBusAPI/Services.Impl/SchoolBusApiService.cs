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
        /// <param name="item"></param>
        /// <response code="201">SchoolBus created</response>
        public virtual IActionResult AddBusAsync(SchoolBus item)
        {
            _context.SchoolBuss.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);            
        }

        /// <summary>
        /// Creates several school buses
        /// </summary>
        /// <remarks>Used for bulk creation of schoolbus records.</remarks>
        /// <param name="items"></param>
        /// <response code="201">SchoolBus items created</response>
        public virtual IActionResult AddSchoolBusBulkAsync(SchoolBus[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBus item in items)
            {
                _context.SchoolBuss.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        public virtual IActionResult FindBusByIdAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBuss.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// Returns a collection of school buses
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult GetAllBusesAsync()
        {
            var result = _context.SchoolBuss.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        public virtual IActionResult SchoolbusesIdAttachmentsGetAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusAttachments.Where(a => a.SchoolBus.Id == id);
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
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusesIdCcwdataGetAsync(int id)
        {
            // TODO: need to fix the model for CCWData
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        public virtual IActionResult SchoolbusesIdDeleteAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBuss.First(a => a.Id == id);
                if (item != null)
                {
                    _context.SchoolBuss.Remove(item);
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
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch SchoolBusHistory for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusesIdHistoryGetAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusHistorys.Where(a => a.SchoolBus.Id == id);
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
        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        public virtual IActionResult SchoolbusesIdInspectionsGetAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var items = _context.Inspections.Where(a => a.SchoolBus.Id == id);
                return new ObjectResult(items);
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
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        public virtual IActionResult SchoolbusesIdNotesGetAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusNotes.Where(a => a.SchoolBus.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// Updates a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        public virtual IActionResult SchoolbusesIdPutAsync(int id, SchoolBus item)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {

                var dbItem = _context.SchoolBuss.First(a => a.Id == id);
                // can only update certain fields.
                dbItem.CCWData = item.CCWData;
                dbItem.CRNO = item.CRNO;
                dbItem.IsActive = item.IsActive;
                dbItem.NameOfIndependentSchool = item.NameOfIndependentSchool;
                dbItem.NextInspection = item.NextInspection;
                dbItem.SchoolBusOwner = item.SchoolBusOwner;

                _context.Entry(dbItem).State = EntityState.Modified;
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(dbItem);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
            
        }
    }
}
