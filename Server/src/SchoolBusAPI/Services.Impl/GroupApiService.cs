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
using SchoolBusAPI.Mappings;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class GroupApiService : IGroupApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public GroupApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Groups created</response>
        public IActionResult GroupsBulkPostAsync(Group[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Group item in items)
            {                

                bool exists = _context.Groups.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Groups.Update(item);
                }
                else
                {
                    _context.Groups.Add(item);
                }               
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of groups</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult GroupsGetAsync()
        {
            var result = _context.Groups.Select(x => x.ToViewModel()).ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdDeletePostAsync(int id)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Groups.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Groups.Remove(item);
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
        /// <remarks>Returns a Group</remarks>
        /// <param name="id">id of Group to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdGetAsync(int id)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Groups.First(a => a.Id == id);
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
        /// <param name="id">id of Group to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdPutAsync(int id, Group item)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.Groups.Update(item);
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
        /// <response code="201">Group created</response>
        public IActionResult GroupsPostAsync(Group item)
        {
            _context.Groups.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }


    }
}
