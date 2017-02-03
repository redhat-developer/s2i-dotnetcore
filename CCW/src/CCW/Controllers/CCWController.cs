using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolBus.WS.CCW.Facade.Service;

namespace CCW.Controllers
{
    [Route("api/[controller]")]
    public class CCWController : Controller
    {
        readonly IConfiguration Configuration;

        ICCWService service;

        public CCWController(IConfiguration configuration)
        {
            Configuration = configuration;

            service = CCWServiceFactory.CreateService(configuration);
        }

        [HttpGet]
        [Route("GetBySerial/{serial}")]

        public virtual IActionResult GetBySerial([FromRoute]string serial)
        {
            var result = service.GetBCVehicleForSerialNumber(serial);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("GetByRegi/{regi}")]
        public virtual IActionResult GetByRegi([FromRoute] string regi)
        {
            var result = service.GetBCVehicleForRegistrationNumber(regi);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("GetByPlate/{plate}")]
        public virtual IActionResult GetByPlate([FromRoute] string plate)
        {
            var result = service.GetBCVehicleForLicensePlateNumber(plate);
            return new ObjectResult(result);
        }
    }
}
