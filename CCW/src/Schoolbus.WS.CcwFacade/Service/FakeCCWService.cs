using Schoolbus.WS.CcwFacade.Service.Mocks;
using SchoolBus.WS.CCW.Reference;
using SchoolBus.WS.CcwFacade.Service.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBus.WS.CCW.Facade.Service
{
    /// <summary>
    /// Fake implementation of the srevice for testing
    /// </summary>
    public class FakeCCWService : ICCWService
    {
        public VehicleDescription GetBCVehicleForSerialNumber(string userId, string guid, string directory, string serialNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }

        public VehicleDescription GetBCVehicleForRegistrationNumber(string userId, string guid, string directory, string registrationNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }

        public VehicleDescription GetBCVehicleForLicensePlateNumber(string userId, string guid, string directory, string licensePlateNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }

        public VehicleDescription GetBCVehicleForDecalNumber(string userId, string guid, string directory, string decalNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }

        public ClientOrganization GetCurrentClientOrganization(string clientNumber, string organizationNameCode, string userId, string guid, string directory)
        {
            return MockClientOrganization.GetClientOrganization();
        }

        public ClientIndividual GetCurrentClientIndividual(string clientNumber, string organizationNameCode, string userId, string guid, string directory)
        {
            return new ClientIndividual();
        }

        public IcbcVehicleDescription GetIcbcVehicleForRegistrationNumberAsync(string registrationNumber, System.DateTime date, string userId, string guid, string directory)
        {
            return new IcbcVehicleDescription();
        }
    }
}
