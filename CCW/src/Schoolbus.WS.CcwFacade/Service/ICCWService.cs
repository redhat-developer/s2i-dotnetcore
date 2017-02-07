using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolBus.WS.CCW.Reference;

namespace SchoolBus.WS.CCW.Facade.Service
{
    public interface ICCWService
    {
        VehicleDescription GetBCVehicleForSerialNumber(string userId, string guid, string directory, string serialNumber);

        VehicleDescription GetBCVehicleForRegistrationNumber(string userId, string guid, string directory, string registrationNumber);

        VehicleDescription GetBCVehicleForLicensePlateNumber(string userId, string guid, string directory, string licensePlateNumber);

        VehicleDescription GetBCVehicleForDecalNumber(string userId, string guid, string directory, string decalNumber);
    }
}
