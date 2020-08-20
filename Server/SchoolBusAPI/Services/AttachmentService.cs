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
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services
{
    public interface IAttachmentService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Attachment created</response>
        IActionResult AttachmentsBulkPostAsync(Attachment[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        IActionResult AttachmentsGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Attachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>
        IActionResult AttachmentsIdDeletePostAsync(int id);

        /// <summary>
        /// Returns the binary file component of an attachment
        /// </summary>
        /// <param name="id">Attachment Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found in CCW system</response>
        IActionResult AttachmentsIdDownloadGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Attachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>
        IActionResult AttachmentsIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Attachment to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>
        IActionResult AttachmentsIdPutAsync(int id, Attachment item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Attachment created</response>
        IActionResult AttachmentsPostAsync(Attachment item);
    }

    public class AttachmentService : ServiceBase, IAttachmentService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public AttachmentService(DbAppContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor, context, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="items"></param>
        /// <response code="201">Attachments created</response>

        public virtual IActionResult AttachmentsBulkPostAsync(Attachment[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (Attachment item in items)
            {
                _context.Attachments.Add(item);
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>

        /// <response code="200">OK</response>

        public virtual IActionResult AttachmentsGetAsync()
        {
            var result = _context.Attachments.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Attachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>

        public virtual IActionResult AttachmentsIdDeletePostAsync(int id)
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Attachments.First(a => a.Id == id);
                _context.Attachments.Remove(item);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(item);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// Returns the binary file component of an attachment
        /// </summary>
        /// <param name="id">Attachment Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found in system</response>
        public virtual IActionResult AttachmentsIdDownloadGetAsync(int id)
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists)
            {
                var attachment = _context.Attachments.First(a => a.Id == id);
                // 
                // MOTI has requested that files be stored in the database.
                //                                           
                var result = new FileContentResult(attachment.FileContents, "application/octet-stream");
                result.FileDownloadName = attachment.FileName;

                return result;
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Attachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>

        public virtual IActionResult AttachmentsIdGetAsync(int id)
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Attachments.First(a => a.Id == id);
                return new ObjectResult(result);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="id">id of Attachment</param>
        /// <param name="body">body of Attachment</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>

        public virtual IActionResult AttachmentsIdPutAsync(int id, Attachment body)
        {
            var exists = _context.Attachments.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Attachments.Update(body);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(body);
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
        /// <summary>
        /// 
        /// </summary>

        /// <param name="body"></param>
        /// <response code="201">Attachment created</response>

        public virtual IActionResult AttachmentsPostAsync(Attachment body)
        {
            _context.Attachments.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
