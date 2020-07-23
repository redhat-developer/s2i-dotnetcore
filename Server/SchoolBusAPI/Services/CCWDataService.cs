/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using SchoolBusAPI.Extensions;
using Ws.Ccw.Reference;
using SchoolBusCcw;
using System;
using Microsoft.Extensions.Logging;
using System.ServiceModel;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICCWDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">CCWData created</response>
        IActionResult CcwdataBulkPostAsync(CCWData[] items);

        /// <summary>
        /// fetches data from the ICBC CCW system, and constructs a CCWData object from that.  Note that it does not perform the insert of that data into the database, only provides JSON data suitable for insertion. If a CCWData record exists in the schoolbus database then the id field will match that record, however all other data will be from the ICBC CCW system.
        /// </summary>
        /// <param name="regi">Registration Number (also known as Serial)</param>
        /// <param name="vin">Vehicle Identification Number</param>
        /// <param name="plate">License Plate String</param>
        /// <response code="200">OK</response>
        /// <response code="404">Vehicle not found in CCW system</response>
        IActionResult CcwdataFetchGetAsync(string regi, string vin, string plate);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult CcwdataGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        IActionResult CcwdataIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        IActionResult CcwdataIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        IActionResult CcwdataIdPutAsync(int id, CCWData item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">CCWData created</response>
        IActionResult CcwdataPostAsync(CCWData item);

        /// <summary>
        /// Get CCW data from CCW web service and update DB from the returned data
        /// </summary>
        /// <param name="regi"></param>
        /// <param name="plate"></param>
        /// <param name="vin"></param>
        /// <param name="userId"></param>
        /// <param name="guid"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        CCWData GetCCW(string regi, string plate, string vin, string userId, string guid, string directory);
    }

    /// <summary>
    /// 
    /// </summary>
    public class CCWDataService : ServiceBase, ICCWDataService
    {
        private readonly DbAppContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICCWService _ccwService;
        private readonly ILogger<CCWDataService> _logger;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public CCWDataService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, DbAppContext context, ICCWService ccwService, ILogger<CCWDataService> logger) : base(httpContextAccessor, context)
        {
            _context = context;
            _configuration = configuration;
            _ccwService = ccwService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">CCWData created</response>
        public virtual IActionResult CcwdataBulkPostAsync(CCWData[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (CCWData item in items)
            {

                bool exists = _context.CCWDatas.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.CCWDatas.Update(item);
                }
                else
                {
                    _context.CCWDatas.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }


        /// <summary>
        /// fetches data from the ICBC CCW system, and constructs a CCWData object from that.  Note that it does not perform the insert of that data into the database, only provides JSON data suitable for insertion. If a CCWData record exists in the schoolbus database then the id field will match that record, however all other data will be from the ICBC CCW system.
        /// </summary>
        /// <param name="regi">Registration Number (also known as Serial)</param>
        /// <param name="vin">Vehicle Identification Number</param>
        /// <param name="plate">License Plate String</param>
        /// <response code="200">OK</response>
        /// <response code="404">Vehicle not found in CCW system</response>
        public virtual IActionResult CcwdataFetchGetAsync(string regi, string vin, string plate)
        {
            var (userId, guid, directory) = User.GetUserInfo();

            CCWData result = GetCCW(regi, plate, vin, userId, guid, directory);

            if (result != null)
            {
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        public CCWData GetCCW(string regi, string plate, string vin, string userId, string guid, string directory)
        {
            // check we have the right headers.
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(guid) || string.IsNullOrEmpty(directory))
            {
                return null;
            }

            var batchUser = _configuration.GetValue<string>("CCW_USER_ID");
            var logPrefix = batchUser == userId ? "[Hangfire]" : "";

            // Check for the following data:
            // 1. registration
            // 2. plate
            // 3. decal

            VehicleDescription vehicle = null;
            if (regi != null)
            {
                // format the regi.
                try
                {
                    int registration = int.Parse(regi);
                    // zero padded, 8 digits
                    regi = registration.ToString("D8");
                }
                catch (Exception)
                {
                    _logger.LogInformation($"{logPrefix} Exception occured parsing registration number {regi}.");
                }

                vehicle = _ccwService.GetBCVehicleForRegistrationNumber(regi, userId, guid, directory);
            }

            if (vehicle == null && plate != null) // check the plate.
            {
                vehicle = _ccwService.GetBCVehicleForLicensePlateNumber(plate, userId, guid, directory);
            }

            if (vehicle == null && vin != null) // check the vin.
            {
                vehicle = _ccwService.GetBCVehicleForSerialNumber(vin, userId, guid, directory);
            }

            if (vehicle == null)
            {
                return null;
            }

            string icbcRegistrationNumber = vehicle.registrationNumber;

            CCWData ccwdata = null;

            if (_context.CCWDatas.Any(x => x.ICBCRegistrationNumber == icbcRegistrationNumber))
            {
                ccwdata = _context.CCWDatas.First(x => x.ICBCRegistrationNumber == icbcRegistrationNumber);
                _logger.LogInformation($"{logPrefix} Found CCW record for Registration # " + ccwdata.ICBCRegistrationNumber);
            }
            else
            {
                _logger.LogInformation($"{logPrefix} Creating new CCW record");
                ccwdata = new CCWData();
            }

            // update the ccw record.
            ccwdata.ICBCBody = vehicle.bodyCode;
            ccwdata.ICBCColour = vehicle.colour;
            ccwdata.ICBCCVIPDecal = vehicle.inspectionDecalNumber;
            ccwdata.ICBCCVIPExpiry = vehicle.inspectionExpiryDate;
            ccwdata.ICBCFleetUnitNo = SanitizeInt(vehicle.fleetUnitNumber);
            ccwdata.ICBCFuel = vehicle.fuelTypeDescription;
            ccwdata.ICBCGrossVehicleWeight = SanitizeInt(vehicle.grossVehicleWeight);
            ccwdata.ICBCMake = vehicle.make;
            ccwdata.ICBCModel = vehicle.model;
            ccwdata.ICBCGrossVehicleWeight = SanitizeInt(vehicle.grossVehicleWeight);
            ccwdata.ICBCModelYear = SanitizeInt(vehicle.modelYear);
            ccwdata.ICBCNetWt = SanitizeInt(vehicle.netWeight);
            ccwdata.ICBCNotesAndOrders = vehicle.cvipDataFromLastInspection;
            ccwdata.ICBCOrderedOn = vehicle.firstOpenOrderDate;
            ccwdata.ICBCRateClass = vehicle.rateClass;
            ccwdata.ICBCRebuiltStatus = vehicle.statusCode;
            ccwdata.ICBCRegistrationNumber = vehicle.registrationNumber;
            ccwdata.ICBCRegOwnerAddr1 = vehicle.owner.mailingAddress1;
            ccwdata.ICBCRegOwnerAddr2 = vehicle.owner.mailingAddress2;
            ccwdata.ICBCRegOwnerCity = vehicle.owner.mailingAddress3;
            ccwdata.ICBCRegOwnerName = vehicle.owner.name1;
            ccwdata.ICBCRegOwnerPODL = vehicle.principalOperatorDlNum;
            ccwdata.ICBCRegOwnerPostalCode = vehicle.owner.postalCode;
            ccwdata.ICBCRegOwnerProv = vehicle.owner.mailingAddress4;
            ccwdata.ICBCRegOwnerRODL = vehicle.owner.driverLicenseNumber;
            ccwdata.ICBCSeatingCapacity = SanitizeInt(vehicle.seatingCapacity);
            ccwdata.ICBCVehicleType = vehicle.vehicleType + " - " + vehicle.vehicleTypeDescription;

            ccwdata.ICBCVehicleIdentificationNumber = vehicle.serialNumber;

            ccwdata.NSCPlateDecal = vehicle.decalNumber;
            ccwdata.NSCPolicyEffectiveDate = vehicle.policyStartDate;
            ccwdata.NSCPolicyExpiryDate = vehicle.policyExpiryDate;
            ccwdata.NSCPolicyStatus = vehicle.policyStatus + " - " + vehicle.policyStatusDescription;

            // policyAquiredCurrentStatusDate is the preferred field, however it is often null.
            if (vehicle.policyAcquiredCurrentStatusDate != null)
            {
                ccwdata.NSCPolicyStatusDate = vehicle.policyAcquiredCurrentStatusDate;
            }
            else if (vehicle.policyTerminationDate != null)
            {
                ccwdata.NSCPolicyStatusDate = vehicle.policyTerminationDate;
            }
            else if (vehicle.policyReplacedOnDate != null)
            {
                ccwdata.NSCPolicyStatusDate = vehicle.policyReplacedOnDate;
            }
            else if (vehicle.policyStartDate != null)
            {
                ccwdata.NSCPolicyStatusDate = vehicle.policyStartDate;
            }

            if (vehicle.owner != null)
            {
                ccwdata.ICBCRegOwnerRODL = vehicle.owner.driverLicenseNumber;
            }

            ccwdata.ICBCLicencePlateNumber = vehicle.policyNumber;
            // these fields are the same.
            ccwdata.NSCPolicyNumber = vehicle.policyNumber;
            ccwdata.NSCClientNum = vehicle.nscNumber;

            ccwdata.DateFetched = DateTime.UtcNow;

            // get the nsc client organization data.

            bool foundNSCData = false;

            if (!string.IsNullOrEmpty(ccwdata.NSCPolicyNumber))
            {
                string organizationNameCode = "LE";

                ClientOrganization clientOrganization = _ccwService.GetCurrentClientOrganization(ccwdata.NSCClientNum, organizationNameCode, userId, guid, directory);

                if (clientOrganization != null)
                {
                    foundNSCData = true;
                    ccwdata.NSCCarrierConditions = clientOrganization.nscInformation.carrierStatus;
                    ccwdata.NSCCarrierName = clientOrganization.displayName;
                    ccwdata.NSCCarrierSafetyRating = clientOrganization.nscInformation.safetyRating;
                }

                // now try the individual service if there was no match.
                if (foundNSCData == false)
                {
                    ClientIndividual clientIndividual = _ccwService.GetCurrentClientIndividual(ccwdata.NSCClientNum, organizationNameCode, userId, guid, directory);

                    if (clientIndividual != null)
                    {
                        foundNSCData = true;
                        ccwdata.NSCCarrierConditions = clientIndividual.nscInformation.carrierStatus;
                        ccwdata.NSCCarrierName = clientIndividual.displayName;
                        ccwdata.NSCCarrierSafetyRating = clientIndividual.nscInformation.safetyRating;
                    }
                }
            }

            if (ccwdata.Id > 0)
            {
                _context.Update(ccwdata);
            }
            else
            {
                _context.Add(ccwdata);
            }

            _logger.LogInformation($"{logPrefix} CCW data has been added/updated.");
            _context.SaveChanges();

            return ccwdata;
        }

        /// <summary>
        /// Utility function to convert strings to nullable int.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private int? SanitizeInt(string val)
        {
            int? result = null;
            try
            {
                result = int.Parse(val);
            }
            catch (Exception e)
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        public virtual IActionResult CcwdataGetAsync()
        {
            var result = _context.CCWDatas.ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of CCWData to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdDeletePostAsync(int id)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.CCWDatas.First(a => a.Id == id);
                if (item != null)
                {
                    _context.CCWDatas.Remove(item);
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
        /// <param name="id">id of CCWData to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdGetAsync(int id)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.CCWDatas.First(a => a.Id == id);
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
        /// <param name="id">id of CCWData to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">CCWData not found</response>
        public virtual IActionResult CcwdataIdPutAsync(int id, CCWData item)
        {
            var exists = _context.CCWDatas.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.CCWDatas.Update(item);
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
        /// <response code="201">CCWData created</response>
        public virtual IActionResult CcwdataPostAsync(CCWData item)
        {
            _context.CCWDatas.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
