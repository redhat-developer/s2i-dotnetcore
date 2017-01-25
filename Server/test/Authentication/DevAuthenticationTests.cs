using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SchoolBusAPI.Authentication;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SchoolBusAPI.Test
{
    public class DevAuthenticationTests
    {
        private readonly TestServer _server;
		private readonly HttpClient _client;

        private readonly DevAuthenticationOptions _devAuthOptions;
        private readonly string _testUserName;

        /// <summary>
        /// Setup the test
        /// </summary>        
        public DevAuthenticationTests()
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
        public async void NotAuthenticated_NoHeaders_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async void NotAuthenticated_NotAUser_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_devAuthOptions.AuthenticationTokenKey, "SomeUser");

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async void Authenticated_Header_ExpectOk()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_devAuthOptions.AuthenticationTokenKey, _testUserName);

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Authenticated_Cookie_ExpectOk()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add("Cookie", $"ACookie=AValue;{_devAuthOptions.AuthenticationTokenKey}={_testUserName}");

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void AuthenticationSchemeOnlyAvailableInDev_ExpectUnauthorized()
        {
            var server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Staging")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            var client = server.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/headers");
            request.Headers.Add(_devAuthOptions.AuthenticationTokenKey, _testUserName);

            var response = await client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
