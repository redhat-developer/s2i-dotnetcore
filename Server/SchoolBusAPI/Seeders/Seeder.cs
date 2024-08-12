using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBusAPI.Seeders
{
    public abstract class Seeder<T> where T : DbContext
    {
        public const string AllProfiles = "all";

        private IWebHostEnvironment _env;

        internal Seeder(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        protected bool IsEnvironment(string environmentName)
        {
            return _env.IsEnvironment(environmentName);
        }

        protected bool IsDevelopmentEnvironment { get { return _env.IsDevelopment(); } }
        protected bool IsTestEnvironment { get { return _env.IsEnvironment("Test"); } }
        protected bool IsStagingEnvironment { get { return _env.IsStaging(); } }
        protected bool IsProductionEnvironment { get { return _env.IsProduction(); } }

        protected IConfiguration Configuration { get; private set; }

        public virtual Type InvokeAfter { get { return null; } }
        protected abstract IEnumerable<string> TriggerProfiles { get; }
        protected abstract void Invoke(T context);

        public void Seed(T context)
        {
            if (this.TriggerProfiles.Contains(_env.EnvironmentName, StringComparer.OrdinalIgnoreCase) || this.TriggerProfiles.Contains(AllProfiles, StringComparer.OrdinalIgnoreCase))
            {
                Log.Debug("The trigger for {0} ({1}) matches the deployment profile ({2}); executing...", this.GetType().Name, string.Join(", ", this.TriggerProfiles), AllProfiles);
                this.Invoke(context);
            }
            else
            {
                Log.Debug("Trigger profile(s) for {0} ({1}), do not match the deployment profile ({2}); skipping...", this.GetType().Name, string.Join(", ", this.TriggerProfiles), _env.EnvironmentName);
            }
        }
    }
}
