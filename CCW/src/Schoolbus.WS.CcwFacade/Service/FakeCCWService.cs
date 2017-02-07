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
        public VehicleDescription GetBCVehicleForSerialNumber(string serialNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }

        public VehicleDescription GetBCVehicleForRegistrationNumber(string registrationNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }

        public VehicleDescription GetBCVehicleForLicensePlateNumber(string licensePlateNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }

        public VehicleDescription GetBCVehicleForDecalNumber(string decalNumber)
        {
            return MockVehicleDescription.GetVehicleDescription();
        }
    }
}
