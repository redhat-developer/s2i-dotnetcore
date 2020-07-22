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
    public static class CCWTools 
    {
        /// <summary>
        /// Fetch CCW data from the microservice
        /// </summary>
        /// <param name="Configuration"></param>
        /// <param name="regi"></param>
        /// <param name="vin"></param>
        /// <param name="plate"></param>
        /// <param name="cCW_userId"></param>
        /// <param name="cCW_guid"></param>
        /// <param name="cCW_directory"></param>
        /// <param name="ccwHost"></param>
        /// <returns></returns>
        public static CCWData FetchCCW(string regi, string vin, string plate, string cCW_userId, string cCW_guid, string cCW_directory, string ccwHost)
        {            
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
            using HttpClient client = new HttpClient();

            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine("Exception while CCW call.");
                Console.WriteLine($"{ex}");
                result = null;
            }

            return result;
        }
    }
}
