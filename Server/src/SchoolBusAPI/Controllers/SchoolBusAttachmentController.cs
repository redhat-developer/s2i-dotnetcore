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
    public partial class SchoolBusAttachmentController : Controller
    {
        private readonly ISchoolBusAttachmentService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusAttachmentController(ISchoolBusAttachmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusAttachment created</response>
        [HttpPost]
        [Route("/api/schoolbusattachments/bulk")]
        [SwaggerOperation("SchoolbusattachmentsBulkPost")]
        public virtual IActionResult SchoolbusattachmentsBulkPost([FromBody]SchoolBusAttachment[] items)
        {
            return this._service.SchoolbusattachmentsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusattachments")]
        [SwaggerOperation("SchoolbusattachmentsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusAttachment>))]
        public virtual IActionResult SchoolbusattachmentsGet()
        {
            return this._service.SchoolbusattachmentsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusAttachment to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        [HttpPost]
        [Route("/api/schoolbusattachments/{id}/delete")]
        [SwaggerOperation("SchoolbusattachmentsIdDeletePost")]
        public virtual IActionResult SchoolbusattachmentsIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusattachmentsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        [HttpGet]
        [Route("/api/schoolbusattachments/{id}")]
        [SwaggerOperation("SchoolbusattachmentsIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusAttachment))]
        public virtual IActionResult SchoolbusattachmentsIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusattachmentsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusAttachment to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusAttachment not found</response>
        [HttpPut]
        [Route("/api/schoolbusattachments/{id}")]
        [SwaggerOperation("SchoolbusattachmentsIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusAttachment))]
        public virtual IActionResult SchoolbusattachmentsIdPut([FromRoute]int id, [FromBody]SchoolBusAttachment item)
        {
            return this._service.SchoolbusattachmentsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusAttachment created</response>
        [HttpPost]
        [Route("/api/schoolbusattachments")]
        [SwaggerOperation("SchoolbusattachmentsPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusAttachment))]
        public virtual IActionResult SchoolbusattachmentsPost([FromBody]SchoolBusAttachment item)
        {
            return this._service.SchoolbusattachmentsPostAsync(item);
        }
    }
}
