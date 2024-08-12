using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SchoolBusAPI.Extensions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SchoolBusAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (httpContext.Response.HasStarted || httpContext.RequestAborted.IsCancellationRequested)
                    return;

                var guid = Guid.NewGuid();
                Log.Error($"HMCR Exception{guid}: {ex}");
                await HandleExceptionAsync(httpContext, guid);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Guid guid)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problem = new ValidationProblemDetails()
            {
                Type = "https://sb.bc.gov.ca/exception",
                Title = "An unexpected error occurred!",
                Status = StatusCodes.Status500InternalServerError,
                Detail = "The instance value should be used to identify the problem when calling customer support",
                Instance = $"urn:sbi:error:{Guid.NewGuid()}"
            };

            problem.Extensions.Add("traceId", context.TraceIdentifier);

            await context.Response.WriteJsonAsync(problem, "application/problem+json");
        }
    }

}
