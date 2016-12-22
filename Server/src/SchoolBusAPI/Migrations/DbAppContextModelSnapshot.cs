using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Migrations
{
    [DbContext(typeof(DbAppContext))]
    partial class DbAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("SchoolBusAPI.Models.CCWData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Body")
                        .HasColumnName("BODY");

                    b.Property<string>("CVIPDecal")
                        .HasColumnName("CVIPDECAL");

                    b.Property<DateTime?>("CVIPExpiry")
                        .HasColumnName("CVIPEXPIRY");

                    b.Property<string>("Colour")
                        .HasColumnName("COLOUR");

                    b.Property<int?>("FleetUnitNo")
                        .HasColumnName("FLEET_UNIT_NO");

                    b.Property<string>("Fuel")
                        .HasColumnName("FUEL");

                    b.Property<int?>("GVW")
                        .HasColumnName("GVW");

                    b.Property<string>("Model")
                        .HasColumnName("MODEL");

                    b.Property<int?>("ModelYear")
                        .HasColumnName("MODEL_YEAR");

                    b.Property<int?>("NetWt")
                        .HasColumnName("NET_WT");

                    b.Property<string>("RateClass")
                        .HasColumnName("RATE_CLASS");

                    b.Property<string>("RebuiltStatus")
                        .HasColumnName("REBUILT_STATUS");

                    b.Property<int?>("SeatingCapacity")
                        .HasColumnName("SEATING_CAPACITY");

                    b.HasKey("Id");

                    b.ToTable("CCWDATA");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("RegionId")
                        .HasColumnName("REGION_ID");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("CITY");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.FavouriteContextType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("FAVOURITE_CONTEXT_TYPE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("GROUP");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.GroupMembership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("Active")
                        .HasColumnName("ACTIVE");

                    b.Property<int?>("GroupId")
                        .HasColumnName("GROUP_ID");

                    b.Property<int?>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GROUP_MEMBERSHIP");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("InspectorId")
                        .HasColumnName("INSPECTOR_ID");

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.HasKey("Id");

                    b.HasIndex("InspectorId");

                    b.HasIndex("SchoolBusId");

                    b.ToTable("INSPECTION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.LocalArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("RegionId")
                        .HasColumnName("REGION_ID");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("LOCAL_AREA");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("Event2Id")
                        .HasColumnName("EVENT2_ID");

                    b.Property<int?>("EventId")
                        .HasColumnName("EVENT_ID");

                    b.Property<bool?>("HasBeenViewed")
                        .HasColumnName("HAS_BEEN_VIEWED");

                    b.Property<bool?>("IsAllDay")
                        .HasColumnName("IS_ALL_DAY");

                    b.Property<bool?>("IsExpired")
                        .HasColumnName("IS_EXPIRED");

                    b.Property<bool?>("IsWatchNotification")
                        .HasColumnName("IS_WATCH_NOTIFICATION");

                    b.Property<string>("PriorityCode")
                        .HasColumnName("PRIORITY_CODE");

                    b.Property<int?>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("Event2Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("NOTIFICATION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.NotificationEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("EventSubTypeCode")
                        .HasColumnName("EVENT_SUB_TYPE_CODE");

                    b.Property<string>("EventTime")
                        .HasColumnName("EVENT_TIME");

                    b.Property<string>("EventTypeCode")
                        .HasColumnName("EVENT_TYPE_CODE");

                    b.Property<string>("Notes")
                        .HasColumnName("NOTES");

                    b.Property<bool?>("NotificationGenerated")
                        .HasColumnName("NOTIFICATION_GENERATED");

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.ToTable("NOTIFICATION_EVENT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .HasColumnName("CODE");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("PERMISSION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("REGION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("ROLE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("PermisionId")
                        .HasColumnName("PERMISION_ID");

                    b.Property<int?>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.HasKey("Id");

                    b.HasIndex("PermisionId");

                    b.HasIndex("RoleId");

                    b.ToTable("ROLE_PERMISSION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("CCWDataId")
                        .HasColumnName("CCWDATA_ID");

                    b.Property<string>("CRNO")
                        .HasColumnName("CRNO");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("IS_ACTIVE");

                    b.Property<bool?>("IsOutOfProvince")
                        .HasColumnName("IS_OUT_OF_PROVINCE");

                    b.Property<string>("NameOfIndependentSchool")
                        .HasColumnName("NAME_OF_INDEPENDENT_SCHOOL");

                    b.Property<DateTime?>("NextInspection")
                        .HasColumnName("NEXT_INSPECTION");

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("CCWDataId");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SCHOOL_BUS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("ExternalFileName")
                        .HasColumnName("EXTERNAL_FILE_NAME");

                    b.Property<string>("InternalFileName")
                        .HasColumnName("INTERNAL_FILE_NAME");

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.ToTable("SCHOOL_BUS_ATTACHMENT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.ToTable("SCHOOL_BUS_HISTORY");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool?>("Expired")
                        .HasColumnName("EXPIRED");

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.Property<string>("Value")
                        .HasColumnName("VALUE");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.ToTable("SCHOOL_BUS_NOTE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("CityId")
                        .HasColumnName("CITY_ID");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnName("DATE_CREATED");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("IS_ACTIVE");

                    b.Property<int?>("LocalAreaId")
                        .HasColumnName("LOCAL_AREA_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.Property<int?>("PrimaryContactRefId")
                        .HasColumnName("PRIMARY_CONTACT_REF_ID");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("LocalAreaId");

                    b.HasIndex("PrimaryContactRefId")
                        .IsUnique();

                    b.ToTable("SCHOOL_BUS_OWNER");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SCHOOL_BUS_OWNER_ATTACHMENT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.HasKey("Id");

                    b.ToTable("SCHOOL_BUS_OWNER_CONTACT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerContactAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("SchoolBusOwnerContactId")
                        .HasColumnName("SCHOOL_BUS_OWNER_CONTACT_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusOwnerContactId");

                    b.ToTable("SCHOOL_BUS_OWNER_CONTACT_ADDRESS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerContactPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("SchoolBusOwnerContactId")
                        .HasColumnName("SCHOOL_BUS_OWNER_CONTACT_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusOwnerContactId");

                    b.ToTable("SCHOOL_BUS_OWNER_CONTACT_PHONE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SCHOOL_BUS_OWNER_HISTORY");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool?>("Expired")
                        .HasColumnName("EXPIRED");

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SCHOOL_BUS_OWNER_NOTE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolDistrict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("RegionId")
                        .HasColumnName("REGION_ID");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("SCHOOL_DISTRICT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("Active")
                        .HasColumnName("ACTIVE");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL");

                    b.Property<string>("GivenName")
                        .HasColumnName("GIVEN_NAME");

                    b.Property<string>("Guid")
                        .HasColumnName("GUID");

                    b.Property<string>("Initials")
                        .HasColumnName("INITIALS");

                    b.Property<string>("SmAuthorizationDirectory")
                        .HasColumnName("SM_AUTHORIZATION_DIRECTORY");

                    b.Property<string>("SmUserId")
                        .HasColumnName("SM_USER_ID");

                    b.Property<string>("Surname")
                        .HasColumnName("SURNAME");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserFavourite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("FavouriteContextTypeId")
                        .HasColumnName("FAVOURITE_CONTEXT_TYPE_ID");

                    b.Property<bool?>("IsDefault")
                        .HasColumnName("IS_DEFAULT");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.Property<string>("Value")
                        .HasColumnName("VALUE");

                    b.HasKey("Id");

                    b.HasIndex("FavouriteContextTypeId");

                    b.ToTable("USER_FAVOURITE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnName("EFFECTIVE_DATE");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnName("EXPIRY_DATE");

                    b.Property<int?>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.Property<int?>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("USER_ROLE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.City", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.GroupMembership", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("SchoolBusAPI.Models.User", "User")
                        .WithMany("GroupMemberships")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Inspection", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.User", "Inspector")
                        .WithMany()
                        .HasForeignKey("InspectorId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.LocalArea", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Notification", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.NotificationEvent", "Event2")
                        .WithMany()
                        .HasForeignKey("Event2Id");

                    b.HasOne("SchoolBusAPI.Models.NotificationEvent", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("SchoolBusAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.NotificationEvent", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.RolePermission", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Permission", "Permision")
                        .WithMany()
                        .HasForeignKey("PermisionId");

                    b.HasOne("SchoolBusAPI.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBus", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.CCWData", "CCWData")
                        .WithMany()
                        .HasForeignKey("CCWDataId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner", "SchoolBusOwner")
                        .WithMany()
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusAttachment", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusHistory", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusNote", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwner", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("SchoolBusAPI.Models.LocalArea", "LocalArea")
                        .WithMany()
                        .HasForeignKey("LocalAreaId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwnerContact", "PrimaryContact")
                        .WithOne("SchoolBusOwner")
                        .HasForeignKey("SchoolBusAPI.Models.SchoolBusOwner", "PrimaryContactRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerAttachment", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner", "SchoolBusOwner")
                        .WithMany()
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerContactAddress", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwnerContact", "SchoolBusOwnerContact")
                        .WithMany()
                        .HasForeignKey("SchoolBusOwnerContactId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerContactPhone", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwnerContact", "SchoolBusOwnerContact")
                        .WithMany()
                        .HasForeignKey("SchoolBusOwnerContactId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerHistory", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner", "SchoolBusOwner")
                        .WithMany()
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwnerNote", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner", "SchoolBusOwner")
                        .WithMany()
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolDistrict", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserFavourite", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.FavouriteContextType", "FavouriteContextType")
                        .WithMany()
                        .HasForeignKey("FavouriteContextTypeId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserRole", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("SchoolBusAPI.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
