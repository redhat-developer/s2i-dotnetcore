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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRegionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Region created</response>
        IActionResult RegionsBulkPostAsync(Region[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult RegionsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Region to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        IActionResult RegionsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the districts for a specific region</remarks>
        /// <param name="id">id of Region for which to fetch the Districts</param>
        /// <response code="200">OK</response>
        IActionResult RegionsIdDistrictsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Region to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        IActionResult RegionsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Region to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        IActionResult RegionsIdPutAsync(int id, Region item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Region created</response>
        IActionResult RegionsPostAsync(Region item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class RegionService : ServiceBase, IRegionService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public RegionService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of regions.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsBulkPostAsync(Region[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Region item in items)
            {
                var exists = _context.Regions.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Regions.Update(item);
                }
                else
                {
                    _context.Regions.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available regions</remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsGetAsync()
        {
            var result = _context.Regions.ToList();
            return new ObjectResult(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a region</remarks>
        /// <param name="id">id of Region to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>

        public virtual IActionResult RegionsIdDeletePostAsync(int id)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Regions.First(a => a.Id == id);
                _context.Regions.Remove(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific region</remarks>
        /// <param name="id">id of Regions to fetch</param>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsIdGetAsync(int id)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Regions.First(a => a.Id == id);
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
        /// <remarks>Returns a list of LocalAreas for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsIdDistrictsGetAsync(int id)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Districts.Where(a => a.Region.Id == id);
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
        /// <remarks>Updates a region</remarks>
        /// <param name="id">id of Region to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>

        public virtual IActionResult RegionsIdPutAsync(int id, Region item)
        {
            var exists = _context.Regions.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.Entry(item).State = EntityState.Modified;
                // save the changes
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
        /// <remarks>Adds a region</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>

        public virtual IActionResult RegionsPostAsync(Region item)
        {
            _context.Regions.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
