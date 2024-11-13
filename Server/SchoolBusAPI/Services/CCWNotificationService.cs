using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SchoolBusAPI.Authorization;
using SchoolBusAPI.Extensions;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBusAPI.Services
{
    public interface ICCWNotificationService
    {
        List<CCWNotificationViewModel> GetNotifications(DateTime dateFrom, DateTime dateTo, int?[] districts, int?[] inspectors, int? owner, string regi, string vin, string plate, bool hideRead);
        (bool valid, IActionResult error) UpdateHasBeenRead(List<CCWNotificationUpdateViewModel> ccwNotifications, bool read);
        (bool valid, IActionResult error) DeleteNotifications(List<CCWNotificationUpdateViewModel> ccwNotifications);
    }

    public class CCWNotificationService : ServiceBase, ICCWNotificationService
    {
        public CCWNotificationService(IHttpContextAccessor httpContextAccessor, DbAppContext context, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
        }

        public List<CCWNotificationViewModel> GetNotifications(DateTime dateFrom, DateTime dateTo, int?[] districts, int?[] inspectors, int? owner, string regi, string vin, string plate, bool hideRead)
        {
            var data = DbContext.SchoolBuss.AsNoTracking();
            var keySearch = false;

            if (regi.IsNotEmpty())
            {
                regi = regi.Replace(" ", String.Empty);
                data = data.Where(x => x.ICBCRegistrationNumber.Contains(regi));
                keySearch = true;
            }

            if (vin != null)
            {
                // Normalize vin to ignore case and whitespaces
                vin = vin.Replace(" ", String.Empty).ToUpper();
                data = data.Where(x => x.VehicleIdentificationNumber.ToUpper().Contains(vin));
                keySearch = true;
            }

            if (plate != null)
            {
                // Normalize plate to ignore case and whitespaces
                plate = plate.Replace(" ", String.Empty).ToUpper();
                data = data.Where(x => x.LicencePlateNumber.Replace(" ", String.Empty).ToUpper().Contains(plate));
                keySearch = true;
            }

            // only search other fields if a key search was not done.
            if (!keySearch)
            {
                if (districts != null)
                {
                    data = data.Where(x => districts.Contains(x.DistrictId));
                }

                if (inspectors != null)
                {
                    data = data.Where(x => inspectors.Contains(x.InspectorId));
                }

                if (owner != null)
                {
                    data = data.Where(x => x.SchoolBusOwner.Id == owner);
                }
            }

            dateFrom = DateUtils.ConvertPacificToUtcTime(
                new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 0, 0, 0));
            dateFrom = DateTime.SpecifyKind(dateFrom, DateTimeKind.Unspecified);
            


            dateTo = DateUtils.ConvertPacificToUtcTime(
                new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 0, 0, 0))
                    .AddDays(1)
                    .AddSeconds(-1);
            dateTo = DateTime.SpecifyKind(dateTo, DateTimeKind.Unspecified);

            var notifications = data.SelectMany(x => x.CCWNotifications)
                .Include(x => x.CCWNotificationDetails)
                .Include(x => x.SchoolBus)
                    .ThenInclude(x => x.SchoolBusOwner)
                .Include(x => x.SchoolBus)
                    .ThenInclude(x => x.Inspector)
                .Where(x => 
                    x.CreateTimestamp >= dateFrom 
                    && x.CreateTimestamp <= dateTo);

            if (hideRead)
            {
                notifications = notifications.Where(x => !x.HasBeenViewed);
            }

            return Mapper.Map<List<CCWNotificationViewModel>>(notifications);
        }

        public (bool valid, IActionResult error) UpdateHasBeenRead(List<CCWNotificationUpdateViewModel> ccwNotifications, bool read)
        {
            var currentUserId = GetCurrentUserId();

            foreach (var ccwNotification in ccwNotifications)
            {
                var entity = DbContext.CCWNotifications
                    .Include(x => x.SchoolBus)
                    .Include(x => x.CCWNotificationDetails)
                    .FirstOrDefault(x => x.Id == ccwNotification.Id);

                if (entity == null)
                {
                    return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 501, $"The CCW Notification [{ccwNotification.Id}] does not exist.")));
                }

                if (!User.IsSystemAdmin() && entity.SchoolBus.InspectorId != currentUserId)
                {
                    return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 502, $"The CCW Notification [{ccwNotification.Id}] does not belong to the user[{GetCurrentSmUserId()}].")));
                }

                entity.HasBeenViewed = read;
            }

            DbContext.SaveChanges();

            return (true, null);
        }

        public (bool valid, IActionResult error) DeleteNotifications(List<CCWNotificationUpdateViewModel> ccwNotifications)
        {
            var currentUserId = GetCurrentUserId();

            foreach (var ccwNotification in ccwNotifications)
            {
                var entity = DbContext.CCWNotifications
                    .Include(x => x.SchoolBus)
                    .Include(x => x.CCWNotificationDetails)
                    .FirstOrDefault(x => x.Id == ccwNotification.Id);

                if (entity == null)
                {
                    return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 501, $"The CCW Notification [{ccwNotification.Id}] does not exist.")));
                }

                if (!User.IsSystemAdmin() && entity.SchoolBus.InspectorId != currentUserId)
                {
                    return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 502, $"The CCW Notification [{ccwNotification.Id}] does not belong to the user[{GetCurrentSmUserId()}].")));
                }

                DbContext.CCWNotifications.Remove(entity);
            }

            DbContext.SaveChanges();

            return (true, null);
        }
    }
}
