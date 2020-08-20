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
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISchoolDistrictService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolDistrict created</response>
        IActionResult SchooldistrictsBulkPostAsync(SchoolDistrict[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchooldistrictsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolDistrict to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolDistrict not found</response>
        IActionResult SchooldistrictsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolDistrict to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolDistrict not found</response>
        IActionResult SchooldistrictsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolDistrict to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolDistrict not found</response>
        IActionResult SchooldistrictsIdPutAsync(int id, SchoolDistrict item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolDistrict created</response>
        IActionResult SchooldistrictsPostAsync(SchoolDistrict item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class SchoolDistrictService : ServiceBase, ISchoolDistrictService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolDistrictService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of SchoolDistricts for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchooldistrictsIdGetAsync(int id)
        {
            var result = _context.SchoolDistricts.Where(a => a.Id == id);
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of school districts.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchooldistrictsBulkPostAsync(SchoolDistrict[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolDistrict item in items)
            {
                var exists = _context.SchoolDistricts.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.SchoolDistricts.Update(item);
                }
                else
                {
                    _context.SchoolDistricts.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available schooldistricts</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult SchooldistrictsGetAsync()
        {
            var result = _context.SchoolDistricts.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a School District</remarks>
        /// <param name="id">id of School District to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
        public virtual IActionResult SchooldistrictsIdDeletePostAsync(int id)
        {
            var exists = _context.SchoolDistricts.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolDistricts.First(a => a.Id == id);
                if (item != null)
                {
                    _context.SchoolDistricts.Remove(item);
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
        /// <remarks>Updates a school district</remarks>
        /// <param name="id">id of School District to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">School District not found</response>
        public virtual IActionResult SchooldistrictsIdPutAsync(int id, SchoolDistrict item)
        {
            var exists = _context.SchoolDistricts.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.SchoolDistricts.Update(item);
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
        /// <remarks>Adds a school district</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchooldistrictsPostAsync(SchoolDistrict item)
        {
            _context.SchoolDistricts.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
