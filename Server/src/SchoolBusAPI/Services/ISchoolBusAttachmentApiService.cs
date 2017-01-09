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
    public interface ISchoolBusAttachmentApiService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusAttachments created</response>
        IActionResult SchoolbusattachmentsBulkPostAsync(SchoolBusAttachment[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchoolbusattachmentsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        IActionResult SchoolbusattachmentsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        IActionResult SchoolbusattachmentsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        IActionResult SchoolbusattachmentsIdPutAsync(int id, SchoolBusAttachment item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusAttachment created</response>
        IActionResult SchoolbusattachmentsPostAsync(SchoolBusAttachment item);
    }
}
