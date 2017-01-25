using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchoolBusAPI.Models
{
    public static class IDbAppContextExtensions
    {
        public static Role GetRole(this IDbAppContext context, string name)
        {
            Role role = context.Roles.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .Include(r => r.RolePermissions).ThenInclude(p => p.Permission)
                    .FirstOrDefault();
            return role;
        }

        public static Group GetGroup(this IDbAppContext context, string name)
        {
            return context.Groups.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static User GetUserByGuid(this IDbAppContext context, string guid)
        {
            User user = context.Users.Where(x => x.Guid != null && x.Guid.Equals(guid, StringComparison.OrdinalIgnoreCase))
                    .Include(u => u.UserRoles).ThenInclude(r => r.Role).ThenInclude(rp => rp.RolePermissions).ThenInclude(p => p.Permission)
                    .Include(u => u.GroupMemberships).ThenInclude(gm => gm.Group)
                    .FirstOrDefault();
            return user;
        }

        public static User GetUserBySmUserId(this IDbAppContext context, string smUserId)
        {
            User user = context.Users.Where(x => x.SmUserId != null && x.SmUserId.Equals(smUserId, StringComparison.OrdinalIgnoreCase))
                    .Include(u => u.UserRoles).ThenInclude(r => r.Role).ThenInclude(rp => rp.RolePermissions).ThenInclude(p => p.Permission)
                    .Include(u => u.GroupMemberships).ThenInclude(gm => gm.Group)
                    .FirstOrDefault();
            return user;
        }

        public static void AddInitialUsersFromFile(this IDbAppContext context, string userJsonPath)
        {
            if (!string.IsNullOrEmpty(userJsonPath) && File.Exists(userJsonPath))
            {
                string userJson = File.ReadAllText(userJsonPath);
                context.AddInitialUsers(userJson);
            }
        }

        private static void AddInitialUsers(this IDbAppContext context, string userJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(userJson);
            if(users != null)
            {
                context.AddInitialUsers(users);
            }
        }

        private static void AddInitialUsers(this IDbAppContext context, List<User> users)
        {
            users.ForEach(u => context.AddInitialUser(u));
        }

        /// <summary>
        /// Adds a user to the system, only if they do not exist.
        /// </summary>
        private static void AddInitialUser(this IDbAppContext context, User initialUser)
        {
            User user = context.GetUserBySmUserId(initialUser.SmUserId);
            if (user != null)
            {
                return;
            }

            user = new User();
            user.Active = true;
            user.Email = initialUser.Email;
            user.GivenName = initialUser.GivenName;
            user.Initials = initialUser.Initials;
            user.SmAuthorizationDirectory = initialUser.SmAuthorizationDirectory;
            user.SmUserId = initialUser.SmUserId;
            user.Surname = initialUser.Surname;

            string[] userRoles = initialUser.UserRoles.Select(x => x.Role.Name).ToArray();
            if (user.UserRoles == null)
                user.UserRoles = new List<UserRole>();

            foreach (string userRole in userRoles)
            {
                Role role = context.GetRole(userRole);
                if (role != null)
                { 
                    user.UserRoles.Add(
                        new UserRole
                        {
                            EffectiveDate = DateTime.Now,
                            Role = role
                        });
                }
            }

            string[] userGroups = initialUser.GroupMemberships.Select(x => x.Group.Name).ToArray();
            if (user.GroupMemberships == null)
                user.GroupMemberships = new List<GroupMembership>();

            foreach (string userGroup in userGroups)
            {
                Group group = context.GetGroup(userGroup);
                if (group != null)
                {
                    user.GroupMemberships.Add(
                        new GroupMembership
                        {
                            Active = true,
                            Group = context.GetGroup("Other")
                        });
                }
            }

            context.Users.Add(user);
        }

        public static void UpdateSeedUserInfo(this DbAppContext context, User userInfo)
        {
            User user = context.GetUserByGuid(userInfo.Guid);
            if (user == null)
            {
                context.Users.Add(userInfo);
            }
            else
            {
                user.Active = userInfo.Active;
                user.Email = userInfo.Email;
                user.GivenName = userInfo.GivenName;
                // user.Guid = userInfo.Guid;
                user.Initials = userInfo.Initials;
                user.SmAuthorizationDirectory = userInfo.SmAuthorizationDirectory;
                user.SmUserId = userInfo.SmUserId;
                user.Surname = userInfo.Surname;

                // Sync Roles
                if (user.UserRoles != null)
                {
                    foreach (UserRole item in user.UserRoles)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    foreach (UserRole item in userInfo.UserRoles)
                    {
                        user.UserRoles.Add(item);
                    }
                }

                // Sync Groups
                if (user.GroupMemberships != null)
                {
                    foreach (GroupMembership item in user.GroupMemberships)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    foreach (GroupMembership item in userInfo.GroupMemberships)
                    {
                        user.GroupMemberships.Add(item);
                    }
                }
            }
        }
    }
}
