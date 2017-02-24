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


        [HttpGet]
        [Route("GetPDF")]

        public async Task<IActionResult> GetPDF([FromServices] INodeServices nodeServices)
        {
            var result = await nodeServices.InvokeAsync<JSONResponse>("./pdf");

            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"report.pdf";
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
