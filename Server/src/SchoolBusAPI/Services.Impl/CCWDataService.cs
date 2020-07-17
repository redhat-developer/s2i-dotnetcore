/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using SchoolBusAPI.Extensions;

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
            var (cCW_userId, cCW_guid, cCW_directory) = User.GetUserInfo();

            string ccwHost = Configuration["CCW_SERVICE_NAME"];
            CCWData result = CCWTools.FetchCCW (regi, vin, plate, cCW_userId, cCW_guid, cCW_directory, ccwHost);

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
