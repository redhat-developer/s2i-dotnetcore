using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolBusAPI.Models;

namespace SchoolBusAPI
{
    /// <summary>
    /// Uility class used to update database column comments or descriptions.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class DbCommentsUpdater<TContext>
        where TContext : DbAppContext
    {
        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="context"></param>
        public DbCommentsUpdater(TContext context)
        {
            this.context = context;
        }

        readonly TContext context;
        IDbContextTransaction transaction;

        /// <summary>
        /// Update the database descriptions
        /// </summary>
        public void UpdateDatabaseDescriptions()
        {
            Type contextType;
            contextType = typeof(TContext);
            var props = contextType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            DbConnection con = context.Database.GetDbConnection();
            try
            {
                con.Open();
                transaction = context.Database.BeginTransaction();
                foreach (var prop in props)
                {
                    if (prop.PropertyType.InheritsOrImplements((typeof(DbSet<>))))
                    {
                        var tableType = prop.PropertyType.GetGenericArguments()[0];
                        SetTableDescriptions(tableType);
                    }
                }
                transaction.Commit();
            }
            catch
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }

        /// <summary>
        /// Set a table comment
        /// </summary>
        /// <param name="tableType"></param>
        private void SetTableDescriptions(Type tableType)
        {
            var entityType = context.Model.FindEntityType(tableType);

            string fullTableName = entityType.Relational().TableName;
            Regex regex = new Regex(@"(\[\w+\]\.)?\[(?<table>.*)\]");
            Match match = regex.Match(fullTableName);
            string tableName;
            if (match.Success)
                tableName = match.Groups["table"].Value;
            else
                tableName = fullTableName;

            var tableAttrs = tableType.GetTypeInfo().GetCustomAttributes(typeof(TableAttribute), false);
            var tableAttrsArray = tableAttrs.ToArray<Attribute>();
            if (tableAttrsArray.Length > 0)
            {
                tableName = ((TableAttribute)tableAttrsArray[0]).Name;
            }

            //  get the table description
            var tableExtAttrs = tableType.GetTypeInfo().GetCustomAttributes(typeof(MetaDataExtension), false);
            var tableExtAttrssArray = tableExtAttrs.ToArray<Attribute>();
            if (tableExtAttrssArray.Length > 0)
            {
                SetTableDescription(tableName, ((MetaDataExtension)tableExtAttrssArray[0]).Description);

            }

            foreach (Property entityProperty in entityType.GetProperties().OfType<Property>())
            {
                // Not all properties have MemberInfo, so a null check is required.
                if (entityProperty.MemberInfo != null)
                {
                    // get the custom attributes for this field.                
                    var attrs = entityProperty.MemberInfo.GetCustomAttributes(typeof(MetaDataExtension), false);
                    var attrsArray = attrs.ToArray<Attribute>();
                    if (attrsArray.Length > 0)
                    {
                        SetColumnDescription(tableName, entityProperty.Relational().ColumnName, ((MetaDataExtension)attrsArray[0]).Description);
                    }
                }

            }

        }

        /// <summary>
        /// Set a column comment
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="description"></param>
        private void SetColumnDescription(string tableName, string columnName, string description)
        {
            // Postgres has the COMMENT command to update a description.
            string query = "COMMENT ON COLUMN \"" + tableName + "\".\"" + columnName + "\" IS '" + description.Replace("'", "\'") + "'";
            context.Database.ExecuteSqlCommand(query);
        }

        /// <summary>
        /// Set a column comment
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="description"></param>
        private void SetTableDescription(string tableName, string description)
        {
            // Postgres has the COMMENT command to update a description.
            string query = "COMMENT ON TABLE \"" + tableName + "\" IS '" + description.Replace("'", "\'") + "'";
            context.Database.ExecuteSqlCommand(query);
        }


    }
    public static class ReflectionUtil
    {

        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            parent = ResolveGenericTypeDefinition(parent);

            var currentChild = child.GetTypeInfo().IsGenericType
                                    ? child.GetGenericTypeDefinition()
                                    : child;

            while (currentChild != typeof(object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.GetTypeInfo().BaseType != null
                                && currentChild.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType
                                    ? currentChild.GetTypeInfo().BaseType.GetGenericTypeDefinition()
                                    : currentChild.GetTypeInfo().BaseType;

                if (currentChild == null)
                    return false;
            }
            return false;
        }

        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces()
                .Any(childInterface =>
                {
                    var currentInterface = childInterface.GetTypeInfo().IsGenericType
                        ? childInterface.GetGenericTypeDefinition()
                        : childInterface;

                    return currentInterface == parent;
                });
        }

        private static Type ResolveGenericTypeDefinition(Type parent)
        {
            var shouldUseGenericType = true;
            if (parent.GetTypeInfo().IsGenericType && parent.GetGenericTypeDefinition() != parent)
                shouldUseGenericType = false;

            if (parent.GetTypeInfo().IsGenericType && shouldUseGenericType)
                parent = parent.GetGenericTypeDefinition();
            return parent;
        }
    }
}
