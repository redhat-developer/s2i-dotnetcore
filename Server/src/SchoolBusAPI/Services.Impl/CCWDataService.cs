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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;
using System.Net.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class CCWDataService : ServiceBase, ICCWDataService
    {
        private readonly DbAppContext _context;
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public CCWDataService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, DbAppContext context) : base(httpContextAccessor, context)
        {
            _context = context;
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">CCWData created</response>
        public virtual IActionResult CcwdataBulkPostAsync(CCWData[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (CCWData item in items)
            {

                bool exists = _context.CCWDatas.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.CCWDatas.Update(item);
                }
                else
                {
                    _context.CCWDatas.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }


        /// <summary>
        /// fetches data from the ICBC CCW system, and constructs a CCWData object from that.  Note that it does not perform the insert of that data into the database, only provides JSON data suitable for insertion. If a CCWData record exists in the schoolbus database then the id field will match that record, however all other data will be from the ICBC CCW system.
        /// </summary>
        /// <param name="regi">Registration Number (also known as Serial)</param>
        /// <param name="vin">Vehicle Identification Number</param>
        /// <param name="plate">License Plate String</param>
        /// <response code="200">OK</response>
        /// <response code="404">Vehicle not found in CCW system</response>
        public virtual IActionResult CcwdataFetchGetAsync(string regi, string vin, string plate)
        {
            CCWData result = null;

            string ccwHost = Configuration["CCW_SERVICE_NAME"];

            // construct the query string

            Dictionary<string, string> parametersToAdd = new Dictionary<string, string>();
            if (regi != null)
            {
                parametersToAdd.Add("regi", regi);
            }
            if (vin != null)
            {
                parametersToAdd.Add("vin", vin);
            }
            if (plate != null)
            {
                parametersToAdd.Add("plate", plate);
            }            
            var targetUrl = ccwHost + "/api/CCW/GetCCW";
            string newUri = QueryHelpers.AddQueryString(targetUrl, parametersToAdd);
            
            // call the microservice

            try
            {
                HttpClient client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, newUri);
                request.Headers.Clear();
                // transfer over the request headers.
                foreach (var item in Request.Headers )
                {
                    string key = item.Key;
                    string value = item.Value;                    
                    request.Headers.Add(key, value);
                }
                
                Task<HttpResponseMessage> responseTask = client.SendAsync(request);
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.StatusCode == HttpStatusCode.OK) // success
                {
                    var stringtask = response.Content.ReadAsStringAsync();
                    stringtask.Wait();
                    // parse as JSON.
                    string jsonString = stringtask.Result;
                    result = JsonConvert.DeserializeObject<CCWData>(jsonString);
                }
            }
            catch (Exception e)
            {
                result = null;
            }

            // return the result, or 404 if no result was found.

            if (result != null)
            {
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult CcwdataGetAsync()
        {
            var result = _context.CCWDatas.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdDeletePostAsync(int id)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.CCWDatas.First(a => a.Id == id);
                if (item != null)
                {
                    _context.CCWDatas.Remove(item);
                    // Save the changes
                    _context.SaveChanges();
                }
                return new ObjectResult(item);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdGetAsync(int id)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.CCWDatas.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdPutAsync(int id, CCWData item)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.CCWDatas.Update(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">CCWData created</response>
        public virtual IActionResult CcwdataPostAsync(CCWData item)
        {
            _context.CCWDatas.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
