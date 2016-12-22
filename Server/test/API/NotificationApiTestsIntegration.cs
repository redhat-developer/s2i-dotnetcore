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
using Newtonsoft.Json;
using System.Net;

namespace SchoolBusAPI.Test
{
	public class NotificationApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public NotificationApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}	
		
		[Fact]
		/// <summary>
        /// Integration test for notificationsBulkPost
        /// </summary>
		public async void TestnotificationsBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/inspections/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for notificationsGet
        /// </summary>
		public async void TestNotifications()
		{
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/notifications");

            // create a new schoolbus.
            Notification notification = new Notification();
            string jsonString = notification.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            notification = JsonConvert.DeserializeObject<Notification>(jsonString);
            // get the id
            var id = notification.Id;

            // make a change.    

            // now do an update.

            request = new HttpRequestMessage(HttpMethod.Put, "/api/notifications/" + id);
            request.Content = new StringContent(notification.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/notifications/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            notification = JsonConvert.DeserializeObject<Notification>(jsonString);

            // compare the change, should match.
            // Assert.Equal(schoolbus.IsActive, testActive);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Delete, "/api/notifications/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/notifications/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
        
        
    }
}
