using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SchoolBusCommon;
using System;
using System.Net.Http;
using System.Reflection;

namespace SchoolBusClient.Controllers
{
    [Route("version")]
    [Route("schoolbus/version")]
    public class VersionController : Controller
    {
        private readonly Uri _apiServerUri;

        public VersionController(IOptions<ApiProxyServerOptions> apiServerOptions)
        {
            _apiServerUri = apiServerOptions.Value.ToUri();
        }

        [HttpGet]
        public virtual IActionResult GetVersion()
        {
            ProductVersionInfo version = GetVersion<ProductVersionInfo>("/api/version");
            version.ApplicationVersions.Add(GetApplicationVersionInfo());
            return Ok(version);
        }

        private T GetVersion<T>(string path)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = _apiServerUri;
            var content = httpClient.GetStringAsync(path).Result;
            return JsonConvert.DeserializeObject<T>(content);
        }

        private ApplicationVersionInfo GetApplicationVersionInfo()
        {
            Assembly assembly = this.GetType().GetTypeInfo().Assembly;
            return assembly.GetApplicationVersionInfo();
        }

    }
}
