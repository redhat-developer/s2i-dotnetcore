/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using SchoolBusAPI.Authorization;
using SchoolBusAPI.ViewModels;
using SchoolBusCommon.Helpers;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInspectionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Inspection to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        IActionResult InspectionsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        IActionResult InspectionsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Inspection to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        IActionResult InspectionsIdPutAsync(int id, Inspection item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Inspection created</response>
        IActionResult InspectionsPostAsync(Inspection item);

        InspectionCountsViewModel GetInspectionCounts(int?[] districts, int?[] inspectors);
    }

    /// <summary>
    /// 
    /// </summary>
    public class InspectionService : ServiceBase, IInspectionService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public InspectionService(IHttpContextAccessor httpContextAccessor, DbAppContext context, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Inspection to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>
        public virtual IActionResult InspectionsIdDeletePostAsync(int id)
        {
            // Delete Inspection has special behavior.
            // By design, an Inspector is only able to delete an Inspection 24 hours after it has been entered.
            // Admin user still can delete it any time.
            // Also, the related Schoolbus will be updated with the value of the PreviousNextInspectionDate and PreviousNextInspectionType fields.

            if (!_context.Inspections.Any(a => a.Id == id))
                return new StatusCodeResult(404);

            var item = _context.Inspections.Include(x => x.SchoolBus).First(a => a.Id == id);

            if (item.CreatedDate <= DateTime.UtcNow.AddDays(-1) && !User.IsSystemAdmin())
                return new StatusCodeResult(403);

            // update the Schoolbus record.
            if (item.SchoolBus != null)
            {
                int schoolbusId = item.SchoolBus.Id;

                bool schoolbus_exists = _context.SchoolBuss.Any(x => x.Id == schoolbusId);
                if (schoolbus_exists)
                {
                    SchoolBus schoolbus = _context.SchoolBuss.First(x => x.Id == schoolbusId);
                    schoolbus.NextInspectionDate = item.PreviousNextInspectionDate;
                    schoolbus.NextInspectionTypeCode = item.PreviousNextInspectionTypeCode;
                    _context.Update(schoolbus);
                }
            }

            _context.Inspections.Remove(item);

            // Save the changes
            _context.SaveChanges();
            return new ObjectResult(item);
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Inspection to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>

        public virtual IActionResult InspectionsIdGetAsync(int id)
        {
            var exists = _context.Inspections.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Inspections
                    .Include(x => x.Inspector)
                    .Include(x => x.SchoolBus)
                    .Include(x => x.SchoolBus.Attachments)
                    .Include(x => x.SchoolBus.HomeTerminalCity)
                    .Include(x => x.SchoolBus.SchoolDistrict)
                    .Include(x => x.SchoolBus.SchoolBusOwner.PrimaryContact)
                    .Include(x => x.SchoolBus.District.Region)
                    .Include(x => x.SchoolBus.History)
                    .Include(x => x.SchoolBus.Attachments)
                    .Include(x => x.SchoolBus.Notes)
                    .Include(x => x.SchoolBus.Inspector)
                    .First(a => a.Id == id);
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

        /// <param name="id">id of Inspection</param>
        /// <param name="item">item of Inspection</param>
        /// <response code="200">OK</response>
        /// <response code="404">Inspection not found</response>

        public virtual IActionResult InspectionsIdPutAsync(int id, Inspection item)
        {
            // adjust the user
            if (item.Inspector != null)
            {
                int user_id = item.Inspector.Id;
                bool user_exists = _context.Users.Any(a => a.Id == user_id);
                if (user_exists)
                {
                    User user = _context.Users.First(a => a.Id == user_id);
                    item.Inspector = user;
                }
                else
                {
                    item.Inspector = null;
                }
            }
            // adjust the schoolbus
            if (item.SchoolBus != null)
            {
                int schoolbus_id = item.SchoolBus.Id;
                bool schoolbus_exists = _context.SchoolBuss.Any(a => a.Id == schoolbus_id);
                if (schoolbus_exists)
                {
                    SchoolBus schoolbus = _context.SchoolBuss.First(a => a.Id == schoolbus_id);
                    item.SchoolBus = schoolbus;
                }
                else
                {
                    item.SchoolBus = null;
                }
            }

            var exists = _context.Inspections.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.Inspections.Update(item);
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

        /// <param name="item"></param>
        /// <response code="201">Inspection created</response>

        public virtual IActionResult InspectionsPostAsync(Inspection item)
        {
            if (item != null)
            {
                if (item.Inspector != null)
                {
                    int user_id = item.Inspector.Id;
                    bool user_exists = _context.Users.Any(a => a.Id == user_id);
                    if (user_exists)
                    {
                        User user = _context.Users.First(a => a.Id == user_id);
                        item.Inspector = user;
                    }
                    else
                    {
                        item.Inspector = null;
                    }
                }
                // adjust the schoolbus
                if (item.SchoolBus != null)
                {
                    int schoolbus_id = item.SchoolBus.Id;
                    bool schoolbus_exists = _context.SchoolBuss.Any(a => a.Id == schoolbus_id);
                    if (schoolbus_exists)
                    {
                        SchoolBus schoolbus = _context.SchoolBuss.First(a => a.Id == schoolbus_id);
                        item.SchoolBus = schoolbus;
                    }
                    else
                    {
                        item.SchoolBus = null;
                    }
                }

                // set the Inspection's Previous Next Inspection Date and to the SchoolBus Next Inspection Date
                if (item.SchoolBus != null)
                {
                    item.PreviousNextInspectionDate = item.SchoolBus.NextInspectionDate;
                    item.PreviousNextInspectionTypeCode = item.SchoolBus.NextInspectionTypeCode;
                }

                var exists = _context.Inspections.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Inspections.Update(item);
                    // Save the changes
                    _context.SaveChanges();
                    return new ObjectResult(item);
                }
                else
                {
                    // Inspection has a special field, createdDate which is set to now.
                    item.CreatedDate = DateTime.UtcNow;
                    // TH-120363
                    item.CreatedDate = DateTime.SpecifyKind(item.CreatedDate, DateTimeKind.Unspecified);
                    _context.Inspections.Add(item);
                }
                _context.SaveChanges();
                return new ObjectResult(item);

            }
            else
            {
                // no data
                return new StatusCodeResult(404);
            }
        }


        public InspectionCountsViewModel GetInspectionCounts(int?[] districts, int?[] inspectors)
        {
            DateTime today = DateUtils.ConvertPacificToUtcTime(
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0));

            DateTime dateTo = today.AddDays(31).AddSeconds(-1);

            var data = DbContext.SchoolBuss.AsNoTracking();

            if (districts != null)
            {
                data = data.Where(x => districts.Contains(x.DistrictId));
            }

            if (inspectors != null)
            {
                data = data.Where(x => inspectors.Contains(x.InspectorId));
            }

            int overdue = data
                .Count(x => x.NextInspectionDate < today && x.Status.ToLower() == "active");

            int within30days = _context.SchoolBuss
                .Count(x => x.NextInspectionDate >= today && x.NextInspectionDate <= dateTo && x.Status.ToLower() == "active");

            int scheduledInspections = _context.SchoolBuss
                .Count(x => x.NextInspectionDate >= today && x.Status.ToLower() == "active");

            int reInspections = _context.SchoolBuss
                .Count(x => x.NextInspectionTypeCode.ToLower() == "re-inspection" && x.Status.ToLower() == "active");

            return new InspectionCountsViewModel(overdue, within30days, scheduledInspections, reInspections);
        }
    }
}
