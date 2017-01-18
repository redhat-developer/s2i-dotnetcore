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
using SchoolBusAPI.Models;
using System.Text;
using Newtonsoft.Json;

namespace SchoolBusAPI.Test
{
	public class CurrentUserApiIntegrationTest 
    { 
		private readonly TestServer _server;
		private readonly HttpClient _client;
			
		/// <summary>
        /// Setup the test
        /// </summary>        
		public CurrentUserApiIntegrationTest()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();
		}
	
		
		[Fact]
		/// <summary>
        /// Integration test for UsersCurrentGet
        /// </summary>
		public async void TestUsersCurrentGet()
		{
			var response = await _client.GetAsync("/api/users/current");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}


        [Fact]
        /// <summary>
        /// Integration test for Current User Favourites
        /// </summary>
        public async void TestUsersCurrentFavourites()
        {
            // add a favourite.

            string testType = "test";
            string testName = "name";
            string testValue = "value";
            string newValue = "newValue";

            UserFavourite userFavourite = new UserFavourite();
            userFavourite.Type = testType;
            userFavourite.Name = testName;
            userFavourite.Value = testValue;

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users/current/favourites");
            request.Content = new StringContent(userFavourite.ToJson(), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            string jsonString = await response.Content.ReadAsStringAsync();
            userFavourite = JsonConvert.DeserializeObject<UserFavourite>(jsonString);

            // test an update.
            userFavourite.Value = newValue;

            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/current/favourites");
            request.Content = new StringContent(userFavourite.ToJson(), Encoding.UTF8, "application/json");

            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // get test results.

            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/current/favourites/test");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            jsonString = await response.Content.ReadAsStringAsync();
            UserFavourite[] results = JsonConvert.DeserializeObject<UserFavourite[]>(jsonString);

            bool found = false;
            foreach (UserFavourite item in results)
            {
                if (item.Value == newValue)
                {
                    found = true;
                }
            }

            Assert.Equal(found, true);

            // cleanup.

            foreach (UserFavourite item in results)
            {
                request = new HttpRequestMessage(HttpMethod.Post, "/api/users/current/favourites/"+item.Id+"/delete");
                response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
                        
            // confirm the cleanup worked.

            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/current/favourites/test");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            jsonString = await response.Content.ReadAsStringAsync();
            results = JsonConvert.DeserializeObject<UserFavourite[]>(jsonString);

            found = false;
            foreach (UserFavourite item in results)
            {
                if (item.Value == newValue)
                {
                    found = true;
                }
            }

            Assert.Equal(found, false);

        }

    }
}
