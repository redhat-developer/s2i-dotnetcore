using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SchoolBusAPI.Models;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SchoolBusAPI.Authentication
{
    public static class DevAuthenticationHandlerExtensions
    {
        /// <summary>
        /// Wires the <see cref="DevAuthenticationHandler"/> into development environment the pipeline.
        /// The <see cref="DevAuthenticationHandler"/> will only be wired if the hosting environment
        /// is set to Development.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="IApplicationBuilder"/> for the pipeline.
        /// </param>
        /// <param name="env">
        /// The <see cref="IHostingEnvironment"/> describing the current hosting environment.
        /// </param>
        /// <returns>
        /// The configured <see cref="IApplicationBuilder"/>.
        /// </returns>
        public static IApplicationBuilder UseDevAuthenticationHandler(this IApplicationBuilder builder, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Only wire developer token based authentication in the development environment.
                builder.UseMiddleware<DevAuthenticationHandlerMiddleware>();
            }

            return builder;
        }
    }

    public class DevAuthenticationOptions : CustomAuthenticationOptions
    {
        private const string Dev_Authentication_Token_Key = "DEV-USER";

        public static string AuthenticationSchemeName
        {
            get { return "dev-auth"; }
        }

        public DevAuthenticationOptions()
        {
            AuthenticationScheme = AuthenticationSchemeName;
            AuthenticationTokenKey = Dev_Authentication_Token_Key;
        }

        public string AuthenticationTokenKey { get; private set; }
    }

    public class DevAuthenticationHandlerMiddleware : AuthenticationMiddleware<DevAuthenticationOptions>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IDbAppContextFactory _dbContextFactory;
        private readonly DbContextFactoryOptions _dbFactoryOptions = new DbContextFactoryOptions();

        public DevAuthenticationHandlerMiddleware(RequestDelegate next, IDbAppContextFactory dbContextFactory, IOptions<DevAuthenticationOptions> options, ILoggerFactory loggerFactory, UrlEncoder encoder)
            : base(next, options, loggerFactory, encoder)
        {
            _loggerFactory = loggerFactory;
            this._dbContextFactory = dbContextFactory;
        }

        protected override AuthenticationHandler<DevAuthenticationOptions> CreateHandler()
        {
            return new DevAuthenticationHandler(_dbContextFactory.Create(), _loggerFactory);
        }
    }

    /// <summary>
    /// Performs authentication based on the username contained in token.
    /// </summary>
    /// <remarks>
    /// This is intended for developer convenience.
    /// It should only be wired up in a development environment; 
    /// <see cref="DevAuthenticationHandlerExtensions.UseDevAuthenticationHandler"/> makes sure of this.
    /// </remarks>
    public class DevAuthenticationHandler : AuthenticationHandler<DevAuthenticationOptions>
    {
        private readonly ILogger _logger;
        private readonly IDbAppContext _context;

        public DevAuthenticationHandler(IDbAppContext context, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(SiteminderAuthenticationHandler));
            _context = context;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            _logger.LogDebug("Parsing the request for development environment authentication credentials ...");

            // Look for credentials in the request cookies ...
            var username = Request.Cookies[Options.AuthenticationTokenKey];

            // Look for credentials in the request headers ...
            if (string.IsNullOrEmpty(username))
            {
                username = Request.Headers[Options.AuthenticationTokenKey];
            }

            if (string.IsNullOrEmpty(username))
            {
                // Defer to another layer ...
                _logger.LogWarning($"Could not find user information in the request!");
                return Task.FromResult(AuthenticateResult.Fail("Missing required authentication information!"));
            }

            var user = _context.LoadUser(username);
            if (user == null)
            {
                // Defer to another layer ...
                _logger.LogWarning($"Could not find user {username}!");
                return Task.FromResult(AuthenticateResult.Fail("Invalid credentials!"));
            }

            ClaimsPrincipal principal = user.ToClaimsPrincipal(Options.AuthenticationScheme);
            _logger.LogInformation($"Setting identity to {principal.Identity.Name} ...");
            AuthenticationTicket ticket = new AuthenticationTicket(principal, null, Options.AuthenticationScheme);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

        protected override Task<bool> HandleForbiddenAsync(ChallengeContext context)
        {
            return base.HandleForbiddenAsync(context);
        }

        protected override Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
        {
            return base.HandleUnauthorizedAsync(context);
        }
    }
}
