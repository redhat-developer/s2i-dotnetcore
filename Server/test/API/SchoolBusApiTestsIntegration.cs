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
			var response = await _client.GetAsync("/api/schoolbuses/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for FindBusById
        /// </summary>
		public async void TestFindBusById()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
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
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesIdAttachmentsGet
        /// </summary>
		public async void TestSchoolbusesIdAttachmentsGet()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{id}/attachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesIdCcwdataGet
        /// </summary>
		public async void TestSchoolbusesIdCcwdataGet()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{id}/ccwdata");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesIdDelete
        /// </summary>
		public async void TestSchoolbusesIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesIdHistoryGet
        /// </summary>
		public async void TestSchoolbusesIdHistoryGet()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{id}/history");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesIdNotesGet
        /// </summary>
		public async void TestSchoolbusesIdNotesGet()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{id}/notes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusesIdPut
        /// </summary>
		public async void TestSchoolbusesIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbuses/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
