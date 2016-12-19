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
            .UseStartup<Startup>()            
            );
            _client = _server.CreateClient();
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
        /// Integration test for InspectionsGet_0
        /// </summary>
		public async void TestInspectionsGet_0()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{schoolbus-id}/inspections");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for InspectionsInspectionIdGet
        /// </summary>
		public async void TestInspectionsInspectionIdGet()
		{
			var response = await _client.GetAsync("/api/inspections/{inspection-id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
