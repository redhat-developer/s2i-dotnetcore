/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
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
    public class ServiceAreaApiIntegrationTest : ApiIntegrationTestBase
    { 
		[Fact]
		/// <summary>
        /// Integration test for ServiceareasGet
        /// </summary>
		public async void TestServiceareasBulk()
		{	
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/serviceareas/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }		
        
		
		[Fact]
		/// <summary>
        /// Integration test for Serviceareas
        /// </summary>
		public async void TestServiceareas()
		{
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/serviceareas");

            // create a new object.
            ServiceArea servicearea = new ServiceArea();
            string jsonString = servicearea.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            servicearea = JsonConvert.DeserializeObject<ServiceArea>(jsonString);
            // get the id
            var id = servicearea.Id;

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/serviceareas/" + id);
            request.Content = new StringContent(servicearea.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/serviceareas/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            servicearea = JsonConvert.DeserializeObject<ServiceArea>(jsonString);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/serviceareas/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/serviceareas/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		
        
        
    }
}
