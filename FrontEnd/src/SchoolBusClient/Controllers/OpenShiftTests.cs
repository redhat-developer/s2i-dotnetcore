/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.AspNetCore.Mvc;

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
