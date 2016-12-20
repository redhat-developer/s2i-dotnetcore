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
	public class SchoolBusOwnerNoteApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerNoteApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesBulkPost
        /// </summary>
		public async void TestSchoolbusownernotesBulkPost()
		{
			var response = await _client.GetAsync("/api/schoolbusownernotes/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesGet
        /// </summary>
		public async void TestSchoolbusownernotesGet()
		{
			var response = await _client.GetAsync("/api/schoolbusownernotes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesIdDelete
        /// </summary>
		public async void TestSchoolbusownernotesIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbusownernotes/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesIdGet
        /// </summary>
		public async void TestSchoolbusownernotesIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbusownernotes/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesIdPut
        /// </summary>
		public async void TestSchoolbusownernotesIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbusownernotes/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesPost
        /// </summary>
		public async void TestSchoolbusownernotesPost()
		{
			var response = await _client.GetAsync("/api/schoolbusownernotes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
