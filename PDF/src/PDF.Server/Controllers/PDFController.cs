using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using PDF.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.NodeServices;

namespace PDF.Controllers
{
    public class JSONResponse
    {
        public string type;
        public byte[] data;
    }
    [Route("api/[controller]")]
    public class PDFController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly DbAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string userId;
        private string guid;
        private string directory;

        protected ILogger _logger;

        public PDFController(IHttpContextAccessor httpContextAccessor, IConfigurationRoot configuration, DbAppContext context, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
           
            _httpContextAccessor = httpContextAccessor;
            _context = context;

            userId = getFromHeaders("SM_UNIVERSALID");
            guid = getFromHeaders("SMGOV_USERGUID");
            directory = getFromHeaders("SM_AUTHDIRNAME");

            _logger = loggerFactory.CreateLogger(typeof(PDFController));
        }

        private string getFromHeaders(string key)
        {
            string result = null;
            if (Request.Headers.ContainsKey(key))
            {
                result = Request.Headers[key];
            }
            return result;
        }


        [HttpPost]
        [Route("GetPDF")]

        public async Task<IActionResult> GetPDF([FromServices] INodeServices nodeServices, [FromBody]  Object rawdata )
        {
            JSONResponse result = null;
            var options = new { format="letter", orientation= "landscape" };

            var sampleData = new
            {
                permitNumber = 29332,
                permitIssueDate = "2017/03/02",
                schoolBusOwnerName = "Sample Owner",
                schoolBusOwnerAddressLine1 = "Sample Address 1",
                schoolBusOwnerAddressLine2 = "Sample Address 2",
                icbcRegistrationNumber = "123456",
                vehicleIdentificationNumber = "VIN123456",
                icbcModelYear = "2001",
                icbcMake = "Chevrolet",
                restrictionsText = "No Restrictions",
                schoolDistrictshortName = "SD 38",
                schoolBusSeatingCapacity = 72
            };

            // execute the Node.js component
            if (rawdata != null)
            {                
                result = await nodeServices.InvokeAsync<JSONResponse>("./pdf", "schoolbus_permit", rawdata, options); 
            }
            else
            {
                result = await nodeServices.InvokeAsync<JSONResponse>("./pdf", "schoolbus_permit", sampleData, options); 
            }            

            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"output.pdf";
            HttpContext.Response.Headers.Add("x-filename", filename);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-filename");
            HttpContext.Response.Body.Write(result.data, 0, result.data.Length);
            return new ContentResult();
        }

        protected HttpRequest Request
        {
            get { return _httpContextAccessor.HttpContext.Request; }
        }
    }
}
