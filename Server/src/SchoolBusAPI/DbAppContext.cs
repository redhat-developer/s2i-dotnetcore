/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */


using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace SchoolBusAPI.Models
{

	public class DbAppContext : DbContext
    {
        /// <summary>
        /// Constructor used by automated tests
        /// </summary>
         public DbAppContext()
       : base()
        { }

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
            modelBuilder.UpperCaseUnderscoreSingularConvention();                        
        }
			
        // Add methods here to get and set items in the model.
        // For example:

        public virtual DbSet<CCWData> CCWDatas { get; set; } 
        public virtual DbSet<City> Cities { get; set; } 
        public virtual DbSet<FavouriteContextType> FavouriteContextTypes { get; set; } 
        public virtual DbSet<Inspection> Inspections { get; set; } 
        public virtual DbSet<LocalArea> LocalAreas { get; set; } 
        public virtual DbSet<Notification> Notifications { get; set; } 
        public virtual DbSet<NotificationEvent> NotificationEvents { get; set; } 
        public virtual DbSet<Region> Regions { get; set; } 
        public virtual DbSet<SchoolBus> SchoolBuss { get; set; } 
        public virtual DbSet<SchoolBusAttachment> SchoolBusAttachments { get; set; } 
        public virtual DbSet<SchoolBusHistory> SchoolBusHistorys { get; set; } 
        public virtual DbSet<SchoolBusNote> SchoolBusNotes { get; set; } 
        public virtual DbSet<SchoolBusOwner> SchoolBusOwners { get; set; } 
        public virtual DbSet<SchoolBusOwnerAttachment> SchoolBusOwnerAttachments { get; set; } 
        public virtual DbSet<SchoolBusOwnerContact> SchoolBusOwnerContacts { get; set; } 
        public virtual DbSet<SchoolBusOwnerContactAddress> SchoolBusOwnerContactAddresss { get; set; } 
        public virtual DbSet<SchoolBusOwnerContactPhone> SchoolBusOwnerContactPhones { get; set; } 
        public virtual DbSet<SchoolBusOwnerHistory> SchoolBusOwnerHistorys { get; set; } 
        public virtual DbSet<SchoolBusOwnerNote> SchoolBusOwnerNotes { get; set; } 
        public virtual DbSet<SchoolDistrict> SchoolDistricts { get; set; } 
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<UserFavourite> UserFavourites { get; set; } 

        // public DbSet<Classname> Classname { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = 127.0.0.1; Username = test; Password = test161107; Database = test");
        }
    }
}
