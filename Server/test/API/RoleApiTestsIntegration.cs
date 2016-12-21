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
	public class RoleApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public RoleApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for RolesGet
        /// </summary>
		public async void TestRolesGet()
		{
			var response = await _client.GetAsync("/api/roles");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesIdDelete
        /// </summary>
		public async void TestRolesIdDelete()
		{
			var response = await _client.GetAsync("/api/roles/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesIdGet
        /// </summary>
		public async void TestRolesIdGet()
		{
			var response = await _client.GetAsync("/api/roles/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesIdPermissionsGet
        /// </summary>
		public async void TestRolesIdPermissionsGet()
		{
			var response = await _client.GetAsync("/api/roles/{id}/permissions");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesIdPermissionsPut
        /// </summary>
		public async void TestRolesIdPermissionsPut()
		{
			var response = await _client.GetAsync("/api/roles/{id}/permissions");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesIdPut
        /// </summary>
		public async void TestRolesIdPut()
		{
			var response = await _client.GetAsync("/api/roles/{id}");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesIdUsersGet
        /// </summary>
		public async void TestRolesIdUsersGet()
		{
			var response = await _client.GetAsync("/api/roles/{id}/users");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesIdUsersPut
        /// </summary>
		public async void TestRolesIdUsersPut()
		{
			var response = await _client.GetAsync("/api/roles/{id}/users");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for RolesPost
        /// </summary>
		public async void TestRolesPost()
		{
			var response = await _client.GetAsync("/api/roles");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
