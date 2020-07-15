using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SchoolBusAPI.Seeders
{
    /// <summary>
    /// This class automattically loades all seeder classes defined in this assembly,
    /// and provides a simple interface for seeding the application and database with data.
    /// </summary>
    public class SeedFactory<T> where T : DbContext
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        private List<Seeder<T>> SeederInstances = new List<Seeder<T>>();

        public SeedFactory(IConfiguration configuration, IWebHostEnvironment env, ILogger logger)
        {
            _env = env;
            _configuration = configuration;
            _logger = logger;

            this.LoadSeeders();
            SeederInstances.Sort(new SeederComparer<T>());
        }

        private void LoadSeeders()
        {
            _logger.LogDebug("Loading seeders...");

            Assembly assembly = typeof(SeedFactory<T>).GetTypeInfo().Assembly;
            List<Type> Types = assembly.GetTypes().Where(t => t.GetTypeInfo().IsSubclassOf(typeof(Seeder<T>))).ToList();
            foreach (Type type in Types)
            {
                _logger.LogDebug($"\tCreating instance of {type.Name}...");
                SeederInstances.Add((Seeder<T>)Activator.CreateInstance(type, _configuration, _env, _logger));
            }

            _logger.LogDebug($"\tA total of {Types.Count} seeders loaded.");
        }

        public void Seed(T context)
        {
            SeederInstances.ForEach(seeder =>
            {
                seeder.Seed(context);
            });
        }

        private class SeederComparer<T> : Comparer<Seeder<T>> where T : DbContext
        {
            public override int Compare(Seeder<T> x, Seeder<T> y)
            {
                // < 0 x is less than y
                // = 0 same
                // > 0 x greater than y
                int rtnValue = 0;
                if (x.InvokeAfter == y.InvokeAfter)
                {
                    rtnValue = 0;
                }

                if (x.InvokeAfter == null && y.InvokeAfter != null)
                {
                    rtnValue = -1;
                }

                if (x.GetType() == y.InvokeAfter)
                {
                    rtnValue = -1;
                }

                if (x.InvokeAfter == y.GetType())
                {
                    rtnValue = 1;
                }

                return rtnValue;
            }
        }
    }
}
