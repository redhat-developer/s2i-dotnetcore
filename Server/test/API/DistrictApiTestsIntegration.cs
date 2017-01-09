/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
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
using SchoolBusAPI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace SchoolBusAPI.Test
{
	public class DistrictApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public DistrictApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for DistrictsBulkPost
        /// </summary>
		public async void TestDistrictsBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/districts/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for Districts
        /// </summary>
		public async void TestDistrictsGet()
		{
            string initialName = "InitialName";
            string changedName = "ChangedName";

            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/districts");

            // create a new object.
            District district = new District();
            district.Name = initialName;
            string jsonString = district.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            district = JsonConvert.DeserializeObject<District>(jsonString);
            // get the id
            var id = district.Id;

            // change the name
            district.Name = changedName;        

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/districts/" + id);
            request.Content = new StringContent(district.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/districts/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            district = JsonConvert.DeserializeObject<District>(jsonString);

            Assert.Equal(changedName, district.Name);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/districts/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/districts/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
               
    }
}
