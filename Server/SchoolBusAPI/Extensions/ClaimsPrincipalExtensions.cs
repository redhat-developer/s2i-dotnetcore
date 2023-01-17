using System.Security.Claims;

namespace SchoolBusAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static (string username, string userGuid, string directory) GetUserInfo(this ClaimsPrincipal principal)
        {
            var preferredUsername = principal.FindFirstValue("preferred_username");
            var usernames = preferredUsername?.Split("@");
            var username = (principal.FindFirstValue("idir_username") == null) ? usernames?[0].ToUpperInvariant() : principal.FindFirstValue("idir_username");
            var directory = usernames?[1].ToUpperInvariant();
            var userGuidClaim = directory?.ToUpperInvariant() == "IDIR" ? "idir_user_guid" : "bceid_userid";
            var userGuid = principal.FindFirstValue(userGuidClaim)?.ToUpperInvariant();
            userGuid = (userGuid != null)? userGuid: principal.FindFirstValue("idir_userid")?.ToUpperInvariant();
            return (username, userGuid, directory);
        }
    }
}
