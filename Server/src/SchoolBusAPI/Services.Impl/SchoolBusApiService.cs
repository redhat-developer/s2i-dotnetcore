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
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusApiService : ISchoolBusApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// Creates a new school bus
        /// </summary>
        /// <remarks>The Location response-header field is used to redirect the recipient to a location other than the Request-URI for completion of the request or identification of a new resource. For 201 (Created) responses, the Location is that of the new resource which was created by the request.    The field value consists of a single absolute URI. </remarks>
        /// <param name="item"></param>
        /// <response code="201">SchoolBus created</response>

        public virtual IActionResult AddBusAsync (SchoolBus item)        
        {

            // adjust school bus owner

            if (item.SchoolBusOwner != null)
            {
                int school_bus_owner_id = item.SchoolBusOwner.Id;
                bool school_bus_owner_exists = _context.SchoolBusOwners.Any(a => a.Id == school_bus_owner_id);
                if (school_bus_owner_exists)
                {
                    SchoolBusOwner school_bus_owner = _context.SchoolBusOwners.First(a => a.Id == school_bus_owner_id);
                    item.SchoolBusOwner = school_bus_owner;
                }
            }

            // adjust service area.

            if (item.ServiceArea != null)
            {
                int service_area_id = item.ServiceArea.Id;
                bool service_area_exists = _context.ServiceAreas.Any(a => a.Id == service_area_id);
                if (service_area_exists)
                {
                    ServiceArea service_area = _context.ServiceAreas.First(a => a.Id == service_area_id);
                    item.ServiceArea = service_area;
                }
            }

            // adjust school district

            if (item.SchoolBusDistrict != null)
            {
                int schoolbus_district_id = item.SchoolBusDistrict.Id;
                bool schoolbus_district_exists = _context.SchoolDistricts.Any(a => a.Id == schoolbus_district_id);
                if (schoolbus_district_exists)
                {
                    SchoolDistrict school_district = _context.SchoolDistricts.First(a => a.Id == schoolbus_district_id);
                    item.SchoolBusDistrict = school_district;
                }
            }

            // adjust home city

            if (item.HomeTerminalCity != null)
            {
                int city_id = item.HomeTerminalCity.Id;
                bool city_exists = _context.Cities.Any(a => a.Id == city_id);
                if (city_exists)
                {
                    City city = _context.Cities.First(a => a.Id == city_id);
                    item.HomeTerminalCity = city;
                }
            }

            _context.SchoolBuss.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);            
        }
        /// <summary>
        /// Creates several school buses
        /// </summary>
        /// <remarks>Used for bulk creation of schoolbus records.</remarks>
        /// <param name="body"></param>
        /// <response code="201">SchoolBus items created</response>

        public virtual IActionResult AddSchoolBusBulkAsync (SchoolBus[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBus item in items)
            {
                // adjust school bus owner

                if (item.SchoolBusOwner != null)
                {
                    int school_bus_owner_id = item.SchoolBusOwner.Id;
                    bool school_bus_owner_exists = _context.SchoolBusOwners.Any(a => a.Id == school_bus_owner_id);
                    if (school_bus_owner_exists)
                    {
                        SchoolBusOwner school_bus_owner = _context.SchoolBusOwners.First(a => a.Id == school_bus_owner_id);
                        item.SchoolBusOwner = school_bus_owner;
                    }
                }

                // adjust service area.

                if (item.ServiceArea != null)
                {
                    int service_area_id = item.ServiceArea.Id;
                    bool service_area_exists = _context.ServiceAreas.Any(a => a.Id == service_area_id);
                    if (service_area_exists)
                    {
                        ServiceArea service_area = _context.ServiceAreas.First(a => a.Id == service_area_id);
                        item.ServiceArea = service_area;
                    }
                }

                // adjust school district

                if (item.SchoolBusDistrict != null)
                {
                    int schoolbus_district_id = item.SchoolBusDistrict.Id;
                    bool schoolbus_district_exists = _context.SchoolDistricts.Any(a => a.Id == schoolbus_district_id);
                    if (schoolbus_district_exists)
                    {
                        SchoolDistrict school_district = _context.SchoolDistricts.First(a => a.Id == schoolbus_district_id);
                        item.SchoolBusDistrict = school_district;
                    }
                }

                // adjust home city

                if (item.HomeTerminalCity != null)
                {
                    int city_id = item.HomeTerminalCity.Id;
                    bool city_exists = _context.Cities.Any(a => a.Id == city_id);
                    if (city_exists)
                    {
                        City city = _context.Cities.First(a => a.Id == city_id);
                        item.HomeTerminalCity = city;
                    }
                }

                var exists = _context.SchoolBuss.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.SchoolBuss.Update(item);
                }
                else
                {
                    _context.SchoolBuss.Add(item);
                }                
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>

        public virtual IActionResult FindBusByIdAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBuss.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// Returns a collection of school buses
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult GetAllBusesAsync ()        
        {
            var result = _context.SchoolBuss
                .Include (x => x.HomeTerminalCity)
                .Include(x => x.SchoolBusDistrict)
                .Include(x => x.SchoolBusOwner)
                .Include(x => x.ServiceArea)                
                .ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdAttachmentsGetAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusAttachments.Where(a => a.SchoolBus.Id == id);
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
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusesIdCcwdataGetAsync (int id)        
        {
            // TODO: need to fix the model for CCWData
            var result = "";
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id">id of SchoolBus to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdDeletePostAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBuss.First(a => a.Id == id);
                if (item != null)
                {
                    _context.SchoolBuss.Remove(item);
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
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch SchoolBusHistory for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusesIdHistoryGetAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusHistorys.Where(a => a.SchoolBus.Id == id);
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
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdNotesGetAsync (int id)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusNotes.Where(a => a.SchoolBus.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// Updates a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>

        public virtual IActionResult SchoolbusesIdPutAsync (int id, SchoolBus body)        
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.SchoolBuss.Update(body);                
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

        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdInspectionsGetAsync(int id)
        {
            var exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var items = _context.Inspections.Where(a => a.SchoolBus.Id == id);
                return new ObjectResult(items);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// Searches school buses
        /// </summary>
        /// <remarks>Used for the search schoolbus page.</remarks>
        /// <param name="serviceareas">Service areas (array of id numbers)</param>
        /// <param name="inspectors">Assigned School Bus Inspectors (array of id numbers)</param>
        /// <param name="cities">Cities (array of id numbers)</param>
        /// <param name="schooldistricts">School Districts (array of id numbers)</param>
        /// <param name="owner"></param>
        /// <param name="regi">ICBC Regi Number</param>
        /// <param name="vin">VIN</param>
        /// <param name="plate">License Plate String</param>
        /// <param name="includeInactive">True if Inactive schoolbuses will be returned</param>
        /// <param name="onlyReInspections">If true, only buses that need a re-inspection will be returned</param>
        /// <param name="startDate">Inspection start date</param>
        /// <param name="endDate">Inspection end date</param>
        /// <response code="200">OK</response>
        public IActionResult SchoolbusesSearchGetAsync(int?[] serviceareas, int?[] inspectors, int?[] cities, int?[] schooldistricts, int? owner, string regi, string vin, string plate, bool? includeInactive, bool? onlyReInspections, DateTime? startDate, DateTime? endDate)
        {

            // Eager loading of related data
            var data = _context.SchoolBuss
                .Include(x => x.HomeTerminalCity)
                .Include(x => x.SchoolBusDistrict)
                .Include(x => x.SchoolBusOwner)
                .Include(x => x.ServiceArea)
                .Select(x => x); 
          
            if (serviceareas != null)
            {
                foreach (int? servicearea in serviceareas)
                {
                    if (servicearea != null)
                    {
                        data = data.Where(x => x.ServiceArea.Id == servicearea);
                    }                    
                }                
            }

            if (inspectors != null)
            {
                // no inspectors yet.
            }

            if (cities != null)
            {
                foreach (int? city in cities)
                {
                    if (city != null)
                    {
                        data = data.Where(x => x.HomeTerminalCity.Id == city);
                    }
                }
            }

            if (schooldistricts != null)
            {
                foreach (int? schooldistrict in schooldistricts)
                {
                    if (schooldistrict != null)
                    {
                        data = data.Where(x => x.SchoolBusDistrict.Id == schooldistrict);
                    }
                }
            }

            if (owner != null)
            {
                data = data.Where(x => x.SchoolBusOwner.Id == owner);
            }

            if (regi != null)
            {
                data = data.Where(x => x.Regi == regi);
            }

            if (vin != null)
            {
                data = data.Where(x => x.VIN == vin);
            }

            if (includeInactive == null)
            {
                data = data.Where(x => x.Status == "Active");
            }

            if (onlyReInspections != null)
            {
                data = data.Where(x => x.NextInspectionType == "Re-inspection");
            }
            
            if (startDate != null)
            {
                data = data.Where(x => x.NextInspectionDate >= startDate);
            }

            if (endDate != null)
            {
                data = data.Where(x => x.NextInspectionDate >= endDate);
            }

            var result = data.ToList();
            return new ObjectResult(result);
        }
    }
}
