/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Mappings;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleApiService : IRoleApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public RoleApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of roles</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult RolesGetAsync()
        {
            var result = _context.Roles.Select(x => x.ToViewModel()).ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult RolesIdDeletePostAsync(int id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return new ObjectResult(role.ToViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult RolesIdGetAsync(int id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }
            return new ObjectResult(role.ToViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the permissions for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult RolesIdPermissionsGetAsync(int id)
        {
            // Eager loading of related data
            var role = _context.Roles
                .Where(x => x.Id == id)
                .Include(x => x.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefault();

            if (role == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            var dbPermissions = role.RolePermissions.Select(x => x.Permission);

            // Create DTO with serializable response
            var result = dbPermissions.Select(x => x.ToViewModel()).ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the permissions for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult RolesIdPermissionsPutAsync(int id, PermissionViewModel[] items)
        {
            using (var txn = _context.BeginTransaction())
            {
                // Eager loading of related data
                var role = _context.Roles
                    .Where(x => x.Id == id)
                    .Include(x => x.RolePermissions)
                    .ThenInclude(rolePerm => rolePerm.Permission)
                    .FirstOrDefault();

                if (role == null)
                {
                    // Not Found
                    return new StatusCodeResult(404);
                }

                var allPermissions = _context.Permissions.ToList();
                var permissionCodes = items.Select(x => x.Code).ToList();
                var existingPermissionCodes = role.RolePermissions.Select(x => x.Permission.Code).ToList();
                var permissionCodesToAdd = permissionCodes.Where(x => !existingPermissionCodes.Contains(x)).ToList();

                // Permissions to add
                foreach (var code in permissionCodesToAdd)
                {
                    var permToAdd = allPermissions.FirstOrDefault(x => x.Code == code);
                    if (permToAdd == null)
                    {
                        // TODO throw new BusinessLayerException(string.Format("Invalid Permission Code {0}", code));
                    }
                    role.AddPermission(permToAdd);
                }

                // Permissions to remove
                List<RolePermission> permissionsToRemove = role.RolePermissions.Where(x => !permissionCodes.Contains(x.Permission.Code)).ToList();
                foreach (RolePermission perm in permissionsToRemove)
                {
                    role.RemovePermission(perm.Permission);
                    _context.RolePermissions.Remove(perm);
                }

                _context.Roles.Update(role);
                _context.SaveChanges();
                txn.Commit();

                List<RolePermission> dbPermissions = _context.RolePermissions.ToList();

                // Create DTO with serializable response
                var result = dbPermissions.Select(x => x.ToViewModel()).ToList();
                return new ObjectResult(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult RolesIdPutAsync(int id, RoleViewModel item)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            role.Name = item.Name;
            role.Description = item.Description;
            _context.Roles.Update(role);

            // Save changes
            _context.SaveChanges();
            return new ObjectResult(role.ToViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Gets all the users for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult RolesIdUsersGetAsync(int id)
        {
            // Eager loading of related data
            var role = _context.Roles
                .Where(x => x.Id == id)
                .Include(x => x.UserRoles)
                .ThenInclude(userRole => userRole.User)
                .FirstOrDefault();

            if (role == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            var usersWithRole = role.UserRoles;

            // Create DTO with serializable response
            var result = usersWithRole.Select(x => x.ToViewModel()).ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the users for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult RolesIdUsersPutAsync(int id, UserRoleViewModel[] items)
        {
            using (var txn = _context.BeginTransaction())
            {
                // Eager loading of related data
                var role = _context.Roles
                    .Where(x => x.Id == id)
                    .Include(x => x.UserRoles)
                    .ThenInclude(userRole => userRole.User)
                    .FirstOrDefault();

                // Not Found
                if (role == null)
                {
                    return new StatusCodeResult(404);
                }

                var userIds = items.Select(x => x.UserId).ToList();
                var allUsers = _context.Users.Where(x => userIds.Contains(x.Id)).ToList();

                foreach (var userRoleDto in items)
                {
                    if (userRoleDto.Id.HasValue)
                    {
                        var existingUserRole = role.UserRoles.FirstOrDefault(x => x.Id == userRoleDto.Id.Value);
                        if (existingUserRole == null)
                        {
                            // TODO throw new ResourceNotFoundException(string.Format("Cannot find userrole with id {0} on role {1}", userRole.Id.Value, roleId));
                        }
                        else
                        {
                            // TODO Check serialization of Dates
                            existingUserRole.EffectiveDate = userRoleDto.EffectiveDate;
                            existingUserRole.ExpiryDate = userRoleDto.ExpiryDate;
                        }
                    }
                    else
                    {
                        var dbUserRole = new UserRole();
                        dbUserRole.Role = role;
                        dbUserRole.User = allUsers.FirstOrDefault(x => x.Id == userRoleDto.UserId);
                        _context.UserRoles.Add(dbUserRole);

                        role.UserRoles.Add(dbUserRole);
                    }
                }

                // Users to remove
                var toRemove = role.UserRoles.Where(x => !userIds.Contains(x.User.Id)).ToList();
                toRemove.ForEach(x => role.RemoveUser(x.User));
                _context.UserRoles.RemoveRange(toRemove);
                _context.Roles.Update(role);

                // Save changes
                _context.SaveChanges();
                txn.Commit();

                var result = role.UserRoles.ToList();
                return new ObjectResult(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Role created</response>
        public virtual IActionResult RolesPostAsync(RoleViewModel item)
        {
            var role = new Role();
            role.Description = item.Description;
            role.Name = item.Name;

            // Save changes
            _context.Roles.Add(role);
            _context.SaveChanges();
            return new ObjectResult(role.ToViewModel());
        }
    }
}
