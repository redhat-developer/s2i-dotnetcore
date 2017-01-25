using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SchoolBusAPI.Authentication;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SchoolBusAPI.Test
{
    public class SiteMinderAuthenticationTests
    {
        private readonly TestServer _server;
		private readonly HttpClient _client;
        private readonly SiteminderAuthenticationOptions _siteminderOptions;
        private readonly string _testUserName;
        private readonly string _testUserId;

        /// <summary>
        /// Setup the test
        /// </summary>        
        public SiteMinderAuthenticationTests()
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
        public async void NotAuthenticated_NoHeaders_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async void NotAuthenticated_NoGuid_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_siteminderOptions.SiteMinderUserNameKey, _testUserName);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async void NotAuthenticated_NoUserId_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async void NotAuthenticated_NotAUser_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_siteminderOptions.SiteMinderUserNameKey, "SomeUser");
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, "00000000000000000000000000000001");

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async void Authenticated_sm_user_ExpectOk()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_siteminderOptions.SiteMinderUserNameKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Authenticated_sm_user_ExpectOk_IgnoreCase()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_siteminderOptions.SiteMinderUserNameKey.ToUpper(), _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey.ToUpper(), _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Authenticated_sm_universalid_ExpectOk()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey, _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey, _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Authenticated_sm_universalid_ExpectOk_IgnoreCase()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_siteminderOptions.SiteMinderUniversalIdKey.ToUpper(), _testUserName);
            request.Headers.Add(_siteminderOptions.SiteMinderUserGuidKey.ToUpper(), _testUserId);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
