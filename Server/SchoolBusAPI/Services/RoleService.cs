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
using Microsoft.AspNetCore.Mvc.ApiExplorer;

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
        /// <response code="200">OK</response>
        IActionResult GetRoles(bool includeExpired = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult DeleteRole(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult GetRole(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get all the permissions for a role</remarks>
        /// <param name="id">id of Role to fetch</param>
        /// <response code="200">OK</response>
        IActionResult GetRolePermissions(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the permissions for a role</remarks>
        /// <param name="id">id of Role to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult UpdateRolePermissions(int id, PermissionViewModel[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        IActionResult UpdateRole(int id, RoleViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Role created</response>
        IActionResult CreateRole(RoleViewModel item);
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
        /// <remarks>Returns a collection of active roles</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult GetRoles(bool includeExpired = false)
        {
            var data = _context.Roles
                .AsNoTracking();

            if (!includeExpired)
            {
                data = data.Where(r => !r.ExpiryDate.HasValue || r.ExpiryDate == DateTime.MinValue || r.ExpiryDate > DateTime.Today);
            }

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
        public virtual IActionResult DeleteRole(int id)
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
        public virtual IActionResult GetRole(int id)
        {
            var role = _context.Roles.AsNoTracking().FirstOrDefault(x => x.Id == id);

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
        public virtual IActionResult GetRolePermissions(int id)
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
        public virtual IActionResult UpdateRolePermissions(int id, PermissionViewModel[] items)
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

            var result = Mapper.Map<List<RolePermissionViewModel>>(role.RolePermissions);

            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Role to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Role not found</response>
        public virtual IActionResult UpdateRole(int id, RoleViewModel item)
        {
            if (id != item.Id)
            {
                return new UnprocessableEntityObjectResult(new Error("Validation Error", 203, $"Id [{id}] mismatches [{item.Id}]."));
            }

            var role = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            if (_context.Roles.AsNoTracking().Any(r => r.Id != item.Id && r.Name.ToUpper() == item.Name.ToUpperInvariant()))
            {
                return new UnprocessableEntityObjectResult(new Error("Validation Error", 202, $"Role [{item.Name}] already exists."));
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
        public virtual IActionResult CreateRole(RoleViewModel item)
        {
            if (_context.Roles.AsNoTracking().Any(r => r.Name.ToUpper() == item.Name.ToUpperInvariant()))
            {
                return new UnprocessableEntityObjectResult(new Error("Validation Error", 201, $"Role [{item.Name}] already exists."));
            }

            var role = new Role();

            Mapper.Map(item, role);
            _context.Roles.Add(role);
            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<RoleViewModel>(role));
        }
    }
}
