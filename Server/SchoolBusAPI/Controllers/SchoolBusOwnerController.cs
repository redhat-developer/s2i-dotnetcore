/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;
using SchoolBusAPI.Authorization;
using SchoolBusAPI.Helpers;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    public class SchoolBusOwnerController : ControllerBase
    {
        private readonly ISchoolBusOwnerService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusOwnerController(ISchoolBusOwnerService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusOwner created</response>
        [HttpPost]
        [Route("/api/schoolbusowners/bulk")]
        [RequiresPermission(Permissions.OwnerWrite)]
        public virtual IActionResult SchoolbusownersBulkPost([FromBody]SchoolBusOwner[] items)
        {
            return this._service.SchoolbusownersBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusowners")]
        public virtual IActionResult SchoolbusownersGet()
        {
            return this._service.SchoolbusownersGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusowners/{id}/attachments")]
        public virtual IActionResult SchoolbusownersIdAttachmentsGet([FromRoute]int id)
        {
            return this._service.SchoolbusownersIdAttachmentsGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        [HttpPost]
        [Route("/api/schoolbusowners/{id}/delete")]
        public virtual IActionResult SchoolbusownersIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusownersIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        [HttpGet]
        [Route("/api/schoolbusowners/{id}")]
        public virtual IActionResult SchoolbusownersIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusownersIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch History for</param>
        /// <param name="offset">offset for records that are returned</param>
        /// <param name="limit">limits the number of records returned.</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusowners/{id}/history")]
        public virtual IActionResult SchoolbusownersIdHistoryGet([FromRoute]int id, [FromQuery]int? offset, [FromQuery]int? limit)
        {
            return this._service.SchoolbusownersIdHistoryGetAsync(id, offset, limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Add a History record to the SchoolBus Owner</remarks>
        /// <param name="id">id of SchoolBusOwner to add History for</param>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        [HttpPost]
        [Route("/api/schoolbusowners/{id}/history")]
        public virtual IActionResult SchoolbusownersIdHistoryPost([FromRoute]int id, [FromBody]History item)
        {
            return this._service.SchoolbusownersIdHistoryPostAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusowners/{id}/notes")]
        public virtual IActionResult SchoolbusownersIdNotesGet([FromRoute]int id)
        {
            return this._service.SchoolbusownersIdNotesGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>
        [HttpPut]
        [Route("/api/schoolbusowners/{id}")]
        public virtual IActionResult SchoolbusownersIdPut([FromRoute]int id, [FromBody]SchoolBusOwner item)
        {
            return this._service.SchoolbusownersIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns SchoolBusOwner data plus additional information required for display</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusowners/{id}/view")]
        public virtual IActionResult SchoolbusownersIdViewGet([FromRoute]int id)
        {
            return this._service.SchoolbusownersIdViewGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusOwner created</response>
        [HttpPost]
        [Route("/api/schoolbusowners")]
        public virtual IActionResult SchoolbusownersPost([FromBody]SchoolBusOwner item)
        {
            return this._service.SchoolbusownersPostAsync(item);
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
        [HttpGet]
        [Route("/api/schoolbusowners/search")]
        public virtual IActionResult SchoolbusownersSearchGet(
            [ModelBinder(BinderType = typeof(CsvArrayBinder))]int?[] districts, 
            [ModelBinder(BinderType = typeof(CsvArrayBinder))]int?[] inspectors,
            [FromQuery]int? owner,
            [FromQuery]bool? includeInactive)
        {
            return this._service.SchoolbusownersSearchGetAsync(districts, inspectors, owner, includeInactive);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "id">id of school bus owner to fetch contacts</param>
        /// <response code = "200">OK</response>
        /// <response code = "404">school bus owner not found</response>
        [HttpGet]
        [Route("/api/schoolbusowners/{id}/contacts")]
        public virtual IActionResult SchoolbusesIdInspectionsGet([FromRoute]int id)
        {
            return this._service.SchoolbuseownersIdContactsGetAsync(id);
        }
    }
}
