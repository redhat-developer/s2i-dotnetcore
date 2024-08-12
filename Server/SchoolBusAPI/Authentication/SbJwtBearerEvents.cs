using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBusAPI.Extensions;
using SchoolBusAPI.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolBusAPI.Authentication
{
    public class SbJwtBearerEvents : JwtBearerEvents
    {
        private DbAppContext _dbContext;

        public SbJwtBearerEvents(DbAppContext dbContext) : base()
        {
            _dbContext = dbContext;
        }

        public override async Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            var problem = new ValidationProblemDetails()
            {
                Type = "https://sb.bc.gov.ca/exception",
                Title = "Access denied",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "Authentication failed.",
                Instance = context.Request.Path
            };

            problem.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

            await context.Response.WriteJsonAsync(problem, "application/problem+json");
        }

        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var (username, userGuid, directory) = context.Principal.GetUserInfo();

            var user = _dbContext.LoadUser(username, userGuid);

            if (user == null)
            {
                context.Fail("Access Denied");
                return;
            }

            context.Principal = user.ToClaimsPrincipal(JwtBearerDefaults.AuthenticationScheme);

            await Task.CompletedTask;
        }
    }
}
