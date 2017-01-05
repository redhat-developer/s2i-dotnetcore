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
    public interface INotificationEventApiService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">NotificationEvents created</response>
        IActionResult NotificationeventsBulkPostAsync(NotificationEvent[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult NotificationeventsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        IActionResult NotificationeventsIdDeleteAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        IActionResult NotificationeventsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        IActionResult NotificationeventsIdPutAsync(int id, NotificationEvent item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">NotificationEvent created</response>
        IActionResult NotificationeventsPostAsync(NotificationEvent item);
    }
}
