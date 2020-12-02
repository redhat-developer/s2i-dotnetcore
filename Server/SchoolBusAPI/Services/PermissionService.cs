/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Permission created</response>
        IActionResult PermissionsBulkPostAsync(Permission[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult PermissionsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Permission to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        IActionResult PermissionsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Permission to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        IActionResult PermissionsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Permission to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        IActionResult PermissionsIdPutAsync(int id, PermissionViewModel item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Permission created</response>
        IActionResult PermissionsPostAsync(PermissionViewModel item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class PermissionService : ServiceBase, IPermissionService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public PermissionService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Permissions created</response>
        public virtual IActionResult PermissionsBulkPostAsync(Permission[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Permission item in items)
            {
                var exists = _context.Permissions.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Permissions.Update(item);
                }
                else
                {
                    _context.Permissions.Add(item);
                }
            }

            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a collection of active permissions</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult PermissionsGetAsync()
        {
            var permissions = _context.Permissions
                .AsNoTracking()
                .Where(p => !p.ExpiryDate.HasValue || p.ExpiryDate == DateTime.MinValue || p.ExpiryDate > DateTime.Now);

            return new ObjectResult(Mapper.Map<List<PermissionViewModel>>(permissions));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Permission to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        public virtual IActionResult PermissionsIdDeletePostAsync(int id)
        {
            var permission = _context.Permissions.FirstOrDefault(x => x.Id == id);
            if (permission == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            permission.ExpiryDate = DateTime.Today;

            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<PermissionViewModel>(permission));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a permission</remarks>
        /// <param name="id">id of Permission to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        public virtual IActionResult PermissionsIdGetAsync(int id)
        {
            var permission = _context.Permissions.FirstOrDefault(x => x.Id == id);

            if (permission == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            return new ObjectResult(Mapper.Map<PermissionViewModel>(permission));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Permission to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Permission not found</response>
        public virtual IActionResult PermissionsIdPutAsync(int id, PermissionViewModel item)
        {
            var permission = _context.Permissions.FirstOrDefault(x => x.Id == id);
            if (permission == null)
            {
                // Not Found
                return new StatusCodeResult(404);
            }

            Mapper.Map(item, permission);

            // Save changes
            _context.Permissions.Update(permission);
            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<PermissionViewModel>(permission));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Permission created</response>
        public virtual IActionResult PermissionsPostAsync(PermissionViewModel item)
        {
            if (item == null)
            {
                // Not Found
                return new StatusCodeResult(400);
            }
            var permission = new Permission();

            Mapper.Map(item, permission);

            // Save changes
            _context.Permissions.Add(permission);
            _context.SaveChanges();

            return new ObjectResult(Mapper.Map<PermissionViewModel>(permission));
        }
    }
}
