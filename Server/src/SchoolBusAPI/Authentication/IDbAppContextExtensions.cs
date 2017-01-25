using SchoolBusAPI.Models;
using System;

namespace SchoolBusAPI.Authentication
{
    public static class IDbAppContextExtensions
    {
        public static User LoadUser(this IDbAppContext context, string username, string guid = null)
        {
            User user = null;
            if (!string.IsNullOrEmpty(guid))
            {
                user = context.GetUserByGuid(guid);
            }

            if (user == null)
            {
                user = context.GetUserBySmUserId(username);
            }

            if (user == null)
            {
                return null;
            }

            if (guid != null)
            {
                if (string.IsNullOrEmpty(user.Guid))
                {
                    // Self register ...
                    user.Guid = guid;
                    context.SaveChanges();
                }
                else if (!user.Guid.Equals(guid, StringComparison.OrdinalIgnoreCase))
                {
                    // Registered users are not allowed to change their SiteMinder IDs ...
                    return null;
                }
            }

            return user;
        }
    }
}
