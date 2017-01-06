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
    public interface IPermissionApiService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Permissions created</response>
        IActionResult PermissionsBulkPostAsync(Permission[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of permissions</remarks>
        /// <response code="200">OK</response>
        IActionResult PermissionsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Permission to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        IActionResult PermissionsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a permission</remarks>
        /// <param name="id">id of Permission to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        IActionResult PermissionsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Permission to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        IActionResult PermissionsIdPutAsync(int id, PermissionViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Permission created</response>
        IActionResult PermissionsPostAsync(Permission item);
    }
}
