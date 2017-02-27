using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
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
    public static class SiteminderAuthenticationExtensions
    {
        public static IApplicationBuilder UseSiteminderAuthenticationHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SiteminderAuthenticationMiddleware>();
        }
    }

    public class SiteminderAuthenticationOptions : CustomAuthenticationOptions
    {
        private const string SiteMinder_User_Guid_Key = "smgov_userguid";
        private const string SiteMinder_Universal_Id_Key = "sm_universalid";
        private const string SiteMinder_User_Name_Key = "sm_user";
        private const string SiteMinder_User_Display_Name_Key = "smgov_userdisplayname";

        public static string AuthenticationSchemeName
        {
            get { return "site-minder-auth"; }
        }

        public SiteminderAuthenticationOptions()
        {
            AuthenticationScheme = AuthenticationSchemeName;
            SiteMinderUserGuidKey = SiteMinder_User_Guid_Key;
            SiteMinderUniversalIdKey = SiteMinder_Universal_Id_Key;
            SiteMinderUserNameKey = SiteMinder_User_Name_Key;
            SiteMinderUserDisplayNameKey = SiteMinder_User_Display_Name_Key;
        }

        public string SiteMinderUserGuidKey { get; private set; }
        public string SiteMinderUniversalIdKey { get; private set; }
        public string SiteMinderUserNameKey { get; private set; }
        public string SiteMinderUserDisplayNameKey { get; private set; }
    }

    public class SiteminderAuthenticationMiddleware : AuthenticationMiddleware<SiteminderAuthenticationOptions>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IDbAppContextFactory _dbContextFactory;
        private readonly DbContextFactoryOptions _dbFactoryOptions = new DbContextFactoryOptions();

        public SiteminderAuthenticationMiddleware(RequestDelegate next, IDbAppContextFactory dbContextFactory, IOptions<SiteminderAuthenticationOptions> options, ILoggerFactory loggerFactory, UrlEncoder encoder) 
            : base(next, options, loggerFactory, encoder)
        {
            _loggerFactory = loggerFactory;
            this._dbContextFactory = dbContextFactory;
        }

        protected override AuthenticationHandler<SiteminderAuthenticationOptions> CreateHandler()
        {
            return new SiteminderAuthenticationHandler(_dbContextFactory.Create(), _loggerFactory);
        }
    }

    public class SiteminderAuthenticationHandler : AuthenticationHandler<SiteminderAuthenticationOptions>
    {
        private readonly ILogger _logger;
        private readonly IDbAppContext _context;

        public SiteminderAuthenticationHandler(IDbAppContext context, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(SiteminderAuthenticationHandler));
            _context = context;
        }

        private string SiteMinderGuid
        {
            get
            {
                return this.Request.Headers[Options.SiteMinderUserGuidKey];
            }
        }

        private string SiteMinderUserId
        {
            get
            {
                string smUserId = this.Request.Headers[Options.SiteMinderUserNameKey];
                if (string.IsNullOrEmpty(smUserId))
                {
                    smUserId = this.Request.Headers[Options.SiteMinderUniversalIdKey];
                }

                return smUserId;
            }
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            _logger.LogDebug("Parsing the header for SiteMinder authentication credentials...");
            string username = this.SiteMinderUserId;
            string siteMinderGuid = this.SiteMinderGuid;

            if (string.IsNullOrEmpty(username))
            {
                // Defer to another layer ...
                _logger.LogWarning($"Missing username");
                return Task.FromResult(AuthenticateResult.Fail("Missing SiteMinder UserId!"));
            }

            if (string.IsNullOrEmpty(siteMinderGuid))
            {
                // Defer to another layer ...
                _logger.LogWarning($"Missing guid!");
                return Task.FromResult(AuthenticateResult.Fail("Missing SiteMinder Guid!"));
            }

            var user = _context.LoadUser(username, siteMinderGuid);
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
