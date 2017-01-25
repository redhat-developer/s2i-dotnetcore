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
using SchoolBusAPI.Models;
using System.Net;
using Newtonsoft.Json;

namespace SchoolBusAPI.Test
{
	public class ContactApiIntegrationTest : ApiIntegrationTestBase
    { 
		[Fact]
		/// <summary>
        /// Integration test for ContactsBulkPost
        /// </summary>
		public async void TestContactsBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "api/Contacts/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for Contacts
        /// </summary>
		public async void TestContacts()
		{
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Contacts");

            // create a new schoolbus.
            Contact Contact = new Contact();            
            string jsonString = Contact.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            Contact = JsonConvert.DeserializeObject<Contact>(jsonString);
            // get the id
            var id = Contact.Id; 
            
            // do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/Contacts/" + id);
            request.Content = new StringContent(Contact.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/Contacts/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            Contact = JsonConvert.DeserializeObject<Contact>(jsonString);
            
            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/Contacts/" + id +"/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/Contacts/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
        
		
    }
}
