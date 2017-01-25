using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolBusAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBusAPI.Seeders
{
    internal class PermissionSeeder : Seeder<DbAppContext>
    {
        private string[] ProfileTriggers = { AllProfiles };

        public PermissionSeeder(IConfiguration configuration, IHostingEnvironment env, ILoggerFactory loggerFactory) 
            : base(configuration, env, loggerFactory)
        { }

        protected override IEnumerable<string> TriggerProfiles
        {
            get { return ProfileTriggers; }
        }

        protected override void Invoke(DbAppContext context)
        {
            UpdatePermissions(context);
            context.SaveChanges();

            _logger.LogDebug("Listing permissions ...");
            foreach (var p in context.Permissions.ToList())
            {
                _logger.LogDebug($"{p.Code}");
            }
        }

        private void UpdatePermissions(DbAppContext context)
        {
            var permissions = Permission.ALL_PERMISSIONS;

            _logger.LogDebug("Updating permissions ...");
            foreach (var permission in permissions)
            {
                _logger.LogDebug($"Looking up {permission.Code} ...");
                var p = context.Permissions.Where(x => x.Code == permission.Code).FirstOrDefault();
                if (p == null)
                {
                    _logger.LogDebug($"{permission.Code} does not exist, adding it ...");
                    context.Permissions.Add(permission);
                }
                else
                {
                    _logger.LogDebug($"Updating the fields for {permission.Code} ...");
                    p.Description = permission.Description;
                    p.Name = permission.Name;
                }
            }

            // Remove any that don't exist anymore
            _logger.LogDebug("Removing permissions that don't exit anymore ...");
            foreach (var permission in context.Permissions.ToList())
            {
                var p = permissions.Where(x => x.Code == permission.Code).FirstOrDefault();
                if (p == null)
                {
                    _logger.LogDebug($"Removing {permission.Code} ...");
                    context.Permissions.Remove(permission);
                }
            }
        }
    }
}
