using System.Collections.Generic;

namespace SchoolBusCommon
{
    public class DatabaseVersionInfo : VersionInfo
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public IEnumerable<string> Migrations { get; set; }
        public IEnumerable<string> AppliedMigrations { get; set; }
        public IEnumerable<string> PendingMigrations { get; set; }
    }
}
