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
    public class SchoolBusHistoryApiService : ISchoolBusHistoryApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusHistoryApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusHistories created</response>
        public virtual IActionResult SchoolbushistoriesBulkPostAsync(SchoolBusHistory[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusHistory item in items)
            {
                _context.SchoolBusHistorys.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbushistoriesGetAsync()
        {
            var result = _context.SchoolBusHistorys.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusHistory to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>
        public virtual IActionResult SchoolbushistoriesIdDeleteAsync(int id)
        {
            var exists = _context.SchoolBusHistorys.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusHistorys.First(a => a.Id == id);           
                _context.SchoolBusHistorys.Remove(item);
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
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>
        public virtual IActionResult SchoolbushistoriesIdGetAsync(int id)
        {
            var exists = _context.SchoolBusHistorys.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusHistorys.First(a => a.Id == id);
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
        /// <param name="id">id of SchoolBusHistory to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusHistory not found</response>
        public virtual IActionResult SchoolbushistoriesIdPutAsync(int id, SchoolBusHistory item)
        {
            var exists = _context.SchoolBusHistorys.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.SchoolBusHistorys.First(a => a.Id == id);
                dbItem.SchoolBus = item.SchoolBus;                
                _context.SchoolBusHistorys.Update(dbItem);                
                // Save the changes
                _context.SaveChanges();            
                return new ObjectResult(dbItem);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusHistory created</response>
        public virtual IActionResult SchoolbushistoriesPostAsync(SchoolBusHistory item)
        {
            _context.SchoolBusHistorys.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
