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


namespace SchoolBusAPI.Services
{ 
    /// <summary>
    /// 
    /// </summary>
    public interface IRegionApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of regions.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>        

        IActionResult RegionsBulkPostAsync (Region[] items);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available regions</remarks>
        /// <response code="200">OK</response>        

        IActionResult RegionsGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of cities for a given region</remarks>
        /// <param name="id">id of Region to fetch Cities for</param>
        /// <response code="200">OK</response>        

        IActionResult RegionsIdCitiesGetAsync (int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a region</remarks>
        /// <param name="id">id of Region to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>        

        IActionResult RegionsIdDeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific region</remarks>
        /// <param name="id">id of Regions to fetch</param>
        /// <response code="200">OK</response>        

        IActionResult RegionsIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of LocalAreas for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>        

        IActionResult RegionsIdLocalareasGetAsync (int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a region</remarks>
        /// <param name="id">id of Region to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>        

        IActionResult RegionsIdPutAsync(int id, Region item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a region</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>        

        IActionResult RegionsPostAsync (Region item);        
        
    }
}
