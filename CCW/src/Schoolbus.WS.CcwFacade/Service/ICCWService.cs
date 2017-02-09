using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolBus.WS.CCW.Reference;

namespace SchoolBus.WS.CCW.Facade.Service
{
    public interface ICCWService
    {
        VehicleDescription GetBCVehicleForSerialNumber(string serialNumber, string userId, string guid, string directory);

        VehicleDescription GetBCVehicleForRegistrationNumber(string registrationNumber, string userId, string guid, string directory);

        VehicleDescription GetBCVehicleForLicensePlateNumber(string licensePlateNumber, string userId, string guid, string directory);

        VehicleDescription GetBCVehicleForDecalNumber(string decalNumber, string userId, string guid, string directory);

        ClientOrganization GetCurrentClientOrganization(string clientNumber, string organizationNameCode, string userId, string guid, string directory);

        IcbcVehicleDescription GetIcbcVehicleForRegistrationNumberAsync(string registrationNumber, System.DateTime date, string userId, string guid, string directory);
    }
}
