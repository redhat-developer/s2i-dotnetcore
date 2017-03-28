using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SchoolBusAPI.Authentication;
using System;

namespace SchoolBusAPI.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private string _devAuthenticationTokenKey;
        private IHostingEnvironment _env;

        public AuthenticationController(IOptions<DevAuthenticationOptions> options, IHostingEnvironment env)
        {
            _env = env;
            _devAuthenticationTokenKey = options.Value.AuthenticationTokenKey;
        }

        /// <summary>
        /// Injects an authentication token cookie into the response for use with the 
        /// <see cref="DevAuthenticationHandler"/>, which performs user authentication
        /// during development sessions.  This allows the authentication and 
        /// authorization infrastructure to be easily integrated into the development
        /// environment.
        /// </summary>
        [HttpGet]
        [Route("dev/token/{userid}")]
        [AllowAnonymous]
        public virtual IActionResult GetDevAuthenticationCookie(string userId)
        {
            if(!_env.IsDevelopment())
            {
                return BadRequest("This API is not available outside a development environment.");
            }

            if (!string.IsNullOrEmpty(userId))
            {
                CookieOptions options = new CookieOptions();
                options.Path = "/";
                options.Expires = DateTime.UtcNow.AddDays(7);
                Response.Cookies.Append(_devAuthenticationTokenKey, userId, options);
                return Ok();
            }

            return BadRequest("Missing required userId query parameter.");
        }
    }
}
