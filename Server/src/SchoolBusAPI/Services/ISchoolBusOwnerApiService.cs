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
    public interface ISchoolBusOwnerApiService
    {
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns list of available FavouriteContextTypes</remarks>
        /// <response code="200">OK</response>        

        IActionResult FavouritecontexttypesGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwners created</response>        

        IActionResult SchoolbusownersBulkPostAsync (List<SchoolBusOwner> body);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownersGetAsync ();        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownersIdAttachmentsGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownersIdContactaddressesGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownersIdContactphonesGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>        

        IActionResult SchoolbusownersIdDeleteAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownersIdGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>        

        IActionResult SchoolbusownersIdNotesGetAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>        

        IActionResult SchoolbusownersIdPutAsync (int id);        
        
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwner created</response>        

        IActionResult SchoolbusownersPostAsync (SchoolBusOwner body);        
        
    }
}
