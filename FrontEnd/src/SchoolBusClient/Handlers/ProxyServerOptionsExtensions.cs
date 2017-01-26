using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace SchoolBusClient.Handlers
{
    public static class ProxyServerOptionsExtensions
    {
        public static Uri ToUri(this ProxyServerOptions options)
        {
            int portNumber = 80;
            int.TryParse(options.Port, out portNumber);
            UriBuilder uriBuilder = new UriBuilder(options.Scheme, options.Host, portNumber);
            return uriBuilder.Uri;
        }


        public static IOptions<ProxyOptions> ToProxyOptions(this ProxyServerOptions options)
        {
            ProxyOptions proxyOptions = new ProxyOptions()
            {
                Host = options.Host,
                Port = options.Port,
                Scheme = options.Scheme
            };

            return Options.Create(proxyOptions);
        }
    }
}
