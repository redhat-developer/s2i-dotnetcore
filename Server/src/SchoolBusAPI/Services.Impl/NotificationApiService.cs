/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
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

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationApiService : INotificationApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public NotificationApiService(DbAppContext context)
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
        /// <response code="200">OK</response>
        public virtual IActionResult NotificationsGetAsync()
        {
            var result = _context.Notifications.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        public virtual IActionResult NotificationsIdDeleteAsync(int id)
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
        /// <param name="id">id of Notification to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        public virtual IActionResult NotificationsIdPutAsync(int id, Notification item)
        {
            var exists = _context.Notifications.Any(a => a.Id == id);
            if (exists)
            {
                var dbItem = _context.Notifications.First(a => a.Id == id);
                dbItem.Event = item.Event;
                dbItem.Event2 = item.Event2;
                dbItem.HasBeenViewed = item.HasBeenViewed;
                dbItem.IsAllDay = item.IsAllDay;
                dbItem.IsExpired = item.IsExpired;
                dbItem.IsWatchNotification = item.IsWatchNotification;
                dbItem.PriorityCode = item.PriorityCode;
                dbItem.User = item.User;

                _context.Notifications.Update(dbItem);
                // Save the changes
                _context.SaveChanges();                
                return new ObjectResult(dbItem);
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
            _context.Notifications.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
