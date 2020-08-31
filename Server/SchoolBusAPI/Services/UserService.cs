/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all users</remarks>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult GetUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a user</remarks>
        /// <param name="id">id of User to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult DeleteUser(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns data for a particular user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult GetUser(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult UpdateUser(int id, UserViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the roles for a user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult GetUserRoles(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a role to a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="201">Role created for user</response>
        IActionResult CreateUserRole(int id, UserRoleViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the roles for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult UpdateUserRoles(int id, UserRoleViewModel[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="item"></param>
        /// <response code="201">User created</response>
        IActionResult CreateUser(User item);

        /// <summary>
        /// Searches Users
        /// </summary>
        /// <remarks>Used for the search users.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="surname"></param>
        /// <param name="includeInactive">True if Inactive users will be returned</param>
        /// <response code="200">OK</response>
        IActionResult SearchUsers(int?[] districts, string surname, bool? includeInactive);

        IActionResult GetInspectors(bool? includeInactive);
    }

    /// <summary>
    /// 
    /// </summary>
    public class UserService : ServiceBase, IUserService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public UserService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        private void AdjustUser(SchoolBusAPI.Models.User item)
        {
            if (item.District != null)
            {
                bool district_exists = _context.Districts.Any(x => x.Id == item.District.Id);
                if (district_exists)
                {
                    District district = _context.Districts.First(x => x.Id == item.District.Id);
                    item.District = district;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all users</remarks>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult GetUsers()
        {
            var users = _context.Users
                .AsNoTracking()
                .Include(x => x.District)
                .Include(x => x.UserRoles)
                .ThenInclude(y => y.Role)
                .ThenInclude(z => z.RolePermissions)
                .ThenInclude(z => z.Permission);

            return new ObjectResult(Mapper.Map<List<UserViewModel>>(users));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a user</remarks>
        /// <param name="id">id of User to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult DeleteUser(int id)
        {
            var user = _context.Users
                .Include(x => x.UserRoles)
                .FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }
            if (user.UserRoles != null)
            {
                foreach (var item in user.UserRoles)
                {
                    _context.UserRoles.Remove(item);
                }
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<UserViewModel>(user));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns data for a particular user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult GetUser(int id)
        {
            var user = _context.Users
                .AsNoTracking()
                .Include(x => x.District)
                .Include(x => x.UserRoles)
                .ThenInclude(y => y.Role)
                .ThenInclude(z => z.RolePermissions)
                .ThenInclude(z => z.Permission)
                .FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }
            return new ObjectResult(Mapper.Map<UserViewModel>(user));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UpdateUser(int id, UserViewModel item)
        {
            var user = _context.Users
                .Include(x => x.District)
                .Include(x => x.UserRoles)
                .ThenInclude(y => y.Role)
                .ThenInclude(z => z.RolePermissions)
                .ThenInclude(z => z.Permission)
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            user.Active = item.Active;
            user.Email = item.Email;
            user.GivenName = item.GivenName;
            user.Surname = item.Surname;
            user.SmUserId = item.SmUserId;

            if (item.District != null)
            {
                bool district_exists = _context.Districts.Any(x => x.Id == item.District.Id);
                if (district_exists)
                {
                    District district = _context.Districts
                        .Include(x => x.Region)
                        .First(x => x.Id == item.District.Id);
                    user.District = district;
                }
            }

            // Save changes
            _context.Users.Update(user);
            _context.SaveChanges();
            return new ObjectResult(Mapper.Map<UserViewModel>(user));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the roles for a user</remarks>
        /// <param name="id">id of User to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult GetUserRoles(int id)
        {
            var user = _context.Users
                .AsNoTracking()
                .Include(x => x.UserRoles)
                .ThenInclude(y => y.Role)
                .First(x => x.Id == id);

            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            var result = Mapper.Map<List<UserRoleViewModel>>(user.UserRoles);

            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a role to a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="item"></param>
        /// <response code="201">Role created for user</response>
        public virtual IActionResult CreateUserRole(int id, UserRoleViewModel item)
        {
            bool exists = _context.Users.Any(x => x.Id == id);
            bool success = false;
            if (exists)
            {
                // check the role id
                bool role_exists = _context.Roles.Any(x => x.Id == item.RoleId);
                if (role_exists)
                {
                    User user = _context.Users
                        .Include(x => x.District)
                        .Include(x => x.UserRoles)
                        .ThenInclude(y => y.Role)
                        .ThenInclude(z => z.RolePermissions)
                        .ThenInclude(z => z.Permission)
                        .First(x => x.Id == id);
                    if (user.UserRoles == null)
                    {
                        user.UserRoles = new List<UserRole>();
                    }
                    // create a new UserRole based on the view model.
                    UserRole userRole = new UserRole();
                    Role role = _context.Roles.First(x => x.Id == item.RoleId);
                    userRole.Role = role;
                    userRole.EffectiveDate = item.EffectiveDate;
                    userRole.ExpiryDate = item.ExpiryDate;

                    if (!user.UserRoles.Contains(userRole))
                    {
                        user.UserRoles.Add(userRole);
                    }
                    _context.Update(user);
                    _context.SaveChanges();
                    success = true;
                }
            }

            if (success)
            {
                return new StatusCodeResult(201);
            }
            else
            {
                return new StatusCodeResult(400);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates the roles for a user</remarks>
        /// <param name="id">id of User to update</param>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UpdateUserRoles(int id, UserRoleViewModel[] items)
        {
            bool exists = _context.Users.Any(x => x.Id == id);
            if (exists && items != null)
            {
                User user = _context.Users
                    .Include(x => x.District)
                    .Include(x => x.UserRoles)
                    .ThenInclude(y => y.Role)
                    .ThenInclude(z => z.RolePermissions)
                    .ThenInclude(z => z.Permission)
                    .First(x => x.Id == id);
                if (user.UserRoles == null)
                {
                    user.UserRoles = new List<UserRole>();
                }
                else
                {
                    // existing data, clear it.
                    foreach (var userRole in user.UserRoles)
                    {
                        if (_context.UserRoles.Any(x => x.Id == userRole.Id))
                        {
                            UserRole delete = _context.UserRoles.First(x => x.Id == userRole.Id);
                            _context.Remove(delete);
                        }
                    }
                    user.UserRoles.Clear();
                }


                foreach (var item in items)
                {
                    // check the role id
                    bool role_exists = _context.Roles.Any(x => x.Id == item.RoleId);
                    if (role_exists)
                    {
                        // create a new UserRole based on the view model.
                        UserRole userRole = new UserRole();
                        Role role = _context.Roles.First(x => x.Id == item.RoleId);
                        userRole.Role = role;
                        userRole.EffectiveDate = item.EffectiveDate;
                        userRole.ExpiryDate = item.ExpiryDate;

                        _context.Add(userRole);

                        if (!user.UserRoles.Contains(userRole))
                        {
                            user.UserRoles.Add(userRole);
                        }
                    }
                }
                _context.Update(user);
                _context.SaveChanges();
                return new StatusCodeResult(201);
            }
            else
            {
                return new StatusCodeResult(400);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="item"></param>
        /// <response code="201">User created</response>
        public virtual IActionResult CreateUser(User item)
        {
            AdjustUser(item);
            bool exists = _context.Users.Any(x => x.Id == item.Id);
            if (exists)
            {

                _context.Users.Update(item);
            }
            else
            {
                _context.Users.Add(item);
            }

            _context.SaveChanges();
            return new ObjectResult(item);
        }

        /// <summary>
        /// Searches Users
        /// </summary>
        /// <remarks>Used for the search users.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="surname"></param>
        /// <param name="includeInactive">True if Inactive users will be returned</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SearchUsers(int?[] districts, string surname, bool? includeInactive)
        {
            // Eager loading of related data
            var data = _context.Users
                .AsNoTracking()
                .Include(x => x.District)
                .Include(x => x.UserRoles)
                .ThenInclude(y => y.Role)
                .ThenInclude(z => z.RolePermissions)
                .ThenInclude(z => z.Permission)
                .Select(x => x);

            // Note that Districts searches SchoolBus Districts, not SchoolBusOwner Districts
            if (districts != null)
            {

                foreach (int? district in districts)
                {
                    if (district != null)
                    {
                        data = data.Where(x => x.District.Id == district);
                    }
                }
            }

            if (surname != null)
            {
                data = data.Where(x => x.Surname.ToLower().Contains(surname.ToLower()));
            }

            if (includeInactive == null || includeInactive == false)
            {
                data = data.Where(x => x.Active == true);
            }

            // now convert the results to the view model.
            var result = Mapper.Map<List<UserListViewModel>>(data);

            return new ObjectResult(result);
        }

        public IActionResult GetInspectors(bool? includeInactive = false)
        {
            var data = _context.UserRoles
                .AsNoTracking()
                .Where(ur => ur.Role.Name == Roles.Inspector)
                .Select(ur => ur.User);

            if (includeInactive == null || includeInactive == false)
            {
                data = data.Where(u => u.Active == true);
            }                

            var result = Mapper.Map<List<InspectorViewModel>>(data);

            return new ObjectResult(result);
        }
    }
}
