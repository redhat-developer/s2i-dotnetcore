/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
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
        IActionResult FavouritecontexttypesGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwners created</response>
        IActionResult SchoolbusownersBulkPostAsync(SchoolBusOwner[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdAttachmentsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdContactaddressesGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdContactphonesGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        IActionResult SchoolbusownersIdDeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdNotesGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        IActionResult SchoolbusownersIdPutAsync(int id, SchoolBusOwner item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwner created</response>
        IActionResult SchoolbusownersPostAsync(SchoolBusOwner item);
    }
}
