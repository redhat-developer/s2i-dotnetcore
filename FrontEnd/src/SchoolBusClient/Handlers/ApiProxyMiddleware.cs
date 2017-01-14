using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Proxy;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace SchoolBusClient.Handlers
{
    public class ApiProxyMiddleware
    {
        private static readonly string _apiPathKey = "/api/";
        private readonly Microsoft.AspNetCore.Proxy.ProxyMiddleware _proxy;

        public ApiProxyMiddleware(RequestDelegate next, IOptions<ApiProxyServerOptions> apiServerOptions)
        {
            _proxy = new ProxyMiddleware(next, apiServerOptions.Value.ToProxyOptions());
        }

        /// <summary>
        /// The invoke method is called by the ProxyExtension class.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            string requestPath = context.Request.Path.Value;
            int indexOfApi = requestPath.IndexOf(_apiPathKey);
            context.Request.Path = requestPath.Remove(0, indexOfApi);
            await _proxy.Invoke(context);
        }

        public static bool IsApiPath(HttpContext httpContext)
        {
            return httpContext.Request.Path.Value.IndexOf(_apiPathKey, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}

