using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Migrations
{
    [DbContext(typeof(DbAppContext))]
    [Migration("20161216224526_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("SchoolBusAPI.Models.BusNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.ToTable("BUS_NOTIFICATION");
                });

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

            modelBuilder.Entity("SchoolBusAPI.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("CityId")
                        .HasColumnName("CITY_ID");

                    b.Property<string>("Diff")
                        .HasColumnName("DIFF");

                    b.Property<int?>("FleetNum")
                        .HasColumnName("FLEET_NUM");

                    b.Property<string>("FleetSize")
                        .HasColumnName("FLEET_SIZE");

                    b.Property<int?>("HasBuses")
                        .HasColumnName("HAS_BUSES");

                    b.Property<int?>("HasDups")
                        .HasColumnName("HAS_DUPS");

                    b.Property<string>("LeaseSize")
                        .HasColumnName("LEASE_SIZE");

                    b.Property<string>("MCCode")
                        .HasColumnName("MCCODE");

                    b.Property<int?>("SchoolDistrictId")
                        .HasColumnName("SCHOOL_DISTRICT_ID");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("SchoolDistrictId");

                    b.ToTable("OWNER");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerAttachments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("OwnerId")
                        .HasColumnName("OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("OWNER_ATTACHMENTS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("OwnerId")
                        .HasColumnName("OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("OWNER_CONTACT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerContactAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("OwnerContactId")
                        .HasColumnName("OWNER_CONTACT_ID");

                    b.HasKey("Id");

                    b.HasIndex("OwnerContactId");

                    b.ToTable("OWNER_CONTACT_ADDRESS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerContactPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("OwnerContactId")
                        .HasColumnName("OWNER_CONTACT_ID");

                    b.HasKey("Id");

                    b.HasIndex("OwnerContactId");

                    b.ToTable("OWNER_CONTACT_PHONE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerNotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("OwnerId")
                        .HasColumnName("OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("OWNER_NOTES");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.HasKey("Id");

                    b.ToTable("REGION");
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

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnName("LAST_UPDATE");

                    b.Property<int?>("LesseeNumber")
                        .HasColumnName("LESSEE_NUMBER");

                    b.Property<DateTime?>("LicenseExpiryDate")
                        .HasColumnName("LICENSE_EXPIRY_DATE");

                    b.Property<string>("MCCap")
                        .HasColumnName("MCCAP");

                    b.Property<int?>("ManYear")
                        .HasColumnName("MAN_YEAR");

                    b.Property<DateTime?>("NextInspectionDate")
                        .HasColumnName("NEXT_INSPECTION_DATE");

                    b.Property<int?>("OwnerId")
                        .HasColumnName("OWNER_ID");

                    b.Property<DateTime?>("PermitExpiryDate")
                        .HasColumnName("PERMIT_EXPIRY_DATE");

                    b.Property<string>("Plate")
                        .HasColumnName("PLATE");

                    b.Property<string>("SBCap")
                        .HasColumnName("SBCAP");

                    b.Property<string>("WCCap")
                        .HasColumnName("WCCAP");

                    b.HasKey("Id");

                    b.HasIndex("CCWDataId");

                    b.HasIndex("OwnerId");

                    b.ToTable("SCHOOL_BUS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

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

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.ToTable("SCHOOL_BUS_NOTE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolDistrict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("LocalAreaId")
                        .HasColumnName("LOCAL_AREA_ID");

                    b.HasKey("Id");

                    b.HasIndex("LocalAreaId");

                    b.ToTable("SCHOOL_DISTRICT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL");

                    b.Property<string>("GivenName")
                        .HasColumnName("GIVEN_NAME");

                    b.Property<string>("SmUserid")
                        .HasColumnName("SM_USERID");

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

                    b.Property<string>("JsonData")
                        .HasColumnName("JSON_DATA");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("FavouriteContextTypeId");

                    b.ToTable("USER_FAVOURITE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserNotifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int?>("BusNotificationId")
                        .HasColumnName("BUS_NOTIFICATION_ID");

                    b.Property<int?>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("BusNotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("USER_NOTIFICATIONS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.BusNotification", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.City", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
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

            modelBuilder.Entity("SchoolBusAPI.Models.Owner", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("SchoolBusAPI.Models.SchoolDistrict", "SchoolDistrict")
                        .WithMany()
                        .HasForeignKey("SchoolDistrictId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerAttachments", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerContact", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerContactAddress", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.OwnerContact", "OwnerContact")
                        .WithMany()
                        .HasForeignKey("OwnerContactId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerContactPhone", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.OwnerContact", "OwnerContact")
                        .WithMany()
                        .HasForeignKey("OwnerContactId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.OwnerNotes", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBus", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.CCWData", "CCWData")
                        .WithMany()
                        .HasForeignKey("CCWDataId");

                    b.HasOne("SchoolBusAPI.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
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

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolDistrict", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.LocalArea", "LocalArea")
                        .WithMany()
                        .HasForeignKey("LocalAreaId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserFavourite", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.FavouriteContextType", "FavouriteContextType")
                        .WithMany()
                        .HasForeignKey("FavouriteContextTypeId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserNotifications", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.BusNotification", "BusNotification")
                        .WithMany()
                        .HasForeignKey("BusNotificationId");

                    b.HasOne("SchoolBusAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
