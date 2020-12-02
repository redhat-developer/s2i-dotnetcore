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
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult ContactsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Contact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>
        IActionResult ContactsIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Contact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>
        IActionResult ContactsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Contact to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>
        IActionResult ContactsIdPutAsync(int id, Contact item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Contact created</response>
        IActionResult ContactsPostAsync(Contact item);
    }

    /// <summary>
    /// 
    /// </summary>
    public class ContactService : ServiceBase, IContactService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public ContactService(IHttpContextAccessor httpContextAccessor, DbAppContext context, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Contact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>

        public virtual IActionResult ContactsIdDeletePostAsync(int id)
        {
            var exists = _context.Contacts.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Contacts.Include(x => x.SchoolBusOwner).First(a => a.Id == id);
                if (item != null)
                {

                    _context.Contacts.Remove(item);
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

        /// <param name="id">id of Contact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>

        public virtual IActionResult ContactsIdGetAsync(int id)
        {
            var exists = _context.Contacts.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Contacts
                    .Include(x => x.SchoolBusOwner)
                    .First(a => a.Id == id);
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
        /// <response code="200">OK</response>
        public virtual IActionResult ContactsGetAsync()
        {
            var result = _context.Contacts
                .Include(x => x.SchoolBusOwner)
                .ToList();
            return new ObjectResult(result);
        }


        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Contact to fetch</param>
        /// <param name="body">object of contact to be updated</param>>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>

        public virtual IActionResult ContactsIdPutAsync(int id, Contact body)
        {
            //adjust the school bus owner
            if (body.SchoolBusOwner != null)
            {
                int owner_id = body.SchoolBusOwner.Id;
                bool owner_exists = _context.SchoolBusOwners.Any(a => a.Id == owner_id);
                if (owner_exists)
                {
                    SchoolBusOwner owner = _context.SchoolBusOwners.First(a => a.Id == owner_id);
                    body.SchoolBusOwner = owner;
                }
                else
                {
                    body.SchoolBusOwner = null;
                }
            }

            var exists = _context.Contacts.Any(a => a.Id == id);
            if (exists && body.Id == id)
            {
                _context.Contacts.Update(body);
                // Save the changes
                _context.SaveChanges();

                return new ObjectResult(body);
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
        /// <response code="201">contact create</response>
        public virtual IActionResult ContactsPostAsync(Contact item)
        {
            if (item != null)
            {
                //adjust schoolBusOwner
                if (item.SchoolBusOwner != null)
                {
                    int owner_id = item.SchoolBusOwner.Id;
                    bool owner_exists = _context.SchoolBusOwners.Any(a => a.Id == owner_id);
                    if (owner_exists)
                    {
                        SchoolBusOwner owner = _context.SchoolBusOwners.First(x => x.Id == owner_id);
                        item.SchoolBusOwner = owner;
                    }
                    else
                    {
                        item.SchoolBusOwner = null;
                    }
                }

                var exists = _context.Contacts.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Contacts.Update(item);
                }
                else
                {
                    _context.Contacts.Add(item);
                }

                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                //no data
                return new StatusCodeResult(404);
            }
        }
    }
}
