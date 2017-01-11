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
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Test
{
	public class UserApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public UserApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}

        [Fact]
        /// <summary>
        /// Integration test for Users Bulk
        /// </summary>
        public async void TestUsersBulk()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users/bulk");
            request.Content = new StringContent("[]", Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
		/// <summary>
        /// Basic Integration test for Users
        /// </summary>
		public async void TestUsersBasic()
		{
            string initialName = "InitialName";
            string changedName = "ChangedName";
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");

            // create a new object.
            UserViewModel user = new UserViewModel();
            user.GivenName = initialName;
            string jsonString = user.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            user = JsonConvert.DeserializeObject<UserViewModel>(jsonString);
            // get the id
            var id = user.Id;
            // change the name
            user.GivenName = changedName;

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + id);
            request.Content = new StringContent(user.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            user = JsonConvert.DeserializeObject<UserViewModel>(jsonString);

            // verify the change went through.
            Assert.Equal(user.GivenName, changedName);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Fact]
        /// <summary>
        /// Integration test for User Favourites.
        /// </summary>
        public async void TestUserFavorites()
        {
            string initialName = "InitialName";
            // create a user.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");
            UserViewModel user = new UserViewModel();
            user.GivenName = initialName;
            string jsonString = user.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            user = JsonConvert.DeserializeObject<UserViewModel>(jsonString);
            // get the id
            var id = user.Id;
            
            // add and associate the favourite
            

            // verify the user has a favourite.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id + "/favourites");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            UserFavouriteViewModel[] items = JsonConvert.DeserializeObject<UserFavouriteViewModel[]>(jsonString);

            // cleanup the user            
            response.EnsureSuccessStatusCode();
        }

        [Fact]
		/// <summary>
        /// Integration test for Users
        /// </summary>
		public async void TestUsers()
		{
            string initialName = "InitialName";
            string changedName = "ChangedName";
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");

            // create a new object.
            UserViewModel user = new UserViewModel();
            user.GivenName = initialName;
            string jsonString = user.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            user = JsonConvert.DeserializeObject<UserViewModel>(jsonString);
            // get the id
            var id = user.Id;
            // change the name
            user.GivenName = changedName;

            // now do an update.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + id);
            request.Content = new StringContent(user.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // do a get.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            user = JsonConvert.DeserializeObject<UserViewModel>(jsonString);

            // verify the change went through.
            Assert.Equal(user.GivenName, changedName);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

        }        
    }
}
