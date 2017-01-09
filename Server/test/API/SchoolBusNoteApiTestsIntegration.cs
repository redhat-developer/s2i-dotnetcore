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
using System.Net;

namespace SchoolBusAPI.Test
{
	public class SchoolBusNoteApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusNoteApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesBulkPost
        /// </summary>
		public async void TestSchoolbusnotesBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusnotes/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();           
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesGet
        /// </summary>
		public async void TestSchoolbusNotes()
		{
            // now create a school bus owner record

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusnotes");
            SchoolBusNote schoolBusNote = new SchoolBusNote();

            var jsonString = schoolBusNote.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            schoolBusNote = JsonConvert.DeserializeObject<SchoolBusNote>(jsonString);
            // get the id
            var id = schoolBusNote.Id;

            // make a change.    

            // now do an update.

            request = new HttpRequestMessage(HttpMethod.Put, "/api/schoolbusnotes/" + id);
            request.Content = new StringContent(schoolBusNote.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusnotes/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusNote = JsonConvert.DeserializeObject<SchoolBusNote>(jsonString);
            
            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusnotes/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusnotes/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		        
    }
}
