using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;
using Microsoft.Extensions.Configuration;
using NpgsqlTypes;
using Serilog.Debugging;
using Serilog.Sinks.PostgreSQL.ColumnWriters;
using Serilog.Sinks.PeriodicBatching;

namespace Serilog.Sinks.SbiPostgreSql
{
    /// <summary>
    ///     This class contains the PostgreSQL logger configuration.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1650:ElementDocumentationMustBeSpelledCorrectly",
        Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable once UnusedMember.Global
    public static class LoggerConfigurationSbiPostgreSqlExtensions
    {
        /// <summary>
        ///     The default batch size limit.
        /// </summary>
        private const int DefaultBatchSizeLimit = 30;

        /// <summary>
        /// The default queue limit.
        /// </summary>
        private const int DefaultQueueLimit = int.MaxValue;

        /// <summary>
        ///     Default time to wait between checking for event batches.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly TimeSpan DefaultPeriod = TimeSpan.FromSeconds(5);

        /// <summary>
        ///     Adds a sink which writes to PostgreSQL table.
        /// </summary>
        /// <param name="sinkConfiguration">The logger configuration.</param>
        /// <param name="connectionString">The connection string to the database where to store the events.</param>
        /// <param name="tableName">Name of the table to store the events in.</param>
        /// <param name="columnOptions">Table columns writers</param>
        /// <param name="restrictedToMinimumLevel">The minimum log event level required in order to write an event to the sink.</param>
        /// <param name="period">The time to wait between checking for event batches.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <param name="batchSizeLimit">The maximum number of events to include to single batch.</param>
        /// <param name="levelSwitch">A switch allowing the pass-through minimum level to be changed at runtime.</param>
        /// <param name="useCopy">If true inserts data via COPY command, otherwise uses INSERT INTO statement </param>
        /// <param name="schemaName">Schema name</param>
        /// <param name="needAutoCreateTable">Set if sink should create table</param>
        /// <returns>Logger configuration, allowing configuration to continue.</returns>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        // ReSharper disable once UnusedMember.Global
        public static LoggerConfiguration SbiPostgreSql(
            this LoggerSinkConfiguration sinkConfiguration,
            string connectionString,
            string tableName,
            IDictionary<string, ColumnWriterBase> columnOptions = null,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
            TimeSpan? period = null,
            IFormatProvider formatProvider = null,
            int batchSizeLimit = DefaultBatchSizeLimit,
            int queueLimit = DefaultQueueLimit,
            LoggingLevelSwitch levelSwitch = null,
            bool useCopy = true,
            string schemaName = "",
            bool needAutoCreateTable = false,
            bool needAutoCreateSchema = false,
            Action<Exception> failureCallback = null,
            IConfiguration appConfiguration = null)
        {
            if (sinkConfiguration == null)
            {
                throw new ArgumentNullException(nameof(sinkConfiguration));
            }

            period = period ?? DefaultPeriod;

            var connectionStr = GetConnectionString(connectionString, appConfiguration);

            IDictionary<string, ColumnWriterBase> columnOpts = new Dictionary<string, ColumnWriterBase>
            {
                { "message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
                { "message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
                { "level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
                { "raise_date", new TimestampColumnWriter(NpgsqlDbType.TimestampTz) },
                { "exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
                { "properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
                { "props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
                { "machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
            };

            if (columnOptions != null)
            {
                foreach (var columnOption in columnOptions)
                {
                    columnOpts.Add(columnOption.Key, columnOption.Value);
                }
            }

            var optionsLocal = GetOptions(
                connectionStr,
                tableName,
                columnOpts,
                period.Value,
                formatProvider,
                batchSizeLimit,
                queueLimit,
                useCopy,
                schemaName,
                needAutoCreateTable,
                needAutoCreateSchema,
                failureCallback
            );

            var batchingOptions = new PeriodicBatchingSinkOptions()
            {
                BatchSizeLimit = optionsLocal.BatchSizeLimit,
                Period = optionsLocal.Period,
                QueueLimit = optionsLocal.QueueLimit
            };

            var batchingSink = new PeriodicBatchingSink(
                new SbiPostgreSqlSink(optionsLocal),
                batchingOptions
            );

            return sinkConfiguration.Sink(batchingSink, restrictedToMinimumLevel, levelSwitch);
        }

        private static string GetConnectionString(string nameOrConnectionString, IConfiguration appConfiguration)
        {
            // If there is an `=`, we assume this is a raw connection string not a named value
            // If there are no `=`, attempt to pull the named value from config
            if (nameOrConnectionString.IndexOf('=') > -1) return nameOrConnectionString;
            string cs = appConfiguration?.GetConnectionString(nameOrConnectionString);
            if (string.IsNullOrEmpty(cs))
            {
                SelfLog.WriteLine(
                    "SbiPostgreSql sink configured value {0} is not found in ConnectionStrings settings and does not appear to be a raw connection string.", 
                    nameOrConnectionString
                );
            }
            return cs;
        }

        /// <summary>
        ///     Clears the quotation marks from the column options.
        /// </summary>
        internal static IDictionary<string, ColumnWriterBase> ClearQuotationMarksFromColumnOptions(
            IDictionary<string, ColumnWriterBase> columnOptions)
        {
            var result = new Dictionary<string, ColumnWriterBase>(columnOptions);

            foreach (var keyValuePair in columnOptions)
            {
                if (!keyValuePair.Key.Contains('"'))
                {
                    continue;
                }

                result.Remove(keyValuePair.Key);
                result[keyValuePair.Key.Replace("\"", string.Empty)] = keyValuePair.Value;
            }

            return result;
        }

        /// <summary>
        /// Gets the column options.
        /// </summary>
        /// <param name="connectionString">The connection string to the database where to store the events.</param>
        /// <param name="tableName">Name of the table to store the events in.</param>
        /// <param name="columnOptions">The current column options.</param>
        /// <param name="period">The time to wait between checking for event batches.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <param name="batchSizeLimit">The maximum number of events to include to single batch.</param>
        /// <param name="queueLimit">The maximum number of events that should be stored in the batching queue.</param>
        /// <param name="useCopy">If true inserts data via COPY command, otherwise uses INSERT INTO statement.</param>
        /// <param name="schemaName">The schema name.</param>
        /// <param name="needAutoCreateTable">A <seealso cref="bool"/> value indicating whether the table should be auto created or not.</param>
        /// <param name="needAutoCreateSchema">Specifies whether the schema should be auto-created if it does not already exist or not.</param>
        /// <param name="failureCallback">The failure callback.</param>
        internal static PostgreSqlOptions GetOptions(
            string connectionString,
            string tableName,
            IDictionary<string, ColumnWriterBase> columnOptions,
            TimeSpan period,
            IFormatProvider formatProvider,
            int batchSizeLimit,
            int queueLimit,
            bool useCopy,
            string schemaName,
            bool needAutoCreateTable,
            bool needAutoCreateSchema,
            Action<Exception> failureCallback)
        {
            var columnOptionsLocal = ClearQuotationMarksFromColumnOptions(columnOptions ?? ColumnOptions.Default);

            return new PostgreSqlOptions
            {
                ConnectionString = connectionString,
                TableName = tableName.Replace("\"", string.Empty),
                Period = period,
                FormatProvider = formatProvider,
                ColumnOptions = columnOptionsLocal,
                BatchSizeLimit = batchSizeLimit,
                QueueLimit = queueLimit,
                UseCopy = useCopy,
                SchemaName = schemaName.Replace("\"", string.Empty),
                NeedAutoCreateTable = needAutoCreateTable,
                NeedAutoCreateSchema = needAutoCreateSchema,
                FailureCallback = failureCallback
            };
        }
    }
}