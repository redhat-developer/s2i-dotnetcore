using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolBus.WS.CCW.Reference;

namespace SchoolBus.WS.CCW.Facade.Service
{
    public interface ICCWService
    {
        VehicleDescription GetBCVehicleForSerialNumber(string serialNumber);

        VehicleDescription GetBCVehicleForRegistrationNumber(string registrationNumber);

        VehicleDescription GetBCVehicleForLicensePlateNumber(string licensePlateNumber);

        VehicleDescription GetBCVehicleForDecalNumber(string decalNumber);
    }
}
