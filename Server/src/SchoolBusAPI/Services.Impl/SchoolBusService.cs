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
    public class SchoolBusService : ISchoolBusService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// Creates several school buses
        /// </summary>
        /// <remarks>Used for bulk creation of schoolbus records.</remarks>
        /// <param name="body"></param>
        /// <response code="201">SchoolBus items created</response>

        public virtual IActionResult SchoolbusesBulkPostAsync (SchoolBus[] items)        
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
                    else // invalid data
                    {
                        item.SchoolBusOwner = null;
                    }
                }

                // adjust District.
                if (item.District != null)
                {
                    int district_id = item.District.Id;
                    var district_exists = _context.ServiceAreas.Any(a => a.Id == district_id);
                    if (district_exists)
                    {
                        District district = _context.Districts.First(a => a.Id == district_id);
                        item.District = district;
                    }
                    else
                    {
                        item.District = null;
                    }
                }                // adjust school district

                if (item.SchoolDistrict != null)
                {
                    int schoolDistrict_id = item.SchoolDistrict.Id;
                    bool schoolDistrict_exists = _context.SchoolDistricts.Any(a => a.Id == schoolDistrict_id);
                    if (schoolDistrict_exists)
                    {
                        SchoolDistrict school_district = _context.SchoolDistricts.First(a => a.Id == schoolDistrict_id);
                        item.SchoolDistrict = school_district;
                    }
                    else
                    // invalid data
                    {
                        item.SchoolDistrict = null;
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
                    else
                    // invalid data
                    {
                        item.HomeTerminalCity = null;
                    }
                }

                // adjust inspector

                if (item.Inspector != null)
                {
                    int inspector_id = item.Inspector.Id;
                    bool inspector_exists = _context.Users.Any(a => a.Id == inspector_id);
                    if (inspector_exists)
                    {
                        User inspector = _context.Users.First(a => a.Id == inspector_id);
                        item.Inspector = inspector;
                    }
                    else
                    // invalid data
                    {
                        item.Inspector = null;
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

        public virtual IActionResult SchoolbusesIdGetAsync (int id)        
        {
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBuss
                    .Include(x => x.HomeTerminalCity)
                    .Include(x => x.SchoolDistrict)
                    .Include(x => x.SchoolBusOwner.PrimaryContact)
                    .Include(x => x.District.Region)
                    .Include(x => x.Inspector)
                    .First(a => a.Id == id);
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

        public virtual IActionResult SchoolbusesGetAsync ()        
        {
            var result = _context.SchoolBuss
                .Include(x => x.HomeTerminalCity)
                .Include(x => x.SchoolDistrict)
                .Include(x => x.SchoolBusOwner.PrimaryContact)
                .Include(x => x.District.Region)
                .Include(x => x.Inspector)
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
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .Include(x => x.Attachments)
                    .First(a => a.Id == id);
                var result = schoolBus.Attachments;
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
            // validate the bus id            
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolbus = _context.SchoolBuss.Where(a => a.Id == id).First();
                string regi = schoolbus.ICBCRegistrationNumber;
                // get CCW data for this bus.

                // could be none.
                // validate the bus id            
                bool ccw_exists = _context.CCWDatas.Any(a => a.ICBCRegistrationNumber == regi);
                if (ccw_exists)
                {
                    var result = _context.CCWDatas.Where(a => a.ICBCRegistrationNumber == regi).First();
                    return new ObjectResult(result);
                }
                else
                {
                    // record not found
                    CCWData[] nodata = new CCWData[0];
                    return new ObjectResult (nodata);
                }
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
        
        /// <param name="id">id of SchoolBus to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdDeletePostAsync (int id)        
        {
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
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
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .Include(x => x.History)
                    .First(a => a.Id == id);
                var result = schoolBus.History;
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
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .Include(x => x.Notes)
                    .First(a => a.Id == id);
                var result = schoolBus.Notes;
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

        public virtual IActionResult SchoolbusesIdPutAsync (int id, SchoolBus item)        
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


            // adjust District.
            if (item.District != null)
            {
                int district_id = item.District.Id;
                var district_exists = _context.ServiceAreas.Any(a => a.Id == district_id);
                if (district_exists)
                {
                    District district = _context.Districts.First(a => a.Id == district_id);
                    item.District = district;
                }
                else
                {
                    item.District = null;
                }
            }
            // adjust school district

            if (item.SchoolDistrict != null)
            {
                int schoolDistrict_id = item.SchoolDistrict.Id;
                bool schoolDistrict_exists = _context.SchoolDistricts.Any(a => a.Id == schoolDistrict_id);
                if (schoolDistrict_exists)
                {
                    SchoolDistrict school_district = _context.SchoolDistricts.First(a => a.Id == schoolDistrict_id);
                    item.SchoolDistrict = school_district;
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

            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.SchoolBuss.Update(item);                
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
        /// <response code="201">SchoolBus created</response>
        public virtual IActionResult SchoolbusesPostAsync(SchoolBus item)
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

            // adjust District.
            if (item.District != null)
            {
                int district_id = item.District.Id;
                var district_exists = _context.Districts.Any(a => a.Id == district_id);
                if (district_exists)
                {
                    District district = _context.Districts.First(a => a.Id == district_id);
                    item.District = district;
                }
                else
                {
                    item.District = null;
                }
            }

            // adjust school district

            if (item.SchoolDistrict != null)
            {
                int schoolDistrict_id = item.SchoolDistrict.Id;
                bool schoolbus_district_exists = _context.SchoolDistricts.Any(a => a.Id == schoolDistrict_id);
                if (schoolbus_district_exists)
                {
                    SchoolDistrict schoolDistrict = _context.SchoolDistricts.First(a => a.Id == schoolDistrict_id);
                    item.SchoolDistrict = schoolDistrict;
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

            bool exists = _context.SchoolBuss.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.SchoolBuss.Update(item);
                // Save the changes
            }
            else
            {
                // record not found
                _context.SchoolBuss.Add(item);
            }

            _context.SaveChanges();
            return new ObjectResult(item);
            
        }


        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbusesIdInspectionsGetAsync(int id)
        {
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
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
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="inspectors">Assigned School Bus Inspectors (array of id numbers)</param>
        /// <param name="cities">Cities (array of id numbers)</param>
        /// <param name="schooldistricts">School Districts (array of id numbers)</param>
        /// <param name="owner"></param>
        /// <param name="regi">e Regi Number</param>
        /// <param name="vin">VIN</param>
        /// <param name="plate">License Plate String</param>
        /// <param name="includeInactive">True if Inactive schoolbuses will be returned</param>
        /// <param name="onlyReInspections">If true, only buses that need a re-inspection will be returned</param>
        /// <param name="startDate">Inspection start date</param>
        /// <param name="endDate">Inspection end date</param>
        /// <response code="200">OK</response>
        public IActionResult SchoolbusesSearchGetAsync(int?[] districts, int?[] inspectors, int?[] cities, int?[] schooldistricts, int? owner, string regi, string vin, string plate, bool? includeInactive, bool? onlyReInspections, DateTime? startDate, DateTime? endDate)
        {

            // Eager loading of related data
            var data = _context.SchoolBuss
                .Include(x => x.HomeTerminalCity)
                .Include(x => x.SchoolDistrict)
                .Include(x => x.SchoolBusOwner.PrimaryContact)
                .Include(x => x.District.Region)
                .Include(x => x.Inspector)
                .Select(x => x);

            bool keySearch = false;

            // do key search fields first.

            if (regi != null)
            {
                data = data.Where(x => x.ICBCRegistrationNumber == regi);
                keySearch = true;
            }

            if (vin != null)
            {
                data = data.Where(x => x.VehicleIdentificationNumber == vin);
                keySearch = true;
            }

            if (plate != null)
            {
                data = data.Where(x => x.LicencePlateNumber == plate);
                keySearch = true;
            }

            // only search other fields if a key search was not done.
            if (!keySearch)
            {
                if (districts != null)
                {
                    foreach (int? district in districts)
                    {
                        if (district != null)
                        {
                            data = data.Where(x => x.District.Id == district);
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
                            data = data.Where(x => x.SchoolDistrict.Id == schooldistrict);
                        }
                    }
                }

                if (owner != null)
                {
                    data = data.Where(x => x.SchoolBusOwner.Id == owner);
                }

                if (includeInactive == null)
                {
                    data = data.Where(x => x.Status == "Active");
                }

                if (includeInactive == null || (includeInactive != null && includeInactive == false))
                {
                    data = data.Where(x => x.Status == "Active");
                }

                if (onlyReInspections != null && onlyReInspections == true)
                {
                    data = data.Where(x => x.NextInspectionTypeCode == "Re-inspection");
                }

                if (startDate != null)
                {
                    data = data.Where(x => x.NextInspectionDate >= startDate);
                }

                if (endDate != null)
                {
                    data = data.Where(x => x.NextInspectionDate <= endDate);
                }

            }

            var result = data.ToList();
            return new ObjectResult(result);
        }
    }
}
