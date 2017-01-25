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

namespace SchoolBusAPI.Models
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
        DbSet<CCWData> CCWDatas { get; set; }
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
        DbSet<ContactAddress> ContactAddresss { get; set; }
        DbSet<ContactPhone> ContactPhones { get; set; }
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
        public virtual DbSet<ContactAddress> ContactAddresss { get; set; }
        public virtual DbSet<ContactPhone> ContactPhones { get; set; }
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
    }
}
