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
	public class InspectionApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public InspectionApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for InspectionsBulkPost
        /// </summary>
		public async void TestInspectionsBulkPost()
		{
			var response = await _client.GetAsync("/api/inspections/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for InspectionsGet
        /// </summary>
		public async void TestInspectionsGet()
		{
			var response = await _client.GetAsync("/api/inspections");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for InspectionsIdDelete
        /// </summary>
		public async void TestInspectionsIdDelete()
		{
			var response = await _client.GetAsync("/api/inspections/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for InspectionsIdGet
        /// </summary>
		public async void TestInspectionsIdGet()
		{
			var response = await _client.GetAsync("/api/inspections/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for InspectionsIdPut
        /// </summary>
		public async void TestInspectionsIdPut()
		{
			var response = await _client.GetAsync("/api/inspections/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for InspectionsPost
        /// </summary>
		public async void TestInspectionsPost()
		{
			var response = await _client.GetAsync("/api/inspections");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusIdInspectionsGet
        /// </summary>
		public async void TestSchoolbusIdInspectionsGet()
		{
			var response = await _client.GetAsync("/api/schoolbus/{id}/inspections");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
