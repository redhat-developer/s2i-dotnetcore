using Serilog.Sinks.PostgreSQL;

namespace Serilog.Sinks.SbiPostgreSql
{
    public class SbiPostgreSqlSink : PostgreSqlSink
    {
        public SbiPostgreSqlSink(PostgreSqlOptions options) : base(options) { }
    }
}
