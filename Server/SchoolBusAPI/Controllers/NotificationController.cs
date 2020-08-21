/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;
using SchoolBusAPI.Authorization;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Notification created</response>
        [HttpPost]
        [Route("/api/notifications/bulk")]
        [RequiresPermission(Permissions.SchoolBusWrite, Permissions.OwnerWrite)]
        public virtual IActionResult NotificationsBulkPost([FromBody]Notification[] items)
        {
            return this._service.NotificationsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpPost]
        [Route("/api/notifications/{id}/delete")]
        [RequiresPermission(Permissions.SchoolBusWrite, Permissions.OwnerWrite)]
        public virtual IActionResult NotificationsIdDeletePost([FromRoute]int id)
        {
            return this._service.NotificationsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpGet]
        [Route("/api/notifications/{id}")]
        [RequiresPermission(Permissions.SchoolBusRead, Permissions.OwnerRead)]
        public virtual IActionResult NotificationsIdGet([FromRoute]int id)
        {
            return this._service.NotificationsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Notification to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Notification not found</response>
        [HttpPut]
        [Route("/api/notifications/{id}")]
        [RequiresPermission(Permissions.SchoolBusWrite, Permissions.OwnerWrite)]
        public virtual IActionResult NotificationsIdPut([FromRoute]int id, [FromBody]Notification item)
        {
            return this._service.NotificationsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Notification created</response>
        [HttpPost]
        [Route("/api/notifications")]
        [RequiresPermission(Permissions.SchoolBusWrite, Permissions.OwnerWrite)]
        public virtual IActionResult NotificationsPost([FromBody]Notification item)
        {
            return this._service.NotificationsPostAsync(item);
        }
    }
}
