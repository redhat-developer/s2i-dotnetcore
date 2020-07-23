using Microsoft.Extensions.Logging;
using System;
using System.ServiceModel;
using System.Text;
using Ws.Ccw.Reference;

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

        IcbcVehicleDescription GetIcbcVehicleForRegistrationNumber(string registrationNumber, System.DateTime date, string userId, string guid, string directory);
    }

    public class CCWService : ICCWService
    {
        public readonly CVSECommonClient _client;
        private readonly ILogger<CVSECommonClient> _logger;

        public CCWService(CVSECommonClient client, ILogger<CVSECommonClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public VehicleDescription GetBCVehicleForSerialNumber(string serialNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var function = "GetBCVehicleForSerialNumber";
            var logPrefix = appId == _client.BatchAppId ? "[Hangfire]" : "";

            try
            {
                var task = _client.getBCVehicleForSerialNumberAsync(serialNumber, userId, guid, directory, appId);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex => HandleFaultException(logPrefix, function, ex, serialNumber));
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{logPrefix} Unknown Error {function}.");
                _logger.LogInformation($"{logPrefix} {e}");
                return null;
            }
        }

        public VehicleDescription GetBCVehicleForRegistrationNumber(string registrationNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var function = "GetBCVehicleForRegistrationNumber";
            var logPrefix = appId == _client.BatchAppId ? "[Hangfire]" : "";

            try
            {
                var task = _client.getBCVehicleForRegistrationNumberAsync(registrationNumber, userId, guid, directory, appId);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex => HandleFaultException(logPrefix, function, ex, registrationNumber));
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{logPrefix} Unknown Error {function}.");
                _logger.LogInformation($"{logPrefix} {e}");
                return null;
            }
        }

        public VehicleDescription GetBCVehicleForLicensePlateNumber(string licensePlateNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var function = "GetBCVehicleForLicensePlateNumber";
            var logPrefix = appId == _client.BatchAppId ? "[Hangfire]" : "";

            try
            {
                var task = _client.getBCVehicleForLicensePlateNumberAsync(licensePlateNumber, userId, guid, directory, appId);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex => HandleFaultException(logPrefix, function, ex, licensePlateNumber));
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{logPrefix} Unknown Error {function}.");
                _logger.LogInformation($"{logPrefix} {e}");
                return null;
            }
        }

        public VehicleDescription GetBCVehicleForDecalNumber(string decalNumber, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var function = "GetBCVehicleForDecalNumber";
            var logPrefix = appId == _client.BatchAppId ? "[Hangfire]" : "";

            try
            {
                var task = _client.getBCVehicleForDecalNumberAsync(decalNumber, userId, guid, directory, appId);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex => HandleFaultException(logPrefix, function, ex, decalNumber));
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{logPrefix} Unknown Error {function}.");
                _logger.LogInformation($"{logPrefix} {e}");
                return null;
            }
        }

        public IcbcVehicleDescription GetIcbcVehicleForRegistrationNumber(string registrationNumber, System.DateTime date, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var function = "GetIcbcVehicleForRegistrationNumber";
            var logPrefix = appId == _client.BatchAppId ? "[Hangfire]" : "";

            try
            {
                var task = _client.getIcbcVehicleForRegistrationNumberAsync(registrationNumber, date, userId, guid, directory, appId);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex => HandleFaultException(logPrefix, function, ex, registrationNumber, date.ToString("yyyy-MM-dd")));
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{logPrefix} Unknown Error{function}.");
                _logger.LogInformation($"{logPrefix} {e}");
                return null;
            }
        }

        public ClientOrganization GetCurrentClientOrganization(string clientNumber, string organizationNameCode, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var function = "GetCurrentClientOrganization";
            var logPrefix = appId == _client.BatchAppId ? "[Hangfire]" : "";

            try
            {
                var task = _client.getCurrentClientOrganizationAsync(clientNumber, organizationNameCode, userId, guid, directory, appId);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex => HandleFaultException(logPrefix, function, ex, clientNumber, organizationNameCode));
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{logPrefix} Unknown Error {function}.");
                _logger.LogInformation($"{logPrefix} {e}");
                return null;
            }
        }

        public ClientIndividual GetCurrentClientIndividual(string clientNumber, string organizationNameCode, string userId, string guid, string directory)
        {
            string appId = _client.AppId;
            if (userId != null && userId.Equals(_client.BatchUser))
            {
                // batch process.
                appId = _client.BatchAppId;
            }

            var function = "GetCurrentClientIndividual";
            var logPrefix = appId == _client.BatchAppId ? "[Hangfire]" : "";

            try
            {
                var task = _client.getCurrentClientIndividualAsync(clientNumber, organizationNameCode, userId, guid, directory, appId);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex => HandleFaultException(logPrefix, function, ex, clientNumber, organizationNameCode));
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{logPrefix} Unknown Error {function}.");
                _logger.LogInformation($"{logPrefix} {e}");
                return null;
            }
        }

        private bool HandleFaultException(string logPrefix, string function, Exception ex, params string[] args)
        {
            var arguments = new StringBuilder();
            for (var i = 0; i < args.Length; i++)
            {
                arguments.Append($"{args[i]}, ");
            }

            var parameters = arguments.ToString().Trim().TrimEnd(',');

            _logger.LogInformation($"{logPrefix} Aggregate Exception occured while calling {function}({parameters})");

            if (ex is FaultException<CVSECommonException>) // From the web service.
            {
                _logger.LogInformation($"{logPrefix} CVSECommonException:");
                FaultException<CVSECommonException> fault = (FaultException<CVSECommonException>)ex;
                _logger.LogInformation($"{logPrefix}   errorId: {fault.Detail.errorId}");
                _logger.LogInformation($"{logPrefix}   errorMessage: {fault.Detail.errorMessage}");
                _logger.LogInformation($"{logPrefix}   systemError: {fault.Detail.systemError}");
            }

            return true; // ignore other exceptions
        }
    }
}
