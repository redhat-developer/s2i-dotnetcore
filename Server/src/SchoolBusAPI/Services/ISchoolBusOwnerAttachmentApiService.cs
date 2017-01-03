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
    public interface ISchoolBusOwnerAttachmentApiService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerAttachments created</response>
        IActionResult SchoolbusownerattachmentsBulkPostAsync(SchoolBusOwnerAttachment[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownerattachmentsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        IActionResult SchoolbusownerattachmentsIdDeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        IActionResult SchoolbusownerattachmentsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        IActionResult SchoolbusownerattachmentsIdPutAsync(int id, SchoolBusOwnerAttachment item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwnerAttachment created</response>
        IActionResult SchoolbusownerattachmentsPostAsync(SchoolBusOwnerAttachment item);
    }
}
