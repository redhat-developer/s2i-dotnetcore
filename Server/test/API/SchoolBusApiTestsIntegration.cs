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
        /// Integration test for OwnerOwnerIdAttachmentsGet
        /// </summary>
		public async void TestOwnerOwnerIdAttachmentsGet()
		{
			var response = await _client.GetAsync("/api/owner/{owner-id}/attachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusSchoolbusIdAttachmentsGet
        /// </summary>
		public async void TestSchoolbusSchoolbusIdAttachmentsGet()
		{
			var response = await _client.GetAsync("/api/schoolbus/{schoolbus-id}/attachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusSchoolbusIdHistoryGet
        /// </summary>
		public async void TestSchoolbusSchoolbusIdHistoryGet()
		{
			var response = await _client.GetAsync("/api/schoolbus/{schoolbus-id}/history");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesSchoolbusIdGet
        /// </summary>
		public async void TestSchoolbusesSchoolbusIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{schoolbus-id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesSchoolbusIdNotesGet
        /// </summary>
		public async void TestSchoolbusesSchoolbusIdNotesGet()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{schoolbus-id}/notes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
