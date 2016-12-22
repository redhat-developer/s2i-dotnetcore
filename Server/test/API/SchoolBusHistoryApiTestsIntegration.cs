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
using SchoolBusAPI.Models;
using Newtonsoft.Json;
using System.Net;

namespace SchoolBusAPI.Test
{
	public class SchoolBusHistoryApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusHistoryApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbushistoriesBulkPost
        /// </summary>
		public async void TestSchoolBusHistoriesBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbushistories/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbushistoriesGet
        /// </summary>
		public async void TestSchoolBusHistory()
		{			
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbushistories");
            SchoolBusHistory schoolBusHistory = new SchoolBusHistory();

            var jsonString = schoolBusHistory.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusHistory = JsonConvert.DeserializeObject<SchoolBusHistory>(jsonString);
            
            // get the id
            var id = schoolBusHistory.Id;

            // make a change.    

            // now do an update.

            request = new HttpRequestMessage(HttpMethod.Put, "/api/schoolbushistories/" + id);
            request.Content = new StringContent(schoolBusHistory.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbushistories/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusHistory = JsonConvert.DeserializeObject<SchoolBusHistory>(jsonString);

            // compare the change, should match.
            // Assert.Equal(schoolbus.IsActive, testActive);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Delete, "/api/schoolbushistories/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbushistories/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
        
    }
}
