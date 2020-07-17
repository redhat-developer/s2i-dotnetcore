using System.Security.Claims;

namespace SchoolBusAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static (string username, string userGuid, string directory) GetUserInfo(this ClaimsPrincipal principal)
        {
            var preferredUsername = principal.FindFirstValue("preferred_username");

            var usernames = preferredUsername?.Split("@");
            var username = usernames?[0].ToUpperInvariant();
            var directory = usernames?[1].ToUpperInvariant();

            var userGuidClaim = directory?.ToUpperInvariant() == "IDIR" ? "idir_userid" : "bceid_userid";
            var userGuid = principal.FindFirstValue(userGuidClaim)?.ToUpperInvariant();

            return (username, userGuid, directory);
        }
    }
}
