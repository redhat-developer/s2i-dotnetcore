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
