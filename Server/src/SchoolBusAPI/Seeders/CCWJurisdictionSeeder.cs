using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolBusAPI.Extensions;
using SchoolBusAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolBusAPI.Seeders
{
    public class CCWJurisdictionSeeder : Seeder<DbAppContext>
    {
        private string[] ProfileTriggers = { AllProfiles };

        public CCWJurisdictionSeeder(IConfiguration configuration, IWebHostEnvironment env, ILogger logger) 
            : base(configuration, env, logger)
        { }

        protected override IEnumerable<string> TriggerProfiles
        {
            get { return ProfileTriggers; }
        }

        protected override void Invoke(DbAppContext context)
        {
            UpdateCCWJurisdictions(context);
            context.SaveChanges();
        }

        public override Type InvokeAfter
        {
            get
            {
                return typeof(RegionSeeder);
            }
        }

        private void UpdateCCWJurisdictions(DbAppContext context)
        {
            List<CCWJurisdiction> seedUsers = GetSeedCCWJurisdictions(context);
            foreach (CCWJurisdiction CCWJurisdiction in seedUsers)
            {
                context.UpdateSeedCCWJurisdictionInfo(CCWJurisdiction);
                context.SaveChanges();
            }
            AddInitialCCWJurisdictions(context);            
        }

        private void AddInitialCCWJurisdictions(DbAppContext context)
        {
            context.AddInitialCCWJurisdictionsFromFile(Configuration["CCWJurisdictionInitializationFile"]);
        }

        private List<CCWJurisdiction> GetSeedCCWJurisdictions(DbAppContext context)
        {
            List<CCWJurisdiction> CCWJurisdictions = new List<CCWJurisdiction>(GetDefaultCCWJurisdictions(context));
            if (IsDevelopmentEnvironment)
                CCWJurisdictions.AddRange(GetDevCCWJurisdictions(context));
            if (IsTestEnvironment || IsStagingEnvironment)
                CCWJurisdictions.AddRange(GetTestCCWJurisdictions(context));
            if (IsProductionEnvironment)
                CCWJurisdictions.AddRange(GetProdCCWJurisdictions(context));

            return CCWJurisdictions;
        }

        /// <summary>
        /// Returns a list of users to be populated in all environments.
        /// </summary>
        private List<CCWJurisdiction> GetDefaultCCWJurisdictions(DbAppContext context)
        {
            return new List<CCWJurisdiction>();
        }

        /// <summary>
        /// Returns a list of users to be populated in the Development environment.
        /// </summary>
        private List<CCWJurisdiction> GetDevCCWJurisdictions(DbAppContext context)
        {
            return new List<CCWJurisdiction>();
        }

        /// <summary>
        /// Returns a list of users to be populated in the Test environment.
        /// </summary>
        private List<CCWJurisdiction> GetTestCCWJurisdictions(DbAppContext context)
        {
            return new List<CCWJurisdiction>();
        }

        /// <summary>
        /// Returns a list of users to be populated in the Production environment.
        /// </summary>
        private List<CCWJurisdiction> GetProdCCWJurisdictions(DbAppContext context)
        {
            return new List<CCWJurisdiction>();
        }
    }
}
