/*
 * REST API Documentation for Schoolbus
 *
 * This project is to replace the existing permitting and inspection scheduling functionality in AVIS  such that the mainframe application can be retired. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * 
 */

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class RegionApiService : IRegionApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public RegionApiService(DbAppContext context)
        {
            _context = context;
        }

        public virtual IActionResult RegionsGetAsync()
        {
            var results = _context.Regions.ToList();
            return new ObjectResult(results);
        }

        public virtual IActionResult RegionsIdCitiesGetAsync(int id)
        {
            var result = _context.Cities.All(a => a.Region.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult RegionsIdGetAsync(int id)
        {
            var result = _context.Regions.First(a => a.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult RegionsIdLocalareasGetAsync(int id)
        {
            var result = _context.LocalAreas.All(a => a.Region.Id == id);
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IActionResult RegionsIdSchooldistrictsGetAsync(int id)
        {
            var result = _context.SchoolDistricts.All(a => a.LocalArea.Region.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult RegionsPostAsync(Region[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Region item in items)
            {
                _context.Regions.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        public virtual IActionResult RegionsIdSchooldistrictsGetAsync()
        {
            return new ObjectResult("");
        }

    }
}

