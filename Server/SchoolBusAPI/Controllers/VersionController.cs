/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 *
 *
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolBusAPI.Models;
using SchoolBusCommon;
using System.Reflection;

namespace SchoolBusAPI.Controllers
{
    [Route("api")]
    [ApiVersion("1.0")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        // Hack in the git commit id.
        private const string _commitKey = "OPENSHIFT_BUILD_COMMIT";
        private const string _dotnetEnvKey = "ASPNETCORE_ENVIRONMENT";

        private readonly DbContext _context;
        private readonly IConfiguration _configuration;

        public VersionController(IConfiguration configuration, DbAppContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        private string CommitId
        {
            get
            {
                return _configuration[_commitKey];
            }
        }

        private string Environment
        {
            get
            {
                return _configuration[_dotnetEnvKey].ToLowerInvariant();
            }
        }

        [HttpGet]
        [Route("version")]
        public virtual IActionResult GetServerVersionInfo()
        {
            ProductVersionInfo info = new ProductVersionInfo();
            info.ApplicationVersions.Add(GetApplicationVersionInfo());
            info.DatabaseVersions.Add(GetDatabaseVersionInfo());
            return Ok(info);
        }

        [HttpGet]
        [Route("server/version")]
        public virtual IActionResult GetServerVersion()
        {
            return Ok(GetApplicationVersionInfo());
        }

        [HttpGet]
        [Route("database/version")]
        public virtual IActionResult GetDatabaseVersion()
        {
            return Ok(GetDatabaseVersionInfo());
        }

        private ApplicationVersionInfo GetApplicationVersionInfo()
        {
            Assembly assembly = this.GetType().GetTypeInfo().Assembly;
            return assembly.GetApplicationVersionInfo(this.Environment, this.CommitId);
        }

        private DatabaseVersionInfo GetDatabaseVersionInfo()
        {
            return _context.Database.GetDatabaseVersionInfo();
        }
    }
}
