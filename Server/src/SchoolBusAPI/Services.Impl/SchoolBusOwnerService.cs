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
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Mappings;
using Microsoft.EntityFrameworkCore;

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
	
        private void AdjustSchoolBusOwner (SchoolBusOwner item)
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

        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwners created</response>

        public virtual IActionResult SchoolbusownersBulkPostAsync (SchoolBusOwner[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwner item in items)
            {
                AdjustSchoolBusOwner(item);

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
            var result = _context.SchoolBusOwners
                .Include(x => x.Attachments)
                .Include(x => x.Contacts)
                .Include(x => x.District.Region)
                .Include(x => x.History)
                .Include(x => x.Notes)
                .Include(x => x.PrimaryContact)
                .ToList();
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
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners
                    .Include(x => x.Attachments)                    
                    .First(a => a.Id == id);
                var result = MappingExtensions.GetAttachmentListAsViewModel(schoolBusOwner.Attachments);
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
        
        

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
                var result = _context.SchoolBusOwners
                    .Include(x => x.Attachments)
                    .Include(x => x.Contacts)
                    .Include(x => x.District.Region)
                    .Include(x => x.History)
                    .Include(x => x.Notes)
                    .Include(x => x.PrimaryContact)                    
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
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdNotesGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners
                    .Include(x => x.Notes)
                    .First(a => a.Id == id);
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
            AdjustSchoolBusOwner(body);

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
        /// Utility function used by the owner view service
        /// </summary>
        /// <param name="schoolBusOwnerId">Owner for which to lookup inspections</param>
        /// <returns>Date of next inspection, or null if there is none</returns>
        private DateTime? GetNextInspectionDate (int schoolBusOwnerId)
        {
            DateTime? result = null;

            // next inspection is drawn from the schoolbus table
            bool exists = _context.SchoolBuss.Any(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null);
            if (exists)
            {
                SchoolBus schoolbus = _context.SchoolBuss.Where(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null)
                    .OrderByDescending(x => x.NextInspectionDate)
                    .First();
                result = schoolbus.NextInspectionDate;
            }
            return result;
        }

        /// <summary>
        /// Utility function used by the owner view service
        /// </summary>
        /// <param name="schoolBusOwnerId">Owner for which to lookup school buses</param>
        /// <returns>Number of associated school buses</returns>
        private int GetNumberSchoolBuses(int schoolBusOwnerId)
        {
            int result = 0;

            // next inspection is drawn from the inspections table.
            bool exists = _context.SchoolBuss.Any(x => x.SchoolBusOwner.Id == schoolBusOwnerId);
            if (exists)
            {
                result = _context.SchoolBuss.Where(x => x.SchoolBusOwner.Id == schoolBusOwnerId)
                    .Count();
                
            }
            return result;
        }

        private string GetNextInspectionTypeCode(int schoolBusOwnerId)
        {
            string result = null;

            // next inspection is drawn from the inspections table.
            bool exists = _context.SchoolBuss.Any(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null);
            if (exists)
            {
                var record = _context.SchoolBuss
                    .Where(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null)
                    .OrderByDescending(x => x.NextInspectionDate)
                    .First();
                result = record.NextInspectionTypeCode;                
            }
            return result;
        }

        /// <summary>
        /// View service used by the view school bus owner page
        /// </summary>
        /// <param name="id">SchoolBusOwner Id</param>
        /// <returns>A SchoolBusOwnerViewModel, or 404 if the record does not exist</returns>
        public IActionResult SchoolbusownersIdViewGetAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners.First(a => a.Id == id);
                var result = schoolBusOwner.ToViewModel();
                // populate the calculated fields.
                result.nextInspectionDate = GetNextInspectionDate(id); ;
                result.numberOfBuses = GetNumberSchoolBuses(id);
                result.nextInspectionTypeCode = GetNextInspectionTypeCode(id);
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

        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwner created</response>

        public virtual IActionResult SchoolbusownersPostAsync (SchoolBusOwner body)        
        {
            AdjustSchoolBusOwner(body);
            body.DateCreated = DateTime.UtcNow;
            _context.SchoolBusOwners.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }

        /// <summary>
        /// Searches school bus owners
        /// </summary>
        /// <remarks>Used for the search school bus owners.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="inspectors">Assigned School Bus Inspectors (array of id numbers)</param>
        /// <param name="owner"></param>
        /// <param name="includeInactive">True if Inactive schoolbuses will be returned</param>
        /// <response code="200">OK</response>
        public virtual IActionResult SchoolbusownersSearchGetAsync(int?[] districts, int?[] inspectors, int? owner, bool? includeInactive)
        {
            // Eager loading of related data
            var data = _context.SchoolBusOwners
                .Include(x => x.Attachments)
                .Include(x => x.Contacts)
                .Include(x => x.District.Region)
                .Include(x => x.History)
                .Include(x => x.Notes)
                .Include(x => x.PrimaryContact)
                .Select(x => x);           

            // Note that Districts searches SchoolBus Districts, not SchoolBusOwner Districts
            if (districts != null)
            {
                List<int> ids = new List<int>();

                // get the owner ids for matching records.                
                foreach (int? district in districts)
                {
                    if (district != null)
                    {
                        var buses = _context.SchoolBuss
                            .Include(x => x.District)
                            .Include(x => x.SchoolBusOwner)
                            .Where(x => x.District.Id == district);
                        foreach (var bus in buses)
                        {
                            if (bus.SchoolBusOwner != null)
                            {
                                ids.Add(bus.SchoolBusOwner.Id);
                            }
                        }
                        
                    }
                }

                if (ids.Count > 0)
                {
                    data = data.Where(x => ids.Contains(x.Id));
                }

            }
            

            if (inspectors != null)
            {
                List<int> ids = new List<int>();

                // get the owner ids for matching records.                
                foreach (int? inspector in inspectors)
                {
                    if (inspector != null)
                    {
                        var buses = _context.SchoolBuss
                            .Include(x => x.Inspector)
                            .Include( x => x.SchoolBusOwner)
                            .Where(x => x.Inspector.Id == inspector);
                        foreach (var bus in buses)
                        {
                            if (bus.SchoolBusOwner != null)
                            {
                                ids.Add(bus.SchoolBusOwner.Id);
                            }
                        }
                        
                    }
                }

                if (ids.Count > 0)
                {
                    data = data.Where(x => ids.Contains(x.Id));
                }

            }



            if (owner != null)
            {
                data = data.Where(x => x.Id == owner);
            }


            if (includeInactive == null || includeInactive == false)
            {
                data = data.Where(x => x.Status == "Active");
            }

            // now convert the results to the view model.
            var result = new List<SchoolBusOwnerViewModel>();
            foreach (SchoolBusOwner item in data)
            {
                SchoolBusOwnerViewModel record = item.ToViewModel();                
                result.Add(record);                
            }
            // second pass to get the calculated fields
            foreach (SchoolBusOwnerViewModel item in result)
            {                
                // populate the calculated fields.
                item.nextInspectionDate = GetNextInspectionDate(item.Id); ;
                item.numberOfBuses = GetNumberSchoolBuses(item.Id);
                item.nextInspectionTypeCode = GetNextInspectionTypeCode(item.Id);              
            }
            return new ObjectResult(result);
        }
    }
}
