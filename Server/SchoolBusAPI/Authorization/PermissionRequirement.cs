using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace SchoolBusAPI.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> RequiredPermissions { get; }

        public PermissionRequirement(params string[] permissions)
        {
            RequiredPermissions = permissions;
        }
    }
}
