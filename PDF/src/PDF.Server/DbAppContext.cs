/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace PDF.Models
{
    public interface IDbAppContextFactory
    {
        IDbAppContext Create();
    }

    public class DbAppContextFactory : IDbAppContextFactory
    {
        DbContextOptions<DbAppContext> _options;

        public DbAppContextFactory(DbContextOptions<DbAppContext> options)
        {
            _options = options;
        }

        public IDbAppContext Create()
        {
            return new DbAppContext(_options);
        }
    }

    public interface IDbAppContext
    {
           
        int SaveChanges();
    }

    public class DbAppContext : DbContext, IDbAppContext
    {
        /// <summary>
        /// Constructor for Class used for Entity Framework access.
        /// </summary>
        public DbAppContext(DbContextOptions<DbAppContext> options)
                                : base(options)
        { }

        /// <summary>
        /// Override for OnModelCreating - used to change the database naming convention.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add our naming convention extension
            //modelBuilder.UpperCaseUnderscoreSingularConvention();
        }

        // Add methods here to get and set items in the model.
        // For example:

     
        
    }
}
