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
	public class OwnerApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public OwnerApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for FavoritecontexttypesGet
        /// </summary>
		public async void TestFavoritecontexttypesGet()
		{
			var response = await _client.GetAsync("/api/favoritecontexttypes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for OwnerOwnerIdContactaddressesGet
        /// </summary>
		public async void TestOwnerOwnerIdContactaddressesGet()
		{
			var response = await _client.GetAsync("/api/owner/{owner-id}/contactaddresses");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for OwnerOwnerIdContactphonesGet
        /// </summary>
		public async void TestOwnerOwnerIdContactphonesGet()
		{
			var response = await _client.GetAsync("/api/owner/{owner-id}/contactphones");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for OwnerOwnerIdGet
        /// </summary>
		public async void TestOwnerOwnerIdGet()
		{
			var response = await _client.GetAsync("/api/owner/{owner-id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for OwnerOwnerIdNotesGet
        /// </summary>
		public async void TestOwnerOwnerIdNotesGet()
		{
			var response = await _client.GetAsync("/api/owner/{owner-id}/notes");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusSchoolbusIdCcwdataGet
        /// </summary>
		public async void TestSchoolbusSchoolbusIdCcwdataGet()
		{
			var response = await _client.GetAsync("/api/schoolbus/{schoolbus-id}/ccwdata");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersUserIdFavoritesGet
        /// </summary>
		public async void TestUsersUserIdFavoritesGet()
		{
			var response = await _client.GetAsync("/api/users/{user-id}/favorites");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
