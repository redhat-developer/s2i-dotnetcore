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
using System.Net;
using Newtonsoft.Json;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Test
{
	public class SchoolBusOwnerHistoryApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerHistoryApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerhistoryBulkPost
        /// </summary>
		public async void TestSchoolbusownerhistoryBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusownerhistory/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerhistoryGet
        /// </summary>
		public async void TestSchoolBusOwnerHistory()
		{
            // now create a school bus owner record

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusownerhistory");
            SchoolBusOwnerHistory schoolBusOwnerHistory = new SchoolBusOwnerHistory();

            var jsonString = schoolBusOwnerHistory.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            schoolBusOwnerHistory = JsonConvert.DeserializeObject<SchoolBusOwnerHistory>(jsonString);
            // get the id
            var id = schoolBusOwnerHistory.Id;

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/schoolbusownerhistory/" + id);
            request.Content = new StringContent(schoolBusOwnerHistory.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusownerhistory/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusOwnerHistory = JsonConvert.DeserializeObject<SchoolBusOwnerHistory>(jsonString);
            
            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Delete, "/api/schoolbusownerhistory/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusownerhistory/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		                
    }
}
