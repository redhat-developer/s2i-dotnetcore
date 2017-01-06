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
using System.Text;

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

        /// <summary>
        /// Handler for the headers service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/headers")]        
        public virtual IActionResult DoHeaders()
        {
            StringBuilder headers = new StringBuilder();
            headers.AppendLine("<html>");
            headers.AppendLine("<body>");
            foreach (var item in Request.Headers)
            {
                headers.AppendFormat("<b>{0}</b> = {1}<br>\r\n", item.Key, ExpandValue(item.Value));
            }
            headers.AppendLine("</body>");
            headers.AppendLine("</html>");
            
            return new ObjectResult(headers);
        }

        /// <summary>
        /// Utility function used to expand headers.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private string ExpandValue(IEnumerable<string> values)
        {
            StringBuilder value = new StringBuilder();

            foreach (string item in values)
            {
                if (value.Length > 0)
                {
                    value.Append(", ");
                }
                value.Append(item);
            }
            return value.ToString();
        }

    }
}
