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
    public interface IRegionApiService
    {
        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns></returns>
        IActionResult RegionsGetAsync();

        /// <summary>
        /// Get all cities for a Region
        /// </summary>
        /// <param name="id">Region id</param>
        /// <returns></returns>
        IActionResult RegionsIdCitiesGetAsync(int id);

        /// <summary>
        /// Get a specific region
        /// </summary>
        /// <param name="id">Region id</param>
        /// <returns></returns>
        IActionResult RegionsIdGetAsync(int id);

        /// <summary>
        /// Returns local aras in a particular Region
        /// </summary>
        /// <param name="id">Region id</param>
        /// <returns></returns>
        IActionResult RegionsIdLocalareasGetAsync(int id);

        /// <summary>
        /// Returns School Districts in a particular Region
        /// </summary>
        /// <param name="id">Region id</param>
        /// <returns></returns>
        IActionResult RegionsIdSchooldistrictsGetAsync(int id);

        /// <summary>
        /// Update the list of Regions
        /// </summary>
        /// <returns></returns>
        IActionResult RegionsPostAsync(Region[] items);


        /// <summary>
        /// Gets School Districts for a given Region
        /// </summary>
        /// <returns></returns>
        IActionResult RegionsIdSchooldistrictsGetAsync();
    }


}
