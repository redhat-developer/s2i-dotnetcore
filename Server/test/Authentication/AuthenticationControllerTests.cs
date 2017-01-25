using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SchoolBusAPI.Authentication;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SchoolBusAPI.Test
{
    public class AuthenticationControllerTests
    {
        private readonly TestServer _server;
		private readonly HttpClient _client;

        private readonly DevAuthenticationOptions _devAuthOptions;
        private readonly string _testUserName;

        /// <summary>
        /// Setup the test
        /// </summary>        
        public AuthenticationControllerTests()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();

            _devAuthOptions = new DevAuthenticationOptions();
            _testUserName = "TMcTesterson";
        }

        [Fact]
        public async void AllowsAnonymous()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/authentication/dev/token?userId={_testUserName}");
            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ReturnsToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/authentication/dev/token?userId={_testUserName}");
            var response = await _client.SendAsync(request);
            string token = response.Headers.GetValues("Set-Cookie").First();
            Assert.True(token.Contains($"{_devAuthOptions.AuthenticationTokenKey}={_testUserName}"));
        }

        [Fact]
        public async void RequiresUserId_ExpectBadRequest()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/authentication/dev/token");
            var response = await _client.SendAsync(request);
            string msg = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Missing required userId query parameter.", msg);
        }

        [Fact]
        public async void IsOnlyAvailableInDev_ExpectBadRequest()
        {
            var server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Staging")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            var client = server.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/authentication/dev/token?userId={_testUserName}");

            var response = await client.SendAsync(request);
            string msg = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("This API is not available outside a development environment.", msg);
        }
    }
}
