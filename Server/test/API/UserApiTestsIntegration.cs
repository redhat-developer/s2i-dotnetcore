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
using System;
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

        [Fact]
        /// <summary>
        /// Integration test for User Delete
        /// </summary>
        public async void TestUserDelete()
        {
            // first create a role.

            string initialName = "InitialName";
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/roles");
            RoleViewModel role = new RoleViewModel();
            role.Name = initialName;
            role.Description = "test";
            string jsonString = role.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            role = JsonConvert.DeserializeObject<RoleViewModel>(jsonString);
            // get the role id
            var role_id = role.Id;

            // now create a user.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users");
            UserViewModel user = new UserViewModel();
            user.GivenName = initialName;
            jsonString = user.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            user = JsonConvert.DeserializeObject<UserViewModel>(jsonString);
            // get the user id
            var user_id = user.Id;

            // now add the user to the role.
            UserRoleViewModel userRole = new UserRoleViewModel();
            userRole.RoleId = role_id;
            userRole.UserId = user_id;
            userRole.EffectiveDate = DateTime.UtcNow;

            UserRoleViewModel[] items = new UserRoleViewModel[1];
            items[0] = userRole;

            // send the request.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/roles/" + role_id + "/users");
            jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // if we do a get we should get the same items.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/roles/" + role_id + "/users");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            User[] userRolesResponse = JsonConvert.DeserializeObject<User[]>(jsonString);

            Assert.Equal(items[0].UserId, userRolesResponse[0].Id);

            // now add a group to the user
            SchoolBusAPI.Models.User newUser = new SchoolBusAPI.Models.User();
            newUser.Id = user.Id;
            // now create a Group

            request = new HttpRequestMessage(HttpMethod.Post, "/api/groups");
            Group group = new Group();

            group.Name = "initialName";
            jsonString = user.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            group = JsonConvert.DeserializeObject<Group>(jsonString);
            // get the id
            int group_id = user.Id;


            // assign user to group

            GroupMembershipViewModel groupMembership = new GroupMembershipViewModel();
            groupMembership.UserId = newUser.Id;
            groupMembership.GroupId = group.Id;

            GroupMembershipViewModel[] groupmembershipItems = new GroupMembershipViewModel[1];
            groupmembershipItems[0] = groupMembership;

            // send the request.
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + user_id + "/groups");
            jsonString = JsonConvert.SerializeObject(groupmembershipItems, Formatting.Indented);
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
            // cleanup

            // Delete user
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users/" + user_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + user_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // Delete role
            request = new HttpRequestMessage(HttpMethod.Post, "/api/roles/" + role_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/roles/" + role_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // delete the group
            request = new HttpRequestMessage(HttpMethod.Post, "/api/groups/" + group_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/groups/" + group_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Fact]
        /// <summary>
        /// Integration test for User Favourites.
        /// </summary>
        public async void TestUserEdit()
        {
            string initialName = "InitialName";
            string changedName = "ChangedName";

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/roles");
            RoleViewModel role = new RoleViewModel();
            role.Name = initialName;
            role.Description = "test";
            string jsonString = role.ToJson();
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            role = JsonConvert.DeserializeObject<RoleViewModel>(jsonString);
            // get the role id
            var role_id = role.Id;

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

            // create a user.
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users");
            User user = new User();
            user.GivenName = initialName;
            jsonString = user.ToJson();

            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();

            user = JsonConvert.DeserializeObject<User>(jsonString);
            // get the id
            var id = user.Id;

            // add and associate the role            
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users/" + id + "/roles");
            UserRoleViewModel userRoleViewModel = new UserRoleViewModel();
            userRoleViewModel.RoleId = role.Id;
            userRoleViewModel.EffectiveDate = DateTime.UtcNow;

            UserRoleViewModel[] items = new UserRoleViewModel[1];
            items[0] = userRoleViewModel;

            jsonString = JsonConvert.SerializeObject(userRoleViewModel, Formatting.Indented);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // verify the user has a favourite.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id + "/roles");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            UserRoleViewModel[] returnedItems = JsonConvert.DeserializeObject<UserRoleViewModel[]>(jsonString);

            bool found = false;
            foreach (UserRoleViewModel item in returnedItems)
            {
                if (item != null)
                {
                    found = true;
                }
            }
            Assert.Equal(found, true);

            // verify that the put works too.         
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + id + "/roles");            

            jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // verify the user has a role.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id + "/roles");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            returnedItems = JsonConvert.DeserializeObject<UserRoleViewModel[]>(jsonString);

            found = false;
            foreach (UserRoleViewModel item in returnedItems)
            {
                if (item != null)
                {
                    found = true;
                }
            }
            Assert.Equal(found, true);
            // verify that the user has roles.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            UserViewModel userViewModel = JsonConvert.DeserializeObject<UserViewModel>(jsonString);

            Assert.NotNull(userViewModel);
            Assert.NotNull(userViewModel.UserRoles);

            found = false;
            foreach (UserRole userRole in userViewModel.UserRoles)
            {
                if (userRole != null && userRole.Role != null && userRole.Role.Id == role.Id)
                {
                    found = true;
                }
            }
            Assert.Equal(found, true);

            // edit the user.
            userViewModel.Surname = changedName;
            request = new HttpRequestMessage(HttpMethod.Put, "/api/users/" + id);
            request.Content = new StringContent(userViewModel.ToJson(), Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // verify the user still has roles.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id);
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            userViewModel = JsonConvert.DeserializeObject<UserViewModel>(jsonString);

            Assert.NotNull(userViewModel);
            Assert.Equal(userViewModel.Surname, changedName);
            Assert.NotNull(userViewModel.UserRoles);

            found = false;
            foreach (UserRole userRole in userViewModel.UserRoles)
            {
                if (userRole != null && userRole.Role != null && userRole.Role.Id == role.Id)
                {
                    found = true;
                }
            }
            Assert.Equal(found, true);

            // update groups for the user.  start by getting existing groups
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id + "/groups");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // parse as JSON.
            jsonString = await response.Content.ReadAsStringAsync();
            returnedItems = JsonConvert.DeserializeObject<UserRoleViewModel[]>(jsonString);


            // delete the user
            request = new HttpRequestMessage(HttpMethod.Post, "/api/users/" + id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/users/" + id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // Delete role
            request = new HttpRequestMessage(HttpMethod.Post, "/api/roles/" + role_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/roles/" + role_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);

            // Delete group
            request = new HttpRequestMessage(HttpMethod.Post, "/api/groups/" + group_id + "/delete");
            response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // should get a 404 if we try a get now.
            request = new HttpRequestMessage(HttpMethod.Get, "/api/groups/" + group_id);
            response = await _client.SendAsync(request);
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }


    }
}
