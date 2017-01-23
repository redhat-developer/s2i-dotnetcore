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
using Newtonsoft.Json;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusOwnerService : ISchoolBusOwnerService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerService (DbAppContext context)
        {
            _context = context;
        }
	
       
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwners created</response>

        public virtual IActionResult SchoolbusownersBulkPostAsync (SchoolBusOwner[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwner item in items)
            {
                // adjust Primary Contact.
                if (item.PrimaryContact != null)
                {
                    int primary_contact_id = item.PrimaryContact.Id;
                    var primary_contact_exists = _context.Contacts.Any(a => a.Id == primary_contact_id);
                    if (primary_contact_exists)
                    {
                        Contact contact = _context.Contacts.First(a => a.Id == primary_contact_id);
                        item.PrimaryContact = contact;
                    }
                    else
                    {
                        item.PrimaryContact = null;
                    }                    
                }                

                // adjust District.
                if (item.District != null)
                {
                    int district_id = item.District.Id;
                    var district_exists = _context.ServiceAreas.Any(a => a.Id == district_id);
                    if (district_exists)
                    {
                        District district = _context.Districts.First(a => a.Id == district_id);
                        item.District = district;
                    }
                    else
                    {
                        item.District = null;
                    }
                }

                // adjust contacts
                if (item.Contacts != null)
                {
                    for (int i = 0; i < item.Contacts.Count; i++)
                    {
                        Contact contact = item.Contacts[i];
                        if (contact != null)
                        {
                            int contact_id = contact.Id;
                            bool contact_exists = _context.Contacts.Any(a => a.Id == contact_id);
                            if (contact_exists)
                            {
                                Contact new_contact = _context.Contacts.First(a => a.Id == contact_id);
                                item.Contacts[i] = new_contact;
                            }
                            else
                            {
                                item.Contacts[i] = null;
                            }
                        }
                    }
                }

                var exists = _context.SchoolBusOwners.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.SchoolBusOwners.Update(item);
                }
                else
                {
                    _context.SchoolBusOwners.Add(item);
                }               
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersGetAsync ()        
        {
            var result = _context.SchoolBusOwners.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdAttachmentsGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners.First(a => a.Id == id);
                var result = schoolBusOwner.Notes;
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
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdContactaddressesGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                List<ContactAddress> result = new List<ContactAddress>();
                var owner = _context.SchoolBusOwners.Where(a => a.Id == id).First();
                var contacts = owner.Contacts;
                foreach (Contact contact in contacts)
                {
                    // merge the lists
                    result = result.Concat ( contact.ContactAddresses).ToList();
                }
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
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdContactphonesGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                List<ContactPhone> result = new List<ContactPhone>();
                var owner = _context.SchoolBusOwners.Where(a => a.Id == id).First();
                var contacts = owner.Contacts;
                foreach (Contact contact in contacts)
                {
                    // merge the lists
                    result = result.Concat(contact.ContactPhones).ToList();
                }
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
        
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>

        public virtual IActionResult SchoolbusownersIdDeletePostAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusOwners.First(a => a.Id == id);            
                _context.SchoolBusOwners.Remove(item);
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
        /// <remarks>Returns a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwners.First(a => a.Id == id);
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
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdNotesGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners.First(a => a.Id == id);
                var result = schoolBusOwner.Notes;
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
        
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>

        public virtual IActionResult SchoolbusownersIdPutAsync (int id, SchoolBusOwner body)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.SchoolBusOwners.Update(body);
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
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwner created</response>

        public virtual IActionResult SchoolbusownersPostAsync (SchoolBusOwner body)        
        {
            _context.SchoolBusOwners.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
