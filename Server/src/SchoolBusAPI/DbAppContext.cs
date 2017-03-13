/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolBusCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SchoolBusAPI.Models
{    
    public interface IDbAppContextFactory
    {
        IDbAppContext Create();
    }

    public class DbAppContextFactory : IDbAppContextFactory
    {
        DbContextOptions<DbAppContext> _options;
        IHttpContextAccessor _httpContextAccessor;

        public DbAppContextFactory(IHttpContextAccessor httpContextAccessor, DbContextOptions<DbAppContext> options)
        {
            _options = options;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDbAppContext Create()
        {
            return new DbAppContext(_httpContextAccessor, _options);
        }
    }

    public interface IDbAppContext
    {
        DbSet<CCWData> CCWDatas { get; set; }
        DbSet<CCWJurisdiction> CCWJurisdictions { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<GroupMembership> GroupMemberships { get; set; }
        DbSet<Inspection> Inspections { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<NotificationEvent> NotificationEvents { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }
        DbSet<SchoolBus> SchoolBuss { get; set; }
        DbSet<Attachment> Attachments { get; set; }       
        DbSet<History> Historys { get; set; }
        DbSet<Note> Notes { get; set; }
        DbSet<SchoolBusOwner> SchoolBusOwners { get; set; }        
        DbSet<Contact> Contacts { get; set; }
        DbSet<SchoolDistrict> SchoolDistricts { get; set; }
        DbSet<ServiceArea> ServiceAreas { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserFavourite> UserFavourites { get; set; }        
        DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Starts a new transaction.
        /// </summary>
        /// <returns>
        /// A Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction that represents
        /// the started transaction.
        /// </returns>
        IDbContextTransaction BeginTransaction();

        int SaveChanges();
    }

    public class DbAppContext : DbContext, IDbAppContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor for Class used for Entity Framework access.
        /// </summary>
        public DbAppContext(IHttpContextAccessor httpContextAccessor, DbContextOptions<DbAppContext> options)
                                : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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
        public virtual DbSet<CCWJurisdiction> CCWJurisdictions { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupMembership> GroupMemberships { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationEvent> NotificationEvents { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<SchoolBus> SchoolBuss { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<History> Historys { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<SchoolBusOwner> SchoolBusOwners { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<SchoolDistrict> SchoolDistricts { get; set; }
        public virtual DbSet<ServiceArea> ServiceAreas { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFavourite> UserFavourites { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }        

        /// <summary>
        /// Starts a new transaction.
        /// </summary>
        /// <returns>
        /// A Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction that represents
        /// the started transaction.
        /// </returns>
        public virtual IDbContextTransaction BeginTransaction()
        {
            bool existingTransaction = true;
            IDbContextTransaction transaction = this.Database.CurrentTransaction;
            if (transaction == null)
            {
                existingTransaction = false;
                transaction = this.Database.BeginTransaction();
            }
            return new DbContextTransactionWrapper(transaction, existingTransaction);
        }

        /// <summary>
        /// Returns the current web user
        /// </summary>
        protected ClaimsPrincipal HttpContextUser
        {
            get { return _httpContextAccessor.HttpContext.User; }
        }

        /// <summary>
        /// Returns the current user ID 
        /// </summary>
        /// <returns></returns>
        protected string GetCurrentUserId()
        {
            string result = null;

            try
            {
                result = HttpContextUser.FindFirst(ClaimTypes.Name).Value;
            }
            catch (Exception e)
            {
                result = null;
            }
            return result;
        }

        bool FieldHasChanged (EntityEntry entry, string fieldName)
        {
            bool result = false;

            // first check that the property is there.

            var property = entry.Metadata.FindProperty(fieldName);
            if (property != null)
            {
                var oldValue = entry.OriginalValues[fieldName];
                var newValue = entry.CurrentValues[fieldName];
                if (property.ClrType == typeof (int))
                {
                    result = oldValue != newValue;
                }
                else
                {
                    result = !oldValue.Equals(newValue);
                }
                
            }

            return result;
        }

        /// <summary>
        /// Adds the SchoolBus specific history entries
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="smUserId"></param>
        private void AddSchoolBusHistory(EntityEntry entry, string smUserId)
        {
            var schoolBus = (SchoolBus)entry.Entity;
            

            if (entry.State == EntityState.Added)
            {
                string ownerName = "Unknown Owner";
                int ownerId = -1;
                if (schoolBus.SchoolBusOwner != null)
                {
                    ownerName = schoolBus.SchoolBusOwner.Name;
                    ownerId = schoolBus.SchoolBusOwner.Id;
                }
                schoolBus.AddHistory("School Bus <<VIN " + schoolBus.VehicleIdentificationNumber + ":" + schoolBus.Id + ">> owned by <<" + ownerName + ":" + ownerId + ">> was added to the system.", smUserId);                               
            }
            else // update
            {
                string fieldName = "Status";
                if (FieldHasChanged(entry, fieldName))
                {
                    string value = (string) entry.CurrentValues[fieldName];
                    schoolBus.AddHistory("The status of School Bus <<VIN " + schoolBus.VehicleIdentificationNumber + ":" + schoolBus.Id + ">> was changed to " + value, smUserId);                    
                }

                fieldName = "PermitNumber";
                if (FieldHasChanged(entry, fieldName))
                {
                    int value = (int)entry.CurrentValues[fieldName];
                    schoolBus.AddHistory("The permit number for School Bus <<VIN " + schoolBus.VehicleIdentificationNumber + ":" + schoolBus.Id + ">> was changed to " + value, smUserId);                    
                }

                fieldName = "SchoolBusOwner";
                if (FieldHasChanged(entry, fieldName))
                {
                    string ownerName = "Unknown Owner";
                    int ownerId = -1;
                    if (schoolBus.SchoolBusOwner != null)
                    {
                        ownerName = schoolBus.SchoolBusOwner.Name;
                        ownerId = schoolBus.SchoolBusOwner.Id;
                    }
                    schoolBus.AddHistory("The owner for School Bus <<VIN " + schoolBus.VehicleIdentificationNumber + ":" + schoolBus.Id + ">> was changed to <<" + ownerName + ":" + ownerId + ">>.", smUserId);
                }

                schoolBus.AddHistory("Information for School Bus <<VIN " + schoolBus.VehicleIdentificationNumber + ":" + schoolBus.Id + ">> was updated.", smUserId);                    

            }
        }

        private void AddSchoolBusOwnerHistory(EntityEntry entry, string smUserId)
        {
            var schoolBusOwner = (SchoolBusOwner)entry.Entity;
            if (schoolBusOwner.History == null)
            {
                schoolBusOwner.History = new List<History>();
            }

            if (entry.State == EntityState.Added)
            {
                schoolBusOwner.AddHistory("School Bus Owner <<" + schoolBusOwner.Name + ":" + schoolBusOwner.Id + ">> was added to the system.", smUserId);                
            }
            else // update
            {
                string fieldName = "Status";
                if (FieldHasChanged(entry, fieldName))
                {
                    string value = (string)entry.CurrentValues[fieldName];
                    schoolBusOwner.AddHistory("The status of School Bus Owner <<" + schoolBusOwner.Name + ":" + schoolBusOwner.Id + ">> was changed to " + value, smUserId);                    
                }
                schoolBusOwner.AddHistory("Information for School Bus Owner <<" + schoolBusOwner.Name + ":" + schoolBusOwner.Id + ">> was updated.", smUserId);                
            }
        }

        /// <summary>
        /// Override for Save Changes to implement the audit log
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            // update the audit fields for this item.
            string smUserId = null;
            if (_httpContextAccessor != null)
                smUserId = GetCurrentUserId();

            var modifiedEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            DateTime currentTime = DateTime.UtcNow;

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity.GetType().InheritsOrImplements(typeof(AuditableEntity)))
                {
                    var theObject = (AuditableEntity)entry.Entity;
                    theObject.LastUpdateUserid = smUserId;
                    theObject.LastUpdateTimestamp = currentTime;

                    if (entry.State == EntityState.Added)
                    {
                        theObject.CreateUserid = smUserId;
                        theObject.CreateTimestamp = currentTime;
                    }
                }

                // add the SchoolBus specific history items 
                if (entry.Entity.GetType().InheritsOrImplements(typeof(SchoolBus)))
                {
                    AddSchoolBusHistory(entry, smUserId);
                }

                // add the SchoolBusOwner specific history items
                if (entry.Entity.GetType().InheritsOrImplements(typeof(SchoolBusOwner)))
                {
                    AddSchoolBusOwnerHistory(entry, smUserId);
                }
            }

            return base.SaveChanges();
        }
    }
}
