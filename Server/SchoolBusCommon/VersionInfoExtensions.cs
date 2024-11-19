using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace SchoolBusCommon
{
    public static class VersionInfoExtensions
    {
        public static DatabaseVersionInfo GetDatabaseVersionInfo(this DatabaseFacade database)
        {
            using var connection = database.GetDbConnection();
            connection.Open();

            using var cmd = connection.CreateCommand();
            
            cmd.CommandText = "select pg_size_pretty(pg_database_size(current_database()))";
            var databaseSize = cmd.ExecuteScalar().ToString();

            cmd.CommandText = "select count(*) from sbilog where level in ( 'Fatal', 'Error' ) and DATE_PART('day', CURRENT_DATE - raise_date) < 1";
            var appErrorCount = cmd.ExecuteScalar().ToString();

            var info = new DatabaseVersionInfo()
            {
                Name = connection.GetType().Name,
                Version = $"PostgreSQL {connection.ServerVersion}",
                Server = connection.DataSource,
                Database = connection.Database,
                Migrations = database.GetMigrations(),
                AppliedMigrations = database.GetAppliedMigrations(),
                PendingMigrations = database.GetPendingMigrations(),
                DatabaseSize = databaseSize,
                AppErrorCount = appErrorCount
            };

            return info;
        }

        public static ApplicationVersionInfo GetApplicationVersionInfo(this Assembly assembly, string environment = null, string commit = null)
        {
            DateTime creationTime = File.GetLastWriteTimeUtc(assembly.Location);

            ApplicationVersionInfo info = new ApplicationVersionInfo()
            {
                Name = assembly.GetName().Name,
                Version = assembly.GetName().Version.ToString(),
                Copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright,
                Commit = commit,
                Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description,
                FileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version,
                FileCreationTime = creationTime.ToString("O"), // Use the round trip format as it includes the time zone.
                InformationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion.Split('+')[0],
                TargetFramework = assembly.GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName,
                Title = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title,
                ImageRuntimeVersion = assembly.ImageRuntimeVersion,
                Environment = environment,
                Dependancies = assembly.GetReferencedAssemblies().ToIEnumerableVersionInfo()
            };

            return info;
        }

        private static IEnumerable<VersionInfo> ToIEnumerableVersionInfo(this AssemblyName[] assemblyNames)
        {
            return assemblyNames.Select(d => new VersionInfo() { Name = d.Name, Version = d.Version.ToString() }).ToList();
        }

        private static DateTime GetCreationTime(this Assembly assembly)
        {
            return System.IO.File.GetCreationTime(assembly.Location);
        }
    }
}
