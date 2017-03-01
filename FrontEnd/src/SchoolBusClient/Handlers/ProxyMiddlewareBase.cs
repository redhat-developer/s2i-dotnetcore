using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Proxy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;

namespace SchoolBusClient.Handlers
{
    public abstract class ProxyMiddlewareBase<TOptions> where TOptions : ProxyServerOptions, new()
    {
        private readonly ILogger _logger;
        private readonly string _pathKey;
        private readonly string _apiUri;
        private readonly ProxyMiddleware _proxy;

        public ProxyMiddlewareBase(RequestDelegate next, IOptions<TOptions> serverOptions, ILoggerFactory loggerFactory)
        {
            _pathKey = serverOptions.Value.PathKey;
            _apiUri = serverOptions.Value.ToUri().AbsoluteUri;            
            _proxy = new ProxyMiddleware(next, serverOptions.Value.ToProxyOptions());
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
                int indexOfApi = requestPath.IndexOf(_pathKey);                
                context.Request.Path = requestPath.Remove(0, indexOfApi);
                
                // Set security headers
                context.Response.Headers[HeaderNames.CacheControl] = "no-cache";
                context.Response.Headers["X-Frame-Options"] = "SAMEORIGIN";
                context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                
                await _proxy.Invoke(context);                
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(-1, "ProxyMiddleware Exception"), e, $"An unexpected exception occured while forwarding a request to the proxy; {_apiUri}.");
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"Exception encountered forwarding a request to {_apiUri}.");
            }
        }

        public static bool IsApiPath(HttpContext httpContext, IOptions<TOptions> serverOptions)
        {
            return httpContext.Request.Path.Value.IndexOf(serverOptions.Value.PathKey, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}

