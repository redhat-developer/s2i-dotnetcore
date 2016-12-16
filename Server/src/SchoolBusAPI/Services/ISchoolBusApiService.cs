/*
 * REST API Documentation for Schoolbus
 *
 * This project is to replace the existing permitting and inspection scheduling functionality in AVIS  such that the mainframe application can be retired. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * 
 */

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolBusAPI.Models;

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
        /// <param name="body"></param>
        /// <response code="201">SchoolBus created</response>
        IActionResult AddBusAsync(SchoolBus body);

        /// <summary>
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="schoolbusId">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        IActionResult FindBusByIdAsync(int schoolbusId);

        /// <summary>
        /// Returns a collection of school buses
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">OK</response>
        IActionResult GetAllBusesAsync();
    }
}
