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
	public class SchoolBusNoteApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusNoteApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesBulkPost
        /// </summary>
		public async void TestSchoolbusnotesBulkPost()
		{
			var response = await _client.GetAsync("/api/schoolbusnotes/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesGet
        /// </summary>
		public async void TestSchoolbusnotesGet()
		{
			var response = await _client.GetAsync("/api/schoolbusnotes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesIdDelete
        /// </summary>
		public async void TestSchoolbusnotesIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbusnotes/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesIdGet
        /// </summary>
		public async void TestSchoolbusnotesIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbusnotes/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesIdPut
        /// </summary>
		public async void TestSchoolbusnotesIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbusnotes/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesPost
        /// </summary>
		public async void TestSchoolbusnotesPost()
		{
			var response = await _client.GetAsync("/api/schoolbusnotes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
