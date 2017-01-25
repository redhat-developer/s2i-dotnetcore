using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SchoolBusAPI.Authentication;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SchoolBusAPI.Test
{
    /// <summary>
    /// Tests to ensure the UserSeeder registered the initial users defined in schoolbus\Server\test\Data\initialUsers.json
    /// The best way to ensure this is working properly is to run it against an empty database.
    /// </summary>
    public class UserSeederTests
    {
        private readonly TestServer _server;
		private readonly HttpClient _client;

        private readonly DevAuthenticationOptions _devAuthOptions;

        public UserSeederTests()
		{
			_server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>());
            _client = _server.CreateClient();

            _devAuthOptions = new DevAuthenticationOptions();
        }

        [Fact]
        public async void InitialUserJoeIsAdmin()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/admin/permission/attribute");
            request.Headers.Add(_devAuthOptions.AuthenticationTokenKey, "JDoe");

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void InitialUserJaneIsAdmin()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test/admin/permission/attribute");
            request.Headers.Add(_devAuthOptions.AuthenticationTokenKey, "JDow");

            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
