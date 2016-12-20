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
		public async void TestSchoolbushistoriesBulkPost()
		{
			var response = await _client.GetAsync("/api/schoolbushistories/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbushistoriesGet
        /// </summary>
		public async void TestSchoolbushistoriesGet()
		{
			var response = await _client.GetAsync("/api/schoolbushistories");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbushistoriesIdDelete
        /// </summary>
		public async void TestSchoolbushistoriesIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbushistories/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbushistoriesIdPut
        /// </summary>
		public async void TestSchoolbushistoriesIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbushistories/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbushistoriesPost
        /// </summary>
		public async void TestSchoolbushistoriesPost()
		{
			var response = await _client.GetAsync("/api/schoolbushistories");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
