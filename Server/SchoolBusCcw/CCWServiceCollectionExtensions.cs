using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ws.Ccw.Reference;
using System.ServiceModel;
using static Ws.Ccw.Reference.CVSECommonClient;

namespace SchoolBusCcw
{
    public static class CCWServiceCollectionExtensions
    {
        public static void AddCCWServiceClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<CVSECommonClient>(provider =>
            {
                var username = config.GetValue<string>("CCW_USER_ID");
                var password = config.GetValue<string>("CCW_PASSWORD");
                var url = config.GetValue<string>("CCW_ENDPOINT_URL");
                var appId = config.GetValue<string>("CCW_APP_ID");
                var batchUser = config.GetValue<string>("CCW_USER_ID");
                var batchAppId = config.GetValue<string>("CCW_BATCH_APP_ID");

                var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;

                var client = new CVSECommonClient(EndpointConfiguration.CVSECommon);
                client.ClientCredentials.UserName.UserName = username;
                client.ClientCredentials.UserName.Password = password;
                client.Endpoint.Binding = binding;
                client.Endpoint.Address = new EndpointAddress(url);

                client.BatchAppId = batchAppId;
                client.AppId = appId;
                client.BatchUser = batchUser;

                return client;
            });

            services.AddSingleton<ICCWService, CCWService>();
        }
    }
}
