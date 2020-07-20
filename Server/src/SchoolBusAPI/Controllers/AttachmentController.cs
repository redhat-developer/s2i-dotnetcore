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
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;
using SchoolBusAPI.Authorization;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public AttachmentController(IAttachmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Attachment created</response>
        [HttpPost]
        [Route("/api/attachments/bulk")]
        ////[SwaggerOperation("AttachmentsBulkPost")]
        [RequiresPermission(Permission.ADMIN)]
        public virtual IActionResult AttachmentsBulkPost([FromBody]Attachment[] items)
        {
            return this._service.AttachmentsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/attachments")]
        ////[SwaggerOperation("AttachmentsGet")]
        ////[SwaggerResponse(200, type: typeof(List<Attachment>))]
        public virtual IActionResult AttachmentsGet()
        {
            return this._service.AttachmentsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Attachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>
        [HttpPost]
        [Route("/api/attachments/{id}/delete")]
        ////[SwaggerOperation("AttachmentsIdDeletePost")]
        public virtual IActionResult AttachmentsIdDeletePost([FromRoute]int id)
        {
            return this._service.AttachmentsIdDeletePostAsync(id);
        }

        /// <summary>
        /// Returns the binary file component of an attachment
        /// </summary>
        /// <param name="id">Attachment Id</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found in CCW system</response>
        [HttpGet]
        [Route("/api/attachments/{id}/download")]
        //[SwaggerOperation("AttachmentsIdDownloadGet")]
        public virtual IActionResult AttachmentsIdDownloadGet([FromRoute]int id)
        {
            return this._service.AttachmentsIdDownloadGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Attachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>
        [HttpGet]
        [Route("/api/attachments/{id}")]
        //[SwaggerOperation("AttachmentsIdGet")]
        //[SwaggerResponse(200, type: typeof(Attachment))]
        public virtual IActionResult AttachmentsIdGet([FromRoute]int id)
        {
            return this._service.AttachmentsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Attachment to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Attachment not found</response>
        [HttpPut]
        [Route("/api/attachments/{id}")]
        //[SwaggerOperation("AttachmentsIdPut")]
        //[SwaggerResponse(200, type: typeof(Attachment))]
        public virtual IActionResult AttachmentsIdPut([FromRoute]int id, [FromBody]Attachment item)
        {
            return this._service.AttachmentsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Attachment created</response>
        [HttpPost]
        [Route("/api/attachments")]
        //[SwaggerOperation("AttachmentsPost")]
        //[SwaggerResponse(200, type: typeof(Attachment))]
        public virtual IActionResult AttachmentsPost([FromBody]Attachment item)
        {
            return this._service.AttachmentsPostAsync(item);
        }
    }
}
