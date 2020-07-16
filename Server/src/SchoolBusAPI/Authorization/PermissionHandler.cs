using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

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

            return Task.CompletedTask;
        }
    }
}
