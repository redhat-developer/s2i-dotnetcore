using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace SchoolBusCommon
{
    /// <summary>
    /// Captures synchronous and asynchronous exceptions from the pipeline and generates JSON error responses.
    /// </summary>
    public class JsonExceptionResultMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        
        private readonly System.Diagnostics.DiagnosticSource _diagnosticSource;        

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonExceptionResultMiddleware"/> class
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="diagnosticSource"></param>
        public JsonExceptionResultMiddleware(
                RequestDelegate next,
                ILoggerFactory loggerFactory,
                IHostingEnvironment hostingEnvironment,
                System.Diagnostics.DiagnosticSource diagnosticSource)
            {
                if (next == null)
                {
                    throw new ArgumentNullException(nameof(next));
                }
                
                _next = next;
                _logger = loggerFactory.CreateLogger<JsonExceptionResultMiddleware>();
                _diagnosticSource = diagnosticSource;
                
            }

            /// <summary>
            /// Process an individual request.
            /// </summary>
            /// <param name="context"></param>
            /// <returns></returns>
            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(0, ex, "An unhandled exception has occurred while executing the request");

                    if (context.Response.HasStarted)
                    {
                        _logger.LogWarning("The response has already started, the error page middleware will not be executed.");
                        throw;
                    }

                    try
                    {
                        
                        context.Response.StatusCode = 500;

                        await DisplayException(context, ex);

                        if (_diagnosticSource.IsEnabled("Microsoft.AspNetCore.Diagnostics.UnhandledException"))
                        {
                            _diagnosticSource.Write("Microsoft.AspNetCore.Diagnostics.UnhandledException", new { httpContext = context, exception = ex });
                        }

                        return;
                    }
                    catch (Exception ex2)
                    {
                        // If there's a Exception while generating the error page, re-throw the original exception.
                        _logger.LogError(0, ex2, "An exception was thrown attempting to display the error page.");
                    }
                    throw;
                }
            }

            // Assumes the response headers have not been sent.  If they have, still attempt to write to the body.
            private Task DisplayException(HttpContext context, Exception ex)
            {
                // send the exception back as json.
                return context.Response.WriteAsync (JsonConvert.SerializeObject(ex));
            }
    
    }
}

