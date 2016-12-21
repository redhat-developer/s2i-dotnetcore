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
	public class SchoolBusOwnerApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for FavouritecontexttypesGet
        /// </summary>
		public async void TestFavouritecontexttypesGet()
		{
			var response = await _client.GetAsync("/api/favouritecontexttypes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersBulkPost
        /// </summary>
		public async void TestSchoolbusownersBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusowners/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersGet
        /// </summary>
		public async void TestSchoolbusownersGet()
		{
			var response = await _client.GetAsync("/api/schoolbusowners");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersIdAttachmentsGet
        /// </summary>
		public async void TestSchoolbusownersIdAttachmentsGet()
		{
			var response = await _client.GetAsync("/api/schoolbusowners/{id}/attachments");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersIdContactaddressesGet
        /// </summary>
		public async void TestSchoolbusownersIdContactaddressesGet()
		{
			var response = await _client.GetAsync("/api/schoolbusowners/{id}/contactaddresses");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersIdContactphonesGet
        /// </summary>
		public async void TestSchoolbusownersIdContactphonesGet()
		{
			var response = await _client.GetAsync("/api/schoolbusowners/{id}/contactphones");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersIdDelete
        /// </summary>
		public async void TestSchoolbusownersIdDelete()
		{
			var response = await _client.GetAsync("/api/schoolbusowners/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersIdGet
        /// </summary>
		public async void TestSchoolbusownersIdGet()
		{
			var response = await _client.GetAsync("/api/schoolbusowners/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersIdNotesGet
        /// </summary>
		public async void TestSchoolbusownersIdNotesGet()
		{
			var response = await _client.GetAsync("/api/schoolbusowners/{id}/notes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersIdPut
        /// </summary>
		public async void TestSchoolbusownersIdPut()
		{
			var response = await _client.GetAsync("/api/schoolbusowners/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownersPost
        /// </summary>
		public async void TestSchoolbusownersPost()
		{
			var response = await _client.GetAsync("/api/schoolbusowners");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
