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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using AutoMapper;
using Serilog;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISchoolBusService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdAttachmentsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdCcwdataGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch History for</param>
        /// <param name="offset">offset for records that are returned</param>
        /// <param name="limit">limits the number of records returned.</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdHistoryGetAsync(int id, int? offset, int? limit);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Add a History record to the SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch History for</param>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        IActionResult SchoolbusesIdHistoryPostAsync(int id, History item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdInspectionsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Obtains a new permit number for the indicated Schoolbus.  Returns the updated SchoolBus record.</remarks>
        /// <param name="id">id of SchoolBus to obtain a new permit number for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdNewpermitPutAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdNotesGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a PDF version of the permit for the selected Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to obtain the PDF permit for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusesIdPdfpermitGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        IActionResult SchoolbusesIdPutAsync(int id, SchoolBus item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBus created</response>
        IActionResult SchoolbusesPostAsync(SchoolBus item);

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
        IActionResult SchoolbusesSearchGetAsync(int?[] districts, int?[] inspectors, int?[] cities, int?[] schooldistricts, int? owner, string regi, string vin, string plate, bool? includeInactive, bool? onlyReInspections, DateTime? startDate, DateTime? endDate);

        (bool valid, IActionResult error) CreateSchoolBusNote(int sbId, NoteSaveViewModel note);
        (bool valid, IActionResult error) UpdateSchoolBusNote(int sbId, int noteId, NoteSaveViewModel note);
        (bool valid, IActionResult error) DeleteSchoolBusNote(int sbId, int noteId);
    }

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
        public SchoolBusService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, DbAppContext context, IMapper mapper) 
            : base(httpContextAccessor, context, mapper)
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
        /// Returns a single school bus object
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">Id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>

        public virtual IActionResult SchoolbusesIdGetAsync(int id)
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

        public virtual IActionResult SchoolbusesGetAsync()
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

        public virtual IActionResult SchoolbusesIdAttachmentsGetAsync(int id)
        {
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .Include(x => x.Attachments)
                    .First(a => a.Id == id);

                var result = Mapper.Map<List<AttachmentViewModel>>(schoolBus.Attachments);

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
        public virtual IActionResult SchoolbusesIdCcwdataGetAsync(int id)
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
                    return new ObjectResult(nodata);
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
        public virtual IActionResult SchoolbusesIdDeletePostAsync(int id)
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
        /// Returns History for a particular SchoolBus
        /// </summary>
        /// <param name="id"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public virtual IActionResult SchoolbusesIdHistoryGetAsync(int id, int? offset, int? limit)
        {
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .Include(x => x.History)
                    .First(a => a.Id == id);

                List<History> data = schoolBus.History.OrderByDescending(y => y.LastUpdateTimestamp).ToList();

                if (offset == null)
                {
                    offset = 0;
                }
                if (limit == null)
                {
                    limit = data.Count() - offset;
                }
                List<HistoryViewModel> result = new List<HistoryViewModel>();

                for (int i = (int)offset; i < data.Count() && i < offset + limit; i++)
                {
                    var viewModel = Mapper.Map<HistoryViewModel>(data[i]);
                    viewModel.AffectedEntityId = id;

                    var user = _context.Users
                        .FirstOrDefault(x => x.SmUserId == viewModel.LastUpdateUserid);

                    if (user != null)
                    {
                        viewModel.UserName = $"{user.Surname}, {user.GivenName}";
                    }

                    result.Add(viewModel);
                }

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
        /// <remarks>Add a History record to the SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch History for</param>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        public virtual IActionResult SchoolbusesIdHistoryPostAsync(int id, History item)
        {
            HistoryViewModel result = new HistoryViewModel();

            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .Include(x => x.History)
                    .First(a => a.Id == id);
                if (schoolBus.History == null)
                {
                    schoolBus.History = new List<History>();
                }
                // force add
                item.Id = 0;
                schoolBus.History.Add(item);
                _context.SchoolBuss.Update(schoolBus);
                _context.SaveChanges();
            }

            result.HistoryText = item.HistoryText;
            result.Id = item.Id;
            result.LastUpdateTimestamp = item.LastUpdateTimestamp;
            result.LastUpdateUserid = item.LastUpdateUserid;
            result.AffectedEntityId = id;

            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        public virtual IActionResult SchoolbusesIdNotesGetAsync(int id)
        {
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolBus = _context.SchoolBuss
                    .AsNoTracking()
                    .Include(x => x.Notes)
                    .First(a => a.Id == id);
                var result = schoolBus.Notes;
                return new ObjectResult(Mapper.Map<List<NoteViewModel>>(result));
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
        public virtual IActionResult SchoolbusesIdPdfpermitGetAsync(int id)
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

                    permitViewModel.SchoolBusOwnerAddressLine1 = schoolBus.CCWData.ICBCRegOwnerAddr1;

                    // line 2 is a combination of the various fields that may contain data.
                    List<string> strings = new List<string>();
                    if (!string.IsNullOrWhiteSpace(schoolBus.CCWData.ICBCRegOwnerAddr2))
                    {
                        strings.Add(schoolBus.CCWData.ICBCRegOwnerAddr2);
                    }
                    if (!string.IsNullOrWhiteSpace(schoolBus.CCWData.ICBCRegOwnerCity))
                    {
                        strings.Add(schoolBus.CCWData.ICBCRegOwnerCity);
                    }
                    if (!string.IsNullOrWhiteSpace(schoolBus.CCWData.ICBCRegOwnerProv))
                    {
                        strings.Add(schoolBus.CCWData.ICBCRegOwnerProv);
                    }
                    if (!string.IsNullOrWhiteSpace(schoolBus.CCWData.ICBCRegOwnerPostalCode))
                    {
                        strings.Add(schoolBus.CCWData.ICBCRegOwnerPostalCode);
                    }
                    if (strings.Count > 0)
                    {
                        permitViewModel.SchoolBusOwnerAddressLine2 = String.Join(", ", strings);
                    }

                    permitViewModel.SchoolBusOwnerPostalCode = schoolBus.CCWData.ICBCRegOwnerPostalCode;
                    permitViewModel.SchoolBusOwnerProvince = schoolBus.CCWData.ICBCRegOwnerProv;
                    permitViewModel.SchoolBusOwnerCity = schoolBus.CCWData.ICBCRegOwnerCity;
                    permitViewModel.SchoolBusOwnerName = schoolBus.CCWData.ICBCRegOwnerName;

                }

                permitViewModel.PermitIssueDate = schoolBus.PermitIssueDate == null ?
                    null : ConvertUtcToPacificTime((DateTime)schoolBus.PermitIssueDate).ToString("yyyy-MM-dd");

                permitViewModel.PermitNumber = schoolBus.PermitNumber;
                permitViewModel.RestrictionsText = schoolBus.RestrictionsText;
                permitViewModel.SchoolBusMobilityAidCapacity = schoolBus.MobilityAidCapacity.ToString();
                permitViewModel.UnitNumber = schoolBus.UnitNumber;
                permitViewModel.PermitClassCode = schoolBus.PermitClassCode;
                permitViewModel.BodyTypeCode = schoolBus.BodyTypeCode;
                permitViewModel.SchoolBusSeatingCapacity = schoolBus.SchoolBusSeatingCapacity;

                if (schoolBus.SchoolDistrict != null)
                {
                    permitViewModel.SchoolDistrictshortName = schoolBus.SchoolDistrict.ShortName;
                }

                string payload = JsonConvert.SerializeObject(permitViewModel);

                // pass the request on to the PDF Micro Service
                string pdfHost = Configuration["PDF_SERVICE_NAME"];

                string targetUrl = pdfHost + "/api/PDF/GetPDF";

                // call the microservice

                HttpClient client = new HttpClient();
                try
                {
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
                    string exceptionMessage = e.ToString();
                    Log.Error($"SchoolbusesIdPdfpermitGetAsync exception: {exceptionMessage}");
                }

                finally
                {
                    if (client != null)
                    {
                        try
                        {
                            client.Dispose();
                        }
                        catch (Exception e)
                        {
                            string exceptionMessage = e.ToString();
                            Log.Error($"SchoolbusesIdPdfpermitGetAsync exception: {exceptionMessage}");
                        }
                    }

                }

                // check that the result has a value
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new StatusCodeResult(503);
                }

            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        private static DateTime ConvertUtcToPacificTime(DateTime utcDate)
        {
            var date = ConvertTimeFromUtc(utcDate, "America/Vancouver");

            if (date != null)
                return (DateTime)date;

            date = ConvertTimeFromUtc(utcDate, "Pacific Standard Time");

            if (date != null)
                return (DateTime)date;

            return utcDate;
        }

        private static DateTime? ConvertTimeFromUtc(DateTime date, string timeZoneId)
        {
            try
            {
                var timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return TimeZoneInfo.ConvertTimeFromUtc(date, timezone);
            }
            catch (TimeZoneNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        /// Updates a single school bus object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual IActionResult SchoolbusesIdPutAsync(int id, SchoolBus item)
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
                .Include(x => x.SchoolBusOwner)
                .Include(x => x.District)
                .Include(x => x.SchoolDistrict)
                .Include(x => x.Inspector)
                .Include(x => x.SchoolDistrict)
                .Select(x => x);

            bool keySearch = false;

            // do key search fields first.

            if (regi != null)
            {
                // first convert the regi to a number.
                int tempRegi;
                bool parsed = int.TryParse(regi, out tempRegi);

                if (parsed)
                {
                    regi = tempRegi.ToString();
                }

                data = data.Where(x => x.ICBCRegistrationNumber.Contains(regi));
                keySearch = true;
            }

            if (vin != null)
            {
                // Normalize vin to ignore case and whitespaces
                vin = vin.Replace(" ", String.Empty).ToUpperInvariant();
                data = data.Where(x => x.VehicleIdentificationNumber.ToUpper().Contains(vin));
                keySearch = true;
            }

            if (plate != null)
            {
                // Normalize plate to ignore case and whitespaces
                plate = plate.Replace(" ", String.Empty).ToUpperInvariant();
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

                if (cities != null)
                {
                    data = data.Where(x => cities.Contains(x.HomeTerminalCityId));
                }

                if (schooldistricts != null)
                {
                    data = data.Where(x => schooldistricts.Contains(x.SchoolDistrictId));
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
                    var dateFrom = ((DateTime)startDate).Date;
                    data = data.Where(x => x.NextInspectionDate >= dateFrom);
                }

                if (endDate != null)
                {
                    var dateTo = ((DateTime)endDate).Date.AddDays(1).AddSeconds(-1);
                    data = data.Where(x => x.NextInspectionDate <= dateTo);
                }
            }

            var result = data.ToList();
            return new ObjectResult(result);
        }

        public (bool valid, IActionResult error) CreateSchoolBusNote(int sbId, NoteSaveViewModel note)
        {
            var sbEntity = _context.SchoolBuss
                .Include(x => x.Notes)
                .FirstOrDefault(x => x.Id == sbId);

            if (sbEntity == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 601, $"The school bus [{sbId}] does not exist.")));
            }

            if (note.NoteText.Length > 2048)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 605, $"The note text must have less than 2,048 characters.")));
            }

            note.SchoolBusOwnerId = null;

            sbEntity.Notes.Add(Mapper.Map<Note>(note));

            _context.SaveChanges();

            return (true, null);
        }

        public (bool valid, IActionResult error) UpdateSchoolBusNote(int sbId, int noteId, NoteSaveViewModel note)
        {
            var sbEntity = _context.SchoolBuss
                .Include(x => x.Notes)
                .FirstOrDefault(x => x.Id == sbId);

            if (sbEntity == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 601, $"The school bus [{sbId}] does not exist.")));
            }

            var noteEntity = sbEntity.Notes.FirstOrDefault(x => x.Id == noteId);

            if (noteEntity == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 602, $"The note [{noteId}] does not exist.")));
            }

            if (note.Id != noteId)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 603, $"The note ID [{noteId}] does not match the note ID [{note.Id}] of the content.")));
            }

            if (note.SchoolBusId == null || note.SchoolBusId != sbId)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 604, $"The school bus ID [{sbId}] does not match the school bus ID [{note.SchoolBusId}] of the content.")));
            }

            if (note.NoteText.Length > 2048)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 605, $"The note text must have less than 2,048 characters.")));
            }

            note.SchoolBusOwnerId = null;

            Mapper.Map(note, noteEntity);

            _context.SaveChanges();

            return (true, null);
        }

        public (bool valid, IActionResult error) DeleteSchoolBusNote(int sbId, int noteId)
        {
            if (!_context.SchoolBuss.Any(x => x.Id == sbId))
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 601, $"The school bus [{sbId}] does not exist.")));
            }

            var noteEntity = _context.Notes.FirstOrDefault(x => x.Id == noteId);

            if (noteEntity == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 602, $"The note [{noteId}] does not exist.")));
            }

            _context.Notes.Remove(noteEntity);

            _context.SaveChanges();

            return (true, null);
        }
    }
}
