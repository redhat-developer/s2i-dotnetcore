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
using Newtonsoft.Json;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserApiService
    {
        /// <summary>
        /// Returns Favorites for a given User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IActionResult UsersIdFavouritesGetAsync(int id);

        /// <summary>
        /// Returns a User
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        IActionResult UsersIdGetAsync(int id);

        /// <summary>
        /// Used to get notifications for a user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Array of notifications</returns>
        IActionResult UsersIdNotificationGetAsync(int id);
    }
}
