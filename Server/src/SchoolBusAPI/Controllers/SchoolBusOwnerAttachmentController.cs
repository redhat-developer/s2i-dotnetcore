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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SchoolBusOwnerAttachmentController : Controller
    {
        private readonly ISchoolBusOwnerAttachmentService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusOwnerAttachmentController(ISchoolBusOwnerAttachmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwnerAttachment created</response>
        [HttpPost]
        [Route("/api/schoolbusownerattachments/bulk")]
        [SwaggerOperation("SchoolbusownerattachmentsBulkPost")]
        public virtual IActionResult SchoolbusownerattachmentsBulkPost([FromBody]SchoolBusOwnerAttachment[] items)
        {
            return this._service.SchoolbusownerattachmentsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusownerattachments")]
        [SwaggerOperation("SchoolbusownerattachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusOwnerAttachment>))]
        public virtual IActionResult SchoolbusownerattachmentsGet()
        {
            return this._service.SchoolbusownerattachmentsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        [HttpPost]
        [Route("/api/schoolbusownerattachments/{id}/delete")]
        [SwaggerOperation("SchoolbusownerattachmentsIdDeletePost")]
        public virtual IActionResult SchoolbusownerattachmentsIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusownerattachmentsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        [HttpGet]
        [Route("/api/schoolbusownerattachments/{id}")]
        [SwaggerOperation("SchoolbusownerattachmentsIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerAttachment))]
        public virtual IActionResult SchoolbusownerattachmentsIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusownerattachmentsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwnerAttachment to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwnerAttachment not found</response>
        [HttpPut]
        [Route("/api/schoolbusownerattachments/{id}")]
        [SwaggerOperation("SchoolbusownerattachmentsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerAttachment))]
        public virtual IActionResult SchoolbusownerattachmentsIdPut([FromRoute]int id, [FromBody]SchoolBusOwnerAttachment item)
        {
            return this._service.SchoolbusownerattachmentsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwnerAttachment created</response>
        [HttpPost]
        [Route("/api/schoolbusownerattachments")]
        [SwaggerOperation("SchoolbusownerattachmentsPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusOwnerAttachment))]
        public virtual IActionResult SchoolbusownerattachmentsPost([FromBody]SchoolBusOwnerAttachment item)
        {
            return this._service.SchoolbusownerattachmentsPostAsync(item);
        }
    }
}
