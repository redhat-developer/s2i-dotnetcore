/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.AspNetCore.Mvc;
using SchoolBusCommon;

namespace SchoolBusAPI.Controllers
{
    [Route("api/test")]
    public class TestApiController : Controller
    {
        /// <summary>
        /// Echos request headers
        /// </summary>
        /// <returns>
        /// The request headers formatted as html
        /// </returns>
        [HttpGet]
        [Route("headers")]
        [Produces("text/html")]        
        public virtual IActionResult EchoHeaders()
        {
            return Ok(Request.Headers.ToHtml());
        }
    }
}
