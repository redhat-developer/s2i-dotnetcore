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
	public class NotificationEventApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public NotificationEventApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for NotficationeventsBulkPost
        /// </summary>
		public async void TestNotficationeventsBulkPost()
		{
			var response = await _client.GetAsync("/api/notficationevents/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for NotficationeventsGet
        /// </summary>
		public async void TestNotficationeventsGet()
		{
			var response = await _client.GetAsync("/api/notficationevents");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for NotficationeventsIdDelete
        /// </summary>
		public async void TestNotficationeventsIdDelete()
		{
			var response = await _client.GetAsync("/api/notficationevents/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for NotficationeventsIdGet
        /// </summary>
		public async void TestNotficationeventsIdGet()
		{
			var response = await _client.GetAsync("/api/notficationevents/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for NotficationeventsIdPut
        /// </summary>
		public async void TestNotficationeventsIdPut()
		{
			var response = await _client.GetAsync("/api/notficationevents/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for NotficationeventsPost
        /// </summary>
		public async void TestNotficationeventsPost()
		{
			var response = await _client.GetAsync("/api/notficationevents");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
