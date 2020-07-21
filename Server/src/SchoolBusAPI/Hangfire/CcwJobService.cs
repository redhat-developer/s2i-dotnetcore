using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolBusAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.Hangfire
{
    public interface ICcwJobService 
    {
        Task PopulateCCWJob();
        Task UpdateCCWJob();
    }

    public class CcwJobService : ICcwJobService
    {
        private readonly DbAppContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        private readonly string _userId;
        private readonly string _userGuid;
        private readonly string _directory;
        private readonly string _ccwHost;

        public CcwJobService(DbAppContext context, IConfiguration configuration, ILogger<CcwJobService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;

            _userId = _configuration["CCW_userId"];
            _userGuid = _configuration["CCW_guid"];
            _directory = _configuration["CCW_directory"];
            _ccwHost = _configuration["CCW_SERVICE_NAME"];
        }

    /// <summary>
    /// Hangfire job to populate CCW data.  Only used for a deploy to PROD with a new database.
    /// </summary>
    /// <param name="connectionString"></param>
    /// <param name="Configuration"></param>
    [AutomaticRetry(Attempts = 0)]
        public async Task PopulateCCWJob()
        {
            await Task.CompletedTask;

            // sanity check
            if (_userId != null && _userGuid != null && _directory != null && _ccwHost != null)
            {
                // make a database connection and see if there are any records that are missing the CCW link.
                // we restrict the query to records not updated in the last 6 hours so that the batch process does not repeatedly try a failed record. 
                var data = _context.SchoolBuss
                    .FirstOrDefault(x => x.CCWDataId == null && x.LastUpdateTimestamp < DateTime.UtcNow.AddHours(-6));

                if (data == null)
                {
                    _logger.LogInformation("[Hangfire] PopulateCCWJob - No bus with CCWDataId = null.");
                    return;
                }

                // get the data for the request from the result of the database query.
                string regi = data.ICBCRegistrationNumber;
                string vin = data.VehicleIdentificationNumber;
                string plate = data.LicencePlateNumber;

                // Fetch the record.
                CCWData cCWData = CCWTools.FetchCCW(_ccwHost, regi, vin, plate, _userId, _userGuid, _directory);

                if (cCWData == null)
                {
                    _logger.LogInformation($"[Hangfire] PopulateCCWJob - No data from CCW for regi: {regi} vin: {vin}, plate: {plate}.");
                    return;
                }

                data.CCWData = cCWData;

                // ensure that the record is touched in the database
                data.LastUpdateTimestamp = DateTime.UtcNow;
                _context.SaveChanges();
                _logger.LogInformation($"[Hangfire] PopulateCCWJob - Saved bus record with the ID {data.Id}.");
            }
        }

        /// <summary>
        /// Hangfire job to refresh existing data.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="Configuration"></param>
        [AutomaticRetry(Attempts = 0)]
        public async Task UpdateCCWJob()
        {
            await Task.CompletedTask;

            // sanity check
            if (_userId != null && _userGuid != null && _directory != null && _ccwHost != null)
            {
                int maxUpdateCount = _context.CCWDatas
                    .Count(x => x.LastUpdateTimestamp > DateTime.UtcNow.AddDays(-1));

                if (maxUpdateCount > 500)
                {
                    _logger.LogInformation($"[Hangfire] UpdateCCWJob - Today's max update count({maxUpdateCount}) reached.");
                    return;
                }

                // make a database connection and see if there are any records that are missing the CCW link.                
                var data = _context.CCWDatas
                    .OrderBy(x => x.LastUpdateTimestamp)
                    .FirstOrDefault(x => x.LastUpdateTimestamp < DateTime.UtcNow.AddDays(-1));

                if (data == null)
                {
                    _logger.LogInformation($"[Hangfire] UpdateCCWJob - All records up to {DateTime.UtcNow.AddDays(-1)} has been done.");
                    return;
                }

                // get the data for the request from the result of the database query.
                string regi = data.ICBCRegistrationNumber;
                string vin = data.ICBCVehicleIdentificationNumber;
                // plate is excluded from the batch update because it can be shared.
                string plate = null;

                // Fetch the record. this FetchCCW actually updates CCWData too. Refer to CCW microservice
                CCWData cCWData = CCWTools.FetchCCW(_ccwHost, regi, vin, plate, _userId, _userGuid, _directory);

                data.LastUpdateTimestamp = DateTime.UtcNow;

                // fetch did not work, but we don't want it to fire again, so update the timestamp.
                if (cCWData == null)
                {
                    _logger.LogInformation($"[Hangfire] UpdateCCWJob - No data from CCW for regi: {regi} vin: {vin}, plate: {plate}.");
                    _context.SaveChanges();
                    return;
                }

                //update records in SchoolBus table
                bool exists = _context.SchoolBuss.Any(x => x.CCWDataId == cCWData.Id);
                if (exists)
                {
                    SchoolBus bus = _context.SchoolBuss.First(a => a.CCWDataId == cCWData.Id);
                    if (cCWData.ICBCRegistrationNumber != null && bus.ICBCRegistrationNumber != null && !cCWData.ICBCRegistrationNumber.Equals(bus.ICBCRegistrationNumber))
                    {
                        bus.ICBCRegistrationNumber = cCWData.ICBCRegistrationNumber;
                    }

                    if (cCWData.ICBCVehicleIdentificationNumber != null && bus.VehicleIdentificationNumber != null && !cCWData.ICBCVehicleIdentificationNumber.Equals(bus.VehicleIdentificationNumber))
                    {
                        bus.VehicleIdentificationNumber = cCWData.ICBCVehicleIdentificationNumber;
                    }

                    if (cCWData.ICBCLicencePlateNumber != null && bus.LicencePlateNumber != null && !cCWData.ICBCLicencePlateNumber.Equals(bus.LicencePlateNumber))
                    {
                        bus.LicencePlateNumber = cCWData.ICBCLicencePlateNumber;
                    }

                    _context.SaveChanges();
                    _logger.LogInformation($"[Hangfire] UpdateCCWJob - Saved bus record with the ID {data.Id}.");
                }
            }

            await Task.CompletedTask;
        }
    }
}
