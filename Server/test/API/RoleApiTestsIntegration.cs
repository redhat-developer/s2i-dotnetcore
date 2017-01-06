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
		public async void TestRoles()
		{
			var response = await _client.GetAsync("/api/roles");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        		
    }
}
