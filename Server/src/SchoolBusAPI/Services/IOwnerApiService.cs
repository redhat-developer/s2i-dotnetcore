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
    public interface IOwnerApiService
    {
        /// <summary>
        /// Returns a list of available favorite context types
        /// </summary>
        /// <returns></returns>
        IActionResult FavouritecontexttypesGetAsync();

        /// <summary>
        /// Returns attachments for a given owner
        /// </summary>
        /// <param name="id">Owner id</param>
        /// <returns></returns>
        IActionResult OwnersIdAttachmentsGetAsync(int id);

        /// <summary>
        /// Returns Contact Addresses for a given Owner ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IActionResult OwnersIdContactaddressesGetAsync(int id);

        /// <summary>
        /// Returns Contact Phones for a given Owner
        /// </summary>
        /// <param name="id">Owner id</param>
        /// <returns></returns>
        IActionResult OwnersIdContactphonesGetAsync(int id);

        /// <summary>
        /// Returns a given Owner
        /// </summary>
        /// <param name="id">Owner id</param>
        /// <returns></returns>
        IActionResult OwnersIdGetAsync(int id);

        /// <summary>
        /// Returns Notes for a given Owner
        /// </summary>
        /// <param name="id">Owner id</param>
        /// <returns></returns>
        IActionResult OwnersIdNotesGetAsync(int id);
    }
}
