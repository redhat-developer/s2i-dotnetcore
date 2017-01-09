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
    public interface ISchoolDistrictApiService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of school districts.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        IActionResult SchooldistrictsBulkPostAsync(SchoolDistrict[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available schooldistricts</remarks>
        /// <response code="200">OK</response>
        IActionResult SchooldistrictsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a School District</remarks>
        /// <param name="id">id of School District to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
        IActionResult SchooldistrictsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific school district</remarks>
        /// <param name="id">id of School Districts to fetch</param>
        /// <response code="200">OK</response>
        IActionResult SchooldistrictsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a school district</remarks>
        /// <param name="id">id of School District to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
        IActionResult SchooldistrictsIdPutAsync(int id, SchoolDistrict item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a school district</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        IActionResult SchooldistrictsPostAsync(SchoolDistrict item);
    }
}
