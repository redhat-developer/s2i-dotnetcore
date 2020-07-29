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
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServiceAreaService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">ServiceArea created</response>
        IActionResult ServiceareasBulkPostAsync(ServiceArea[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult ServiceareasGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of ServiceArea to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">ServiceArea not found</response>
        IActionResult ServiceareasIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of ServiceArea to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">ServiceArea not found</response>
        IActionResult ServiceareasIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of ServiceArea to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">ServiceArea not found</response>
        IActionResult ServiceareasIdPutAsync(int id, ServiceArea item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">ServiceArea created</response>
        IActionResult ServiceareasPostAsync(ServiceArea item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class ServiceAreaService : IServiceAreaService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public ServiceAreaService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of districts.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasBulkPostAsync(ServiceArea[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (ServiceArea item in items)
            {
                // avoid inserting a District if possible.
                int district_id = item.District.Id;
                var exists = _context.Districts.Any(a => a.Id == district_id);
                if (exists)
                {
                    District district = _context.Districts.First(a => a.Id == district_id);
                    item.District = district;
                }

                exists = _context.ServiceAreas.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.ServiceAreas.Update(item);
                }
                else
                {
                    _context.ServiceAreas.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available districts</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasGetAsync()
        {
            var result = _context.ServiceAreas
                .Include(x => x.District.Region)
                .ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a Service Area</remarks>
        /// <param name="id">id of Service Area to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Service Area not found</response>
        public virtual IActionResult ServiceareasIdDeletePostAsync(int id)
        {
            var exists = _context.ServiceAreas.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.ServiceAreas.First(a => a.Id == id);
                if (item != null)
                {
                    _context.ServiceAreas.Remove(item);
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
        /// <remarks>Returns a specific Service Area</remarks>
        /// <param name="id">id of Service Area to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasIdGetAsync(int id)
        {
            var exists = _context.ServiceAreas.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.ServiceAreas
                    .Where(a => a.Id == id)
                    .Include(a => a.District.Region)
                    .FirstOrDefault();
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
        /// <remarks>Updates a Service Area</remarks>
        /// <param name="id">id of Service Area to update</param>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Service Area not found</response>
        public virtual IActionResult ServiceareasIdPutAsync(int id, ServiceArea body)
        {
            var exists = _context.ServiceAreas.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.ServiceAreas.Update(body);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(body);
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
        /// <remarks>Adds a Service Area</remarks>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult ServiceareasPostAsync(ServiceArea body)
        {
            _context.ServiceAreas.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
