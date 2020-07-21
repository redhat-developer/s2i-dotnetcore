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

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface INotificationEventService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">NotificationEvent created</response>
        IActionResult NotificationeventsBulkPostAsync(NotificationEvent[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult NotificationeventsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        IActionResult NotificationeventsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        IActionResult NotificationeventsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>
        IActionResult NotificationeventsIdPutAsync(int id, NotificationEvent item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">NotificationEvent created</response>
        IActionResult NotificationeventsPostAsync(NotificationEvent item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class NotificationEventService : INotificationEventService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public NotificationEventService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="items"></param>
        /// <response code="201">NotificationEvents created</response>

        public virtual IActionResult NotificationeventsBulkPostAsync(NotificationEvent[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (NotificationEvent item in items)
            {
                _context.NotificationEvents.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>

        /// <response code="200">OK</response>

        public virtual IActionResult NotificationeventsGetAsync()
        {
            var result = _context.NotificationEvents.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of NotificationEvent to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>

        public virtual IActionResult NotificationeventsIdDeletePostAsync(int id)
        {
            var exists = _context.NotificationEvents.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.NotificationEvents.First(a => a.Id == id);
                _context.NotificationEvents.Remove(item);
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

        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>

        public virtual IActionResult NotificationeventsIdGetAsync(int id)
        {
            var exists = _context.NotificationEvents.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.NotificationEvents.First(a => a.Id == id);
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

        /// <param name="id">id of NotificationEvent to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">NotificationEvent not found</response>

        public virtual IActionResult NotificationeventsIdPutAsync(int id, NotificationEvent body)
        {
            var exists = _context.NotificationEvents.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.NotificationEvents.Update(body);
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

        /// <param name="body"></param>
        /// <response code="201">NotificationEvent created</response>

        public virtual IActionResult NotificationeventsPostAsync(NotificationEvent body)
        {
            _context.NotificationEvents.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
