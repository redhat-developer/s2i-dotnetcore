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
    public interface ISchoolBusNoteApiService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusNotes created</response>
        IActionResult SchoolbusnotesBulkPostAsync(SchoolBusNote[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchoolbusnotesGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusNote to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        IActionResult SchoolbusnotesIdDeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        IActionResult SchoolbusnotesIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusNote to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        IActionResult SchoolbusnotesIdPutAsync(int id, SchoolBusNote item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusNote created</response>
        IActionResult SchoolbusnotesPostAsync(SchoolBusNote item);
    }
}
