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
    public interface ISchoolBusOwnerService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwner created</response>
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
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        IActionResult SchoolbusownersIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        IActionResult SchoolbusownersIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch History for</param>
        /// <param name="offset">offset for records that are returned</param>
        /// <param name="limit">limits the number of records returned.</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdHistoryGetAsync(int id, int? offset, int? limit);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Add a History record to the SchoolBus Owner</remarks>
        /// <param name="id">id of SchoolBusOwner to add History for</param>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        IActionResult SchoolbusownersIdHistoryPostAsync(int id, History item);

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
        /// <remarks>Returns SchoolBusOwner data plus additional information required for display</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdViewGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwner created</response>
        IActionResult SchoolbusownersPostAsync(SchoolBusOwner item);

        /// <summary>
        /// Searches school bus owners
        /// </summary>
        /// <remarks>Used for the search school bus owners.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="inspectors">Assigned School Bus Inspectors (array of id numbers)</param>
        /// <param name="owner"></param>
        /// <param name="includeInactive">True if Inactive schoolbuses will be returned</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersSearchGetAsync(int?[] districts, int?[] inspectors, int? owner, bool? includeInactive);
    }
}
