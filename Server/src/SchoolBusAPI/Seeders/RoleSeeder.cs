using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolBusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBusAPI.Seeders
{
    public class RoleSeeder : Seeder<DbAppContext>
    {
        private string[] ProfileTriggers = { AllProfiles };

        public RoleSeeder(IConfiguration configuration, IHostingEnvironment env, ILoggerFactory loggerFactory) 
            : base(configuration, env, loggerFactory)
        { }

        protected override IEnumerable<string> TriggerProfiles
        {
            get { return ProfileTriggers; }
        }

        public override Type InvokeAfter
        {
            get
            {
                return typeof(PermissionSeeder);
            }
        }

        protected override void Invoke(DbAppContext context)
        {
            UpdateRoles(context);
            context.SaveChanges();
        }

        private void UpdateRoles(DbAppContext context)
        {
            var permissions = context.Permissions.ToList();

            // Load the roles
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "User",
                    Description = "A regular user in the system.",
                    RolePermissions = permissions.Where(p =>
                        new string[] { Permission.LOGIN }
                        .Contains(p.Code))
                        .Select(p => new RolePermission()
                        {
                            Permission = p
                        }).ToList()
                },
                new Role
                {
                    Name = "Administrator",
                    Description = "System Administrator; full access to the whole system.",
                    RolePermissions = permissions.Select(p => new RolePermission()
                    {
                        Permission = p
                    }).ToList()
                },
            };

            _logger.LogDebug("Updating roles ...");
            foreach (var role in roles)
            {
                var r = context.GetRole(role.Name);
                if (r == null)
                {
                    _logger.LogDebug($"Adding role; {role.Name} ...");
                    context.Roles.Add(role);
                }
                else
                {
                    _logger.LogDebug($"Updating role; {r.Name} ...");
                    r.Description = role.Description;
                }
            }
        }
    }
}
