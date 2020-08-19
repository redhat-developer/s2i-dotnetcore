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

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public ContactController(IContactService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">Contact created</response>
        [HttpPost]
        [Route("/api/contacts/bulk")]
        [RequiresPermission(Permissions.OwnerWrite)]
        public virtual IActionResult ContactsBulkPost([FromBody]Contact[] items)
        {
            return this._service.ContactsBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/contacts")]
        public virtual IActionResult ContactsGet()
        {
            return this._service.ContactsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Contact to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>
        [HttpPost]
        [Route("/api/contacts/{id}/delete")]
        public virtual IActionResult ContactsIdDeletePost([FromRoute]int id)
        {
            return this._service.ContactsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Contact to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>
        [HttpGet]
        [Route("/api/contacts/{id}")]
        public virtual IActionResult ContactsIdGet([FromRoute]int id)
        {
            return this._service.ContactsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Contact to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Contact not found</response>
        [HttpPut]
        [Route("/api/contacts/{id}")]
        public virtual IActionResult ContactsIdPut([FromRoute]int id, [FromBody]Contact item)
        {
            return this._service.ContactsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Contact created</response>
        [HttpPost]
        [Route("/api/contacts")]
        public virtual IActionResult ContactsPost([FromBody]Contact item)
        {
            return this._service.ContactsPostAsync(item);
        }
    }
}
