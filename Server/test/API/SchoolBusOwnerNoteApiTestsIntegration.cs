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
using System.Net;
using Newtonsoft.Json;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Test
{
	public class SchoolBusOwnerNoteApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerNoteApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesBulkPost
        /// </summary>
		public async void TestSchoolbusownernotesBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusownernotes/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusownernotesGet
        /// </summary>
		public async void TestSchoolbusOwnerNotes()
		{
            // now create a school bus owner record

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusownernotes");
            SchoolBusOwnerNote schoolBusOwnerNote = new SchoolBusOwnerNote();

            var jsonString = schoolBusOwnerNote.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            schoolBusOwnerNote = JsonConvert.DeserializeObject<SchoolBusOwnerNote>(jsonString);
            // get the id
            var id = schoolBusOwnerNote.Id;

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/schoolbusownernotes/" + id);
            request.Content = new StringContent(schoolBusOwnerNote.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusownernotes/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusOwnerNote = JsonConvert.DeserializeObject<SchoolBusOwnerNote>(jsonString);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Delete, "/api/schoolbusownernotes/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusownernotes/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
        
    }
}
