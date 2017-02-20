using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolBusAPI.Seeders
{
    public class UserSeeder : Seeder<DbAppContext>
    {
        private string[] ProfileTriggers = { AllProfiles };

        public UserSeeder(IConfiguration configuration, IHostingEnvironment env, ILoggerFactory loggerFactory) 
            : base(configuration, env, loggerFactory)
        { }

        protected override IEnumerable<string> TriggerProfiles
        {
            get { return ProfileTriggers; }
        }

        public override Type InvokeAfter
        {
            get
            {
                return typeof(RoleSeeder);
            }
        }

        protected override void Invoke(DbAppContext context)
        {
            UpdateUsers(context);
        }

        private void UpdateUsers(DbAppContext context)
        {
            List<User> seedUsers = GetSeedUsers(context);
            foreach (var user in seedUsers)
            {
                context.UpdateSeedUserInfo(user);
            }

            AddInitialUsers(context);
            context.SaveChanges();
        }

        private void AddInitialUsers(DbAppContext context)
        {
            context.AddInitialUsersFromFile(Configuration["UserInitializationFile"]);
        }

        private List<User> GetSeedUsers(DbAppContext context)
        {
            List<User> users = new List<User>(GetDefaultUsers(context));
            if (IsDevelopmentEnvironment)
                users.AddRange(GetDevUsers(context));
            if (IsTestEnvironment || IsStagingEnvironment)
                users.AddRange(GetTestUsers(context));
            if (IsProductionEnvironment)
                users.AddRange(GetProdUsers(context));

            return users;
        }

        /// <summary>
        /// Returns a list of users to be populated in all environments.
        /// </summary>
        private List<User> GetDefaultUsers(DbAppContext context)
        {
            return new List<User>();
        }

        /// <summary>
        /// Returns a list of users to be populated in the Development environment.
        /// </summary>
        private List<User> GetDevUsers(DbAppContext context)
        {
            return new List<User>
            {
                new User
                {
                    Active = true,
                    Email = "Testy.McTesterson@TestDomain.test",
                    GivenName = "Testy",
                    GroupMemberships = new List<GroupMembership>
                    {
                        new GroupMembership
                        {
                            Active = true,
                            Group = context.GetGroup("Other")
                        }
                    },
                    Guid = "2cbf7cb8d6b445f087fb82ad75566a9c",
                    Initials = "TT",
                    SmAuthorizationDirectory = "TEST",
                    SmUserId = "TMcTesterson",
                    Surname = "McTesterson",
                    UserRoles = new List<UserRole>
                    {
                        new UserRole
                        {
                            EffectiveDate = DateTime.UtcNow,
                            Role = context.GetRole("User")
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Returns a list of users to be populated in the Test environment.
        /// </summary>
        private List<User> GetTestUsers(DbAppContext context)
        {
            return new List<User>();
        }

        /// <summary>
        /// Returns a list of users to be populated in the Production environment.
        /// </summary>
        private List<User> GetProdUsers(DbAppContext context)
        {
            return new List<User>();
        }
    }
}
