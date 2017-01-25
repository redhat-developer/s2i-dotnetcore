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
using SchoolBusAPI.ViewModels;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace SchoolBusAPI.Test
{
    public class UserApiIntegrationTest : ApiIntegrationTestBase
    { 
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
            User user = new User();
            user.GivenName = initialName;
            string jsonString = user.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            user = JsonConvert.DeserializeObject<User>(jsonString);
            // get the id
            var id = user.Id;

            // add and associate the favourite            
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users/" + id + "/favourites");
            UserFavourite userFavourite = new UserFavourite();
            userFavourite.User = user;
            UserFavourite[] items = new UserFavourite[1];
            items[0] = userFavourite;
            jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // verify the user has a favourite.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id + "/favourites");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            items = JsonConvert.DeserializeObject<UserFavourite[]>(jsonString);


            bool found = false;
            foreach (UserFavourite item in items)
            {
                if (item != null)
                {
                    found = true;
                }
            }
            Assert.Equal(found, true);

            // remove the favourites from the user
            items = new UserFavourite[0];
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + id + "/favourites");
            jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // verify the group membership - should be false now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id + "/favourites");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            jsonString = await response.Content.ReadAsStringAsync();
            items = JsonConvert.DeserializeObject<UserFavourite[]>(jsonString);

            found = false;
            foreach (UserFavourite item in items)
            {
                if (item != null)
                {
                    found = true;
                }
            }

            Assert.Equal(found, false);

            // delete the user
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
