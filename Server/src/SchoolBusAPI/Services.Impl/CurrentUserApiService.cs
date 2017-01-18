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
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class CurrentUserApiService : ICurrentUserApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public CurrentUserApiService (DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Removes all of the current user&#39;s favourites</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult UsersCurrentFavouritesDeletePostAsync()
        {
            var data = _context.UserFavourites.Select(x => x);
            // TODO only select the current user's data.  
            foreach (var item in data)
            {
                _context.UserFavourites.Remove(item);
            }
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new favourite for the current user</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        public virtual IActionResult UsersCurrentFavouritesPostAsync(UserFavourite item)
        {
            bool exists = _context.UserFavourites.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.UserFavourites.Update(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                // record not found. add the record.
                _context.UserFavourites.Add(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a favourite</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        public virtual IActionResult UsersCurrentFavouritesPutAsync(UserFavourite item)
        {
            bool exists = _context.UserFavourites.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.UserFavourites.Update(item);
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
        /// <remarks>Returns a user&#39;s favourites of a given type.  If type is empty, returns all.</remarks>
        /// <param name="type">type of favourite to return</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersCurrentFavouritesTypeGetAsync(string type)
        {
            var data = _context.UserFavourites.Select(x => x);
            if (type != null)
            {
                data = data.Where( x => x.Type == type);
            }
            
            return new ObjectResult(data.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get the currently logged in user</remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult UsersCurrentGetAsync ()        
        {
            var result = new CurrentUserViewModel();
            // get the name for the current logged in user
            result.GivenName = "Test";
            result.Surname = "User";
            result.FullName = result.GivenName + " " + result.Surname;
            result.OverdueInspections = 1;
            result.DueNextMonthInspections = 2;
            result.DistrictName = "Victoria";
            result.ScheduledInspections = 3;

            // get the number of inspections available for the current logged in user

            return new ObjectResult(result);
        }
    }
}
