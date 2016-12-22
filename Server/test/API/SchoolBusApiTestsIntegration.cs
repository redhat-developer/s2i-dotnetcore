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

namespace SchoolBusAPI.Test
{
	public class SchoolBusApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
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
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbuses");

            // create a new schoolbus.
            SchoolBus schoolbus = new SchoolBus();
            schoolbus.IsActive = true;
            string jsonString = schoolbus.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            schoolbus = JsonConvert.DeserializeObject<SchoolBus>(jsonString);
            // get the id
            var id = schoolbus.Id;

            // make a change.    
            bool testActive = false;
            schoolbus.IsActive = testActive;
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
            Assert.Equal(schoolbus.IsActive, testActive);

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
            request = new HttpRequestMessage(HttpMethod.Delete, "/api/schoolbuses/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbuses/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for GetAllBuses
        /// </summary>
		public async void TestGetAllBuses()
		{
			var response = await _client.GetAsync("/api/schoolbuses");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        		
        
    }
}
