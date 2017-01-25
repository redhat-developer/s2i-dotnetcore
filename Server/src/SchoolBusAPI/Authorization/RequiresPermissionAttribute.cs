using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SchoolBusAPI.Authorization
{
    /// <summary>
    /// Allows declarative claims based permissions to be applied to controller methods for authorization.
    /// </summary>
    /// <remarks>
    /// This attribute works well at the controller level.  Refer to <see cref="SchoolBusAPI.Controllers.TestController"/>
    /// for examples.  That said this attribute is not triggered by default when applied to methods inside
    /// a service implementation of a controller.  For instance, many of the controllers in the project are
    /// auto-generated with the implementation being deferred to a service implementation which is injected
    /// at runtime (good pattern).  This attribute will work when applied directly to methods of the controller, 
    /// but will not be triggered when applied to the corresponding methods of the implementation.
    /// 
    /// As a workaround you can use the <see cref="SchoolBusAPI.Authorization.ClaimsPrincipalExtensions.HasPermissions"/> 
    /// extension method, <see cref="SchoolBusAPI.Controllers.TestController"/> contains samples of this too.
    /// You will need to have the HttpContext injected into the service implementation via dependency injection in order
    /// to access the User (ClaimsPrincipal) in order to perform the permissions check.
    /// 
    /// A more permanent solution would be to implement a provider that looks for the attribute on service implementations
    /// and ensures it is executed.  We had a similar situation in DARS which was solved by implementing a 
    /// ActionDescriptorFilterProvider and IFilterProvider <see cref="DARS.Server.Filters.DarsFilterProvider"/>
    /// </remarks>
    /// <see href="http://benjamincollins.com/blog/practical-permission-based-authorization-in-asp-net-core/"/>
    public class RequiresPermissionAttribute : TypeFilterAttribute
    {
        public RequiresPermissionAttribute(params string[] permissions)
           : base(typeof(RequiresPermissionAttributeImplementation))
        {
            Arguments = new[] { new PermissionRequirement(permissions) };
        }

        public class RequiresPermissionAttributeImplementation : Attribute, IAsyncResourceFilter
        {
            private readonly ILogger _logger;
            private readonly IAuthorizationService _authService;
            private readonly PermissionRequirement _requiredPermissions;

            public RequiresPermissionAttributeImplementation(ILogger<RequiresPermissionAttribute> logger,
                                            IAuthorizationService authService,
                                            PermissionRequirement requiredPermissions)
            {
                _logger = logger;
                _authService = authService;
                _requiredPermissions = requiredPermissions;
            }

            public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
            {
                if (!await _authService.AuthorizeAsync(context.HttpContext.User,
                                            context.ActionDescriptor.DisplayName,
                                            _requiredPermissions))
                {
                    context.Result = new ChallengeResult();
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
