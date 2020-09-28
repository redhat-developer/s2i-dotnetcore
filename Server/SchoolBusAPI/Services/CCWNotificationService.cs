using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Extensions;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBusAPI.Services
{
    public interface ICCWNotificationService
    {
        List<CCWNotificationViewModel> GetNotifications(DateTime dateFrom, DateTime dateTo, int?[] districts, int?[] inspectors, int? owner, string regi, string vin, string plate);
    }

    public class CCWNotificationService : ServiceBase, ICCWNotificationService
    {
        public CCWNotificationService(IHttpContextAccessor httpContextAccessor, DbAppContext context, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
        }

        public List<CCWNotificationViewModel> GetNotifications(DateTime dateFrom, DateTime dateTo, int?[] districts, int?[] inspectors, int? owner, string regi, string vin, string plate)
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

            var notifications = data.SelectMany(x => x.CCWNotifications)
                .Include(x => x.SchoolBus)
                    .ThenInclude(x => x.SchoolBusOwner)
                .Where(x => x.CreateTimestamp.Date >= dateFrom && x.CreateTimestamp.Date <= dateTo);

            return Mapper.Map<List<CCWNotificationViewModel>>(notifications);
        }
    }
}
