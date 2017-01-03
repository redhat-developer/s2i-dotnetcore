using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace SchoolBusClient.Handlers
{
    public class ProxyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor - called automatically
        /// </summary>
        /// <param name="next"></param>
        /// <param name="configuration"></param>
        public ProxyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        /// <summary>
        /// The invoke method is called by the ProxyExtension class.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {            
            var endRequest = false;

            string contextRequestPath = context.Request.Path.Value;
            string API_PREFIX = "/api/";
            if (contextRequestPath.Length >= API_PREFIX.Length && contextRequestPath.Substring(0, API_PREFIX.Length).Equals(API_PREFIX))
            {
                // extract the remainder of the path.
                string path_remainder = contextRequestPath.Substring(API_PREFIX.Length);

                // Get the application configuration

                string middleware_name = _configuration["MIDDLEWARE_NAME"];

                if (middleware_name != null)
                {
                    // Create a new URL to the next server inline.
                    var url = "http://" + middleware_name + "/api/" + path_remainder;
                    await StreamAsync(context, url);
                    endRequest = true;
                }
                else
                {
                    string error = "Error: Environment variable MIDDLEWARE_NAME is empty.";
                    await context.Response.WriteAsync(error);
                }                
            }
            if (!endRequest)
            {
                await _next(context);
            }
        }

        private static async Task StreamAsync(HttpContext context, string url)
        {
            var httpClientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            var webRequest = new HttpClient(httpClientHandler);

            var localResponse = context.Response;

            string remoteResult = await webRequest.GetStringAsync(url);

            localResponse.ContentLength = remoteResult.Length;
            await localResponse.WriteAsync(remoteResult);
        }
    }

}

