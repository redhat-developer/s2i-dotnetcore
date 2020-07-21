using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolBusAPI.Models;
using System;
using System.Linq;

namespace SchoolBusAPI.Hangfire
{
    public interface ICcwJobService 
    {
        void PopulateCCWJob();
        void UpdateCCWJob();
    }

    public class CcwJobService : ICcwJobService
    {
        private readonly DbAppContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public CcwJobService(DbAppContext context, IConfiguration configuration, ILogger<CcwJobService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Hangfire job to populate CCW data.  Only used for a deploy to PROD with a new database.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="Configuration"></param>
        public void PopulateCCWJob()
        {
            var cCW_userId = _configuration["CCW_userId"];
            var cCW_guid = _configuration["CCW_guid"];
            var cCW_directory = _configuration["CCW_directory"];
            var ccwHost = _configuration["CCW_SERVICE_NAME"];

            // sanity check
            if (cCW_userId != null && cCW_guid != null && cCW_directory != null && ccwHost != null)
            {
                // make a database connection and see if there are any records that are missing the CCW link.
                // we restrict the query to records not updated in the last 6 hours so that the batch process does not repeatedly try a failed record. 
                var data = _context.SchoolBuss
                    .FirstOrDefault(x => x.CCWDataId == null && x.LastUpdateTimestamp < DateTime.UtcNow.AddHours(-1));

                if (data != null)
                {
                    // get the data for the request from the result of the database query.
                    string regi = data.ICBCRegistrationNumber;
                    string vin = data.VehicleIdentificationNumber;
                    string plate = data.LicencePlateNumber;

                    // Fetch the record.
                    CCWData cCWData = CCWTools.FetchCCW(ccwHost, regi, vin, plate, cCW_userId, cCW_guid, cCW_directory);
                    data.CCWData = cCWData;

                    // ensure that the record is touched in the database
                    data.LastUpdateTimestamp = DateTime.UtcNow;

                    // save changes.
                    _context.SchoolBuss.Update(data);
                    _context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Hangfire job to refresh existing data.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="Configuration"></param>
        public void UpdateCCWJob()
        {
            var cCW_userId = _configuration["CCW_userId"];
            var cCW_guid = _configuration["CCW_guid"];
            var cCW_directory = _configuration["CCW_directory"];
            var ccwHost = _configuration["CCW_SERVICE_NAME"];

            // sanity check
            if (cCW_userId != null && cCW_guid != null && cCW_directory != null && ccwHost != null)
            {
                // first get a few metrics.  we only want to update a max of 1% the database per day.
                int databaseTotal = _context.CCWDatas.Count();

                int dailyTotal = _context.CCWDatas
                    .Where(x => x.LastUpdateTimestamp < DateTime.UtcNow.AddDays(-1))
                    .Select(x => x)
                    .Count();

                if (databaseTotal > 0 && dailyTotal < databaseTotal / 100)
                {
                    // make a database connection and see if there are any records that are missing the CCW link.                
                    var data = _context.CCWDatas
                        .OrderBy(x => x.LastUpdateTimestamp)
                        .FirstOrDefault(x => x.LastUpdateTimestamp < DateTime.UtcNow.AddDays(-1));

                    if (data != null)
                    {

                        // get the data for the request from the result of the database query.
                        string regi = data.ICBCRegistrationNumber;
                        string vin = data.ICBCVehicleIdentificationNumber;
                        // plate is excluded from the batch update because it can be shared.
                        string plate = null;

                        // Fetch the record.
                        CCWData cCWData = CCWTools.FetchCCW(regi, vin, plate, cCW_userId, cCW_guid, cCW_directory, ccwHost);

                        if (cCWData == null) // fetch did not work, but we don't want it to fire again, so update the timestamp.
                        {
                            // ensure that the record is touched in the database
                            data.LastUpdateTimestamp = DateTime.UtcNow;
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

                                _context.SchoolBuss.Update(bus);
                            }

                            _context.CCWDatas.Update(data);
                            _context.SaveChanges();

                        }
                    }
                }
            }
        }
    }
}
