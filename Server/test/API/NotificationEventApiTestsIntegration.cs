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
	public class NotificationEventApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public NotificationEventApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}	
		
		[Fact]
		/// <summary>
        /// Integration test for notificationeventsBulkPost
        /// </summary>
		public async void TestnotificationeventsBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/notificationevents/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();    
		}		        
		
		[Fact]
		/// <summary>
        /// Integration test for notificationeventsGet
        /// </summary>
		public async void TestNotificationEvents()
		{
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/notificationevents");

            // create a new schoolbus.
            NotificationEvent notificationEvent = new NotificationEvent();
            string jsonString = notificationEvent.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            notificationEvent = JsonConvert.DeserializeObject<NotificationEvent>(jsonString);
            // get the id
            var id = notificationEvent.Id;

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/notificationevents/" + id);
            request.Content = new StringContent(notificationEvent.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/notificationevents/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            notificationEvent = JsonConvert.DeserializeObject<NotificationEvent>(jsonString);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/notificationevents/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/notificationevents/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
    }
}
