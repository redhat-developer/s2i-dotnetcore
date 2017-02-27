using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SchoolBusAPI.Models
{
    public static class UserModelExtensions
    {
        public static ClaimsPrincipal ToClaimsPrincipal(this User user, string authenticationType)
        {
            return new ClaimsPrincipal(user.ToClaimsIdentity(authenticationType));
        }

        private static ClaimsIdentity ToClaimsIdentity(this User user, string authenticationType)
        {
            return new ClaimsIdentity(user.GetClaims(), authenticationType);
        }

        private static List<Claim> GetClaims(this User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.SmUserId));

            if (!string.IsNullOrEmpty(user.Surname))
                claims.Add(new Claim(ClaimTypes.Surname, user.Surname));

            if (!string.IsNullOrEmpty(user.GivenName))
                claims.Add(new Claim(ClaimTypes.GivenName, user.GivenName));

            if (!string.IsNullOrEmpty(user.Email))
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

            if (user.Id != 0)
                claims.Add(new Claim(User.USERID_CLAIM, user.Id.ToString()));

            var permissions = user.GetActivePermissions().Select(p => new Claim(User.PERMISSION_CLAIM, p.Code)).ToList();
            if (permissions.Any())
                claims.AddRange(permissions);

            var roleSelect = user.GetActiveRoles().Select(r => new Claim(ClaimTypes.Role, r.Name));
            if (roleSelect != null)
            {
                var roles = roleSelect.ToList();
                if (roles.Any())
                    claims.AddRange(roles);
            }

            var groupSelect = user.GetActiveGroups().Select(g => new Claim(ClaimTypes.GroupSid, g.Name));
            if (groupSelect != null)
            {
                var groups = groupSelect.ToList();
                if (groups.Any())
                {
                    claims.AddRange(groups);
                }                    
            }

            return claims;
        }

        private static List<Permission> GetActivePermissions(this User user)
        {
            List<Permission> result = null;

            var activeRoles = user.GetActiveRoles();

            if (activeRoles != null)
            {
                var rolePermissions = activeRoles
                        .Where(x => x != null && x.RolePermissions != null)
                        .SelectMany(x => x.RolePermissions);

                if (rolePermissions != null)
                {
                    result = rolePermissions.Select(x => x.Permission).Distinct().ToList();
                }
            }

            return result;
        }

        private static List<Role> GetActiveRoles(this User user)
        {
            List<Role> roles = new List<Role>();

            if (user.UserRoles == null)
                return roles;

            roles = user.UserRoles.Where(
                x => x.Role != null
                && x.EffectiveDate <= DateTime.UtcNow
                && (x.ExpiryDate == null || x.ExpiryDate > DateTime.UtcNow))
                .Select(x => x.Role).ToList();

            return roles;
        }


        private static List<Group> GetActiveGroups(this User user)
        {
            List<Group> groups = new List<Group>();

            if (user.GroupMemberships == null)
                return groups;

            groups = user.GroupMemberships
                .Where(x => x.Active)
                .Select(x => x.Group).ToList();

            return groups;
        }
    }
}
