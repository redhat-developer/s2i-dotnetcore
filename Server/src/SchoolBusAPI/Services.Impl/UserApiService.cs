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
    public class UserApiService : IUserApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public UserApiService(DbAppContext context)
        {
            _context = context;
        }
        public IActionResult UsersIdFavouritesGetAsync(int id)
        {
            return new ObjectResult("");
        }

        public IActionResult UsersIdGetAsync(int id)
        {
            return new ObjectResult("");
        }

        public IActionResult UsersIdNotificationGetAsync(int id)
        {
            return new ObjectResult("");
        }
    }
}
