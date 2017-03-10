using SchoolBus.WS.CCW.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SchoolBus.WS.CCW.Facade.Service
{
    public class CCWService : ICCWService
    {
        public readonly CVSECommonClient Client;
        private readonly string endpointURL;
        private readonly string applicationIdentifier;
        private readonly string applicationBatchIdentifier;
        private readonly string basicAuth_username;
        private readonly string basicAuth_password;
        private readonly string batchUser;

        public CCWService(string endpointURL, string applicationIdentifier, string basicAuth_username, string basicAuth_password, string batchUser)
        {
            this.endpointURL = endpointURL;
            this.applicationIdentifier = applicationIdentifier;
            this.basicAuth_username = basicAuth_username;
            this.basicAuth_password = basicAuth_password;
            this.batchUser = batchUser;
            this.applicationBatchIdentifier = "SBI-BATCH";
            this.Client = new CVSECommonClient(GetBinding(), new EndpointAddress(this.endpointURL));

            this.Client.ClientCredentials.UserName.UserName = this.basicAuth_username;
            this.Client.ClientCredentials.UserName.Password = this.basicAuth_password;
        }

        public VehicleDescription GetBCVehicleForSerialNumber(string serialNumber, string userId, string guid, string directory)
        {
            string appId = applicationIdentifier;
            if (userId != null && userId.Equals(this.batchUser))
            {
                // batch process.
                appId = applicationBatchIdentifier;
            }
            var task = this.Client.getBCVehicleForSerialNumberAsync(serialNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public VehicleDescription GetBCVehicleForRegistrationNumber(string registrationNumber, string userId, string guid, string directory)
        {
            string appId = applicationIdentifier;
            if (userId != null && userId.Equals(this.batchUser))
            {
                // batch process.
                appId = applicationBatchIdentifier;
            }
            var task = this.Client.getBCVehicleForRegistrationNumberAsync(registrationNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }


        public VehicleDescription GetBCVehicleForLicensePlateNumber(string licensePlateNumber, string userId, string guid, string directory)
        {
            string appId = applicationIdentifier;
            if (userId != null && userId.Equals(this.batchUser))
            {
                // batch process.
                appId = applicationBatchIdentifier;
            }
            var task = this.Client.getBCVehicleForLicensePlateNumberAsync(licensePlateNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public VehicleDescription GetBCVehicleForDecalNumber(string decalNumber, string userId, string guid, string directory)
        {
            string appId = applicationIdentifier;
            if (userId != null && userId.Equals(this.batchUser))
            {
                // batch process.
                appId = applicationBatchIdentifier;
            }
            var task = this.Client.getBCVehicleForDecalNumberAsync(decalNumber, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }

        public IcbcVehicleDescription GetIcbcVehicleForRegistrationNumberAsync(string registrationNumber, System.DateTime date, string userId, string guid, string directory)
        {
            string appId = applicationIdentifier;
            if (userId != null && userId.Equals(this.batchUser))
            {
                // batch process.
                appId = applicationBatchIdentifier;
            }
            var task = this.Client.getIcbcVehicleForRegistrationNumberAsync(registrationNumber, date, userId, guid, directory, appId);
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
            string appId = applicationIdentifier;
            if (userId != null && userId.Equals(this.batchUser))
            {
                // batch process.
                appId = applicationBatchIdentifier;
            }
            var task = this.Client.getCurrentClientOrganizationAsync(clientNumber, organizationNameCode, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }


        public ClientIndividual GetCurrentClientIndividual(string clientNumber, string organizationNameCode, string userId, string guid, string directory)
        {
            string appId = applicationIdentifier;
            if (userId != null && userId.Equals(this.batchUser))
            {
                // batch process.
                appId = applicationBatchIdentifier;
            }
            var task = this.Client.getCurrentClientIndividualAsync(clientNumber, organizationNameCode, userId, guid, directory, appId);
            task.Wait();
            return task.Result;
        }
    }
}
