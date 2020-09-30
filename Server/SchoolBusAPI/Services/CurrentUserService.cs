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
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Removes a specific user favourite</remarks>
        /// <param name="id">id of Favourite to delete</param>
        /// <response code="200">OK</response>
        IActionResult UsersCurrentFavouritesIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new favourite for the current user</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        IActionResult UsersCurrentFavouritesPostAsync(UserFavourite item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a favourite</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        IActionResult UsersCurrentFavouritesPutAsync(UserFavourite item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s favourites of a given type.  If type is empty, returns all.</remarks>
        /// <param name="type">type of favourite to return</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        IActionResult UsersCurrentFavouritesTypeGetAsync(string type);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get the currently logged in user</remarks>
        /// <response code="200">OK</response>
        IActionResult UsersCurrentGetAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    public class CurrentUserService : ServiceBase, ICurrentUserService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, DbAppContext context, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Removes a specific user favourite</remarks>
        /// <param name="id">id of Favourite to delete</param>
        /// <response code="200">OK</response>
        public virtual IActionResult UsersCurrentFavouritesIdDeletePostAsync(int id)
        {
            // get the current user id
            int? user_id = GetCurrentUserId();
            if (user_id != null)
            {
                bool exists = _context.UserFavourites.Where(x => x.User.Id == user_id)
                    .Any(a => a.Id == id);
                if (exists)
                {
                    var item = _context.UserFavourites.First(a => a.Id == id);

                    _context.UserFavourites.Remove(item);
                    // Save the changes
                    _context.SaveChanges();
                    return new ObjectResult(item);
                }
                else
                {
                    // record not found
                    return new StatusCodeResult(404);
                }
            }
            else
            {
                return new StatusCodeResult(403);
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create new favourite for the current user</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        public virtual IActionResult UsersCurrentFavouritesPostAsync(UserFavourite item)
        {
            item.User = null;
            // get the current user id
            int? id = GetCurrentUserId();
            if (id != null)
            {
                bool user_exists = _context.Users.Any(a => a.Id == id);
                if (user_exists)
                {
                    User user = _context.Users.First(a => a.Id == id);
                    item.User = user;
                }
            }

            bool exists = _context.UserFavourites.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.UserFavourites.Update(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                // record not found. add the record.
                _context.UserFavourites.Add(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a favourite</remarks>
        /// <param name="item"></param>
        /// <response code="201">UserFavourite created</response>
        public virtual IActionResult UsersCurrentFavouritesPutAsync(UserFavourite item)
        {
            item.User = null;
            // get the current user id
            int? id = GetCurrentUserId();
            if (id != null)
            {
                bool user_exists = _context.Users.Any(a => a.Id == id);
                if (user_exists)
                {
                    User user = _context.Users.First(a => a.Id == id);
                    item.User = user;
                }
            }

            bool exists = _context.UserFavourites.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.UserFavourites.Update(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user&#39;s favourites of a given type.  If type is empty, returns all.</remarks>
        /// <param name="type">type of favourite to return</param>
        /// <response code="200">OK</response>
        /// <response code="404">User not found</response>
        public virtual IActionResult UsersCurrentFavouritesTypeGetAsync(string type)
        {
            // get the current user id
            int? id = GetCurrentUserId();

            if (id != null)
            {
                var data = _context.UserFavourites
                    .Where(x => x.User.Id == id)
                    .Select(x => x);
                if (type != null)
                {
                    data = data.Where(x => x.Type == type);
                }

                return new ObjectResult(data.ToList());
            }
            else
            {
                // no user context.
                return new StatusCodeResult(403);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Get the currently logged in user</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult UsersCurrentGetAsync()
        {
            // get the current user id
            int? id = GetCurrentUserId();

            if (id != null)
            {
                User currentUser = _context.Users
                                        .AsNoTracking()
                                        .Include(x => x.District)
                                        .Include(x => x.UserRoles)
                                            .ThenInclude(y => y.Role)
                                                .ThenInclude(z => z.RolePermissions)
                                                    .ThenInclude(z => z.Permission)
                                        .First(x => x.Id == id);

                var result = Mapper.Map<CurrentUserViewModel>(currentUser);

                // get the name for the current logged in user
                result.GivenName = User.FindFirst(ClaimTypes.GivenName).Value;
                result.Surname = User.FindFirst(ClaimTypes.Surname).Value;

                DateTime today = DateTime.UtcNow.Date;
                DateTime dateTo = today.AddDays(31).AddSeconds(-1);

                int overdue = _context.SchoolBuss
                    .Count(x => x.Inspector.Id == id && x.NextInspectionDate < today && x.Status.ToLower() == "active");

                int within30days = _context.SchoolBuss
                    .Count(x => x.Inspector.Id == id && x.NextInspectionDate >= today && x.NextInspectionDate <= dateTo && x.Status.ToLower() == "active");

                int scheduledInspections = _context.SchoolBuss
                    .Count(x => x.Inspector.Id == id && x.NextInspectionDate >= today && x.Status.ToLower() == "active");

                int reInspections = _context.SchoolBuss
                    .Count(x => x.Inspector.Id == id && x.NextInspectionTypeCode.ToLower() == "re-inspection" && x.Status.ToLower() == "active");

                result.OverdueInspections = overdue;
                result.DueWithin30DaysInspections = within30days;
                result.ScheduledInspections = scheduledInspections;
                result.ReInspections = reInspections;

                result.Permissions =
                    currentUser
                    .UserRoles
                    .Where(ur => (ur.EffectiveDate == DateTime.MinValue || ur.EffectiveDate <= DateTime.Now) && (!ur.ExpiryDate.HasValue || ur.ExpiryDate == DateTime.MinValue || ur.ExpiryDate > DateTime.Now))
                    .Select(ur => ur.Role)
                    .Where(r => !r.ExpiryDate.HasValue || r.ExpiryDate == DateTime.MinValue || r.ExpiryDate > DateTime.Now) //active roles
                    .SelectMany(r => r.RolePermissions.Select(rp => rp.Permission))
                    .Where(p => !p.ExpiryDate.HasValue || p.ExpiryDate == DateTime.MinValue || p.ExpiryDate > DateTime.Now) //active permissions
                    .ToLookup(p => p.Code)
                    .Select(p => p.First())
                    .Select(p => p.Code)
                    .ToList();

                result.IsSystemAdmin = currentUser.UserRoles.Any(x => x.Role.Name == Roles.SystemAdmininstrator 
                        && (x.EffectiveDate == DateTime.MinValue || x.EffectiveDate <= DateTime.Now) && (!x.ExpiryDate.HasValue || x.ExpiryDate == DateTime.MinValue || x.ExpiryDate > DateTime.Now));
                
                result.IsInspector = currentUser.UserRoles.Any(x => x.Role.Name == Roles.Inspector
                        && (x.EffectiveDate == DateTime.MinValue || x.EffectiveDate <= DateTime.Now) && (!x.ExpiryDate.HasValue || x.ExpiryDate == DateTime.MinValue || x.ExpiryDate > DateTime.Now));

                result.IsManager = currentUser.UserRoles.Any(x => x.Role.Name == Roles.Manager
                        && (x.EffectiveDate == DateTime.MinValue || x.EffectiveDate <= DateTime.Now) && (!x.ExpiryDate.HasValue || x.ExpiryDate == DateTime.MinValue || x.ExpiryDate > DateTime.Now));

                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404); // no current user ID
            }
        }
    }
}
