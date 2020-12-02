using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;
using SchoolBusCcw;
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
        private readonly ICCWDataService _ccwDataService;
        private readonly ILogger _logger;

        private readonly string _userId;
        private readonly string _userGuid;
        private readonly string _userDir;

        public CcwJobService(DbAppContext context, IConfiguration configuration, ICCWDataService ccwDataService, ILogger<CcwJobService> logger)
        {
            _context = context;
            _configuration = configuration;
            _ccwDataService = ccwDataService;
            _logger = logger;

            _userId = _configuration["CCW_USER_ID"];
            _userGuid = _configuration["CCW_USER_GUID"];
            _userDir = _configuration["CCW_USER_DIR"];
        }

        /// <summary>
        /// Hangfire job to populate CCW data.  Only used for a deploy to PROD with a new database.
        /// </summary>
        [AutomaticRetry(Attempts = 0)]
        public async Task PopulateCCWJob()
        {
            await Task.CompletedTask;

            var enableCcwCreate = (_configuration["ENABLE_HANGFIRE_CREATE"] ?? "N").ToUpperInvariant() == "Y";
            if (!enableCcwCreate)
                return;

            // sanity check
            if (_userId != null && _userGuid != null && _userDir != null)
            {
                // make a database connection and see if there are any records that are missing the CCW link.
                // we restrict the query to records not updated in the last 6 hours so that the batch process does not repeatedly try a failed record. 
                var data = _context.SchoolBuss
                    .FirstOrDefault(x => x.CCWDataId == null && x.LastUpdateTimestamp < DateTime.UtcNow.AddHours(-6));

                if (data == null)
                {
                    return;
                }

                data.LastUpdateTimestamp = DateTime.UtcNow;

                // get the data for the request from the result of the database query.
                string regi = data.ICBCRegistrationNumber;
                string vin = data.VehicleIdentificationNumber;
                string plate = data.LicencePlateNumber;

                // Fetch the record.
                CCWData cCWData = _ccwDataService.GetCCW(regi, plate, vin, _userId, _userGuid, _userDir);

                if (cCWData == null)
                {
                    _logger.LogInformation($"[Hangfire] PopulateCCWJob - No data from CCW for regi: {regi} vin: {vin}, plate: {plate}.");
                    _context.SaveChanges();
                    _logger.LogInformation($"[Hangfire] PopulateCCWJob - Updated bus record timestamp with the ID {data.Id}.");
                    return;
                }

                data.CCWData = cCWData;

                // ensure that the record is touched in the database
                _context.SaveChanges();
                _logger.LogInformation($"[Hangfire] PopulateCCWJob - Saved bus record with the ID {data.Id}.");
            }
        }

        /// <summary>
        /// Hangfire job to refresh existing data.
        /// </summary>
        [AutomaticRetry(Attempts = 0)]
        public async Task UpdateCCWJob()
        {
            await Task.CompletedTask;

            var enableCcwUpdate = (_configuration["ENABLE_HANGFIRE_UPDATE"] ?? "N").ToUpperInvariant() == "Y";
            if (!enableCcwUpdate)
                return;

            // sanity check
            if (_userId != null && _userGuid != null && _userDir != null)
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
                    return;
                }

                // get the data for the request from the result of the database query.
                string regi = data.ICBCRegistrationNumber;
                string vin = data.ICBCVehicleIdentificationNumber;
                // plate is excluded from the batch update because it can be shared.
                string plate = null;

                // Fetch the record. this FetchCCW actually updates CCWData too. Refer to CCW microservice
                CCWData cCWData = _ccwDataService.GetCCW(regi, plate, vin, _userId, _userGuid, _userDir);

                data.LastUpdateTimestamp = DateTime.UtcNow;

                // fetch did not work, but we don't want it to fire again, so update the timestamp.
                if (cCWData == null)
                {
                    _logger.LogInformation($"[Hangfire] UpdateCCWJob - No data from CCW for regi: {regi} vin: {vin}, plate: {plate}.");
                    _context.SaveChanges();
                    _logger.LogInformation($"[Hangfire] UpdateCCWJob - Updated bus record timestamp with the ID {data.Id}.");
                    return;
                }

                //update records in SchoolBus table
                bool exists = _context.SchoolBuss.Any(x => x.CCWDataId == cCWData.Id);
                if (exists)
                {
                    var bus = _context.SchoolBuss.First(a => a.CCWDataId == cCWData.Id);
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
