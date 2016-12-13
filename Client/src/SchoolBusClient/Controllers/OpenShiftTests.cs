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
using Swashbuckle.SwaggerGen.Annotations;


namespace SchoolBusClient.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class OpenShiftTestsController : Controller
    {
       

        /// <summary>
        /// Create a controller 
        /// </summary>

        public OpenShiftTestsController()
        {
        
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of regions for a given province</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/readinessProbe")]
        public virtual IActionResult doReadinessProbe()
        {
            string result = "1";
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("/livenessProbe")]
        public virtual IActionResult doLivenessProbe()
        {
            string result = "1";
            return new ObjectResult(result);
        }

    }
}
