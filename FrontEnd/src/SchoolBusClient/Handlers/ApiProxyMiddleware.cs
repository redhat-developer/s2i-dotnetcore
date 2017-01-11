using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Proxy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;


namespace SchoolBusClient.Handlers
{
    // ToDo:
    // - Replace MIDDLEWARE_NAME environment variable with variables the can be used with ApiServerOptions:
    // -- ApiProxyServer:Scheme
    // -- ApiProxyServer:Host
    // -- ApiProxyServer:Port
    // - Remove use of IConfiguration and MIDDLEWARE_NAME environment variable 
    public class ApiProxyMiddleware
    {
        private static readonly string _apiPathKey = "/api/";
        private readonly IOptions<ApiProxyServerOptions> _apiServerOptions;
        private readonly IConfiguration _configuration;
        private readonly Microsoft.AspNetCore.Proxy.ProxyMiddleware _proxy;

        public ApiProxyMiddleware(RequestDelegate next, IConfiguration configuration, IOptions<ApiProxyServerOptions> apiServerOptions)
        {
            _apiServerOptions = apiServerOptions;
            _configuration = configuration;
            _proxy = new ProxyMiddleware(next, this.ProxyOptions);
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

        private IOptions<ProxyOptions> ProxyOptions
        {
            get
            {
                ProxyOptions options = null;
                string apiServerUri = _configuration["MIDDLEWARE_NAME"];
                if (apiServerUri != null)
                {
                    string[] apiServerUriParts = apiServerUri.Split(':');
                    string host = apiServerUriParts[0];
                    string port = apiServerUriParts.Length > 1 ? apiServerUriParts[1] : null;

                    options = new ProxyOptions()
                    {
                        Scheme = "http",
                        Host = host,
                        Port = port
                    };
                }
                else
                {
                    options = new ProxyOptions()
                    {
                        Scheme = _apiServerOptions.Value.Scheme,
                        Host = _apiServerOptions.Value.Host,
                        Port = _apiServerOptions.Value.Port
                    };
                }

                return Options.Create(options);
            }
        }

        public static bool IsApiPath(HttpContext httpContext)
        {
            return httpContext.Request.Path.Value.IndexOf(_apiPathKey, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}

