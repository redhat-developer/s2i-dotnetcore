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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public RegionController(IRegionService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions")]
        [RequiresPermission(Permissions.CodeRead)]
        public virtual IActionResult RegionsGet()
        {
            return this._service.RegionsGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Region to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        [HttpPost]
        [Route("/api/regions/{id}/delete")]
        [RequiresPermission(Permissions.CodeWrite)]
        public virtual IActionResult RegionsIdDeletePost([FromRoute]int id)
        {
            return this._service.RegionsIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the districts for a specific region</remarks>
        /// <param name="id">id of Region for which to fetch the Districts</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{id}/districts")]
        [RequiresPermission(Permissions.CodeRead)]
        public virtual IActionResult RegionsIdDistrictsGet([FromRoute]int id)
        {
            return this._service.RegionsIdDistrictsGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Region to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        [HttpGet]
        [Route("/api/regions/{id}")]
        [RequiresPermission(Permissions.CodeRead)]
        public virtual IActionResult RegionsIdGet([FromRoute]int id)
        {
            return this._service.RegionsIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of Region to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">Region not found</response>
        [HttpPut]
        [Route("/api/regions/{id}")]
        [RequiresPermission(Permissions.CodeWrite)]
        public virtual IActionResult RegionsIdPut([FromRoute]int id, [FromBody]Region item)
        {
            return this._service.RegionsIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">Region created</response>
        [HttpPost]
        [Route("/api/regions")]
        [RequiresPermission(Permissions.CodeWrite)]
        public virtual IActionResult RegionsPost([FromBody]Region item)
        {
            return this._service.RegionsPostAsync(item);
        }
    }
}
