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
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISchoolBusOwnerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwner created</response>
        IActionResult SchoolbusownersBulkPostAsync(SchoolBusOwner[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdAttachmentsGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        IActionResult SchoolbusownersIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        IActionResult SchoolbusownersIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch History for</param>
        /// <param name="offset">offset for records that are returned</param>
        /// <param name="limit">limits the number of records returned.</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdHistoryGetAsync(int id, int? offset, int? limit);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Add a History record to the SchoolBus Owner</remarks>
        /// <param name="id">id of SchoolBusOwner to add History for</param>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        IActionResult SchoolbusownersIdHistoryPostAsync(int id, History item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdNotesGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        IActionResult SchoolbusownersIdPutAsync(int id, SchoolBusOwner item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns SchoolBusOwner data plus additional information required for display</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersIdViewGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwner created</response>
        IActionResult SchoolbusownersPostAsync(SchoolBusOwner item);

        /// <summary>
        /// Searches school bus owners
        /// </summary>
        /// <remarks>Used for the search school bus owners.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="inspectors">Assigned School Bus Inspectors (array of id numbers)</param>
        /// <param name="owner"></param>
        /// <param name="includeInactive">True if Inactive schoolbuses will be returned</param>
        /// <response code="200">OK</response>
        IActionResult SchoolbusownersSearchGetAsync(int?[] districts, int?[] inspectors, int? owner, bool? includeInactive);

        /// <summary>
        /// id of school bus owner for fetch contacts
        /// </summary>
        /// <param name="id">id of school bus owner to fetch contacts</param>
        /// <response code="200">OK</response>
        /// <response code="404">school bus owner not found</response>
        IActionResult SchoolbuseownersIdContactsGetAsync(int id);

        (bool valid, IActionResult error) CreateSchoolBusOwnerNote(int sbId, NoteViewModel note);
        (bool valid, IActionResult error) UpdateSchoolBusOwnerNote(int sbId, int noteId, NoteViewModel note);
    }

    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusOwnerService : ServiceBase, ISchoolBusOwnerService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        private void AdjustSchoolBusOwner(SchoolBusOwner item)
        {
            // adjust Primary Contact.
            if (item.PrimaryContact != null)
            {
                int primary_contact_id = item.PrimaryContact.Id;
                bool primary_contact_exists = _context.Contacts.Any(a => a.Id == primary_contact_id);
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
                bool district_exists = _context.ServiceAreas.Any(a => a.Id == district_id);
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

        public virtual IActionResult SchoolbusownersBulkPostAsync(SchoolBusOwner[] items)
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

        public virtual IActionResult SchoolbusownersGetAsync()
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

        public virtual IActionResult SchoolbusownersIdAttachmentsGetAsync(int id)
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners
                    .Include(x => x.Attachments)
                    .First(a => a.Id == id);
                
                //var result = MappingExtensions.GetAttachmentListAsViewModel(schoolBusOwner.Attachments);
                var result = Mapper.Map<List<AttachmentViewModel>>(schoolBusOwner.Attachments);

                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        public virtual IActionResult SchoolbusownersIdDeletePostAsync(int id)
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

        public virtual IActionResult SchoolbusownersIdGetAsync(int id)
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
        /// Returns History for a particular SchoolBusOwner
        /// </summary>
        /// <param name="id"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public virtual IActionResult SchoolbusownersIdHistoryGetAsync(int id, int? offset, int? limit)
        {
            bool exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners
                    .Include(x => x.History)
                    .First(a => a.Id == id);

                List<History> data = schoolBusOwner.History.OrderByDescending(y => y.LastUpdateTimestamp).ToList();

                if (offset == null)
                {
                    offset = 0;
                }
                if (limit == null)
                {
                    limit = data.Count() - offset;
                }
                List<HistoryViewModel> result = new List<HistoryViewModel>();

                for (int i = (int)offset; i < data.Count() && i < offset + limit; i++)
                {
                    var viewModel = Mapper.Map<HistoryViewModel>(data[i]);
                    viewModel.AffectedEntityId = id;
                    result.Add(viewModel);
                }

                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }

        }

        public virtual IActionResult SchoolbusownersIdHistoryPostAsync(int id, History item)
        {
            HistoryViewModel result = new HistoryViewModel();

            bool exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners
                    .Include(x => x.History)
                    .First(a => a.Id == id);
                if (schoolBusOwner.History == null)
                {
                    schoolBusOwner.History = new List<History>();
                }
                // force add
                item.Id = 0;
                schoolBusOwner.History.Add(item);

                _context.SchoolBusOwners.Update(schoolBusOwner);
                _context.SaveChanges();
            }

            result.HistoryText = item.HistoryText;
            result.Id = item.Id;
            result.LastUpdateTimestamp = item.LastUpdateTimestamp;
            result.LastUpdateUserid = item.LastUpdateUserid;
            result.AffectedEntityId = id;

            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdNotesGetAsync(int id)
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
        /// <param name="body">object of modified SchoolBusOwner</param>>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>

        public virtual IActionResult SchoolbusownersIdPutAsync(int id, SchoolBusOwner body)
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
        private DateTime? GetNextInspectionDate(int schoolBusOwnerId)
        {
            DateTime? result = null;

            // next inspection is drawn from the schoolbus table
            bool exists = _context.SchoolBuss.Any(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null && x.Status.ToLower() == "active");
            if (exists)
            {
                SchoolBus schoolbus = _context.SchoolBuss.Where(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null && x.Status.ToLower() == "active")
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
                result = _context.SchoolBuss.Where(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.Status.ToLower() == "active")
                    .Count();

            }
            return result;
        }

        private string GetNextInspectionTypeCode(int schoolBusOwnerId)
        {
            string result = null;

            // next inspection is drawn from the inspections table.
            bool exists = _context.SchoolBuss.Any(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null && x.Status.ToLower() == "active");
            if (exists)
            {
                var record = _context.SchoolBuss
                    .Where(x => x.SchoolBusOwner.Id == schoolBusOwnerId && x.NextInspectionDate != null && x.Status.ToLower() == "active")
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
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners.Include(x => x.PrimaryContact).First(a => a.Id == id);
                SchoolBusOwnerViewModel result = Mapper.Map<SchoolBusOwnerViewModel>(schoolBusOwner);

                // populate the calculated fields.
                result.NextInspectionDate = GetNextInspectionDate(id);
                result.NumberOfBuses = GetNumberSchoolBuses(id);
                result.NextInspectionTypeCode = GetNextInspectionTypeCode(id);

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

        public virtual IActionResult SchoolbusownersPostAsync(SchoolBusOwner body)
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

            var result = new List<SchoolBusOwnerViewModel>();

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

                if (ids.Count == 0)
                {
                    return new ObjectResult(result);
                }

                data = data.Where(x => ids.Contains(x.Id));

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
                            .Include(x => x.SchoolBusOwner)
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

                if (ids.Count == 0)
                {
                    return new ObjectResult(result);
                }

                data = data.Where(x => ids.Contains(x.Id));
            }



            if (owner != null)
            {
                data = data.Where(x => x.Id == owner);
            }


            if (includeInactive == null || includeInactive == false)
            {
                data = data.Where(x => x.Status == "Active");
            }

            result = Mapper.Map<List<SchoolBusOwnerViewModel>>(data);

            // second pass to get the calculated fields
            foreach (SchoolBusOwnerViewModel item in result)
            {
                // populate the calculated fields.
                item.NextInspectionDate = GetNextInspectionDate(item.Id); ;
                item.NumberOfBuses = GetNumberSchoolBuses(item.Id);
                item.NextInspectionTypeCode = GetNextInspectionTypeCode(item.Id);
            }
            return new ObjectResult(result);
        }

        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>

        public virtual IActionResult SchoolbuseownersIdContactsGetAsync(int id)
        {
            bool exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var items = _context.Contacts
                    .Include(x => x.SchoolBusOwner)
                    .Where(a => a.SchoolBusOwner.Id == id);
                return new ObjectResult(items);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        public (bool valid, IActionResult error) CreateSchoolBusOwnerNote(int ownerId, NoteViewModel note)
        {
            var ownerEntity = _context.SchoolBusOwners
                .Include(x => x.Notes)
                .FirstOrDefault(x => x.Id == ownerId);

            if (ownerEntity == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 601, $"The school bus owner [{ownerId}] does not exist.")));
            }

            if (note.NoteText.Length > 2048)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 605, $"The note text must have less than 2,048 characters.")));
            }

            note.SchoolBusId = null;

            ownerEntity.Notes.Add(Mapper.Map<Note>(note));

            _context.SaveChanges();

            return (true, null);
        }

        public (bool valid, IActionResult error) UpdateSchoolBusOwnerNote(int ownerId, int noteId, NoteViewModel note)
        {
            var ownerEntity = _context.SchoolBusOwners
                .Include(x => x.Notes)
                .FirstOrDefault(x => x.Id == ownerId);

            if (ownerEntity == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 601, $"The school bus owner [{ownerId}] does not exist.")));
            }

            var noteEntity = ownerEntity.Notes.FirstOrDefault(x => x.Id == noteId);

            if (noteEntity == null)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 602, $"The note [{noteId}] does not exist.")));
            }

            if (note.Id != noteId)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 603, $"The note ID [{noteId}] does not match the note ID [{note.Id}] of the content.")));
            }

            if (note.SchoolBusOwnerId == null || note.SchoolBusOwnerId != ownerId)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 604, $"The school bus owner ID [{ownerId}] does not match the school bus owner ID [{note.SchoolBusOwnerId}] of the content.")));
            }

            if (note.NoteText.Length > 2048)
            {
                return (false, new UnprocessableEntityObjectResult(new Error("Validation Error", 605, $"The note text must have less than 2,048 characters.")));
            }

            note.SchoolBusId = null;

            Mapper.Map(note, noteEntity);

            _context.SaveChanges();

            return (true, null);
        }
    }
}
