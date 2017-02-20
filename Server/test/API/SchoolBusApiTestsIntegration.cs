/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using SchoolBusAPI;
using System.Text;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Mappings;

namespace SchoolBusAPI.Test
{
	public class SchoolBusApiIntegrationTest : ApiIntegrationTestBase
    { 	
		[Fact]
		/// <summary>
        /// Integration test for AddBus
        /// </summary>
		public async void TestAddBus()
		{
			var response = await _client.GetAsync("/api/schoolbuses");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for AddSchoolBusBulk
        /// </summary>
		public async void TestAddSchoolBusBulk()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "api/schoolbuses/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();            
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for FindBusById
        /// </summary>
		public async void TestSchoolBuses()
		{
            // create a district.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/districts");
            District district = new District();
            string jsonString = district.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            district = JsonConvert.DeserializeObject<District>(jsonString);
            var district_id = district.Id;


            // create a schoolbus owner.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusowners");
            SchoolBusOwner schoolBusOwner = new SchoolBusOwner();
            jsonString = schoolBusOwner.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusOwner = JsonConvert.DeserializeObject<SchoolBusOwner>(jsonString);
            var schoolBusOwner_id = schoolBusOwner.Id;            

            // create a bus
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbuses");

            // create a new schoolbus.
            SchoolBus schoolbus = new SchoolBus();
            schoolbus.Status = "0";
            schoolbus.District = district;
            schoolbus.SchoolBusOwner = schoolBusOwner;
            

            jsonString = schoolbus.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            schoolbus = JsonConvert.DeserializeObject<SchoolBus>(jsonString);
            // get the id
            var id = schoolbus.Id;

            // make a change.    
            string testStatus = "1";
            schoolbus.Status = testStatus;
            // now do an update.

            request = new HttpRequestMessage(HttpMethod.Put, "/api/schoolbuses/" + id);
            request.Content = new StringContent(schoolbus.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolbus = JsonConvert.DeserializeObject<SchoolBus>(jsonString);

            // compare the change, should match.
            Assert.Equal(schoolbus.Status, testStatus);

            //test attachments            
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id + "/attachments");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //test attachments            
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id + "/ccwdata");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //test history            
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id + "/history");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //test notes            
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id + "/notes");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //test inspections
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id + "/inspections");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();            

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbuses/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // cleanup service area.

            request = new HttpRequestMessage(HttpMethod.Post, "/api/districts/" + district_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/districts/" + district_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // cleanup schoolbus owner

            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusowners/" + schoolBusOwner_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusowners/" + schoolBusOwner_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
            

        }

        // automates the search
        private async Task<SchoolBus[]> SearchHelper(Dictionary<string, string> parametersToAdd)
        {
            var targetUrl = "/api/schoolbuses/search";
            var newUri = QueryHelpers.AddQueryString(targetUrl, parametersToAdd);

            var request = new HttpRequestMessage(HttpMethod.Get, newUri);

            var response = await _client.SendAsync(request);
            

            // parse as JSON.
            var jsonString = await response.Content.ReadAsStringAsync();
            // should be an array of schoolbus records.
            SchoolBus[] searchresults = JsonConvert.DeserializeObject<SchoolBus[]>(jsonString);
            return searchresults;
        }

        [Fact]
		/// <summary>
        /// Integration test for GetAllBuses
        /// </summary>
		public async void TestBusSearch()
		{
            //setup test
            // create a district 
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/districts");
            District district = new District();
            string jsonString = district.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            district = JsonConvert.DeserializeObject<District>(jsonString);
            var district_id = district.Id;


            // create a schoolbus owner.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusowners");
            SchoolBusOwner schoolBusOwner = new SchoolBusOwner();
            jsonString = schoolBusOwner.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusOwner = JsonConvert.DeserializeObject<SchoolBusOwner>(jsonString);
            var schoolBusOwner_id = schoolBusOwner.Id;

            // create a bus
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbuses");

            // create a new schoolbus.
            SchoolBus schoolbus = new SchoolBus();
            schoolbus.Status = "Active";
            schoolbus.District = district;
            schoolbus.SchoolBusOwner = schoolBusOwner;
            schoolbus.VehicleIdentificationNumber = "1234";
            schoolbus.LicencePlateNumber = "12345";
            DateTime nextInspection = DateTime.UtcNow;
            schoolbus.NextInspectionDate = nextInspection;

            jsonString = schoolbus.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            schoolbus = JsonConvert.DeserializeObject<SchoolBus>(jsonString);
            // get the id
            var id = schoolbus.Id;

            // make a change.    
            string testStatus = "1";
            schoolbus.Status = "Active";
            // now do an update.

            request = new HttpRequestMessage(HttpMethod.Put, "/api/schoolbuses/" + id);
            request.Content = new StringContent(schoolbus.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolbus = JsonConvert.DeserializeObject<SchoolBus>(jsonString);

            // test the search

            var parametersToAdd = new System.Collections.Generic.Dictionary<string, string> { { "district", "["+district_id +"]" } };

            SchoolBus[] searchresults = await SearchHelper(parametersToAdd);

            Assert.NotNull(searchresults);
            Assert.NotEqual(searchresults.Length, 0);
            bool found = false;
            foreach (SchoolBus item in searchresults)
            {
                if (item.Id == id)
                {
                    found = true;
                }
            }

            Assert.Equal(found, true);

            parametersToAdd = new System.Collections.Generic.Dictionary<string, string> { { "owner", "" + schoolBusOwner_id } };
            searchresults = await SearchHelper(parametersToAdd);

            Assert.NotNull(searchresults);
            Assert.NotEqual(searchresults.Length, 0);
            found = false;
            foreach (SchoolBus item in searchresults)
            {
                if (item.Id == id)
                {
                    found = true;
                }
            }

            Assert.Equal(found, true);

            parametersToAdd = new System.Collections.Generic.Dictionary<string, string> { { "vin", "1234" } };
            searchresults = await SearchHelper(parametersToAdd);

            Assert.NotNull(searchresults);
            Assert.NotEqual(searchresults.Length, 0);
            found = false;
            foreach (SchoolBus item in searchresults)
            {
                if (item.Id == id)
                {
                    found = true;
                }
            }

            Assert.Equal(found, true);

            parametersToAdd = new System.Collections.Generic.Dictionary<string, string> { { "plate", "12345" } };
            searchresults = await SearchHelper(parametersToAdd);

            Assert.NotNull(searchresults);
            Assert.NotEqual(searchresults.Length, 0);
            found = false;
            foreach (SchoolBus item in searchresults)
            {
                if (item.Id == id)
                {
                    found = true;
                }
            }

            Assert.Equal(found, true);

            // now test the owner view.

            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusowners/" + schoolBusOwner_id + "/view");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            SchoolBusOwnerViewModel model = JsonConvert.DeserializeObject<SchoolBusOwnerViewModel>(jsonString);

            // should be one bus.
            Assert.Equal(model.numberOfBuses, 1);
            Assert.Equal(model.nextInspectionDate.Value.Hour, nextInspection.Hour);
            Assert.Equal(model.nextInspectionDate.Value.Minute, nextInspection.Minute);
            Assert.Equal(model.nextInspectionDate.Value.Second, nextInspection.Second);            

            // teardown
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbuses/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // cleanup service area.

            request = new HttpRequestMessage(HttpMethod.Post, "/api/districts/" + district_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/districts/" + district_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // cleanup schoolbus owner
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusowners/" + schoolBusOwner_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusowners/" + schoolBusOwner_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
        		
        
    }
}
