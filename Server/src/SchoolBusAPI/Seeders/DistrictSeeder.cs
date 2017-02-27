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
    public class DistrictSeeder : Seeder<DbAppContext>
    {
        private string[] ProfileTriggers = { AllProfiles };

        public DistrictSeeder(IConfiguration configuration, IHostingEnvironment env, ILoggerFactory loggerFactory) 
            : base(configuration, env, loggerFactory)
        { }

        protected override IEnumerable<string> TriggerProfiles
        {
            get { return ProfileTriggers; }
        }

        protected override void Invoke(DbAppContext context)
        {
            UpdateDistricts(context);
            context.SaveChanges();
        }

        public override Type InvokeAfter
        {
            get
            {
                return typeof(RegionSeeder);
            }
        }

        private void UpdateDistricts(DbAppContext context)
        {
            List<District> seedUsers = GetSeedDistricts(context);
            foreach (District district in seedUsers)
            {
                context.UpdateSeedDistrictInfo(district);
                context.SaveChanges();
            }
            AddInitialDistricts(context);            
        }

        private void AddInitialDistricts(DbAppContext context)
        {
            context.AddInitialDistrictsFromFile(Configuration["DistrictInitializationFile"]);
        }

        private List<District> GetSeedDistricts(DbAppContext context)
        {
            List<District> districts = new List<District>(GetDefaultDistricts(context));
            if (IsDevelopmentEnvironment)
                districts.AddRange(GetDevDistricts(context));
            if (IsTestEnvironment || IsStagingEnvironment)
                districts.AddRange(GetTestDistricts(context));
            if (IsProductionEnvironment)
                districts.AddRange(GetProdDistricts(context));

            return districts;
        }

        /// <summary>
        /// Returns a list of users to be populated in all environments.
        /// </summary>
        private List<District> GetDefaultDistricts(DbAppContext context)
        {
            return new List<District>();
        }

        /// <summary>
        /// Returns a list of users to be populated in the Development environment.
        /// </summary>
        private List<District> GetDevDistricts(DbAppContext context)
        {
            return new List<District>();            
        }

        /// <summary>
        /// Returns a list of users to be populated in the Test environment.
        /// </summary>
        private List<District> GetTestDistricts(DbAppContext context)
        {
            return new List<District>();
        }

        /// <summary>
        /// Returns a list of users to be populated in the Production environment.
        /// </summary>
        private List<District> GetProdDistricts(DbAppContext context)
        {
            return new List<District>();
        }

    }
}
