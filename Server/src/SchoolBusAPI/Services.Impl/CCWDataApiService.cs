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
    public class CCWDataApiService : ICCWDataApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public CCWDataApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">CCWData created</response>
        public virtual IActionResult CcwdataBulkPostAsync(CCWData[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (CCWData item in items)
            {

                bool exists = _context.CCWDatas.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.CCWDatas.Update(item);
                }
                else
                {
                    _context.CCWDatas.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult CcwdataGetAsync()
        {
            var result = _context.CCWDatas.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdDeletePostAsync(int id)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.CCWDatas.First(a => a.Id == id);
                if (item != null)
                {
                    _context.CCWDatas.Remove(item);
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
        /// <param name="id">id of CCWData to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdGetAsync(int id)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.CCWDatas.First(a => a.Id == id);
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
        /// <param name="id">id of CCWData to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdPutAsync(int id, CCWData item)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.CCWDatas.Update(item);
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
        /// <param name="item"></param>
        /// <response code="201">CCWData created</response>
        public virtual IActionResult CcwdataPostAsync(CCWData item)
        {
            _context.CCWDatas.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
