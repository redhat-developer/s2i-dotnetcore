/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */


using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SchoolBusAPI.Models
{

    /// <summary>
    /// Utility extension added to entity framework
    /// </summary>

    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Implements the following naming convention:
        /// Camel Case converted to upper case, with underscores between words.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void UpperCaseUnderscoreSingularConvention(this ModelBuilder modelBuilder)
        {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Skip shadow types
                if (entityType.ClrType == null)
                    continue;

                entityType.Relational().TableName = ConvertName(entityType.ClrType.Name);

                // Now convert the column names.
                foreach (var entityProperty in entityType.GetProperties())
                {
                    entityProperty.Relational().ColumnName = ConvertName(entityProperty.Name);
                }
            }
        }

        /// <summary>
        /// Utility function to perform the text conversion
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static String ConvertName(String name)
        {
            // first add the underscore
            string result = Regex.Replace(name, "([^_A-Z])([A-Z])", "$1_$2");
            // then convert to uppercase.  
            result = result.ToUpperInvariant();
            return result;
        }

    }


}