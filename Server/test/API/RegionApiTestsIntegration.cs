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
using Newtonsoft.Json;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Test
{
	public class RegionApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public RegionApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		/// <summary>
        /// Integration test for the bulk upload
        /// </summary>
        [Fact]
        public async void TestRegionBulkUpload()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/regions/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }


		[Fact]
		/// <summary>
        /// Integration test for RegionsGet
        /// </summary>
		public async void TestRegions()
		{
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/regions");
            request.Content = new StringContent("{'name':'TestRegion'}", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            string jsonString = await response.Content.ReadAsStringAsync();

            Region region = (Region) JsonConvert.DeserializeObject(jsonString);
            // get the id
            var id = region.Id;

            // make a change.

            // now do an update.

            request = new HttpRequestMessage(HttpMethod.Put, "/api/regions/"+id);
            request.Content = new StringContent(region.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/regions/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // get cities for the region.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/regions/" + id + "/cities");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // get local areas for the region.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/regions/" + id + "/localareas");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Delete, "/api/regions/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // update this to test the API.
            Assert.True(true);
		}				
        
    }
}
