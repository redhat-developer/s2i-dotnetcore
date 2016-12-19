using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBusAPI.Services.Impl
{
    public class OwnerApiService : IOwnerApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public OwnerApiService (DbAppContext context)
        {
            _context = context;
        }

        public virtual IActionResult FavouritecontexttypesGetAsync()
        {
            return new ObjectResult("");
        }


        public virtual IActionResult OwnersIdAttachmentsGetAsync(int id)
        {
            var result = _context.OwnerAttachmentss.All(a => a.Owner.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult OwnersIdContactaddressesGetAsync(int id)
        {
            var result = _context.OwnerContactAddresss.All(a => a.OwnerContact.Owner.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult OwnersIdContactphonesGetAsync(int id)
        {
            var result = _context.OwnerContactPhones.All(a => a.OwnerContact.Owner.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult OwnersIdGetAsync(int id)
        {
            var result = _context.Owners.First(a => a.Id == id);
            return new ObjectResult(result);
        }

        public virtual IActionResult OwnersIdNotesGetAsync(int id)
        {
            var result = _context.OwnerNotess.All(a => a.Owner.Id == id);
            return new ObjectResult(result);
        }
    }
}
