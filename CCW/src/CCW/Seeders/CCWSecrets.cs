using CCW.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CCW.Seeders
{
    public class CCWSecrets : Seeder<DbAppContext>
    {
        private string[] ProfileTriggers = { AllProfiles };

        public CCWSecrets(IConfigurationRoot configuration, IHostingEnvironment env, ILoggerFactory loggerFactory) 
            : base(configuration, env, loggerFactory)
        { }


        protected override IEnumerable<string> TriggerProfiles
        {
            get { return ProfileTriggers; }
        }


        protected override void Invoke(DbAppContext context)
        {
            UpdateSecrets(context);
        }

        private void UpdateConfigurationString (Dictionary<string, string> strings, string key)
        {
            if (strings.ContainsKey(key))
            {
                Configuration[key] = strings[key];
            }
        }

        private void UpdateSecrets(DbAppContext context)
        {
            string filename = Configuration["CCWInitializationFile"];
            if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
            {
                string json = File.ReadAllText(filename);

                Dictionary<string, string> strings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                UpdateConfigurationString(strings, "CCW_userId");
                UpdateConfigurationString(strings, "CCW_guid");
                UpdateConfigurationString(strings, "CCW_directory");
                UpdateConfigurationString(strings, "CCW_endpointURL");
                UpdateConfigurationString(strings, "CCW_applicationIdentifier");
                UpdateConfigurationString(strings, "CCW_basicAuth_username");
                UpdateConfigurationString(strings, "CCW_basicAuth_password");

            }
            
        }

    }
}
