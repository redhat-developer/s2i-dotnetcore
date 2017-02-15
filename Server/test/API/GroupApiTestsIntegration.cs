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
using SchoolBusAPI.ViewModels;
using System.Text;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using System.Net;

namespace SchoolBusAPI.Test
{
	public class GroupApiIntegrationTest : ApiIntegrationTestBase
    { 
		[Fact]
		/// <summary>
        /// Integration test for GroupsGet
        /// </summary>
		public async void TestGroups()
		{
            // this test will do the following:
            // 1. Create a User
            // 2. Create a Group
            // 3. Assign the User to the Group
            // 4. Verify that the User is in the Group
            // 5. Remove the User from the group
            // 6. Delete the Group
            // 7. Delete the User

            string initialName = "InitialName";
            string changedName = "ChangedName";
            // first test the POST.
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");

            // create a new object.
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
            int user_id = user.Id;

            // now create a Group

            request = new HttpRequestMessage(HttpMethod.Post, "/api/groups");
            Group group = new Group();

            group.Name = "initialName";
            jsonString = group.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            group = JsonConvert.DeserializeObject<Group>(jsonString);
            // get the id
            int group_id = group.Id;

            // assign user to group

            GroupMembershipViewModel groupMembership = new GroupMembershipViewModel();
            groupMembership.UserId = user.Id;
            groupMembership.GroupId = group.Id;

            GroupMembershipViewModel[] items = new GroupMembershipViewModel[1];
            items[0] = groupMembership;

            // send the request.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + user_id + "/groups");
            jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // verify the group membership
            request = new HttpRequestMessage(HttpMethod.Get, "/api/groups/" + group_id + "/users");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            jsonString = await response.Content.ReadAsStringAsync();
            User[] users = JsonConvert.DeserializeObject<User[]>(jsonString);

            bool found = false;
            foreach (User item in users)
            {
                if (item != null && item.Id == user_id)
                {
                    found = true;
                }
            }

            Assert.Equal(found, true);

            // remove the user from the group
            items = new GroupMembershipViewModel[0];
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + user_id + "/groups");
            jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // verify the group membership - should be false now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/groups/" + group_id + "/users");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            jsonString = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<User[]>(jsonString);

            found = false;
            foreach (User item in users)
            {
                if (item != null && item.Id == user_id)
                {
                    found = true;
                }
            }

            Assert.Equal(found, false);

            // delete the group

            request = new HttpRequestMessage(HttpMethod.Post, "/api/groups/" + group_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/groups/" + group_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // do a delete.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users/" + user_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + user_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);


        }

    }
}
