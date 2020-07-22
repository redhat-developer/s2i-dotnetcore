using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace SchoolBusAPI.Authorization
{
    public class RequiresPermissionFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authService;
        private readonly PermissionRequirement _requiredPermissions;

        public RequiresPermissionFilter(IAuthorizationService authService, PermissionRequirement requiredPermissions)
        {
            _authService = authService;
            _requiredPermissions = requiredPermissions;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var result = await _authService.AuthorizeAsync(context.HttpContext.User,
                context.ActionDescriptor.DisplayName,
                _requiredPermissions);

            if (!result.Succeeded)
            {
                var problem = new ValidationProblemDetails()
                {
                    Type = "https://sb.bc.gov.ca/exception",
                    Title = "Access denied",
                    Status = StatusCodes.Status401Unauthorized,
                    Detail = "Insufficient permission.",
                    Instance = context.HttpContext.Request.Path
                };

                problem.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                context.Result = new UnauthorizedObjectResult(problem);
            }
        }
    }
}
