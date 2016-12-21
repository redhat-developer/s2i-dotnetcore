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
using System.Collections.Generic;

namespace SchoolBusAPI.Models
{

    public interface IDbAppContext
    {
        DbSet<CCWData> CCWDatas { get; set; }

        DbSet<City> Cities { get; set; }
        DbSet<FavouriteContextType> FavouriteContextTypes { get; set; }
        DbSet<Inspection> Inspections { get; set; }
        DbSet<LocalArea> LocalAreas { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<NotificationEvent> NotificationEvents { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<SchoolBus> SchoolBuss { get; set; }
        DbSet<SchoolBusAttachment> SchoolBusAttachments { get; set; }
        DbSet<SchoolBusHistory> SchoolBusHistorys { get; set; }
        DbSet<SchoolBusNote> SchoolBusNotes { get; set; }
        DbSet<SchoolBusOwner> SchoolBusOwners { get; set; }
        DbSet<SchoolBusOwnerAttachment> SchoolBusOwnerAttachments { get; set; }
        DbSet<SchoolBusOwnerContact> SchoolBusOwnerContacts { get; set; }
        DbSet<SchoolBusOwnerContactAddress> SchoolBusOwnerContactAddresss { get; set; }
        DbSet<SchoolBusOwnerContactPhone> SchoolBusOwnerContactPhones { get; set; }
        DbSet<SchoolBusOwnerHistory> SchoolBusOwnerHistorys { get; set; }
        DbSet<SchoolBusOwnerNote> SchoolBusOwnerNotes { get; set; }
        DbSet<SchoolDistrict> SchoolDistricts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserFavourite> UserFavourites { get; set; }
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

        
    }
}
