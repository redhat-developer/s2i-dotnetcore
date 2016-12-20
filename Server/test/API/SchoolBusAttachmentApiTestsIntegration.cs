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
	public class SchoolBusAttachmentApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusAttachmentApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusattachmentsBulkPost
        /// </summary>
		public async void TestSchoolbusattachmentsBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusattachments/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Assert.True(true);            
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusattachmentsGet
        /// </summary>
		public async void TestSchoolbusattachmentsGet()
		{
			var response = await _client.GetAsync("/api/schoolbusattachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusattachmentsIdDelete
        /// </summary>
		public async void TestSchoolbusattachmentsIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbusattachments/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusattachmentsIdGet
        /// </summary>
		public async void TestSchoolbusattachmentsIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbusattachments/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusattachmentsIdPut
        /// </summary>
		public async void TestSchoolbusattachmentsIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbusattachments/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusattachmentsPost
        /// </summary>
		public async void TestSchoolbusattachmentsPost()
		{
			var response = await _client.GetAsync("/api/schoolbusattachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbushistoriesIdGet
        /// </summary>
		public async void TestSchoolbushistoriesIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbushistories/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
