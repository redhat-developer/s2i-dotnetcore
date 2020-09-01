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
        /// <param name="userRoleId">id of User Role to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult UpdateUserRole(int id, int userRoleId, UserRoleViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="item"></param>
        /// <response code="201">User created</response>
        IActionResult CreateUser(UserViewModel item);

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
                    .ThenInclude(y => y.Role);

            return new ObjectResult(Mapper.Map<List<UserViewModel>>(users));
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
                .FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            var userView = Mapper.Map<UserViewModel>(user);

            return new ObjectResult(userView);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new user</remarks>
        /// <param name="item"></param>
        /// <response code="201">User created</response>
        public virtual IActionResult CreateUser(UserViewModel item)
        {
            var (userValid, smUserError) = ValidateSmUserId(item);
            if (!userValid)
            {
                return smUserError;
            }

            var (districtValid, districtError) = ValidateDistrict(item);
            if (!districtValid)
            {
                return districtError;
            }

            var user = Mapper.Map<User>(item);

            _context.Users.Add(user);

            _context.SaveChanges();

            return new ObjectResult(item);
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
            if (id != item.Id)
            {
                return new UnprocessableEntityObjectResult(new Error("Validation Error", 100, $"Id [{id}] mismatches [{item.Id}]."));
            }

            var user = _context.Users
                .Include(x => x.District)
                .Include(x => x.UserRoles)
                    .ThenInclude(y => y.Role)
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return new StatusCodeResult(404);
            }

            var (userValid, smUserError) = ValidateSmUserId(item);
            if (!userValid)
            {
                return smUserError;
            }

            var (districtValid, districtError) = ValidateDistrict(item);
            if (!districtValid)
            {
                return districtError;
            }

            user = Mapper.Map(item, user);

            user.District = _context.Districts
                        .First(x => x.Id == item.District.Id);

            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<UserViewModel>(user));
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
                .Include(x => x.District)
                .Include(x => x.UserRoles)
                    .ThenInclude(y => y.Role)
                .FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            user.Active = false;
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

        public virtual IActionResult UpdateUserRole(int userId, int userRoleId, UserRoleViewModel item)
        {
            bool exists = _context.Users.Any(x => x.Id == userId);

            if (!_context.Users.Any(x => x.Id == userId) || item == null)
                return new StatusCodeResult(400);

            if (userRoleId != item.Id)
            {
                return new UnprocessableEntityObjectResult(new Error("Validation Error", 100, $"Id [{userId}] mismatches [{item.Id}]."));
            }

            if (!_context.UserRoles.Any(x => x.Id == userRoleId && x.UserId == userId))
                return new StatusCodeResult(400);

            var userRole = _context.UserRoles.First(x => x.Id == item.Id);

            userRole.ExpiryDate = item.ExpiryDate;

            _context.SaveChanges();
            return new StatusCodeResult(201);

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

        private (bool success, UnprocessableEntityObjectResult errorResult) ValidateDistrict(UserViewModel user)
        {
            if (user.District == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 303, $"District is mandatory.")));
            }

            if (!_context.Districts.Any(x => x.Id == user.District.Id))
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 304, $"District ID [{user.District.Id}] does not exist.")));
            }

            return (true, null);
        }

        private (bool success, UnprocessableEntityObjectResult errorResult) ValidateSmUserId(UserViewModel user)
        {
            if (user.Id > 0)
            {
                if (_context.Users.Any(x => x.Id != user.Id && x.SmUserId.ToUpper() == user.SmUserId.ToUpper()))
                {
                    return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 301, $"User ID [{user.SmUserId}] already exists.")));
                }
            }
            else
            {
                if (_context.Users.Any(x => x.SmUserId.ToUpper() == user.SmUserId.ToUpper()))
                {
                    return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 302, $"User ID [{user.SmUserId}] already exists.")));
                }
            }

            return (true, null);
        }
    }
}
