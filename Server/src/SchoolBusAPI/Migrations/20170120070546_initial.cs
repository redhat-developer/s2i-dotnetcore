using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SBI_CCWDATA",
                columns: table => new
                {
                    CCWDATA_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ICBCBODY = table.Column<string>(nullable: true),
                    ICBCCVIPDECAL = table.Column<string>(nullable: true),
                    ICBCCVIPEXPIRY = table.Column<DateTime>(nullable: true),
                    ICBCCOLOUR = table.Column<string>(nullable: true),
                    ICBCFLEET_UNIT_NO = table.Column<int>(nullable: true),
                    ICBCFUEL = table.Column<string>(nullable: true),
                    ICBCGROSS_VEHICLE_WEIGHT = table.Column<int>(nullable: true),
                    ICBCMAKE = table.Column<string>(nullable: true),
                    ICBCMODEL = table.Column<string>(nullable: true),
                    ICBCMODEL_YEAR = table.Column<int>(nullable: true),
                    ICBCNET_WT = table.Column<int>(nullable: true),
                    ICBCNOTES_AND_ORDERS = table.Column<string>(nullable: true),
                    ICBCORDERED_ON = table.Column<DateTime>(nullable: true),
                    ICBCRATE_CLASS = table.Column<string>(nullable: true),
                    ICBCREBUILT_STATUS = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_ADDR1 = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_ADDR2 = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_CITY = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_NAME = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_POOL = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_POSTAL_CODE = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_PROV = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_RODL = table.Column<string>(nullable: true),
                    ICBCREG_OWNER_STATUS = table.Column<string>(nullable: true),
                    ICBCREGI = table.Column<string>(nullable: true),
                    ICBCSEATING_CAPACITY = table.Column<int>(nullable: true),
                    ICBCVEHICLE_TYPE = table.Column<string>(nullable: true),
                    NSCCARRIER_CONDITIONS = table.Column<string>(nullable: true),
                    NSCCARRIER_NAME = table.Column<string>(nullable: true),
                    NSCCARRIER_SAFETY_RATING = table.Column<string>(nullable: true),
                    NSCCLIENT_NUM = table.Column<string>(nullable: true),
                    NSCPLATE_DECAL = table.Column<string>(nullable: true),
                    NSCPOLICY_EFFECTIVE_DATE = table.Column<DateTime>(nullable: true),
                    NSCPOLICY_EXPIRY_DATE = table.Column<DateTime>(nullable: true),
                    NSCPOLICY_NUMBER = table.Column<string>(nullable: true),
                    NSCPOLICY_STATUS = table.Column<string>(nullable: true),
                    NSCPOLICY_STATUS_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CCWDATA", x => x.CCWDATA_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_CITY",
                columns: table => new
                {
                    CITY_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CITY", x => x.CITY_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_GROUP",
                columns: table => new
                {
                    GROUP_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_GROUP", x => x.GROUP_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_PERMISSION",
                columns: table => new
                {
                    PERMISSION_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CODE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_PERMISSION", x => x.PERMISSION_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_REGION",
                columns: table => new
                {
                    REGION_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    END_DATE = table.Column<DateTime>(nullable: true),
                    MINISTRY_REGION_ID = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    START_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_REGION", x => x.REGION_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_ROLE",
                columns: table => new
                {
                    ROLE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_ROLE", x => x.ROLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_DISTRICT",
                columns: table => new
                {
                    SCHOOL_DISTRICT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NAME = table.Column<string>(nullable: true),
                    SHORT_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_DISTRICT", x => x.SCHOOL_DISTRICT_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_USER",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ACTIVE = table.Column<bool>(nullable: false),
                    EMAIL = table.Column<string>(nullable: true),
                    GIVEN_NAME = table.Column<string>(nullable: true),
                    GUID = table.Column<string>(nullable: true),
                    INITIALS = table.Column<string>(nullable: true),
                    SM_AUTHORIZATION_DIRECTORY = table.Column<string>(nullable: true),
                    SM_USER_ID = table.Column<string>(nullable: true),
                    SURNAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_USER", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_USER_FAVOURITE",
                columns: table => new
                {
                    USER_FAVOURITE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IS_DEFAULT = table.Column<bool>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    TYPE = table.Column<string>(nullable: true),
                    VALUE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_USER_FAVOURITE", x => x.USER_FAVOURITE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_DISTRICT",
                columns: table => new
                {
                    DISTRICT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    END_DATE = table.Column<DateTime>(nullable: true),
                    MINISTRY_DISTRICT_ID = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    REGION_REF_ID = table.Column<int>(nullable: true),
                    START_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_DISTRICT", x => x.DISTRICT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_DISTRICT_SBI_REGION_REGION_REF_ID",
                        column: x => x.REGION_REF_ID,
                        principalTable: "SBI_REGION",
                        principalColumn: "REGION_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_ROLE_PERMISSION",
                columns: table => new
                {
                    ROLE_PERMISSION_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PERMISSION_REF_ID = table.Column<int>(nullable: true),
                    ROLE_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_ROLE_PERMISSION", x => x.ROLE_PERMISSION_ID);
                    table.ForeignKey(
                        name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISSION_REF_ID",
                        column: x => x.PERMISSION_REF_ID,
                        principalTable: "SBI_PERMISSION",
                        principalColumn: "PERMISSION_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_ROLE_PERMISSION_SBI_ROLE_ROLE_REF_ID",
                        column: x => x.ROLE_REF_ID,
                        principalTable: "SBI_ROLE",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_GROUP_MEMBERSHIP",
                columns: table => new
                {
                    GROUP_MEMBERSHIP_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ACTIVE = table.Column<bool>(nullable: false),
                    GROUP_REF_ID = table.Column<int>(nullable: true),
                    USER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_GROUP_MEMBERSHIP", x => x.GROUP_MEMBERSHIP_ID);
                    table.ForeignKey(
                        name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_REF_ID",
                        column: x => x.GROUP_REF_ID,
                        principalTable: "SBI_GROUP",
                        principalColumn: "GROUP_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_REF_ID",
                        column: x => x.USER_REF_ID,
                        principalTable: "SBI_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_USER_ROLE",
                columns: table => new
                {
                    USER_ROLE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EFFECTIVE_DATE = table.Column<DateTime>(nullable: false),
                    EXPIRY_DATE = table.Column<DateTime>(nullable: true),
                    ROLE_REF_ID = table.Column<int>(nullable: true),
                    USER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_USER_ROLE", x => x.USER_ROLE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_USER_ROLE_SBI_ROLE_ROLE_REF_ID",
                        column: x => x.ROLE_REF_ID,
                        principalTable: "SBI_ROLE",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_USER_ROLE_SBI_USER_USER_REF_ID",
                        column: x => x.USER_REF_ID,
                        principalTable: "SBI_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SERVICE_AREA",
                columns: table => new
                {
                    SERVICE_AREA_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DISTRICT_REF_ID = table.Column<int>(nullable: true),
                    END_DATE = table.Column<DateTime>(nullable: true),
                    MINISTRY_SERVICE_AREA_ID = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    START_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SERVICE_AREA", x => x.SERVICE_AREA_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SERVICE_AREA_SBI_DISTRICT_DISTRICT_REF_ID",
                        column: x => x.DISTRICT_REF_ID,
                        principalTable: "SBI_DISTRICT",
                        principalColumn: "DISTRICT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS",
                columns: table => new
                {
                    SCHOOL_BUS_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HOME_TERMINAL_ADDR1 = table.Column<string>(nullable: true),
                    HOME_TERMINAL_ADDR2 = table.Column<string>(nullable: true),
                    HOME_TERMINAL_CITY_REF_ID = table.Column<int>(nullable: true),
                    HOME_TERMINAL_COMMENT = table.Column<string>(nullable: true),
                    HOME_TERMINAL_POSTAL_CODE = table.Column<string>(nullable: true),
                    HOME_TERMINAL_PROVINCE = table.Column<string>(nullable: true),
                    INSPECTOR_REF_ID = table.Column<int>(nullable: true),
                    IS_INDEPENDENT_SCHOOL = table.Column<bool>(nullable: true),
                    IS_OUT_OF_PROVINCE = table.Column<bool>(nullable: true),
                    MOBILITY_AID_CAPACITY = table.Column<int>(nullable: true),
                    NAME_OF_INDEPENDENT_SCHOOL = table.Column<string>(nullable: true),
                    NEXT_INSPECTION_DATE = table.Column<DateTime>(nullable: true),
                    NEXT_INSPECTION_TYPE = table.Column<string>(nullable: true),
                    PERMIT_NUMBER = table.Column<string>(nullable: true),
                    PLATE = table.Column<string>(nullable: true),
                    REGI = table.Column<string>(nullable: true),
                    RESTRICTIONS = table.Column<string>(nullable: true),
                    SCHOOL_BUS_BODY_TYPE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_BODY_TYPE_OTHER = table.Column<string>(nullable: true),
                    SCHOOL_BUS_CLASS = table.Column<string>(nullable: true),
                    SCHOOL_BUS_DISTRICT_REF_ID = table.Column<int>(nullable: true),
                    SCHOOL_BUS_OWNER_REF_ID = table.Column<int>(nullable: true),
                    SCHOOL_BUS_SEATING_CAPACITY = table.Column<int>(nullable: true),
                    SCHOOL_BUS_UNIT_NUMBER = table.Column<string>(nullable: true),
                    SERVICE_AREA_REF_ID = table.Column<int>(nullable: true),
                    STATUS = table.Column<string>(nullable: true),
                    VIN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS", x => x.SCHOOL_BUS_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_SBI_CITY_HOME_TERMINAL_CITY_REF_ID",
                        column: x => x.HOME_TERMINAL_CITY_REF_ID,
                        principalTable: "SBI_CITY",
                        principalColumn: "CITY_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_SBI_USER_INSPECTOR_REF_ID",
                        column: x => x.INSPECTOR_REF_ID,
                        principalTable: "SBI_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_REF_ID",
                        column: x => x.SCHOOL_BUS_DISTRICT_REF_ID,
                        principalTable: "SBI_SCHOOL_DISTRICT",
                        principalColumn: "SCHOOL_DISTRICT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                        column: x => x.SERVICE_AREA_REF_ID,
                        principalTable: "SBI_SERVICE_AREA",
                        principalColumn: "SERVICE_AREA_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_INSPECTION",
                columns: table => new
                {
                    INSPECTION_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    INSPECTION_DATE = table.Column<DateTime>(nullable: true),
                    INSPECTION_RESULT = table.Column<string>(nullable: true),
                    INSPECTION_TYPE = table.Column<string>(nullable: true),
                    INSPECTOR_REF_ID = table.Column<int>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    RIPINSPECTION_ID = table.Column<string>(nullable: true),
                    RESTRICTIONS = table.Column<string>(nullable: true),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_INSPECTION", x => x.INSPECTION_ID);
                    table.ForeignKey(
                        name: "FK_SBI_INSPECTION_SBI_USER_INSPECTOR_REF_ID",
                        column: x => x.INSPECTOR_REF_ID,
                        principalTable: "SBI_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_INSPECTION_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_NOTIFICATION_EVENT",
                columns: table => new
                {
                    NOTIFICATION_EVENT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EVENT_SUB_TYPE_CODE = table.Column<string>(nullable: true),
                    EVENT_TIME = table.Column<DateTime>(nullable: true),
                    EVENT_TYPE_CODE = table.Column<string>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    NOTIFICATION_GENERATED = table.Column<bool>(nullable: true),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_NOTIFICATION_EVENT", x => x.NOTIFICATION_EVENT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_NOTIFICATION_EVENT_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_ATTACHMENT",
                columns: table => new
                {
                    SCHOOL_BUS_ATTACHMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    EXTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    INTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_ATTACHMENT", x => x.SCHOOL_BUS_ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_ATTACHMENT_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_HISTORY",
                columns: table => new
                {
                    SCHOOL_BUS_HISTORY_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_HISTORY", x => x.SCHOOL_BUS_HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_NOTE",
                columns: table => new
                {
                    SCHOOL_BUS_NOTE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IS_NO_LONGER_RELEVANT = table.Column<bool>(nullable: true),
                    NOTE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_NOTE", x => x.SCHOOL_BUS_NOTE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_NOTIFICATION",
                columns: table => new
                {
                    NOTIFICATION_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EVENT2_REF_ID = table.Column<int>(nullable: true),
                    EVENT_REF_ID = table.Column<int>(nullable: true),
                    HAS_BEEN_VIEWED = table.Column<bool>(nullable: true),
                    IS_ALL_DAY = table.Column<bool>(nullable: true),
                    IS_EXPIRED = table.Column<bool>(nullable: true),
                    IS_WATCH_NOTIFICATION = table.Column<bool>(nullable: true),
                    PRIORITY_CODE = table.Column<string>(nullable: true),
                    USER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_NOTIFICATION", x => x.NOTIFICATION_ID);
                    table.ForeignKey(
                        name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_REF_ID",
                        column: x => x.EVENT2_REF_ID,
                        principalTable: "SBI_NOTIFICATION_EVENT",
                        principalColumn: "NOTIFICATION_EVENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_REF_ID",
                        column: x => x.EVENT_REF_ID,
                        principalTable: "SBI_NOTIFICATION_EVENT",
                        principalColumn: "NOTIFICATION_EVENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_NOTIFICATION_SBI_USER_USER_REF_ID",
                        column: x => x.USER_REF_ID,
                        principalTable: "SBI_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_ATTACHMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    EXTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    INTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT", x => x.SCHOOL_BUS_OWNER_ATTACHMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GIVEN_NAME = table.Column<string>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    ROLE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true),
                    SURNAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_CONTACT", x => x.SCHOOL_BUS_OWNER_CONTACT_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DATE_CREATED = table.Column<DateTime>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    NEXT_INSPECTION_DATE = table.Column<DateTime>(nullable: true),
                    NUMBER_OF_BUSES = table.Column<int>(nullable: true),
                    PRIMARY_CONTACT_REF_ID = table.Column<int>(nullable: true),
                    SERVICE_AREA_REF_ID = table.Column<int>(nullable: true),
                    STATUS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER", x => x.SCHOOL_BUS_OWNER_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                        column: x => x.PRIMARY_CONTACT_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                        column: x => x.SERVICE_AREA_REF_ID,
                        principalTable: "SBI_SERVICE_AREA",
                        principalColumn: "SERVICE_AREA_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ADDR1 = table.Column<string>(nullable: true),
                    ADDR2 = table.Column<string>(nullable: true),
                    CITY = table.Column<string>(nullable: true),
                    POSTAL_CODE = table.Column<string>(nullable: true),
                    PROVINCE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: true),
                    TYPE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS", x => x.SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                        column: x => x.SCHOOL_BUS_OWNER_CONTACT_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_CONTACT_PHONE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PHONE_NUMBER = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: true),
                    TYPE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE", x => x.SCHOOL_BUS_OWNER_CONTACT_PHONE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                        column: x => x.SCHOOL_BUS_OWNER_CONTACT_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_HISTORY_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_OWNER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_HISTORY", x => x.SCHOOL_BUS_OWNER_HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                        column: x => x.SCHOOL_BUS_OWNER_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_NOTE",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_NOTE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IS_NO_LONGER_RELEVANT = table.Column<bool>(nullable: true),
                    NOTE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_NOTE", x => x.SCHOOL_BUS_OWNER_NOTE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                        column: x => x.SCHOOL_BUS_OWNER_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_DISTRICT_REGION_REF_ID",
                table: "SBI_DISTRICT",
                column: "REGION_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_GROUP_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "GROUP_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_USER_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "USER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_INSPECTION_INSPECTOR_REF_ID",
                table: "SBI_INSPECTION",
                column: "INSPECTOR_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_INSPECTION_SCHOOL_BUS_REF_ID",
                table: "SBI_INSPECTION",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_NOTIFICATION_EVENT2_REF_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT2_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_REF_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_NOTIFICATION_USER_REF_ID",
                table: "SBI_NOTIFICATION",
                column: "USER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_SCHOOL_BUS_REF_ID",
                table: "SBI_NOTIFICATION_EVENT",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_ROLE_PERMISSION_PERMISSION_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "PERMISSION_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_ROLE_PERMISSION_ROLE_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "ROLE_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_HOME_TERMINAL_CITY_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "HOME_TERMINAL_CITY_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "INSPECTOR_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SERVICE_AREA_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SERVICE_AREA_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SERVICE_AREA_DISTRICT_REF_ID",
                table: "SBI_SERVICE_AREA",
                column: "DISTRICT_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_USER_ROLE_ROLE_REF_ID",
                table: "SBI_USER_ROLE",
                column: "ROLE_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_USER_ROLE_USER_REF_ID",
                table: "SBI_USER_ROLE",
                column: "USER_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_DISTRICT_SBI_REGION_REGION_REF_ID",
                table: "SBI_DISTRICT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropTable(
                name: "SBI_CCWDATA");

            migrationBuilder.DropTable(
                name: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropTable(
                name: "SBI_INSPECTION");

            migrationBuilder.DropTable(
                name: "SBI_NOTIFICATION");

            migrationBuilder.DropTable(
                name: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_HISTORY");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_NOTE");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropTable(
                name: "SBI_USER_FAVOURITE");

            migrationBuilder.DropTable(
                name: "SBI_USER_ROLE");

            migrationBuilder.DropTable(
                name: "SBI_GROUP");

            migrationBuilder.DropTable(
                name: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropTable(
                name: "SBI_PERMISSION");

            migrationBuilder.DropTable(
                name: "SBI_ROLE");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS");

            migrationBuilder.DropTable(
                name: "SBI_CITY");

            migrationBuilder.DropTable(
                name: "SBI_USER");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropTable(
                name: "SBI_REGION");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropTable(
                name: "SBI_SERVICE_AREA");

            migrationBuilder.DropTable(
                name: "SBI_DISTRICT");
        }
    }
}
