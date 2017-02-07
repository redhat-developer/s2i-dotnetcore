using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolBus.WS.CCW.Facade.Service;
using SchoolBus.WS.CCW.Reference;
using System.ServiceModel;
using Microsoft.EntityFrameworkCore;
using CCW.Models;

namespace CCW.Controllers
{
    [Route("api/[controller]")]
    public class CCWController : Controller
    {
        readonly IConfiguration Configuration;
        private readonly DbAppContext _context;

        ICCWService service;

        public CCWController(IConfigurationRoot configuration, DbAppContext context)
        {
            Configuration = configuration;

            service = CCWServiceFactory.CreateService(configuration);
            _context = context;

        }

        [HttpGet]
        [Route("GetBySerial/{serial}")]

        public virtual IActionResult GetBySerial([FromRoute]string serial)
        {
            var result = new ObjectResult("");
            try
            {
                result = new ObjectResult(service.GetBCVehicleForSerialNumber(serial));
            }
            catch (AggregateException ae)
            {
                ae.Handle((x) =>
                {
                    if (x is FaultException<CVSECommonException>) // From the web service.
                    {
                        result = new ObjectResult(x);
                        return true;
                    }
                    return true; // ignore other exceptions
                });
            }

            return new ObjectResult(result);            
        }

        [HttpGet]
        [Route("GetByRegi/{regi}")]
        public virtual IActionResult GetByRegi([FromRoute] string regi)
        {
            var result = new ObjectResult("");
            try
            {
                result = new ObjectResult(service.GetBCVehicleForRegistrationNumber(regi));                
            }
            catch (AggregateException ae)
            {
                ae.Handle((x) =>
                {
                    if (x is FaultException<CVSECommonException>) // From the web service.
                    {
                        result = new ObjectResult(x);
                        return true;
                    }
                    return true; // ignore other exceptions
                });
            }


            return new ObjectResult(result);          
        }

        [HttpGet]
        [Route("GetByPlate/{plate}")]
        public virtual IActionResult GetByPlate([FromRoute] string plate)
        {
            var result = new ObjectResult("");
            try
            {
                result = new ObjectResult(service.GetBCVehicleForLicensePlateNumber(plate));
            }
            catch (AggregateException ae)
            {
                ae.Handle((x) =>
                {
                    if (x is FaultException<CVSECommonException>) // From the web service.
                    {
                        result = new ObjectResult(x);
                        return true;
                    }
                    return true; // ignore other exceptions
                });
            }


            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("GetCCW")]
        public virtual IActionResult GetCCW([FromQuery] string regi, [FromQuery] string plate, [FromQuery] string vin)
        {
            // Check for the following data:
            // 1. registration
            // 2. plate
            // 3. decal

            VehicleDescription vehicle = null;
            if (regi != null)
            {
                try
                {
                    vehicle = service.GetBCVehicleForRegistrationNumber(regi);
                }
                catch (Exception e)
                {
                    vehicle = null;
                }
            }            
            if (vehicle == null && plate != null) // check the plate.
            {
                try
                {
                    vehicle = service.GetBCVehicleForLicensePlateNumber(plate);
                }
                catch (Exception e)
                {
                    vehicle = null;
                }
            }
            if (vehicle == null && vin != null) // check the vin.
            {
                try
                {
                    vehicle = service.GetBCVehicleForSerialNumber(vin);
                }
                catch (Exception e)
                {
                    vehicle = null;
                }
            }
            if (vehicle == null)
            {
                return new StatusCodeResult(404); // Can't find the vehicle.
            }
            else
            {
                string icbcRegistrationNumber = vehicle.registrationNumber;
                CCWData ccwdata = null;
                bool existing = false;
                if (_context.CCWDatas.Any(x => x.ICBCRegistrationNumber == icbcRegistrationNumber))
                {
                    ccwdata = _context.CCWDatas.First(x => x.ICBCRegistrationNumber == icbcRegistrationNumber);
                    existing = true;
                }
                else
                {
                    ccwdata = new CCWData();
                }

                // update the ccw record.

                ccwdata.ICBCBody = vehicle.bodyCode;
                ccwdata.ICBCColour = vehicle.colour;
                ccwdata.ICBCCVIPDecal = vehicle.inspectionDecalNumber;
                ccwdata.ICBCCVIPExpiry = vehicle.inspectionExpiryDate;
                ccwdata.ICBCFleetUnitNo = SanitizeInt(vehicle.fleetUnitNumber);
                ccwdata.ICBCFuel = vehicle.fuelType;
                ccwdata.ICBCGrossVehicleWeight = SanitizeInt(vehicle.grossVehicleWeight);
                ccwdata.ICBCMake = vehicle.make;
                ccwdata.ICBCModel = vehicle.model;
                ccwdata.ICBCGrossVehicleWeight = SanitizeInt(vehicle.grossVehicleWeight);
                ccwdata.ICBCModelYear = SanitizeInt(vehicle.modelYear);
                ccwdata.ICBCNetWt = SanitizeInt(vehicle.netWeight);
                ccwdata.ICBCNotesAndOrders = vehicle.cvipDataFromLastInspection;
                ccwdata.ICBCOrderedOn = null;
                ccwdata.ICBCRateClass = vehicle.rateClass;
                ccwdata.ICBCRebuiltStatus = "";
                ccwdata.ICBCRegistrationNumber = vehicle.registrationNumber;
                ccwdata.ICBCRegOwnerAddr1 = vehicle.owner.mailingAddress1;
                ccwdata.ICBCRegOwnerAddr2 = vehicle.owner.mailingAddress2;
                ccwdata.ICBCRegOwnerCity = vehicle.owner.mailingAddress3;
                ccwdata.ICBCRegOwnerName = vehicle.owner.name1;
                ccwdata.ICBCRegOwnerPool = "";
                ccwdata.ICBCRegOwnerPostalCode = vehicle.owner.postalCode;
                ccwdata.ICBCRegOwnerProv = vehicle.owner.mailingAddress4;
                ccwdata.ICBCRegOwnerRODL = "";
                ccwdata.ICBCRegOwnerStatus = "";
                ccwdata.ICBCSeatingCapacity = SanitizeInt(vehicle.seatingCapacity);
                ccwdata.ICBCVehicleType = vehicle.vehicleType;

                // get the nsc data.

                string nscnumber = vehicle.nscNumber;

                return new ObjectResult(ccwdata);
            }

        }

            /// <summary>
            /// Utility function to convert strings to nullable int.
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            private int? SanitizeInt (string val)
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
        }
    }
