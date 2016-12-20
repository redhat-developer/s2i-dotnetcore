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

            Assert.True(true);            
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerhistoryGet
        /// </summary>
		public async void TestSchoolbusownerhistoryGet()
		{
			var response = await _client.GetAsync("/api/schoolbusownerhistory");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerhistoryIdDelete
        /// </summary>
		public async void TestSchoolbusownerhistoryIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbusownerhistory/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerhistoryIdGet
        /// </summary>
		public async void TestSchoolbusownerhistoryIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbusownerhistory/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerhistoryIdPut
        /// </summary>
		public async void TestSchoolbusownerhistoryIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbusownerhistory/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerhistoryPost
        /// </summary>
		public async void TestSchoolbusownerhistoryPost()
		{
			var response = await _client.GetAsync("/api/schoolbusownerhistory");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
