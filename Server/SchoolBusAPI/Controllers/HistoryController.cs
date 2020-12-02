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
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public HistoryController(IHistoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of History to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>
        [HttpPost]
        [Route("/api/histories/{id}/delete")]
        [RequiresPermission(Permissions.SchoolBusWrite, Permissions.OwnerWrite)]
        public virtual IActionResult HistoriesIdDeletePost([FromRoute]int id)
        {
            return this._service.HistoriesIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of History to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>
        [HttpGet]
        [Route("/api/histories/{id}")]
        [RequiresPermission(Permissions.SchoolBusRead, Permissions.OwnerRead)]
        public virtual IActionResult HistoriesIdGet([FromRoute]int id)
        {
            return this._service.HistoriesIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of History to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">History not found</response>
        [HttpPut]
        [Route("/api/histories/{id}")]
        [RequiresPermission(Permissions.SchoolBusWrite, Permissions.OwnerWrite)]
        public virtual IActionResult HistoriesIdPut([FromRoute]int id, [FromBody]History item)
        {
            return this._service.HistoriesIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        [HttpPost]
        [Route("/api/histories")]
        [RequiresPermission(Permissions.SchoolBusWrite, Permissions.OwnerWrite)]
        public virtual IActionResult HistoriesPost([FromBody]History item)
        {
            return this._service.HistoriesPostAsync(item);
        }
    }
}
