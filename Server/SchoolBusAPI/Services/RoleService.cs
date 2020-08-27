/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using SchoolBusAPI.Authorization;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Role created</response>
        IActionResult RolepermissionsBulkPostAsync(RolePermission[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Role created</response>
        IActionResult RolesBulkPostAsync(Role[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult RolesGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult RolesIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult RolesIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the permissions for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        IActionResult RolesIdPermissionsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a permissions to a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult RolesIdPermissionsPostAsync(int id, PermissionViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the permissions for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult RolesIdPermissionsPutAsync(int id, PermissionViewModel[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult RolesIdPutAsync(int id, RoleViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Role created</response>
        IActionResult RolesPostAsync(RoleViewModel item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class RoleService : ServiceBase, IRoleService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public RoleService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Bulk load of role permissions</remarks>
        /// <param name="items"></param>
        /// <response code="201">Roles created</response>
        public IActionResult RolepermissionsBulkPostAsync(RolePermission[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (RolePermission item in items)
            {
                // adjust the role
                if (item.Role != null)
                {
                    int role_id = item.Role.Id;
                    bool role_exists = _context.Roles.Any(a => a.Id == role_id);
                    if (role_exists)
                    {
                        Role role = _context.Roles.First(a => a.Id == role_id);
                        item.Role = role;
                    }
                }

                // adjust the permission
                if (item.Permission != null)
                {
                    int permission_id = item.Permission.Id;
                    bool permission_exists = _context.Permissions.Any(a => a.Id == permission_id);
                    if (permission_exists)
                    {
                        Permission permission = _context.Permissions.First(a => a.Id == permission_id);
                        item.Permission = permission;
                    }
                }

                var exists = _context.RolePermissions.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.RolePermissions.Update(item);
                }
                else
                {
                    _context.RolePermissions.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Permissions created</response>
        public IActionResult RolesBulkPostAsync(Role[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Role item in items)
            {
                var exists = _context.Roles.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Roles.Update(item);
                }
                else
                {
                    _context.Roles.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of active roles</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult RolesGetAsync()
        {
            var data = _context.Roles
                .AsNoTracking();

            var roles = Mapper.Map<List<RoleViewModel>>(data);
            if (User.IsSystemAdmin())
                return new ObjectResult(roles);

            var count = roles.Count() - 1;
            for (var i = count; i >= 0; i--)
            {
                var role = roles[i];
                if (!CurrentUserHasAllThePermissions(role.Id)) //return only the roles that the user has access.
                {
                    roles.Remove(role);
                    continue;
                }
            }

            return new ObjectResult(roles);
        }

        private bool CurrentUserHasAllThePermissions(int roleId)
        {
            var permissions = _context.RolePermissions
                .AsNoTracking()
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.Permission.Code)
                .ToArray();

            return User.HasPermissions(permissions);
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

            if (role.Name == Roles.SystemAdmininstrator)
            {
                return new StatusCodeResult(403); 
            }

            role.ExpiryDate = DateTime.Today;

            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<RoleViewModel>(role));
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

            return new ObjectResult(Mapper.Map<RoleViewModel>(role));
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
            var role = _context.Roles.AsNoTracking()
                .Include(x => x.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefault(x => x.Id == id);

            if (role == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            var permissions =
                role
                .RolePermissions
                .Where(rp => !rp.ExpiryDate.HasValue || rp.ExpiryDate == DateTime.MinValue || rp.ExpiryDate > DateTime.Now)
                .Select(rp => rp.Permission)
                .Where(p => !p.ExpiryDate.HasValue || p.ExpiryDate == DateTime.MinValue || p.ExpiryDate > DateTime.Now);

            return new ObjectResult(Mapper.Map<List<PermissionViewModel>>(permissions));
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
                var permissionIds = items.Select(x => x.Id).ToList();
                var existingPermissionIds = role.RolePermissions.Select(x => x.Permission.Id).ToList();
                var permissionIdsToAdd = permissionIds.Where(x => !existingPermissionIds.Contains((int)x)).ToList();

                // Permissions to add
                foreach (var permissionId in permissionIdsToAdd)
                {
                    var permToAdd = allPermissions.FirstOrDefault(x => x.Id == permissionId);
                    if (permToAdd == null)
                    {
                        // TODO throw new BusinessLayerException(string.Format("Invalid Permission Code {0}", code));
                    }
                    role.AddPermission(permToAdd);
                }

                // Permissions to remove
                List<RolePermission> permissionsToRemove = role.RolePermissions.Where(x => !permissionIds.Contains(x.Permission.Id)).ToList();
                foreach (RolePermission perm in permissionsToRemove)
                {
                    role.RemovePermission(perm.Permission);
                    _context.RolePermissions.Remove(perm);
                }

                _context.Roles.Update(role);
                _context.SaveChanges();
                txn.Commit();

                var result = Mapper.Map<List<RolePermissionViewModel>>(role.RolePermissions);

                return new ObjectResult(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds permissions to a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult RolesIdPermissionsPostAsync(int id, Permission[] items)
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
                var permissionIds = items.Select(x => x.Id).ToList();
                var existingPermissionIds = role.RolePermissions.Select(x => x.Permission.Id).ToList();
                var permissionIdsToAdd = permissionIds.Where(x => !existingPermissionIds.Contains((int)x)).ToList();

                // Permissions to add
                foreach (var permissionId in permissionIdsToAdd)
                {
                    var permToAdd = allPermissions.FirstOrDefault(x => x.Id == permissionId);
                    if (permToAdd == null)
                    {
                        // TODO throw new BusinessLayerException(string.Format("Invalid Permission Code {0}", code));
                    }
                    role.AddPermission(permToAdd);
                }

                _context.Roles.Update(role);
                _context.SaveChanges();
                txn.Commit();

                return new ObjectResult(Mapper.Map<List<RolePermissionViewModel>>(role.RolePermissions));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds permissions to a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult RolesIdPermissionsPostAsync(int id, PermissionViewModel item)
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
                var existingPermissionCodes = role.RolePermissions.Select(x => x.Permission.Code).ToList();
                if (!existingPermissionCodes.Contains(item.Code))
                {
                    var permToAdd = allPermissions.FirstOrDefault(x => x.Code == item.Code);
                    if (permToAdd == null)
                    {
                        // TODO throw new BusinessLayerException(string.Format("Invalid Permission Code {0}", code));
                    }
                    role.AddPermission(permToAdd);
                }

                _context.Roles.Update(role);
                _context.SaveChanges();
                txn.Commit();

                return new ObjectResult(Mapper.Map<List<RolePermissionViewModel>>(role.RolePermissions));
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

            Mapper.Map(item, role);
            _context.Roles.Update(role);
            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<RoleViewModel>(role));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Role created</response>
        public virtual IActionResult RolesPostAsync(RoleViewModel item)
        {
            var role = new Role();

            Mapper.Map(item, role);
            _context.Roles.Add(role);
            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<RoleViewModel>(role));
        }

        #region old code. not being used and not tested

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <remarks>Gets all the users for a role</remarks>
        ///// <param name="id">id of Role to fetch</param>
        ///// <response code="200">OK</response>
        //public virtual IActionResult RolesIdUsersGetAsync(int id)
        //{
        //    // and the users with those UserRoles
        //    List<User> result = new List<User>();

        //    List<User> users = _context.Users
        //            .Include(x => x.UserRoles)
        //            .ThenInclude(y => y.Role)
        //            .ToList();

        //    foreach (User user in users)
        //    {
        //        bool found = false;

        //        if (user.UserRoles != null)
        //        {
        //            // ef core does not support lazy loading, so we need to explicitly get data here.
        //            foreach (UserRole userRole in user.UserRoles)
        //            {
        //                if (userRole.Role != null && userRole.Role.Id == id && userRole.EffectiveDate <= DateTime.UtcNow && (userRole.ExpiryDate == null || userRole.ExpiryDate > DateTime.UtcNow))
        //                {
        //                    found = true;
        //                    break;
        //                }
        //            }
        //        }

        //        if (found && !result.Contains(user))
        //        {
        //            result.Add(user);
        //        }
        //    }

        //    return new ObjectResult(result);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <remarks>Updates the users for a role</remarks>
        ///// <param name="id">id of Role to update</param>
        ///// <param name="items"></param>
        ///// <response code="200">OK</response>
        ///// <response code="404">Role not found</response>
        //public virtual IActionResult RolesIdUsersPutAsync(int id, UserRoleViewModel[] items)
        //{
        //    bool role_exists = _context.Roles.Any(x => x.Id == id);
        //    bool data_changed = false;
        //    if (role_exists)
        //    {
        //        Role role = _context.Roles.First(x => x.Id == id);

        //        // scan through users

        //        var users = _context.Users
        //                .Include(x => x.UserRoles)
        //                .ThenInclude(y => y.Role);

        //        foreach (User user in users)
        //        {
        //            // first see if it is one of our matches.                    
        //            UserRoleViewModel foundItem = null;
        //            foreach (var item in items)
        //            {
        //                if (item.UserId == user.Id)
        //                {
        //                    foundItem = item;
        //                    break;
        //                }
        //            }

        //            if (foundItem == null) // delete the user role if it exists.
        //            {
        //                foreach (UserRole userRole in user.UserRoles)
        //                {
        //                    if (userRole.Role.Id == id)
        //                    {
        //                        user.UserRoles.Remove(userRole);
        //                        _context.Users.Update(user);
        //                        data_changed = true;
        //                    }
        //                }
        //            }
        //            else // add the user role if it does not exist.
        //            {
        //                bool found = false;
        //                foreach (UserRole userRole in user.UserRoles)
        //                {
        //                    if (userRole.Role.Id == id)
        //                    {
        //                        found = true;
        //                    }
        //                }
        //                if (found == false)
        //                {
        //                    UserRole newUserRole = new UserRole();
        //                    newUserRole.EffectiveDate = DateTime.UtcNow;
        //                    newUserRole.Role = role;

        //                    user.UserRoles.Add(newUserRole);
        //                    _context.Users.Update(user);
        //                    data_changed = true;
        //                }
        //            }
        //        }
        //        if (data_changed)
        //        {
        //            _context.SaveChanges();
        //        }

        //        return new StatusCodeResult(200);
        //    }
        //    else
        //    {
        //        return new StatusCodeResult(404);
        //    }

        //}
        #endregion
    }
}
