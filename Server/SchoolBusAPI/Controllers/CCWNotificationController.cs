using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Authorization;
using SchoolBusAPI.Helpers;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;
using SchoolBusAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace SchoolBusAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class CCWNotificationController : ControllerBase
    {
        private ICCWNotificationService _ccwNotificationSvc;

        public CCWNotificationController(ICCWNotificationService ccWNotificationSvc)
        {
            _ccwNotificationSvc = ccWNotificationSvc;
        }

        [HttpGet]
        [Route("/api/ccwnotifications")]
        [RequiresPermission(Permissions.SchoolBusRead)]
        public virtual ActionResult<List<CCWNotificationViewModel>> GetCcwNotifications(DateTime? dateFrom, DateTime? dateTo, 
            [ModelBinder(BinderType = typeof(CsvArrayBinder))]int?[] districts, [ModelBinder(BinderType = typeof(CsvArrayBinder))] int?[] inspectors, 
            int? owner, string regi, string vin, string plate, bool hideRead = true)
        {
            if (dateFrom == null || dateTo == null)
            {
                return BadRequest(new Error("Invalid query", 401, "Date range is mandatory"));
            }

            return Ok(_ccwNotificationSvc.GetNotifications((DateTime)dateFrom, (DateTime)dateTo, districts, inspectors, owner, regi, vin, plate, hideRead));
        }

        [HttpPost]
        [Route("/api/ccwnotifications")]
        [RequiresPermission(Permissions.SchoolBusWrite)]
        public virtual IActionResult UpdateCcwNotifications([FromBody]List<CCWNotificationUpdateViewModel> ccwNotifications)
        {
            var (success, error) = _ccwNotificationSvc.UpdateNotifications(ccwNotifications);

            return success ? NoContent() : error;
        }

    }
}
