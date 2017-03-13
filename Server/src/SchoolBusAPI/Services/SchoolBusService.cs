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
    public interface ISchoolBusService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBus created</response>
        IActionResult SchoolbusesBulkPostAsync(SchoolBus[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdAttachmentsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdCcwdataGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch History for</param>
        /// <param name="offset">offset for records that are returned</param>
        /// <param name="limit">limits the number of records returned.</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdHistoryGetAsync(int id, int? offset, int? limit);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdInspectionsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Obtains a new permit number for the indicated Schoolbus.  Returns the updated SchoolBus record.</remarks>
        /// <param name="id">id of SchoolBus to obtain a new permit number for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdNewpermitPutAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdNotesGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a PDF version of the permit for the selected Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to obtain the PDF permit for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdPdfpermitGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdPutAsync(int id, SchoolBus item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBus created</response>
        IActionResult SchoolbusesPostAsync(SchoolBus item);

        /// <summary>
        /// Searches school buses
        /// </summary>
        /// <remarks>Used for the search schoolbus page.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="inspectors">Assigned School Bus Inspectors (array of id numbers)</param>
        /// <param name="cities">Cities (array of id numbers)</param>
        /// <param name="schooldistricts">School Districts (array of id numbers)</param>
        /// <param name="owner"></param>
        /// <param name="regi">e Regi Number</param>
        /// <param name="vin">VIN</param>
        /// <param name="plate">License Plate String</param>
        /// <param name="includeInactive">True if Inactive schoolbuses will be returned</param>
        /// <param name="onlyReInspections">If true, only buses that need a re-inspection will be returned</param>
        /// <param name="startDate">Inspection start date</param>
        /// <param name="endDate">Inspection end date</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesSearchGetAsync(int?[] districts, int?[] inspectors, int?[] cities, int?[] schooldistricts, int? owner, string regi, string vin, string plate, bool? includeInactive, bool? onlyReInspections, DateTime? startDate, DateTime? endDate);
    }
}
