using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolBus.WS.CCW.Facade.Service;
using SchoolBus.WS.CCW.Reference;
using System.ServiceModel;

namespace CCW.Controllers
{
    [Route("api/[controller]")]
    public class CCWController : Controller
    {
        readonly IConfiguration Configuration;

        ICCWService service;

        public CCWController(IConfigurationRoot configuration)
        {
            Configuration = configuration;

            service = CCWServiceFactory.CreateService(configuration);
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
    }
}
