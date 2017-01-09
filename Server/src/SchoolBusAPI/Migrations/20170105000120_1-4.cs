using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CITY_CITY_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_LOCAL_AREA_LOCAL_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropTable(
                name: "SBI_LOCAL_AREA");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CITY_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.RenameColumn(
                name: "VALUE",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "LOCAL_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SERVICE_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "CITY_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "NUMBER_OF_BUSES");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_LOCAL_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "VALUE",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "IS_ACTIVE",
                table: "SBI_SCHOOL_BUS",
                newName: "INDEPENDENT_SCHOOL");

            migrationBuilder.RenameColumn(
                name: "CRNO",
                table: "SBI_SCHOOL_BUS",
                newName: "VIN");

            migrationBuilder.RenameColumn(
                name: "CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_SEATING_CAPACITY");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "SBI_CITY",
                newName: "_CITY");

            migrationBuilder.RenameColumn(
                name: "SEATING_CAPACITY",
                table: "SBI_CCWDATA",
                newName: "ICBCSEATING_CAPACITY");

            migrationBuilder.RenameColumn(
                name: "REBUILT_STATUS",
                table: "SBI_CCWDATA",
                newName: "NSCPOLICY_STATUS");

            migrationBuilder.RenameColumn(
                name: "RATE_CLASS",
                table: "SBI_CCWDATA",
                newName: "NSCPOLICY_NUMBER");

            migrationBuilder.RenameColumn(
                name: "NET_WT",
                table: "SBI_CCWDATA",
                newName: "ICBCNET_WT");

            migrationBuilder.RenameColumn(
                name: "MODEL_YEAR",
                table: "SBI_CCWDATA",
                newName: "ICBCMODEL_YEAR");

            migrationBuilder.RenameColumn(
                name: "MODEL",
                table: "SBI_CCWDATA",
                newName: "NSCPLATE_DECAL");

            migrationBuilder.RenameColumn(
                name: "GVW",
                table: "SBI_CCWDATA",
                newName: "ICBCGROSS_VEHICLE_WEIGHT");

            migrationBuilder.RenameColumn(
                name: "FUEL",
                table: "SBI_CCWDATA",
                newName: "NSCCLIENT_NUM");

            migrationBuilder.RenameColumn(
                name: "FLEET_UNIT_NO",
                table: "SBI_CCWDATA",
                newName: "ICBCFLEET_UNIT_NO");

            migrationBuilder.RenameColumn(
                name: "COLOUR",
                table: "SBI_CCWDATA",
                newName: "NSCCARRIER_SAFETY_RATING");

            migrationBuilder.RenameColumn(
                name: "CVIPEXPIRY",
                table: "SBI_CCWDATA",
                newName: "NSCPOLICY_STATUS_DATE");

            migrationBuilder.RenameColumn(
                name: "CVIPDECAL",
                table: "SBI_CCWDATA",
                newName: "NSCCARRIER_NAME");

            migrationBuilder.RenameColumn(
                name: "BODY",
                table: "SBI_CCWDATA",
                newName: "NSCCARRIER_CONDITIONS");

            migrationBuilder.AddColumn<string>(
                name: "PHONE_NUMBER",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TYPE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ADDR1",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ADDR2",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CITY",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POSTAL_CODE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PROVINCE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TYPE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GIVEN_NAME",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOTES",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ROLE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SURNAME",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EXTERNAL_FILE_NAME",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INTERNAL_FILE_NAME",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BUS_LOCATION_ADDR1",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BUS_LOCATION_ADDR2",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BUS_LOCATION_POST_CODE",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BUS_LOCATION_PROV",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LOCATION_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MOBILITY_AID_CAPACITY",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PLATE",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "REGI",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RESTRICTIONS",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SCHOOL_BUS_CLASS",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SCHOOL_BUS_UNIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "END_DATE",
                table: "SBI_REGION",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MINISTRY_REGION_ID",
                table: "SBI_REGION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "START_DATE",
                table: "SBI_REGION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "INSPECTION_DATE",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INSPECTION_RESULT",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOTES",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RIPINSPECTION_ID",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RESTRICTIONS",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCBODY",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCCVIPDECAL",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ICBCCVIPEXPIRY",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCCOLOUR",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCFUEL",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCMICBCAKE",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCMODEL",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCNOTES_AND_ORDERS",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ICBCORDERED_ON",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCRATE_CLASS",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREBUILT_STATUS",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_ADDR1",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_ADDR2",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_CITY",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_NAME",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_POOL",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_POSTAL_CODE",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_PROV",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_RODL",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREG_OWNER_STATUS",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCREGI",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCVEHICLE_TYPE",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NSCPOLICY_EFFECTIVE_DATE",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NSCPOLICY_EXPIRY_DATE",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SBI_DISTRICT",
                columns: table => new
                {
                    SBI_DISTRICT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    END_DATE = table.Column<DateTime>(nullable: true),
                    MINISTRY_DISTRICT_ID = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    REGION_ID = table.Column<int>(nullable: true),
                    START_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_DISTRICT", x => x.SBI_DISTRICT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_DISTRICT_SBI_REGION_REGION_ID",
                        column: x => x.REGION_ID,
                        principalTable: "SBI_REGION",
                        principalColumn: "SBI_REGION_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_NOTIFICATION_VIEW_MODEL",
                columns: table => new
                {
                    SBI_NOTIFICATION_VIEW_MODEL_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EVENT2_ID = table.Column<int>(nullable: true),
                    EVENT_ID = table.Column<int>(nullable: true),
                    HAS_BEEN_VIEWED = table.Column<bool>(nullable: true),
                    IS_ALL_DAY = table.Column<bool>(nullable: true),
                    IS_EXPIRED = table.Column<bool>(nullable: true),
                    IS_WATCH_NOTIFICATION = table.Column<bool>(nullable: true),
                    PRIORITY_CODE = table.Column<string>(nullable: true),
                    USER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_NOTIFICATION_VIEW_MODEL", x => x.SBI_NOTIFICATION_VIEW_MODEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_USER_FAVOURITE_VIEW_MODEL",
                columns: table => new
                {
                    SBI_USER_FAVOURITE_VIEW_MODEL_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FAVOURITE_CONTEXT_TYPE_ID = table.Column<int>(nullable: true),
                    IS_DEFAULT = table.Column<bool>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    VALUE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_USER_FAVOURITE_VIEW_MODEL", x => x.SBI_USER_FAVOURITE_VIEW_MODEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SERVICE_AREA",
                columns: table => new
                {
                    SBI_SERVICE_AREA_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DISTRICT_ID = table.Column<int>(nullable: true),
                    END_DATE = table.Column<DateTime>(nullable: true),
                    MINISTRY_SERVICE_AREA_ID = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    START_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SERVICE_AREA", x => x.SBI_SERVICE_AREA_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SERVICE_AREA_SBI_DISTRICT_DISTRICT_ID",
                        column: x => x.DISTRICT_ID,
                        principalTable: "SBI_DISTRICT",
                        principalColumn: "SBI_DISTRICT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                column: "BUS_LOCATION_CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_LOCATION_ID",
                table: "SBI_SCHOOL_BUS",
                column: "LOCATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_DISTRICT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_DISTRICT_REGION_ID",
                table: "SBI_DISTRICT",
                column: "REGION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SERVICE_AREA_DISTRICT_ID",
                table: "SBI_SERVICE_AREA",
                column: "DISTRICT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                column: "BUS_LOCATION_CITY_ID",
                principalTable: "SBI_CITY",
                principalColumn: "SBI_CITY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_LOCATION_ID",
                table: "SBI_SCHOOL_BUS",
                column: "LOCATION_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SBI_SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_DISTRICT_ID",
                principalTable: "SBI_SCHOOL_DISTRICT",
                principalColumn: "SBI_SCHOOL_DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SERVICE_AREA_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SBI_SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_LOCATION_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropTable(
                name: "SBI_NOTIFICATION_VIEW_MODEL");

            migrationBuilder.DropTable(
                name: "SBI_SERVICE_AREA");

            migrationBuilder.DropTable(
                name: "SBI_USER_FAVOURITE_VIEW_MODEL");

            migrationBuilder.DropTable(
                name: "SBI_DISTRICT");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_LOCATION_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "PHONE_NUMBER",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropColumn(
                name: "TYPE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropColumn(
                name: "ADDR1",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "ADDR2",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "CITY",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "POSTAL_CODE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "PROVINCE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "TYPE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "GIVEN_NAME",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropColumn(
                name: "NOTES",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropColumn(
                name: "ROLE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropColumn(
                name: "SURNAME",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "EXTERNAL_FILE_NAME",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "INTERNAL_FILE_NAME",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                table: "SBI_SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "BUS_LOCATION_ADDR1",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "BUS_LOCATION_ADDR2",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "BUS_LOCATION_POST_CODE",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "BUS_LOCATION_PROV",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "LOCATION_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "MOBILITY_AID_CAPACITY",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "PLATE",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "REGI",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "RESTRICTIONS",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "SCHOOL_BUS_CLASS",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "SCHOOL_BUS_UNIT_NUMBER",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "END_DATE",
                table: "SBI_REGION");

            migrationBuilder.DropColumn(
                name: "MINISTRY_REGION_ID",
                table: "SBI_REGION");

            migrationBuilder.DropColumn(
                name: "START_DATE",
                table: "SBI_REGION");

            migrationBuilder.DropColumn(
                name: "INSPECTION_DATE",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "INSPECTION_RESULT",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "NOTES",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "RIPINSPECTION_ID",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "RESTRICTIONS",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "ICBCBODY",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCCVIPDECAL",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCCVIPEXPIRY",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCCOLOUR",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCFUEL",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCMICBCAKE",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCMODEL",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCNOTES_AND_ORDERS",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCORDERED_ON",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCRATE_CLASS",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREBUILT_STATUS",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_ADDR1",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_ADDR2",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_CITY",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_NAME",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_POOL",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_POSTAL_CODE",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_PROV",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_RODL",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREG_OWNER_STATUS",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCREGI",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCVEHICLE_TYPE",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "NSCPOLICY_EFFECTIVE_DATE",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "NSCPOLICY_EXPIRY_DATE",
                table: "SBI_CCWDATA");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "VALUE");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "LOCAL_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "NUMBER_OF_BUSES",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "CITY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_LOCAL_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "VALUE");

            migrationBuilder.RenameColumn(
                name: "VIN",
                table: "SBI_SCHOOL_BUS",
                newName: "CRNO");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_SEATING_CAPACITY",
                table: "SBI_SCHOOL_BUS",
                newName: "CCWDATA_ID");

            migrationBuilder.RenameColumn(
                name: "INDEPENDENT_SCHOOL",
                table: "SBI_SCHOOL_BUS",
                newName: "IS_ACTIVE");

            migrationBuilder.RenameColumn(
                name: "_CITY",
                table: "SBI_CITY",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "NSCPOLICY_STATUS_DATE",
                table: "SBI_CCWDATA",
                newName: "CVIPEXPIRY");

            migrationBuilder.RenameColumn(
                name: "NSCPOLICY_STATUS",
                table: "SBI_CCWDATA",
                newName: "REBUILT_STATUS");

            migrationBuilder.RenameColumn(
                name: "NSCPOLICY_NUMBER",
                table: "SBI_CCWDATA",
                newName: "RATE_CLASS");

            migrationBuilder.RenameColumn(
                name: "NSCPLATE_DECAL",
                table: "SBI_CCWDATA",
                newName: "MODEL");

            migrationBuilder.RenameColumn(
                name: "NSCCLIENT_NUM",
                table: "SBI_CCWDATA",
                newName: "FUEL");

            migrationBuilder.RenameColumn(
                name: "NSCCARRIER_SAFETY_RATING",
                table: "SBI_CCWDATA",
                newName: "COLOUR");

            migrationBuilder.RenameColumn(
                name: "NSCCARRIER_NAME",
                table: "SBI_CCWDATA",
                newName: "CVIPDECAL");

            migrationBuilder.RenameColumn(
                name: "NSCCARRIER_CONDITIONS",
                table: "SBI_CCWDATA",
                newName: "BODY");

            migrationBuilder.RenameColumn(
                name: "ICBCSEATING_CAPACITY",
                table: "SBI_CCWDATA",
                newName: "SEATING_CAPACITY");

            migrationBuilder.RenameColumn(
                name: "ICBCNET_WT",
                table: "SBI_CCWDATA",
                newName: "NET_WT");

            migrationBuilder.RenameColumn(
                name: "ICBCMODEL_YEAR",
                table: "SBI_CCWDATA",
                newName: "MODEL_YEAR");

            migrationBuilder.RenameColumn(
                name: "ICBCGROSS_VEHICLE_WEIGHT",
                table: "SBI_CCWDATA",
                newName: "GVW");

            migrationBuilder.RenameColumn(
                name: "ICBCFLEET_UNIT_NO",
                table: "SBI_CCWDATA",
                newName: "FLEET_UNIT_NO");

            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SBI_LOCAL_AREA",
                columns: table => new
                {
                    SBI_LOCAL_AREA_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NAME = table.Column<string>(nullable: true),
                    REGION_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_LOCAL_AREA", x => x.SBI_LOCAL_AREA_ID);
                    table.ForeignKey(
                        name: "FK_SBI_LOCAL_AREA_SBI_REGION_REGION_ID",
                        column: x => x.REGION_ID,
                        principalTable: "SBI_REGION",
                        principalColumn: "SBI_REGION_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CITY_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWDATA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_LOCAL_AREA_REGION_ID",
                table: "SBI_LOCAL_AREA",
                column: "REGION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWDATA_ID",
                principalTable: "SBI_CCWDATA",
                principalColumn: "SBI_CCWDATA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CITY_CITY_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "CITY_ID",
                principalTable: "SBI_CITY",
                principalColumn: "SBI_CITY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_LOCAL_AREA_LOCAL_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "LOCAL_AREA_ID",
                principalTable: "SBI_LOCAL_AREA",
                principalColumn: "SBI_LOCAL_AREA_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
