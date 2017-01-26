using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SchoolBusCommon;
using System;
using System.Net.Http;
using System.Reflection;
using System.Linq;
using SchoolBusClient.Handlers;

namespace SchoolBusClient.Controllers
{
    [Route("version")]
    [Route("schoolbus/version")]
    public class VersionController : Controller
    {
        // Hack in the git commit id.
        private const string _commitKey = "OPENSHIFT_BUILD_COMMIT";

        private readonly Uri _apiServerUri;
        private readonly IConfiguration _configuration;

        public VersionController(IConfiguration configuration, IOptions<ApiProxyServerOptions> apiServerOptions)
        {
            _configuration = configuration;
            _apiServerUri = apiServerOptions.Value.ToUri();
        }

        private string CommitId
        {
            get
            {
                return _configuration[_commitKey];
            }
        }

        [HttpGet]
        public virtual IActionResult GetVersion()
        {
            ProductVersionInfo version = null;

            try
            {
                version = GetVersion<ProductVersionInfo>("/api/version");
            }
            catch { }

            if(version == null)
            {
                version = new ProductVersionInfo();
            }

            version.ApplicationVersions.Add(GetApplicationVersionInfo());
            return Ok(version);
        }

        private T GetVersion<T>(string path)
        {
            var httpClient = new HttpClient();
            Request.Headers.ToList().ForEach(h => httpClient.DefaultRequestHeaders.Add(h.Key, (string)h.Value));
            httpClient.BaseAddress = _apiServerUri;
            var content = httpClient.GetStringAsync(path).Result;
            return JsonConvert.DeserializeObject<T>(content);
        }

        private ApplicationVersionInfo GetApplicationVersionInfo()
        {
            Assembly assembly = this.GetType().GetTypeInfo().Assembly;
            return assembly.GetApplicationVersionInfo(this.CommitId);
        }
    }
}
