using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SchoolBusAPI.Authentication;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SchoolBusAPI.Test
{
    public class SiteMinderAuthorizationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly SiteminderAuthenticationOptions _siteminderOptions;
        private readonly string _testUserName;
        private readonly string _testUserId;

        /// <summary>
        /// Setup the test
        /// </summary>        
        public SiteMinderAuthorizationTests()
        {
            _server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();

            _siteminderOptions = new SiteminderAuthenticationOptions();
            _testUserName = "TMcTesterson";
            _testUserId = "2cbf7cb8d6b445f087fb82ad75566a9c";
        }

        [Fact]
        public async void LoginPermissionAttribute()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/login/permission/attribute");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void LoginPermissionService()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/login/permission/service");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void OtherGroupService()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/other/group/service");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }        

        /// <summary>
        /// The test user does not have Admin permissions, therefore the user should not be able to access
        /// a controller endpoint marked with the [RequiresPermission(Permission.ADMIN)] attribute.
        /// </summary>
        [Fact]
        public async void AdminPermissionAttribute()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/admin/permission/attribute");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        /// <summary>
        /// The test user does not have Admin permissions, therefore the user should not be able to access
        /// a endpoint when it's service implementation checks to ensure the user has the correct permissions;
        /// for example User.HasPermissions(Permission.ADMIN)
        /// </summary>
        [Fact]
        public async void AdminPermissionService()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/admin/permission/service");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        /// <summary>
        /// The test user does not have Admin permissions, therefore the user should not be able to access
        /// a controller endpoint who's service implementation is marked with the [RequiresPermission(Permission.ADMIN)] attribute.
        /// </summary>
        [Fact(Skip = "This feature is not fully functional.")]
        public async void AdminPermissionServiceAttribute()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/admin/permission/service/attribute");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}
