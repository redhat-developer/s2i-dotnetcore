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
    public interface IGroupService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Group created</response>
        IActionResult GroupsBulkPostAsync(Group[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult GroupsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        IActionResult GroupsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        IActionResult GroupsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        IActionResult GroupsIdPutAsync(int id, Group item);

        /// <summary>
        /// returns users in a given Group
        /// </summary>
        /// <remarks>Used to get users in a given Group</remarks>
        /// <param name="id">id of Group to fetch Users for</param>
        /// <response code="200">OK</response>
        IActionResult GroupsIdUsersGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Group created</response>
        IActionResult GroupsPostAsync(Group item);
    }
}
