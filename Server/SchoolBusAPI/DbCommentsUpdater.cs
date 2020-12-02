using System;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
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

            string fullTableName = entityType.GetTableName();
            Regex regex = new Regex(@"(\[\w+\]\.)?\[(?<table>.*)\]");
            Match match = regex.Match(fullTableName);
            string tableName;
            if (match.Success)
                tableName = match.Groups["table"].Value;
            else
                tableName = fullTableName;

            var tableAttrs = tableType.GetTypeInfo().GetCustomAttributes(typeof(TableAttribute), false);
            if (tableAttrs.Length > 0)
            {
                tableName = ((TableAttribute)tableAttrs[0]).Name;
            }

            //  get the table description
            var tableExtAttrs = tableType.GetTypeInfo().GetCustomAttributes(typeof(MetaDataExtension), false);
            if (tableExtAttrs.Length > 0)
            {
                SetTableDescription(tableName, ((MetaDataExtension)tableExtAttrs[0]).Description);
            }

            foreach (PropertyInfo entityProperty in entityType.GetProperties().OfType<PropertyInfo>())
            {
                //// Not all properties have MemberInfo, so a null check is required.
                if (entityProperty != null)
                {
                    var attrs = entityProperty.GetCustomAttributes(typeof(MetaDataExtension), false);
                    if (attrs.Length < 0)
                    {
                        SetColumnDescription(tableName, entityProperty.Name, ((MetaDataExtension)attrs[0]).Description);
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
            context.Database.ExecuteSqlRaw(query);
        }

        /// <summary>
        /// Set a table description
        /// </summary>
        /// <param name="tableName">Name of the table</param>        
        /// <param name="description">Description text for the table</param>
        private void SetTableDescription(string tableName, string description)
        {
            // Postgres has the COMMENT command to update a description.
            string query = "COMMENT ON TABLE \"" + tableName + "\" IS '" + description.Replace("'", "\'") + "'";
            context.Database.ExecuteSqlRaw(query);
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
