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
    public class SchoolBusNoteApiIntegrationTest : ApiIntegrationTestBase
    { 
		[Fact]
		/// <summary>
        /// Integration test for SchoolbusnotesBulkPost
        /// </summary>
		public async void TestSchoolbusnotesBulkPost()
		{
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/notes/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();           
		}		
        
		
		[Fact]
		/// <summary>
        /// Integration test for Notes
        /// </summary>
		public async void TestNotes()
		{
            // now create a school bus owner record

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/notes");
            Note note = new Note();

            var jsonString = note.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            note = JsonConvert.DeserializeObject<Note>(jsonString);
            // get the id
            var id = note.Id;

            // make a change.    

            // now do an update.

            request = new HttpRequestMessage(HttpMethod.Put, "/api/notes/" + id);
            request.Content = new StringContent(note.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/notes/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            note = JsonConvert.DeserializeObject<Note>(jsonString);
            
            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/notes/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/notes/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }		        
    }
}
