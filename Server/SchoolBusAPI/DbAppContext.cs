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
using Serilog;
using SchoolBusAPI.Extensions;
using SchoolBusAPI.ViewModels;
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
        DbSet<CCWNotification> CCWNotifications { get; set; }

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
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        /// <summary>
        /// Override for OnModelCreating - used to change the database naming convention.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add our naming convention extension
            modelBuilder.UpperCaseUnderscoreSingularConvention();

            modelBuilder.Entity<Contact>()
                .HasOne(s => s.SchoolBusOwner)
                .WithMany(g => g.Contacts);

            /*
            // Npgsql 6+ datetime type issue
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? v.Value.ToUniversalTime() : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.IsKeyless)
                {
                    continue;
                }

                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(nullableDateTimeConverter);
                    }
                }
            }
            */
        }

        public virtual DbSet<Audit> Audits { get; set; }
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
        public virtual DbSet<CCWNotification> CCWNotifications { get; set; }

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
            get { return _httpContextAccessor.HttpContext?.User; }
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
                result = HttpContextUser?.FindFirst(ClaimTypes.Name).Value;
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        protected User GetCurrentUser()
        {
            User result = null;

            try
            {
                string userId = HttpContextUser?.FindFirst(SchoolBusAPI.Models.User.USERID_CLAIM).Value;
                int id = int.Parse(userId);
                result = Users.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        bool FieldHasChanged(EntityEntry entry, string fieldName)
        {
            bool result = false;

            // first check that the property is there.

            var property = entry.Metadata.FindProperty(fieldName);
            if (property != null)
            {
                var oldValue = entry.OriginalValues[fieldName];
                var newValue = entry.CurrentValues[fieldName];
                if (property.ClrType == typeof(int))
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
        /// Override for Save Changes to implement the audit log
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            List<Audit> auditEntries = new List<Audit>();            

            // update the audit fields for this item.
            string smUserId = null;
            User currentUser = null;

            if (_httpContextAccessor != null)
            {
                smUserId = GetCurrentUserId();
                currentUser = GetCurrentUser();
            }
                                        
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted).ToList();

            DateTime currentTime = DateTime.UtcNow;

            foreach (var entry in modifiedEntries)
            {
                // handle the table level audit fields
                if ((entry.State == EntityState.Added || entry.State == EntityState.Modified) && entry.Entity.GetType().InheritsOrImplements(typeof(AuditableEntity)))
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

                if (currentUser != null)
                {
                    try
                    {
                        int affectedEntityId = (int)entry.CurrentValues["Id"];

                        string entityName = Model.FindEntityType(entry.Entity.GetType()).GetTableName();

                        if (entry.State == EntityState.Deleted)
                        {
                            // update the Audit log for the delete record
                            Audit audit = new Audit();
                            audit.AppLastUpdateTimestamp = currentTime;
                            audit.AppLastUpdateUserDirectory = currentUser.SmAuthorizationDirectory;
                            audit.AppLastUpdateUserGuid = currentUser.Guid;
                            audit.AppLastUpdateUserid = smUserId;
                            audit.CreateTimestamp = currentTime;
                            audit.CreateUserid = smUserId;
                            audit.EntityName = entityName;
                            audit.EntityId = affectedEntityId;
                            audit.LastUpdateTimestamp = currentTime;
                            audit.LastUpdateUserid = smUserId;
                            audit.IsDelete = true;
                            auditEntries.Add(audit);
                        }
                        else
                        {

                            // loop through the fields and determine any changes.
                            foreach (var item in entry.Properties)
                            {
                                if (item.IsModified || entry.State == EntityState.Added)
                                {
                                    // create an audit entry for this item.
                                    Audit audit = new Audit();
                                    audit.AppLastUpdateTimestamp = currentTime;
                                    audit.AppLastUpdateUserDirectory = currentUser.SmAuthorizationDirectory;
                                    audit.AppLastUpdateUserGuid = currentUser.Guid;
                                    audit.AppLastUpdateUserid = smUserId;
                                    audit.CreateTimestamp = currentTime;
                                    audit.CreateUserid = smUserId;
                                    audit.EntityName = entityName;
                                    audit.EntityId = affectedEntityId;
                                    audit.LastUpdateTimestamp = currentTime;
                                    audit.LastUpdateUserid = smUserId;

                                    if (entry.State == EntityState.Added)
                                    {
                                        audit.AppCreateTimestamp = currentTime;
                                        audit.AppCreateUserid = smUserId;
                                        audit.AppCreateUserGuid = currentUser.Guid;
                                        audit.AppCreateUserDirectory = currentUser.SmAuthorizationDirectory;
                                    }

                                    if (item.OriginalValue != null)
                                    {
                                        audit.OldValue = item.OriginalValue.ToString();
                                    }
                                    if (item.CurrentValue != null)
                                    {
                                        audit.NewValue = item.CurrentValue.ToString();
                                    }
                                    audit.PropertyName = item.Metadata.GetColumnName();
                                    auditEntries.Add(audit);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string exceptionMessage = e.ToString();
                        Log.Error($"DbAppContext exception: {exceptionMessage}");
                    }
                }
            }

            int result = base.SaveChanges();

            // Add the audit entries. 
            if (auditEntries.Count > 0)
            {
                foreach (var item in auditEntries)
                {
                    Audits.Add(item);
                    base.SaveChanges();
                }                
            }

            return result;
        }

        public List<ChangeViewModel> GetAllChanges<T>(T entity, params string[] fieldsToSkip)
        {
            var changes = new List<ChangeViewModel>();

            var entry = Entry(entity);

            var auditProperties = typeof(AuditableEntity).GetProperties();

            foreach (var property in typeof(T).GetProperties())
            {
                if (fieldsToSkip.Any(x => x == property.Name))
                    continue;

                if (auditProperties.Any(x => x.Name == property.Name))
                    continue;

                if (entry.Property(property.Name).IsModified)
                {
                    var valueFrom = entry.OriginalValues[property.Name]?.GetType() == typeof(DateTime) ? 
                        ((DateTime?)entry.OriginalValues[property.Name])?.ToString("yyyy-MM-dd") : entry.OriginalValues[property.Name]?.ToString();

                    var valueTo = entry.CurrentValues[property.Name]?.GetType() == typeof(DateTime) ?
                        ((DateTime?)entry.CurrentValues[property.Name])?.ToString("yyyy-MM-dd") : entry.CurrentValues[property.Name]?.ToString();

                    changes.Add(new ChangeViewModel
                    {
                        ColName = property.Name,
                        ColDescription = property.Name.WordToWords(),
                        ValueFrom = valueFrom ?? "",
                        ValueTo = valueTo ?? ""
                    });
                }
            }

            return changes;
        }

        public List<ChangeViewModel> GetChanges<T>(T entity, params string[] fields)
        {
            var changes = new List<ChangeViewModel>();

            var entry = Entry(entity);

            foreach (var property in typeof(T).GetProperties())
            {
                if (!fields.Any(x => x == property.Name))
                    continue;

                if (entry.Property(property.Name).IsModified)
                {
                    var valueFrom = entry.OriginalValues[property.Name]?.GetType() == typeof(DateTime) ?
                        ((DateTime?)entry.OriginalValues[property.Name])?.ToString("yyyy-MM-dd") : entry.OriginalValues[property.Name]?.ToString();

                    var valueTo = entry.CurrentValues[property.Name]?.GetType() == typeof(DateTime) ?
                        ((DateTime?)entry.CurrentValues[property.Name])?.ToString("yyyy-MM-dd") : entry.CurrentValues[property.Name]?.ToString();

                    changes.Add(new ChangeViewModel
                    {
                        ColName = property.Name,
                        ColDescription = property.Name.WordToWords(),
                        ValueFrom = valueFrom ?? "",
                        ValueTo = valueTo ?? ""
                    });
                }
            }

            return changes;
        }
    }
}
