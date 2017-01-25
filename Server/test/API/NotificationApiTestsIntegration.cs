/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Newtonsoft.Json;
using SchoolBusAPI.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace SchoolBusAPI.Test
{
    public class NotificationApiIntegrationTest : ApiIntegrationTestBase
    { 		
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

            // do a put.    
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
            
            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/notifications/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/notifications/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		                
    }
}
