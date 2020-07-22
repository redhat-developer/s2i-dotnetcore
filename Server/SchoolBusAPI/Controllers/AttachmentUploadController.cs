using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Mappings;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    public class AttachmentUploadController : ControllerBase
    {
        private readonly IAttachmentUploadService _service;
        public AttachmentUploadController(IAttachmentUploadService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/api/schoolbuses/{id}/attachments")]
        public virtual IActionResult SchoolbusesIdAttachmentsPost([FromRoute] int Id, [FromForm] IList<IFormFile> files)
        {
            return _service.SchoolbusesIdAttachmentsPostAsync(Id, files);
        }

        [HttpGet]
        [Route("/api/schoolbuses/{id}/attachmentsForm")]
        [Produces("text/html")]
        public virtual IActionResult SchoolbusesIdAttachmentsFormGet([FromRoute] int Id)
        {
            return new ObjectResult("<html><body><form method=\"post\" action=\"/api/schoolbuses/"+Id+"/attachments\" enctype=\"multipart/form-data\"><input type=\"file\" name = \"files\" multiple /><input type = \"submit\" value = \"Upload\" /></body></html>");
        }

        [HttpPost]
        [Route("/api/schoolbusowners/{id}/attachments")]
        public virtual IActionResult SchoolbusownersIdAttachmentsPost([FromRoute] int Id, [FromForm] IList<IFormFile> files)
        {
            return _service.SchoolbusownersIdAttachmentsPostAsync(Id, files);
        }
    }

    public interface IAttachmentUploadService
    {
        IActionResult SchoolbusesIdAttachmentsPostAsync(int Id, IList<IFormFile> files);

        IActionResult SchoolbusownersIdAttachmentsPostAsync(int Id, IList<IFormFile> files);        
    }

    public class AttachmentUploadService : ServiceBase, IAttachmentUploadService
    {
        private readonly IConfiguration Configuration;
        private readonly DbAppContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        public AttachmentUploadService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, DbAppContext context) : base(httpContextAccessor, context)
        {
            Configuration = configuration;
            _context = context;
        }


        /// <summary>
        /// Utility function used by the various attachment upload functions
        /// </summary>
        /// <param name="attachments">A list of attachments to add to</param>
        /// <param name="files">The files to add to the attachments</param>
        private void AddFilesToAttachments( List<Attachment> attachments, IList<IFormFile> files)
        {
            if (attachments == null)
            {
                attachments = new List<Attachment>();
            }
            //
            // MOTI has requested that files be stored in the database.
            //                                         
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    Attachment attachment = new Attachment();
                    // strip out extra info in the file name.                        
                    if (file.FileName != null && file.FileName.Length > 0)
                    {
                        attachment.FileName = Path.GetFileName(file.FileName);
                    }

                    // allocate storage for the file and create a memory stream
                    attachment.FileContents = new byte[file.Length];                   
                    MemoryStream fileStream = new MemoryStream(attachment.FileContents);
                    file.CopyTo(fileStream);
                    _context.Attachments.Add(attachment);
                    attachments.Add(attachment);
                }
            }
        }
        

        /// <summary>
        ///  Basic file receiver for .NET Core
        /// </summary>
        /// <param name="id">Schoolbus Id</param>
        /// <param name="files">Files to add to attachments</param>
        /// <returns></returns>
        public IActionResult SchoolbusesIdAttachmentsPostAsync(int id, IList<IFormFile> files)
        {
            // validate the bus id            
            bool exists = _context.SchoolBuss.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBus schoolbus = _context.SchoolBuss
                    .Include(x => x.Attachments)
                    .Include(x => x.HomeTerminalCity)
                    .Include(x => x.SchoolDistrict)
                    .Include(x => x.SchoolBusOwner.PrimaryContact)
                    .Include(x => x.District.Region)
                    .Include(x => x.Inspector)
                    .Include(x => x.CCWData)                
                    .First(a => a.Id == id);

                AddFilesToAttachments(schoolbus.Attachments, files);

                _context.SchoolBuss.Update(schoolbus);
                _context.SaveChanges();

                List<AttachmentViewModel> result = MappingExtensions.GetAttachmentListAsViewModel(schoolbus.Attachments);

                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }


        /// <summary>
        ///  Basic file receiver for .NET Core
        /// </summary>
        /// <param name="id">SchoolBus Owner Id</param>
        /// <param name="files">Files to add to attachments</param>
        /// <returns></returns>
        public IActionResult SchoolbusownersIdAttachmentsPostAsync(int id, IList<IFormFile> files)
        {
            // validate the bus id            
            bool exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                SchoolBusOwner schoolBusOwner = _context.SchoolBusOwners
                    .Include(x => x.Attachments)
                    .Include(x => x.Contacts)
                    .Include(x => x.District.Region)
                    .Include(x => x.History)
                    .Include(x => x.Notes)
                    .Include(x => x.PrimaryContact)
                    .First(a => a.Id == id);

                AddFilesToAttachments(schoolBusOwner.Attachments, files);

                _context.SchoolBusOwners.Update(schoolBusOwner);
                _context.SaveChanges();

                List<AttachmentViewModel> result = MappingExtensions.GetAttachmentListAsViewModel(schoolBusOwner.Attachments);

                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }
    }
}
