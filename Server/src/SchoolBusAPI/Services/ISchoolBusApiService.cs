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

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISchoolBusApiService
    {

        /// <summary>
        /// Creates a new school bus
        /// </summary>
        /// <remarks>The Location response-header field is used to redirect the recipient to a location other than the Request-URI for completion of the request or identification of a new resource. For 201 (Created) responses, the Location is that of the new resource which was created by the request.    The field value consists of a single absolute URI. </remarks>
        /// <param name="item"></param>
        /// <response code="201">SchoolBus created</response>
        IActionResult AddBusAsync(SchoolBus item);

        /// <summary>
        /// Creates several school buses
        /// </summary>
        /// <remarks>Used for bulk creation of schoolbus records.</remarks>
        /// <param name="items"></param>
        /// <response code="201">SchoolBus items created</response>
        IActionResult AddSchoolBusBulkAsync(SchoolBus[] items);

        /// <summary>
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        IActionResult FindBusByIdAsync(int id);

        /// <summary>
        /// Returns a collection of school buses
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">OK</response>
        IActionResult GetAllBusesAsync();

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
        IActionResult SchoolbusesIdDeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch SchoolBusHistory for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdHistoryGetAsync(int id);

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
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdNotesGetAsync(int id);

        /// <summary>
        /// Updates a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        IActionResult SchoolbusesIdPutAsync(int id, SchoolBus item);
    }
}
