using Ws.Ccw.Reference;
using System.ServiceModel;

namespace SchoolBusCcw
{
    public interface ICCWService
    {
        VehicleDescription GetBCVehicleForSerialNumber(string serialNumber, string userId, string guid, string directory);

        VehicleDescription GetBCVehicleForRegistrationNumber(string registrationNumber, string userId, string guid, string directory);

        VehicleDescription GetBCVehicleForLicensePlateNumber(string licensePlateNumber, string userId, string guid, string directory);

        VehicleDescription GetBCVehicleForDecalNumber(string decalNumber, string userId, string guid, string directory);

        ClientOrganization GetCurrentClientOrganization(string clientNumber, string organizationNameCode, string userId, string guid, string directory);

        ClientIndividual GetCurrentClientIndividual(string clientNumber, string organizationNameCode, string userId, string guid, string directory);

        IcbcVehicleDescription GetIcbcVehicleForRegistrationNumberAsync(string registrationNumber, System.DateTime date, string userId, string guid, string directory);
    }

    public class CCWService : ICCWService
    {
        public readonly CVSECommonClient _client;

        public CCWService(CVSECommonClient client)
        {
            _client = client;
        }

        public VehicleDescription GetBCVehicleForSerialNumber(string serialNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var task = _client.getBCVehicleForSerialNumberAsync(serialNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public VehicleDescription GetBCVehicleForRegistrationNumber(string registrationNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }
            var task = _client.getBCVehicleForRegistrationNumberAsync(registrationNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public VehicleDescription GetBCVehicleForLicensePlateNumber(string licensePlateNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }
            var task = _client.getBCVehicleForLicensePlateNumberAsync(licensePlateNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public VehicleDescription GetBCVehicleForDecalNumber(string decalNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }
            var task = _client.getBCVehicleForDecalNumberAsync(decalNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public IcbcVehicleDescription GetIcbcVehicleForRegistrationNumberAsync(string registrationNumber, System.DateTime date, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }
            var task = _client.getIcbcVehicleForRegistrationNumberAsync(registrationNumber, date, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        private static BasicHttpBinding GetBinding()
        {
            HttpTransportSecurity transport = new HttpTransportSecurity();
            transport.ClientCredentialType = HttpClientCredentialType.Basic;

            return new BasicHttpBinding()
            {
                Security = { Mode = BasicHttpSecurityMode.Transport, Transport = transport }
            };
        }

        public ClientOrganization GetCurrentClientOrganization(string clientNumber, string organizationNameCode, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }
            var task = _client.getCurrentClientOrganizationAsync(clientNumber, organizationNameCode, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public ClientIndividual GetCurrentClientIndividual(string clientNumber, string organizationNameCode, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }
            var task = _client.getCurrentClientIndividualAsync(clientNumber, organizationNameCode, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }
    }
}
