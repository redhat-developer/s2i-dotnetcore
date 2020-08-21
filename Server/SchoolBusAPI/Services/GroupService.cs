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
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Mappings;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Group created</response>
        IActionResult GroupsBulkPostAsync(Group[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult GroupsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        IActionResult GroupsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        IActionResult GroupsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        IActionResult GroupsIdPutAsync(int id, Group item);

        /// <summary>
        /// returns users in a given Group
        /// </summary>
        /// <remarks>Used to get users in a given Group</remarks>
        /// <param name="id">id of Group to fetch Users for</param>
        /// <response code="200">OK</response>
        IActionResult GroupsIdUsersGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Group created</response>
        IActionResult GroupsPostAsync(Group item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class GroupService : ServiceBase, IGroupService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public GroupService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// returns users in a given Group
        /// </summary>
        /// <remarks>Used to get users in a given Group</remarks>
        /// <param name="id">id of Group to fetch Users for</param>
        /// <response code="200">OK</response>
        public IActionResult GroupsIdUsersGetAsync(int id)
        {
            bool exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var data = _context.GroupMemberships
                    .Include("User")
                    .Include("Group")
                    .Where(x => x.Group.Id == id);

                var result = Mapper.Map<List<GroupMembershipViewModel>>(data);

                return new ObjectResult(result);
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
        /// <param name="items"></param>
        /// <response code="201">Groups created</response>
        public IActionResult GroupsBulkPostAsync(Group[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Group item in items)
            {

                bool exists = _context.Groups.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Groups.Update(item);
                }
                else
                {
                    _context.Groups.Add(item);
                }
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of groups</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult GroupsGetAsync()
        {
            var result = Mapper.Map<List<GroupViewModel>>(_context.Groups);

            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Group to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdDeletePostAsync(int id)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Groups.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Groups.Remove(item);
                    // Save the changes
                    _context.SaveChanges();
                }
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
        /// <remarks>Returns a Group</remarks>
        /// <param name="id">id of Group to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdGetAsync(int id)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Groups.First(a => a.Id == id);
                return new ObjectResult(result);
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
        /// <param name="id">id of Group to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Group not found</response>
        public IActionResult GroupsIdPutAsync(int id, Group item)
        {
            var exists = _context.Groups.Any(a => a.Id == id);
            if (exists && id == item.Id)
            {
                _context.Groups.Update(item);
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
        /// <param name="item"></param>
        /// <response code="201">Group created</response>
        public IActionResult GroupsPostAsync(Group item)
        {
            var exists = _context.Groups.Any(a => a.Id == item.Id);
            if (exists)
            {
                _context.Groups.Update(item);
            }
            else
            {
                // record not found
                _context.Groups.Add(item);
            }

            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}
