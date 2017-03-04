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
using SchoolBusAPI.Mappings;
using SchoolBusAPI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusService : ServiceBase, ISchoolBusService
    {

        private readonly DbAppContext _context;
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, DbAppContext context) : base(httpContextAccessor, context)
        {
            _context = context;
            Configuration = configuration;
        }
	
        /// <summary>
        /// Adjust a SchoolBus item to ensure child object data is in place correctly
        /// </summary>
        /// <param name="item"></param>
        private void AdjustSchoolBus(SchoolBus item)
        {
            if (item != null)
            {


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

                // adjust CCWData

                if (item.CCWData != null)
                {
                    int ccwdata_id = item.CCWData.Id;
                    bool ccwdata_exists = _context.CCWDatas.Any(a => a.Id == ccwdata_id);
                    if (ccwdata_exists)
                    {
                        CCWData ccwdata = _context.CCWDatas.First(a => a.Id == ccwdata_id);
                        item.CCWData = ccwdata;
                    }
                    else
                    // invalid data
                    {
                        item.CCWData = null;
                    }
                }
            }
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
                AdjustSchoolBus(item);

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
                    .Include(x => x.CCWData)
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
                .Include(x => x.CCWData)
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
                var result = MappingExtensions.GetAttachmentListAsViewModel(schoolBus.Attachments); 
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
        /// Returns a PDF Permit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IActionResult SchoolbusesIdPdfpermitGetAsync (int id)        
        {
            FileContentResult result = null;
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .Include(x => x.CCWData)
                    .Include(x => x.SchoolBusOwner.PrimaryContact)
                    .Include(x => x.SchoolDistrict)
                    .First(a => a.Id == id);

                // construct the view model.

                PermitViewModel permitViewModel = new PermitViewModel();

                // only do the ICBC fields if the CCW data is available.

                if (schoolBus.CCWData != null)
                {
                    permitViewModel.IcbcMake = schoolBus.CCWData.ICBCMake;
                    permitViewModel.IcbcModelYear = schoolBus.CCWData.ICBCModelYear;
                    permitViewModel.IcbcRegistrationNumber = schoolBus.CCWData.ICBCRegistrationNumber;
                    permitViewModel.VehicleIdentificationNumber = schoolBus.CCWData.ICBCVehicleIdentificationNumber;                    
                }
                permitViewModel.PermitIssueDate = schoolBus.PermitIssueDate;
                permitViewModel.PermitNumber = schoolBus.PermitNumber;
                permitViewModel.RestrictionsText = schoolBus.RestrictionsText;

                if (schoolBus.SchoolBusOwner != null && schoolBus.SchoolBusOwner.PrimaryContact != null)
                {
                    permitViewModel.SchoolBusOwnerAddressLine1 = schoolBus.SchoolBusOwner.PrimaryContact.Address1;
                    permitViewModel.SchoolBusOwnerAddressLine2 = schoolBus.SchoolBusOwner.PrimaryContact.Address2;
                    permitViewModel.SchoolBusOwnerName = schoolBus.SchoolBusOwner.Name;
                }
                permitViewModel.SchoolBusSeatingCapacity = schoolBus.SchoolBusSeatingCapacity;
                if (schoolBus.SchoolDistrict != null)
                {
                    permitViewModel.SchoolDistrictshortName = schoolBus.SchoolDistrict.ShortName;
                }

                //return new ObjectResult(permitViewModel);
                string payload = JsonConvert.SerializeObject(permitViewModel);

                // pass the request on to the PDF Micro Service
                string pdfHost = Configuration["PDF_SERVICE_NAME"];
                
                string targetUrl = pdfHost + "/api/PDF/GetPDF";
                
                // call the microservice
                try
                {
                    HttpClient client = new HttpClient();

                    var request = new HttpRequestMessage(HttpMethod.Post, targetUrl);
                    request.Content = new StringContent(payload, Encoding.UTF8, "application/json"); 
                                        
                    request.Headers.Clear();
                    // transfer over the request headers.
                    foreach (var item in Request.Headers)
                    {
                        string key = item.Key;
                        string value = item.Value;
                        request.Headers.Add(key, value);
                    }

                    Task<HttpResponseMessage> responseTask = client.SendAsync(request);
                    responseTask.Wait();

                    HttpResponseMessage response = responseTask.Result;
                    if (response.StatusCode == HttpStatusCode.OK) // success
                    {
                        var bytetask = response.Content.ReadAsByteArrayAsync();
                        bytetask.Wait();
                        
                        result = new FileContentResult(bytetask.Result, "application/pdf");
                        result.FileDownloadName = "Permit-" + schoolBus.PermitNumber + ".pdf";                        
                    }
                }
                catch (Exception e)
                {
                    result = null;
                }

                // check that the result has a value
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new StatusCodeResult(400); // problem occured
                }

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
            AdjustSchoolBus(item);

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
            AdjustSchoolBus(item);

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
                var items = _context.Inspections
                    .Include(x => x.Inspector)
                    .Include(x => x.SchoolBus)
                    .Where(a => a.SchoolBus.Id == id);
                return new ObjectResult(items);
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
        /// <remarks>Obtains a new permit number for the indicated Schoolbus.  Returns the updated SchoolBus record.</remarks>
        /// <param name="id">id of SchoolBus to obtain a new permit number for</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusesIdNewpermitPutAsync(int id)
        {
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                // get the current max permit number.

                int permit = 36000;
                var maxPermitRecord = _context.SchoolBuss
                    .OrderByDescending(x => x.PermitNumber)
                    .FirstOrDefault(x => x.PermitNumber != null);

                if (maxPermitRecord != null)
                {
                    permit = (int)maxPermitRecord.PermitNumber + 1;
                }

                var item = _context.SchoolBuss
                    .Include(x => x.HomeTerminalCity)
                    .Include(x => x.SchoolDistrict)
                    .Include(x => x.SchoolBusOwner.PrimaryContact)
                    .Include(x => x.District.Region)
                    .Include(x => x.Inspector)
                    .Include(x => x.CCWData)                   
                    .First(a => a.Id == id);

                item.PermitNumber = permit;
                item.PermitIssueDate = DateTime.UtcNow;

                _context.SchoolBuss.Update(item);
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
                .Include(x => x.CCWData)
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
                    foreach (int? inspector in inspectors)
                    {
                        if (inspector != null)
                        {
                            data = data.Where(x => x.Inspector.Id == inspector);
                        }
                    }
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
                
                if (includeInactive == null || (includeInactive != null && includeInactive == false))
                {
                    data = data.Where(x => x.Status.ToLower() == "active");
                }

                if (onlyReInspections != null && onlyReInspections == true)
                {
                    data = data.Where(x => x.NextInspectionTypeCode.ToLower() == "re-inspection");
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
