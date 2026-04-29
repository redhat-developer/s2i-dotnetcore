/*
 * Migration export API for moving data to the new system.
 * Consumed by Hangfire jobs in the new app via HTTP. Supports pagination for large sets.
 * Access: valid X-Migration-Api-Key header (when Migration:ApiKey is set) OR JWT user with required permission.
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Authorization;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// Endpoints that return full entity data for migration to the new system build bump - CW
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [AllowAnonymous]
    public class MigrationController : ControllerBase
    {
        private readonly IMigrationService _migrationService;

        public MigrationController(IMigrationService migrationService)
        {
            _migrationService = migrationService;
        }

        /// <summary>
        /// Full inspection records with SchoolBus and Inspector. Use skip/take for batching.
        /// </summary>
        /// <param name="skip">Number of records to skip (optional)</param>
        /// <param name="take">Max records to return (optional)</param>
        [HttpGet]
        [Route("/api/migration/inspections")]
        [MigrationAuthorization(Permissions.SchoolBusRead)]
        public IActionResult GetInspections([FromQuery] int? skip, [FromQuery] int? take)
        {
            return _migrationService.GetInspections(skip, take);
        }

        /// <summary>
        /// Full school bus records with Notes, Attachments, History, CCWData, and related entities. Use skip/take for batching.
        /// </summary>
        [HttpGet]
        [Route("/api/migration/schoolbuses")]
        [MigrationAuthorization(Permissions.SchoolBusRead)]
        public IActionResult GetSchoolBuses([FromQuery] int? skip, [FromQuery] int? take)
        {
            return _migrationService.GetSchoolBuses(skip, take);
        }

        /// <summary>
        /// Full school bus owner records with Contacts, Notes, Attachments, History. Use skip/take for batching.
        /// </summary>
        [HttpGet]
        [Route("/api/migration/schoolbusowners")]
        [MigrationAuthorization(Permissions.OwnerRead)]
        public IActionResult GetSchoolBusOwners([FromQuery] int? skip, [FromQuery] int? take)
        {
            return _migrationService.GetSchoolBusOwners(skip, take);
        }

        /// <summary>
        /// All school districts (reference data, typically small set)
        /// </summary>
        [HttpGet]
        [Route("/api/migration/schooldistricts")]
        [MigrationAuthorization(Permissions.CodeRead)]
        public IActionResult GetSchoolDistricts()
        {
            return _migrationService.GetSchoolDistricts();
        }

        /// <summary>
        /// All service areas with District (reference data)
        /// </summary>
        [HttpGet]
        [Route("/api/migration/serviceareas")]
        [MigrationAuthorization(Permissions.CodeRead)]
        public IActionResult GetServiceAreas()
        {
            return _migrationService.GetServiceAreas();
        }

        /// <summary>
        /// Full contact records with SchoolBusOwner. Use skip/take for batching.
        /// </summary>
        [HttpGet]
        [Route("/api/migration/contacts")]
        [MigrationAuthorization(Permissions.OwnerRead)]
        public IActionResult GetContacts([FromQuery] int? skip, [FromQuery] int? take)
        {
            return _migrationService.GetContacts(skip, take);
        }
    }
}
