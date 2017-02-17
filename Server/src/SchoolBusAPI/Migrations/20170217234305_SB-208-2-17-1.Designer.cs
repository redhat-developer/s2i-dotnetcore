using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Migrations
{
    [DbContext(typeof(DbAppContext))]
    [Migration("20170217234305_SB-208-2-17-1")]
    partial class SB2082171
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("SchoolBusAPI.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ATTACHMENT_ID");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(2048);

                    b.Property<string>("ExternalFileName")
                        .HasColumnName("EXTERNAL_FILE_NAME")
                        .HasMaxLength(2048);

                    b.Property<string>("InternalFileName")
                        .HasColumnName("INTERNAL_FILE_NAME")
                        .HasMaxLength(2048);

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SBI_ATTACHMENT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.CCWData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CCWDATA_ID");

                    b.Property<string>("ICBCBody")
                        .HasColumnName("ICBCBODY")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCCVIPDecal")
                        .HasColumnName("ICBCCVIPDECAL")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ICBCCVIPExpiry")
                        .HasColumnName("ICBCCVIPEXPIRY");

                    b.Property<string>("ICBCColour")
                        .HasColumnName("ICBCCOLOUR")
                        .HasMaxLength(255);

                    b.Property<int?>("ICBCFleetUnitNo")
                        .HasColumnName("ICBCFLEET_UNIT_NO");

                    b.Property<string>("ICBCFuel")
                        .HasColumnName("ICBCFUEL")
                        .HasMaxLength(255);

                    b.Property<int?>("ICBCGrossVehicleWeight")
                        .HasColumnName("ICBCGROSS_VEHICLE_WEIGHT");

                    b.Property<string>("ICBCLicencePlateNumber")
                        .HasColumnName("ICBCLICENCE_PLATE_NUMBER")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCMake")
                        .HasColumnName("ICBCMAKE")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCModel")
                        .HasColumnName("ICBCMODEL")
                        .HasMaxLength(255);

                    b.Property<int?>("ICBCModelYear")
                        .HasColumnName("ICBCMODEL_YEAR");

                    b.Property<int?>("ICBCNetWt")
                        .HasColumnName("ICBCNET_WT");

                    b.Property<string>("ICBCNotesAndOrders")
                        .HasColumnName("ICBCNOTES_AND_ORDERS")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ICBCOrderedOn")
                        .HasColumnName("ICBCORDERED_ON");

                    b.Property<string>("ICBCRateClass")
                        .HasColumnName("ICBCRATE_CLASS")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRebuiltStatus")
                        .HasColumnName("ICBCREBUILT_STATUS")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerAddr1")
                        .HasColumnName("ICBCREG_OWNER_ADDR1")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerAddr2")
                        .HasColumnName("ICBCREG_OWNER_ADDR2")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerCity")
                        .HasColumnName("ICBCREG_OWNER_CITY")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerName")
                        .HasColumnName("ICBCREG_OWNER_NAME")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerPODL")
                        .HasColumnName("ICBCREG_OWNER_PODL")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerPostalCode")
                        .HasColumnName("ICBCREG_OWNER_POSTAL_CODE")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerProv")
                        .HasColumnName("ICBCREG_OWNER_PROV")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerRODL")
                        .HasColumnName("ICBCREG_OWNER_RODL")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegOwnerStatus")
                        .HasColumnName("ICBCREG_OWNER_STATUS")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCRegistrationNumber")
                        .HasColumnName("ICBCREGISTRATION_NUMBER")
                        .HasMaxLength(255);

                    b.Property<int?>("ICBCSeatingCapacity")
                        .HasColumnName("ICBCSEATING_CAPACITY");

                    b.Property<string>("ICBCVehicleIdentificationNumber")
                        .HasColumnName("ICBCVEHICLE_IDENTIFICATION_NUMBER")
                        .HasMaxLength(255);

                    b.Property<string>("ICBCVehicleType")
                        .HasColumnName("ICBCVEHICLE_TYPE")
                        .HasMaxLength(255);

                    b.Property<string>("NSCCarrierConditions")
                        .HasColumnName("NSCCARRIER_CONDITIONS")
                        .HasMaxLength(255);

                    b.Property<string>("NSCCarrierName")
                        .HasColumnName("NSCCARRIER_NAME")
                        .HasMaxLength(255);

                    b.Property<string>("NSCCarrierSafetyRating")
                        .HasColumnName("NSCCARRIER_SAFETY_RATING")
                        .HasMaxLength(255);

                    b.Property<string>("NSCClientNum")
                        .HasColumnName("NSCCLIENT_NUM")
                        .HasMaxLength(255);

                    b.Property<string>("NSCPlateDecal")
                        .HasColumnName("NSCPLATE_DECAL")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("NSCPolicyEffectiveDate")
                        .HasColumnName("NSCPOLICY_EFFECTIVE_DATE");

                    b.Property<DateTime?>("NSCPolicyExpiryDate")
                        .HasColumnName("NSCPOLICY_EXPIRY_DATE");

                    b.Property<string>("NSCPolicyNumber")
                        .HasColumnName("NSCPOLICY_NUMBER")
                        .HasMaxLength(255);

                    b.Property<string>("NSCPolicyStatus")
                        .HasColumnName("NSCPOLICY_STATUS")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("NSCPolicyStatusDate")
                        .HasColumnName("NSCPOLICY_STATUS_DATE");

                    b.HasKey("Id");

                    b.ToTable("SBI_CCWDATA");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.CCWJurisdiction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CCWJURISDICTION_ID");

                    b.Property<bool?>("ActiveFlag")
                        .HasColumnName("ACTIVE_FLAG");

                    b.Property<string>("Code")
                        .HasColumnName("CODE")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("EffectiveDate")
                        .HasColumnName("EFFECTIVE_DATE");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnName("EXPIRY_DATE");

                    b.Property<int?>("JurisdictionId")
                        .HasColumnName("JURISDICTION_ID");

                    b.HasKey("Id");

                    b.ToTable("SBI_CCWJURISDICTION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CITY_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.Property<string>("Province")
                        .HasColumnName("PROVINCE")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SBI_CITY");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CONTACT_ID");

                    b.Property<string>("GivenName")
                        .HasColumnName("GIVEN_NAME")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasColumnName("NOTES")
                        .HasMaxLength(150);

                    b.Property<string>("Role")
                        .HasColumnName("ROLE")
                        .HasMaxLength(100);

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.Property<string>("Surname")
                        .HasColumnName("SURNAME")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SBI_CONTACT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.ContactAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CONTACT_ADDRESS_ID");

                    b.Property<string>("Address1")
                        .HasColumnName("ADDRESS1")
                        .HasMaxLength(80);

                    b.Property<string>("Address2")
                        .HasColumnName("ADDRESS2")
                        .HasMaxLength(80);

                    b.Property<string>("City")
                        .HasColumnName("CITY")
                        .HasMaxLength(100);

                    b.Property<int?>("ContactId")
                        .HasColumnName("CONTACT_ID");

                    b.Property<string>("PostalCode")
                        .HasColumnName("POSTAL_CODE")
                        .HasMaxLength(15);

                    b.Property<string>("Province")
                        .HasColumnName("PROVINCE")
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .HasColumnName("TYPE")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("SBI_CONTACT_ADDRESS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.ContactPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CONTACT_PHONE_ID");

                    b.Property<int?>("ContactId")
                        .HasColumnName("CONTACT_ID");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PHONE_NUMBER")
                        .HasMaxLength(20);

                    b.Property<string>("Type")
                        .HasColumnName("TYPE")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("SBI_CONTACT_PHONE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DISTRICT_ID");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnName("END_DATE");

                    b.Property<int>("MinistryDistrictID")
                        .HasColumnName("MINISTRY_DISTRICT_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.Property<int?>("RegionRefId")
                        .HasColumnName("REGION_REF_ID");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnName("START_DATE");

                    b.HasKey("Id");

                    b.HasIndex("RegionRefId");

                    b.ToTable("SBI_DISTRICT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GROUP_ID");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SBI_GROUP");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.GroupMembership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GROUP_MEMBERSHIP_ID");

                    b.Property<bool>("Active")
                        .HasColumnName("ACTIVE");

                    b.Property<int?>("GroupRefId")
                        .HasColumnName("GROUP_REF_ID");

                    b.Property<int?>("UserRefId")
                        .HasColumnName("USER_REF_ID");

                    b.HasKey("Id");

                    b.HasIndex("GroupRefId");

                    b.HasIndex("UserRefId");

                    b.ToTable("SBI_GROUP_MEMBERSHIP");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("HISTORY_ID");

                    b.Property<string>("HistoryText")
                        .HasColumnName("HISTORY_TEXT")
                        .HasMaxLength(2048);

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SBI_HISTORY");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("INSPECTION_ID");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnName("INSPECTION_DATE");

                    b.Property<string>("InspectionResultCode")
                        .HasColumnName("INSPECTION_RESULT_CODE")
                        .HasMaxLength(255);

                    b.Property<string>("InspectionTypeCode")
                        .HasColumnName("INSPECTION_TYPE_CODE")
                        .HasMaxLength(255);

                    b.Property<int?>("InspectorRefId")
                        .HasColumnName("INSPECTOR_REF_ID");

                    b.Property<string>("Notes")
                        .HasColumnName("NOTES")
                        .HasMaxLength(2048);

                    b.Property<string>("RIPInspectionId")
                        .HasColumnName("RIPINSPECTION_ID")
                        .HasMaxLength(255);

                    b.Property<int?>("SchoolBusRefId")
                        .HasColumnName("SCHOOL_BUS_REF_ID");

                    b.HasKey("Id");

                    b.HasIndex("InspectorRefId");

                    b.HasIndex("SchoolBusRefId");

                    b.ToTable("SBI_INSPECTION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NOTE_ID");

                    b.Property<bool?>("IsNoLongerRelevant")
                        .HasColumnName("IS_NO_LONGER_RELEVANT");

                    b.Property<string>("NoteText")
                        .HasColumnName("NOTE_TEXT")
                        .HasMaxLength(2048);

                    b.Property<int?>("SchoolBusId")
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.Property<int?>("SchoolBusOwnerId")
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusId");

                    b.HasIndex("SchoolBusOwnerId");

                    b.ToTable("SBI_NOTE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NOTIFICATION_ID");

                    b.Property<int?>("Event2RefId")
                        .HasColumnName("EVENT2_REF_ID");

                    b.Property<int?>("EventRefId")
                        .HasColumnName("EVENT_REF_ID");

                    b.Property<bool?>("HasBeenViewed")
                        .HasColumnName("HAS_BEEN_VIEWED");

                    b.Property<bool?>("IsAllDay")
                        .HasColumnName("IS_ALL_DAY");

                    b.Property<bool?>("IsExpired")
                        .HasColumnName("IS_EXPIRED");

                    b.Property<bool?>("IsWatchNotification")
                        .HasColumnName("IS_WATCH_NOTIFICATION");

                    b.Property<string>("PriorityCode")
                        .HasColumnName("PRIORITY_CODE")
                        .HasMaxLength(255);

                    b.Property<int?>("UserRefId")
                        .HasColumnName("USER_REF_ID");

                    b.HasKey("Id");

                    b.HasIndex("Event2RefId");

                    b.HasIndex("EventRefId");

                    b.HasIndex("UserRefId");

                    b.ToTable("SBI_NOTIFICATION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.NotificationEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NOTIFICATION_EVENT_ID");

                    b.Property<string>("EventSubTypeCode")
                        .HasColumnName("EVENT_SUB_TYPE_CODE")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("EventTime")
                        .HasColumnName("EVENT_TIME");

                    b.Property<string>("EventTypeCode")
                        .HasColumnName("EVENT_TYPE_CODE")
                        .HasMaxLength(255);

                    b.Property<string>("Notes")
                        .HasColumnName("NOTES")
                        .HasMaxLength(2048);

                    b.Property<bool?>("NotificationGenerated")
                        .HasColumnName("NOTIFICATION_GENERATED");

                    b.Property<int?>("SchoolBusRefId")
                        .HasColumnName("SCHOOL_BUS_REF_ID");

                    b.HasKey("Id");

                    b.HasIndex("SchoolBusRefId");

                    b.ToTable("SBI_NOTIFICATION_EVENT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PERMISSION_ID");

                    b.Property<string>("Code")
                        .HasColumnName("CODE")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SBI_PERMISSION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("REGION_ID");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnName("END_DATE");

                    b.Property<int>("MinistryRegionID")
                        .HasColumnName("MINISTRY_REGION_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnName("START_DATE");

                    b.HasKey("Id");

                    b.ToTable("SBI_REGION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ROLE_ID");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SBI_ROLE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ROLE_PERMISSION_ID");

                    b.Property<int?>("PermissionRefId")
                        .HasColumnName("PERMISSION_REF_ID");

                    b.Property<int?>("RoleRefId")
                        .HasColumnName("ROLE_REF_ID");

                    b.HasKey("Id");

                    b.HasIndex("PermissionRefId");

                    b.HasIndex("RoleRefId");

                    b.ToTable("SBI_ROLE_PERMISSION");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SCHOOL_BUS_ID");

                    b.Property<string>("BodyTypeCode")
                        .HasColumnName("BODY_TYPE_CODE")
                        .HasMaxLength(50);

                    b.Property<int?>("CCWDataRefId")
                        .HasColumnName("CCWDATA_REF_ID");

                    b.Property<int?>("CCWJurisdictionRefId")
                        .HasColumnName("CCWJURISDICTION_REF_ID");

                    b.Property<int?>("DistrictRefId")
                        .HasColumnName("DISTRICT_REF_ID");

                    b.Property<string>("HomeTerminalAddress1")
                        .HasColumnName("HOME_TERMINAL_ADDRESS1")
                        .HasMaxLength(80);

                    b.Property<string>("HomeTerminalAddress2")
                        .HasColumnName("HOME_TERMINAL_ADDRESS2")
                        .HasMaxLength(80);

                    b.Property<int?>("HomeTerminalCityRefId")
                        .HasColumnName("HOME_TERMINAL_CITY_REF_ID");

                    b.Property<string>("HomeTerminalComment")
                        .HasColumnName("HOME_TERMINAL_COMMENT")
                        .HasMaxLength(2048);

                    b.Property<string>("HomeTerminalPostalCode")
                        .HasColumnName("HOME_TERMINAL_POSTAL_CODE")
                        .HasMaxLength(15);

                    b.Property<string>("HomeTerminalProvince")
                        .HasColumnName("HOME_TERMINAL_PROVINCE")
                        .HasMaxLength(40);

                    b.Property<string>("ICBCRegistrationNumber")
                        .HasColumnName("ICBCREGISTRATION_NUMBER")
                        .HasMaxLength(40);

                    b.Property<string>("IndependentSchoolName")
                        .HasColumnName("INDEPENDENT_SCHOOL_NAME")
                        .HasMaxLength(120);

                    b.Property<int?>("InspectorRefId")
                        .HasColumnName("INSPECTOR_REF_ID");

                    b.Property<bool?>("IsIndependentSchool")
                        .HasColumnName("IS_INDEPENDENT_SCHOOL");

                    b.Property<bool?>("IsOutOfProvince")
                        .HasColumnName("IS_OUT_OF_PROVINCE");

                    b.Property<string>("LicencePlateNumber")
                        .HasColumnName("LICENCE_PLATE_NUMBER")
                        .HasMaxLength(15);

                    b.Property<int?>("MobilityAidCapacity")
                        .HasColumnName("MOBILITY_AID_CAPACITY");

                    b.Property<DateTime?>("NextInspectionDate")
                        .HasColumnName("NEXT_INSPECTION_DATE");

                    b.Property<string>("NextInspectionTypeCode")
                        .HasColumnName("NEXT_INSPECTION_TYPE_CODE")
                        .HasMaxLength(30);

                    b.Property<string>("PermitClassCode")
                        .HasColumnName("PERMIT_CLASS_CODE")
                        .HasMaxLength(50);

                    b.Property<string>("PermitNumber")
                        .HasColumnName("PERMIT_NUMBER")
                        .HasMaxLength(20);

                    b.Property<string>("RestrictionsText")
                        .HasColumnName("RESTRICTIONS_TEXT")
                        .HasMaxLength(2048);

                    b.Property<int?>("SchoolBusOwnerRefId")
                        .HasColumnName("SCHOOL_BUS_OWNER_REF_ID");

                    b.Property<int>("SchoolBusSeatingCapacity")
                        .HasColumnName("SCHOOL_BUS_SEATING_CAPACITY");

                    b.Property<int?>("SchoolDistrictRefId")
                        .HasColumnName("SCHOOL_DISTRICT_REF_ID");

                    b.Property<string>("Status")
                        .HasColumnName("STATUS")
                        .HasMaxLength(20);

                    b.Property<string>("UnitNumber")
                        .HasColumnName("UNIT_NUMBER")
                        .HasMaxLength(30);

                    b.Property<string>("VehicleIdentificationNumber")
                        .HasColumnName("VEHICLE_IDENTIFICATION_NUMBER")
                        .HasMaxLength(17);

                    b.HasKey("Id");

                    b.HasIndex("CCWDataRefId");

                    b.HasIndex("CCWJurisdictionRefId");

                    b.HasIndex("DistrictRefId");

                    b.HasIndex("HomeTerminalCityRefId");

                    b.HasIndex("InspectorRefId");

                    b.HasIndex("SchoolBusOwnerRefId");

                    b.HasIndex("SchoolDistrictRefId");

                    b.ToTable("SBI_SCHOOL_BUS");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SCHOOL_BUS_OWNER_ID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("DATE_CREATED");

                    b.Property<int?>("DistrictRefId")
                        .HasColumnName("DISTRICT_REF_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(150);

                    b.Property<int?>("PrimaryContactRefId")
                        .HasColumnName("PRIMARY_CONTACT_REF_ID");

                    b.Property<string>("Status")
                        .HasColumnName("STATUS")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("DistrictRefId");

                    b.HasIndex("PrimaryContactRefId");

                    b.ToTable("SBI_SCHOOL_BUS_OWNER");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolDistrict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SCHOOL_DISTRICT_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.Property<string>("ShortName")
                        .HasColumnName("SHORT_NAME")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SBI_SCHOOL_DISTRICT");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.ServiceArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SERVICE_AREA_ID");

                    b.Property<int?>("DistrictRefId")
                        .HasColumnName("DISTRICT_REF_ID");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnName("END_DATE");

                    b.Property<int>("MinistryServiceAreaID")
                        .HasColumnName("MINISTRY_SERVICE_AREA_ID");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnName("START_DATE");

                    b.HasKey("Id");

                    b.HasIndex("DistrictRefId");

                    b.ToTable("SBI_SERVICE_AREA");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ID");

                    b.Property<bool>("Active")
                        .HasColumnName("ACTIVE");

                    b.Property<int?>("DistrictRefId")
                        .HasColumnName("DISTRICT_REF_ID");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL")
                        .HasMaxLength(255);

                    b.Property<string>("GivenName")
                        .HasColumnName("GIVEN_NAME")
                        .HasMaxLength(255);

                    b.Property<string>("Guid")
                        .HasColumnName("GUID")
                        .HasMaxLength(255);

                    b.Property<string>("Initials")
                        .HasColumnName("INITIALS")
                        .HasMaxLength(10);

                    b.Property<string>("SmAuthorizationDirectory")
                        .HasColumnName("SM_AUTHORIZATION_DIRECTORY")
                        .HasMaxLength(255);

                    b.Property<string>("SmUserId")
                        .HasColumnName("SM_USER_ID")
                        .HasMaxLength(255);

                    b.Property<string>("Surname")
                        .HasColumnName("SURNAME")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DistrictRefId");

                    b.ToTable("SBI_USER");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserFavourite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_FAVOURITE_ID");

                    b.Property<bool?>("IsDefault")
                        .HasColumnName("IS_DEFAULT");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(255);

                    b.Property<string>("Type")
                        .HasColumnName("TYPE")
                        .HasMaxLength(255);

                    b.Property<int?>("UserRefId")
                        .HasColumnName("USER_REF_ID");

                    b.Property<string>("Value")
                        .HasColumnName("VALUE")
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.HasIndex("UserRefId");

                    b.ToTable("SBI_USER_FAVOURITE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ROLE_ID");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnName("EFFECTIVE_DATE");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnName("EXPIRY_DATE");

                    b.Property<int?>("RoleRefId")
                        .HasColumnName("ROLE_REF_ID");

                    b.Property<int?>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("RoleRefId");

                    b.HasIndex("UserId");

                    b.ToTable("SBI_USER_ROLE");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Attachment", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus")
                        .WithMany("Attachments")
                        .HasForeignKey("SchoolBusId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner")
                        .WithMany("Attachments")
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Contact", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner")
                        .WithMany("Contacts")
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.ContactAddress", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Contact")
                        .WithMany("ContactAddresses")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.ContactPhone", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Contact")
                        .WithMany("ContactPhones")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.District", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.GroupMembership", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupRefId");

                    b.HasOne("SchoolBusAPI.Models.User", "User")
                        .WithMany("GroupMemberships")
                        .HasForeignKey("UserRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.History", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus")
                        .WithMany("History")
                        .HasForeignKey("SchoolBusId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner")
                        .WithMany("History")
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Inspection", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.User", "Inspector")
                        .WithMany()
                        .HasForeignKey("InspectorRefId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Note", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus")
                        .WithMany("Notes")
                        .HasForeignKey("SchoolBusId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner")
                        .WithMany("Notes")
                        .HasForeignKey("SchoolBusOwnerId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.Notification", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.NotificationEvent", "Event2")
                        .WithMany()
                        .HasForeignKey("Event2RefId");

                    b.HasOne("SchoolBusAPI.Models.NotificationEvent", "Event")
                        .WithMany()
                        .HasForeignKey("EventRefId");

                    b.HasOne("SchoolBusAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.NotificationEvent", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.SchoolBus", "SchoolBus")
                        .WithMany()
                        .HasForeignKey("SchoolBusRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.RolePermission", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionRefId");

                    b.HasOne("SchoolBusAPI.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBus", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.CCWData", "CCWData")
                        .WithMany()
                        .HasForeignKey("CCWDataRefId");

                    b.HasOne("SchoolBusAPI.Models.CCWJurisdiction", "CCWJurisdiction")
                        .WithMany()
                        .HasForeignKey("CCWJurisdictionRefId");

                    b.HasOne("SchoolBusAPI.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictRefId");

                    b.HasOne("SchoolBusAPI.Models.City", "HomeTerminalCity")
                        .WithMany()
                        .HasForeignKey("HomeTerminalCityRefId");

                    b.HasOne("SchoolBusAPI.Models.User", "Inspector")
                        .WithMany()
                        .HasForeignKey("InspectorRefId");

                    b.HasOne("SchoolBusAPI.Models.SchoolBusOwner", "SchoolBusOwner")
                        .WithMany()
                        .HasForeignKey("SchoolBusOwnerRefId");

                    b.HasOne("SchoolBusAPI.Models.SchoolDistrict", "SchoolDistrict")
                        .WithMany()
                        .HasForeignKey("SchoolDistrictRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.SchoolBusOwner", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictRefId");

                    b.HasOne("SchoolBusAPI.Models.Contact", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.ServiceArea", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.User", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserFavourite", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserRefId");
                });

            modelBuilder.Entity("SchoolBusAPI.Models.UserRole", b =>
                {
                    b.HasOne("SchoolBusAPI.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleRefId");

                    b.HasOne("SchoolBusAPI.Models.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
