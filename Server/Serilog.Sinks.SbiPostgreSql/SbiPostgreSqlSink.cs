using Serilog.Sinks.PostgreSQL;
using System;
using System.Collections.Generic;

namespace Serilog.Sinks.SbiPostgreSql
{
    public class SbiPostgreSqlSink : PostgreSqlSink
    {
        /// <inheritdoc cref="PeriodicBatchingSink" />
        /// <summary>
        ///     Initializes a new instance of the <see cref="PostgreSqlSink" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="period">The time to wait between checking for event batches.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="columnOptions">The column options.</param>
        /// <param name="batchSizeLimit">The maximum number of events to include in a single batch.</param>
        /// <param name="useCopy">Enables the copy command to allow batch inserting instead of multiple INSERT commands.</param>
        /// <param name="schemaName">Name of the schema.</param>
        /// <param name="needAutoCreateTable">Specifies whether the table should be auto-created if it does not already exist or not.</param>
        public SbiPostgreSqlSink(
            string connectionString,
            string tableName,
            TimeSpan period,
            IFormatProvider formatProvider = null,
            IDictionary<string, ColumnWriterBase> columnOptions = null,
            int batchSizeLimit = DefaultBatchSizeLimit,
            bool useCopy = true,
            string schemaName = "",
            bool needAutoCreateTable = false)
            : base(connectionString, tableName, period, formatProvider, columnOptions, batchSizeLimit, useCopy, schemaName, needAutoCreateTable)
        {

        }

        /// <inheritdoc cref="PeriodicBatchingSink" />
        /// <summary>
        ///     Initializes a new instance of the <see cref="PostgreSqlSink" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="period">The time to wait between checking for event batches.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="columnOptions">The column options.</param>
        /// <param name="batchSizeLimit">The maximum number of events to include in a single batch.</param>
        /// <param name="queueLimit">Maximum number of events in the queue.</param>
        /// <param name="useCopy">Enables the copy command to allow batch inserting instead of multiple INSERT commands.</param>
        /// <param name="schemaName">Name of the schema.</param>
        /// <param name="needAutoCreateTable">Specifies whether the table should be auto-created if it does not already exist or not.</param>
        // ReSharper disable once UnusedMember.Global
        public SbiPostgreSqlSink(
            string connectionString,
            string tableName,
            TimeSpan period,
            IFormatProvider formatProvider = null,
            IDictionary<string, ColumnWriterBase> columnOptions = null,
            int batchSizeLimit = DefaultBatchSizeLimit,
            int queueLimit = DefaultQueueLimit,
            bool useCopy = true,
            string schemaName = "",
            bool needAutoCreateTable = false)
            : base(connectionString, tableName, period, formatProvider, columnOptions, batchSizeLimit, queueLimit, useCopy, schemaName, needAutoCreateTable)
        {

        }
    }
}
