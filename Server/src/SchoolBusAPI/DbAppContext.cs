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

        public virtual DbSet<BusNotification> BusNotifications { get; set; } 
        public virtual DbSet<CCWData> CCWDatas { get; set; } 
        public virtual DbSet<City> Citys { get; set; } 
        public virtual DbSet<FavoriteContextType> FavoriteContextTypes { get; set; } 
        public virtual DbSet<Inspection> Inspections { get; set; } 
        public virtual DbSet<LocalArea> LocalAreas { get; set; } 
        public virtual DbSet<Owner> Owners { get; set; } 
        public virtual DbSet<OwnerAttachments> OwnerAttachmentss { get; set; } 
        public virtual DbSet<OwnerContact> OwnerContacts { get; set; } 
        public virtual DbSet<OwnerContactAddress> OwnerContactAddresss { get; set; } 
        public virtual DbSet<OwnerContactPhone> OwnerContactPhones { get; set; } 
        public virtual DbSet<OwnerNotes> OwnerNotess { get; set; } 
        public virtual DbSet<Region> Regions { get; set; } 
        public virtual DbSet<SchoolBus> SchoolBuss { get; set; } 
        public virtual DbSet<SchoolBusAttachment> SchoolBusAttachments { get; set; } 
        public virtual DbSet<SchoolBusHistory> SchoolBusHistorys { get; set; } 
        public virtual DbSet<SchoolBusNote> SchoolBusNotes { get; set; } 
        public virtual DbSet<SchoolDistrict> SchoolDistricts { get; set; } 
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<UserFavorite> UserFavorites { get; set; } 
        public virtual DbSet<UserNotifications> UserNotificationss { get; set; } 

        // public DbSet<Classname> Classname { get; set; }
        
    }
}
