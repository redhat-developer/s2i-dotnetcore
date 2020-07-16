using Microsoft.Extensions.Configuration;

namespace SchoolBus.WS.CCW.Facade.Service
{
    public static class CCWServiceFactory
    {
        public static ICCWService CreateService(IConfiguration configuration)
        {
            Config config = new Config();
            if (config.UseFakeServices)
            {
                return new FakeCCWService();
            }
            else
            {
                string endpointURL = configuration["CCW_endpointURL"];
                string applicationIdentifier = configuration["CCW_applicationIdentifier"];
                string basicAuth_username = configuration["CCW_basicAuth_username"];
                string basicAuth_password = configuration["CCW_basicAuth_password"];
                string batch_user = configuration["CCW_userId"];

                return new CCWService(endpointURL, applicationIdentifier, basicAuth_username, basicAuth_password, batch_user);
            }
        }
    }
}
