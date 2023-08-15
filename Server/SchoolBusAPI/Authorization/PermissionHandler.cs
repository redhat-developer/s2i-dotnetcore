using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Http;

namespace SchoolBusAPI.Authorization
{
    public static class PermissionHandlerExtensions
    {
        /// <summary>
        /// Registers <see cref="PermissionHandler"/> with Dependency Injection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterPermissionHandler(this IServiceCollection services)
        {
            return services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
        }
    }

    /// <summary>
    /// Permission handler
    /// </summary>
    /// <remarks>
    /// Must be registered with Dependency Injection
    /// </remarks>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public PermissionHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var user = context.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (user.HasPermissions(requirement.RequiredPermissions.ToArray()))
            {
                context.Succeed(requirement);
            }
            else
            {
                Log.Information("RequiresPermission - {user} - {url}", user.Identity.Name, _httpContextAccessor.HttpContext.Request.Path);
            }

            return Task.CompletedTask;
        }
    }
}
