using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;
using System.Net.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBusAPI
{
    public class CCWTools 
    {    
        /// <summary>
        /// Hangfire job to populate CCW data.  Only used for a deploy to PROD with a new database.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Configuration"></param>
        public static void PopulateCCWJob (DbAppContext context, IConfiguration Configuration)
        {
            // get credentials
            string cCW_userId = Configuration["CCW_userId"];
            string cCW_guid = Configuration["CCW_guid"];
            string cCW_directory = Configuration["CCW_directory"];

            // make a database connection and see if there are any records that are missing the CCW link.
            // we restrict the query to records not updated in the last 6 hours so that the batch process does not repeatedly try a failed record. 
            var data = context.SchoolBuss
                .FirstOrDefault(x => x.CCWDataId == null && x.LastUpdateTimestamp < DateTime.UtcNow.AddHours(-1));

            if (data != null)
            {               
             
                // get the data for the request from the result of the database query.
                string regi = data.ICBCRegistrationNumber;
                string vin = data.VehicleIdentificationNumber;
                string plate = data.LicencePlateNumber;

                // Fetch the record.
                CCWData cCWData = FetchCCW(Configuration, regi, vin, plate, cCW_userId, cCW_guid, cCW_directory);
                data.CCWData = cCWData;

                // ensure that the record is touched in the database
                data.LastUpdateTimestamp = DateTime.UtcNow;

                // save changes.
                context.SchoolBuss.Update(data);
                context.SaveChanges();
            }                
        }

        /// <summary>
        /// Hangfire job to refresh existing data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Configuration"></param>
        public static void UpdateCCWJob(DbAppContext context, IConfiguration Configuration)
        {
            // make a database connection and see if there are any records that need to be updated.
            // get credentials
            string cCW_userId = Configuration["CCW_userId"];
            string cCW_guid = Configuration["CCW_guid"];
            string cCW_directory = Configuration["CCW_directory"];

            // first get a few metrics.  we only want to update a max of 1% the database per day.
            int databaseTotal = context.CCWDatas.Count();

            int dailyTotal = context.CCWDatas
                .Where(x => x.LastUpdateTimestamp < DateTime.UtcNow.AddDays(-1))
                .Select(x => x)
                .Count();

            if (databaseTotal > 0 && dailyTotal < databaseTotal / 100)
            {
                // make a database connection and see if there are any records that are missing the CCW link.
                // we restrict the query to records not updated in the last 100 days so that the batch process does not repeatedly try a failed record. 
                var data = context.CCWDatas
                    .OrderBy (x => x.LastUpdateTimestamp)
                    .FirstOrDefault(x => x.LastUpdateTimestamp < DateTime.UtcNow.AddDays(-100));

                if (data != null)
                {

                    // get the data for the request from the result of the database query.
                    string regi = data.ICBCRegistrationNumber;
                    string vin = data.ICBCVehicleIdentificationNumber;
                    // plate is excluded from the batch update because it can be shared.
                    string plate = null;

                    // Fetch the record.
                    CCWData cCWData = FetchCCW(Configuration, regi, vin, plate, cCW_userId, cCW_guid, cCW_directory);
                   
                    if (cCWData == null) // fetch did not work, but we don't want it to fire again, so update the timestamp.
                    {
                        // ensure that the record is touched in the database
                        data.LastUpdateTimestamp = DateTime.UtcNow;
                        context.CCWDatas.Update(data);
                        context.SaveChanges();
                    }
                }
            }           
        }

        public static CCWData FetchCCW(IConfiguration Configuration, string regi, string vin, string plate, string cCW_userId, string cCW_guid, string cCW_directory)
        {
            string ccwHost = Configuration["CCW_SERVICE_NAME"];

            CCWData result = null;

            Dictionary<string, string> parametersToAdd = new Dictionary<string, string>();
            if (regi != null)
            {
                // first convert the regi to a number.
                int tempRegi;
                bool parsed = int.TryParse(regi, out tempRegi);

                if (parsed)
                {
                    regi = tempRegi.ToString();
                }
                parametersToAdd.Add("regi", regi);
            }
            if (vin != null)
            {
                parametersToAdd.Add("vin", vin);
            }
            if (plate != null)
            {
                parametersToAdd.Add("plate", plate);
            }
            var targetUrl = ccwHost + "/api/CCW/GetCCW";
            string newUri = QueryHelpers.AddQueryString(targetUrl, parametersToAdd);

            // call the microservice

            try
            {
                HttpClient client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, newUri);
                request.Headers.Clear();
                // transfer over the request headers.
                request.Headers.Add("SM_UNIVERSALID", cCW_userId);
                request.Headers.Add("SMGOV_USERGUID", cCW_guid);
                request.Headers.Add("SM_AUTHDIRNAME", cCW_directory);
                
                Task<HttpResponseMessage> responseTask = client.SendAsync(request);
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.StatusCode == HttpStatusCode.OK) // success
                {
                    var stringtask = response.Content.ReadAsStringAsync();
                    stringtask.Wait();
                    // parse as JSON.
                    string jsonString = stringtask.Result;
                    result = JsonConvert.DeserializeObject<CCWData>(jsonString);
                }
            }
            catch (Exception e)
            {
                result = null;
            }
            return result;
        }
    }
}
