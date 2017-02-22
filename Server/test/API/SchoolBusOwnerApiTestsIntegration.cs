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
using SchoolBusAPI.Models;
using Newtonsoft.Json;

namespace SchoolBusAPI.Test
{
	public class SchoolBusOwnerApiIntegrationTest : ApiIntegrationTestBase
    { 
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
        }

        [Fact]
		/// <summary>
        /// Integration test for SchoolbusownersContacts
        /// </summary>
		public async void TestContacts()
		{
            string initialNumber = "123-123-1234";
            string initialAddress = "1234 Main St.";

            // first create a school bus owner record
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusowners");
            SchoolBusOwner schoolBusOwner = new SchoolBusOwner();
            var jsonString = schoolBusOwner.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            schoolBusOwner = JsonConvert.DeserializeObject<SchoolBusOwner>(jsonString);
            // get the id
            var id = schoolBusOwner.Id;

            // make a change.   
            Contact contact = new Contact();
            
            schoolBusOwner.PrimaryContact = contact;

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/schoolbusowners/" + id);
            request.Content = new StringContent(schoolBusOwner.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusowners/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            schoolBusOwner = JsonConvert.DeserializeObject<SchoolBusOwner>(jsonString);
            
            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/schoolbusowners/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/schoolbusowners/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

        }        	
                
    }
}
