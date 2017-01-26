using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SchoolBusClient.Handlers
{
    public class ApiProxyMiddleware : ProxyMiddlewareBase<ApiProxyServerOptions>
    {
        public ApiProxyMiddleware(RequestDelegate next, IOptions<ApiProxyServerOptions> serverOptions, ILoggerFactory loggerFactory) 
            : base(next, serverOptions, loggerFactory)
        {
        }
    }
}

