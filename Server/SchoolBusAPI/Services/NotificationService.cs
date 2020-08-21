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
    public interface INotificationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Notification created</response>
        IActionResult NotificationsBulkPostAsync(Notification[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        IActionResult NotificationsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        IActionResult NotificationsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        IActionResult NotificationsIdPutAsync(int id, Notification item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Notification created</response>
        IActionResult NotificationsPostAsync(Notification item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class NotificationService : ServiceBase, INotificationService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public NotificationService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="items"></param>
        /// <response code="201">Notifications created</response>

        public virtual IActionResult NotificationsBulkPostAsync(Notification[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Notification item in items)
            {
                _context.Notifications.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>

        public virtual IActionResult NotificationsIdDeletePostAsync(int id)
        {
            var exists = _context.Notifications.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Notifications.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Notifications.Remove(item);
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

        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>

        public virtual IActionResult NotificationsIdGetAsync(int id)
        {
            var exists = _context.Notifications.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Notifications.First(a => a.Id == id);
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

        /// <param name="id">id of Notification</param>
        /// <param name="body">body of Notification</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>

        public virtual IActionResult NotificationsIdPutAsync(int id, Notification body)
        {
            var exists = _context.Notifications.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Notifications.Update(body);
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

        /// <param name="item"></param>
        /// <response code="201">Notification created</response>

        public virtual IActionResult NotificationsPostAsync(Notification item)
        {
            // adjust events

            if (item.Event != null)
            {
                int event_id = item.Event.Id;
                bool event_exists = _context.NotificationEvents.Any(a => a.Id == event_id);
                if (event_exists)
                {
                    NotificationEvent event1 = _context.NotificationEvents.First(a => a.Id == event_id);
                    item.Event = event1;
                }
            }


            if (item.Event2 != null)
            {
                int event2_id = item.Event2.Id;
                bool event2_exists = _context.NotificationEvents.Any(a => a.Id == event2_id);
                if (event2_exists)
                {
                    NotificationEvent event2 = _context.NotificationEvents.First(a => a.Id == event2_id);
                    item.Event2 = event2;
                }
            }

            bool notification_exists = _context.Notifications.Any(a => a.Id == item.Id);
            if (notification_exists)
            {
                _context.Notifications.Update(item);
            }
            else
            {
                _context.Notifications.Add(item);
            }

            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
