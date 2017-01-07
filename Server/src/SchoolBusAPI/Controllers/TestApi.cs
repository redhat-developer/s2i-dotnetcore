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
using Swashbuckle.SwaggerGen.Annotations;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Services;
using System.Text;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestApiController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Test function - returns headers</remarks>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/headers")]        
        public virtual IActionResult UsersCurrentGet()
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
