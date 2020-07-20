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
    public class SchoolBusController : ControllerBase
    {
        private readonly ISchoolBusService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusController(ISchoolBusService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBus created</response>
        [HttpPost]
        [Route("/api/schoolbuses/bulk")]
        //[SwaggerOperation("SchoolbusesBulkPost")]
        [RequiresPermission(Permission.ADMIN)]
        public virtual IActionResult SchoolbusesBulkPost([FromBody]SchoolBus[] items)
        {
            return this._service.SchoolbusesBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses")]
        //[SwaggerOperation("SchoolbusesGet")]
        //[SwaggerResponse(200, type: typeof(List<SchoolBus>))]
        public virtual IActionResult SchoolbusesGet()
        {
            return this._service.SchoolbusesGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch attachments for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/attachments")]
        //[SwaggerOperation("SchoolbusesIdAttachmentsGet")]
        //[SwaggerResponse(200, type: typeof(List<AttachmentViewModel>))]
        public virtual IActionResult SchoolbusesIdAttachmentsGet([FromRoute]int id)
        {
            return this._service.SchoolbusesIdAttachmentsGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns CCWData for a particular Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to fetch CCWData for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/ccwdata")]
        //[SwaggerOperation("SchoolbusesIdCcwdataGet")]
        //[SwaggerResponse(200, type: typeof(CCWData))]
        public virtual IActionResult SchoolbusesIdCcwdataGet([FromRoute]int id)
        {
            return this._service.SchoolbusesIdCcwdataGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpPost]
        [Route("/api/schoolbuses/{id}/delete")]
        //[SwaggerOperation("SchoolbusesIdDeletePost")]
        public virtual IActionResult SchoolbusesIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusesIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}")]
        //[SwaggerOperation("SchoolbusesIdGet")]
        //[SwaggerResponse(200, type: typeof(SchoolBus))]
        public virtual IActionResult SchoolbusesIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusesIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns History for a particular SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch History for</param>
        /// <param name="offset">offset for records that are returned</param>
        /// <param name="limit">limits the number of records returned.</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/history")]
        //[SwaggerOperation("SchoolbusesIdHistoryGet")]
        //[SwaggerResponse(200, type: typeof(List<HistoryViewModel>))]
        public virtual IActionResult SchoolbusesIdHistoryGet([FromRoute]int id, [FromQuery]int? offset, [FromQuery]int? limit)
        {
            return this._service.SchoolbusesIdHistoryGetAsync(id, offset, limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Add a History record to the SchoolBus</remarks>
        /// <param name="id">id of SchoolBus to fetch History for</param>
        /// <param name="item"></param>
        /// <response code="201">History created</response>
        [HttpPost]
        [Route("/api/schoolbuses/{id}/history")]
        //[SwaggerOperation("SchoolbusesIdHistoryPost")]
        //[SwaggerResponse(200, type: typeof(History))]
        public virtual IActionResult SchoolbusesIdHistoryPost([FromRoute]int id, [FromBody]History item)
        {
            return this._service.SchoolbusesIdHistoryPostAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch Inspections for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/inspections")]
        //[SwaggerOperation("SchoolbusesIdInspectionsGet")]
        //[SwaggerResponse(200, type: typeof(List<Inspection>))]
        public virtual IActionResult SchoolbusesIdInspectionsGet([FromRoute]int id)
        {
            return this._service.SchoolbusesIdInspectionsGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Obtains a new permit number for the indicated Schoolbus.  Returns the updated SchoolBus record.</remarks>
        /// <param name="id">id of SchoolBus to obtain a new permit number for</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/api/schoolbuses/{id}/newpermit")]
        //[SwaggerOperation("SchoolbusesIdNewpermitPut")]
        //[SwaggerResponse(200, type: typeof(SchoolBus))]
        public virtual IActionResult SchoolbusesIdNewpermitPut([FromRoute]int id)
        {
            return this._service.SchoolbusesIdNewpermitPutAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns notes for a particular SchoolBus.</remarks>
        /// <param name="id">id of SchoolBus to fetch notes for</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/notes")]
        //[SwaggerOperation("SchoolbusesIdNotesGet")]
        //[SwaggerResponse(200, type: typeof(List<Note>))]
        public virtual IActionResult SchoolbusesIdNotesGet([FromRoute]int id)
        {
            return this._service.SchoolbusesIdNotesGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a PDF version of the permit for the selected Schoolbus</remarks>
        /// <param name="id">id of SchoolBus to obtain the PDF permit for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses/{id}/pdfpermit")]
        //[SwaggerOperation("SchoolbusesIdPdfpermitGet")]
        public virtual IActionResult SchoolbusesIdPdfpermitGet([FromRoute]int id)
        {
            return this._service.SchoolbusesIdPdfpermitGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBus to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBus not found</response>
        [HttpPut]
        [Route("/api/schoolbuses/{id}")]
        //[SwaggerOperation("SchoolbusesIdPut")]
        //[SwaggerResponse(200, type: typeof(SchoolBus))]
        public virtual IActionResult SchoolbusesIdPut([FromRoute]int id, [FromBody]SchoolBus item)
        {
            return this._service.SchoolbusesIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBus created</response>
        [HttpPost]
        [Route("/api/schoolbuses")]
        //[SwaggerOperation("SchoolbusesPost")]
        //[SwaggerResponse(200, type: typeof(SchoolBus))]
        public virtual IActionResult SchoolbusesPost([FromBody]SchoolBus item)
        {
            return this._service.SchoolbusesPostAsync(item);
        }

        /// <summary>
        /// Searches school buses
        /// </summary>
        /// <remarks>Used for the search schoolbus page.</remarks>
        /// <param name="districts">Districts (array of id numbers)</param>
        /// <param name="inspectors">Assigned School Bus Inspectors (array of id numbers)</param>
        /// <param name="cities">Cities (array of id numbers)</param>
        /// <param name="schooldistricts">School Districts (array of id numbers)</param>
        /// <param name="owner"></param>
        /// <param name="regi">e Regi Number</param>
        /// <param name="vin">VIN</param>
        /// <param name="plate">License Plate String</param>
        /// <param name="includeInactive">True if Inactive schoolbuses will be returned</param>
        /// <param name="onlyReInspections">If true, only buses that need a re-inspection will be returned</param>
        /// <param name="startDate">Inspection start date</param>
        /// <param name="endDate">Inspection end date</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbuses/search")]
        //[SwaggerOperation("SchoolbusesSearchGet")]
        //[SwaggerResponse(200, type: typeof(List<SchoolBus>))]
        public virtual IActionResult SchoolbusesSearchGet(
            [ModelBinder(BinderType = typeof(CsvArrayBinder))]int?[] districts, 
            [ModelBinder(BinderType = typeof(CsvArrayBinder))]int?[] inspectors,
            [ModelBinder(BinderType = typeof(CsvArrayBinder))]int?[] cities,
            [ModelBinder(BinderType = typeof(CsvArrayBinder))]int?[] schooldistricts, 
            [FromQuery]int? owner, 
            [FromQuery]string regi, 
            [FromQuery]string vin, 
            [FromQuery]string plate, 
            [FromQuery]bool? includeInactive, 
            [FromQuery]bool? onlyReInspections, 
            [FromQuery]DateTime? startDate, 
            [FromQuery]DateTime? endDate)
        {
            // TODO: Implement fix for Swagger and APIExplorer interpretation of ModelBinder
            // TODO: Return 400 Bad Request status code when query is malformed
            // TODO: Integrate ModelBinder with SimpleModelBinderProvider
            return this._service.SchoolbusesSearchGetAsync(districts, inspectors, cities, schooldistricts, owner, regi, vin, plate, includeInactive, onlyReInspections, startDate, endDate);
        }
    }
}
