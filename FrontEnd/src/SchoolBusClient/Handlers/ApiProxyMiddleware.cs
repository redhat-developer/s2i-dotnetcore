using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Proxy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace SchoolBusClient.Handlers
{
    public class ApiProxyMiddleware
    {
        private static readonly string _apiPathKey = "/api/";
        private static readonly string _swaggerKey = "/swagger/";

        private readonly ILogger _logger;
        private readonly string _apiUri;
        private readonly Microsoft.AspNetCore.Proxy.ProxyMiddleware _proxy;

        public ApiProxyMiddleware(RequestDelegate next, IOptions<ApiProxyServerOptions> apiServerOptions, ILoggerFactory loggerFactory)
        {
            _apiUri = apiServerOptions.Value.ToUri().AbsoluteUri;
            _proxy = new ProxyMiddleware(next, apiServerOptions.Value.ToProxyOptions());
            _logger = loggerFactory.CreateLogger<ApiProxyMiddleware>();
        }

        /// <summary>
        /// The invoke method is called by the ProxyExtension class.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                string requestPath = context.Request.Path.Value;
                int indexOfApi = requestPath.IndexOf(_apiPathKey);
                if (indexOfApi > -1)
                {
                    context.Request.Path = requestPath.Remove(0, indexOfApi);
                }
                else
                {
                    int indexOfSwagger = requestPath.IndexOf(_swaggerKey);
                    if (indexOfSwagger > -1)
                    {
                        context.Request.Path = requestPath.Remove(0, indexOfSwagger);
                    }
                }
                    
                await _proxy.Invoke(context);
            }
            catch(Exception e)
            {
                _logger.LogError(new EventId(-1, "ApiProxyMiddleware Exception"), e, $"An unexpected exception occured while forwarding a request to the API proxy; {_apiUri}.");
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"Exception encountered forwarding a request to {_apiUri}.");
            }
        }

        public static bool IsApiPath(HttpContext httpContext)
        {
            return httpContext.Request.Path.Value.IndexOf(_apiPathKey, StringComparison.OrdinalIgnoreCase) >= 0 ||
                httpContext.Request.Path.Value.IndexOf(_swaggerKey, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}

