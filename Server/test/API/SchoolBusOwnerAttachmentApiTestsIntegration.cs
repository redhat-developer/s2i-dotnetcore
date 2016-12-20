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
	public class SchoolBusOwnerAttachmentApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerAttachmentApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerattachmentsBulkPost
        /// </summary>
		public async void TestSchoolbusownerattachmentsBulkPost()
		{
			var response = await _client.GetAsync("/api/schoolbusownerattachments/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerattachmentsGet
        /// </summary>
		public async void TestSchoolbusownerattachmentsGet()
		{
			var response = await _client.GetAsync("/api/schoolbusownerattachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerattachmentsIdDelete
        /// </summary>
		public async void TestSchoolbusownerattachmentsIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbusownerattachments/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerattachmentsIdGet
        /// </summary>
		public async void TestSchoolbusownerattachmentsIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbusownerattachments/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerattachmentsIdPut
        /// </summary>
		public async void TestSchoolbusownerattachmentsIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbusownerattachments/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownerattachmentsPost
        /// </summary>
		public async void TestSchoolbusownerattachmentsPost()
		{
			var response = await _client.GetAsync("/api/schoolbusownerattachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
