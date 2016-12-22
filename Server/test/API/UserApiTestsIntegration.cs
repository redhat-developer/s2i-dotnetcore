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
	public class UserApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public UserApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for UsersBulkPost
        /// </summary>
		public async void TestUsersBulkPost()
		{
			var response = await _client.GetAsync("/api/users/bulk");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersCurrentGet
        /// </summary>
		public async void TestUsersCurrentGet()
		{
			var response = await _client.GetAsync("/api/users/current");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersGet
        /// </summary>
		public async void TestUsersGet()
		{
			var response = await _client.GetAsync("/api/users");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdDelete
        /// </summary>
		public async void TestUsersIdDelete()
		{
			var response = await _client.GetAsync("/api/users/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdFavouritesGet
        /// </summary>
		public async void TestUsersIdFavouritesGet()
		{
			var response = await _client.GetAsync("/api/users/{id}/favourites");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdGet
        /// </summary>
		public async void TestUsersIdGet()
		{
			var response = await _client.GetAsync("/api/users/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdGroupsGet
        /// </summary>
		public async void TestUsersIdGroupsGet()
		{
			var response = await _client.GetAsync("/api/users/{id}/groups");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdGroupsPut
        /// </summary>
		public async void TestUsersIdGroupsPut()
		{
			var response = await _client.GetAsync("/api/users/{id}/groups");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdNotificationGet
        /// </summary>
		public async void TestUsersIdNotificationGet()
		{
			var response = await _client.GetAsync("/api/users/{id}/notification");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdPermissionsGet
        /// </summary>
		public async void TestUsersIdPermissionsGet()
		{
			var response = await _client.GetAsync("/api/users/{id}/permissions");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdPut
        /// </summary>
		public async void TestUsersIdPut()
		{
			var response = await _client.GetAsync("/api/users/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdRolesGet
        /// </summary>
		public async void TestUsersIdRolesGet()
		{
			var response = await _client.GetAsync("/api/users/{id}/roles");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdRolesPost
        /// </summary>
		public async void TestUsersIdRolesPost()
		{
			var response = await _client.GetAsync("/api/users/{id}/roles");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersIdRolesPut
        /// </summary>
		public async void TestUsersIdRolesPut()
		{
			var response = await _client.GetAsync("/api/users/{id}/roles");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for UsersPost
        /// </summary>
		public async void TestUsersPost()
		{
			var response = await _client.GetAsync("/api/users");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
