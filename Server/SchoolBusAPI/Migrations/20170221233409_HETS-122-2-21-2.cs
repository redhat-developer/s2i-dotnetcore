using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class HETS1222212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_USER_ROLE");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_USER_ROLE");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_USER_ROLE");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_USER_ROLE");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_USER");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_USER");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_USER");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_USER");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_SERVICE_AREA");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SERVICE_AREA");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_SERVICE_AREA");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SERVICE_AREA");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_ROLE");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_ROLE");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_ROLE");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_ROLE");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_REGION");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_REGION");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_REGION");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_REGION");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_PERMISSION");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_PERMISSION");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_PERMISSION");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_PERMISSION");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_NOTE");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_NOTE");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_NOTE");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_NOTE");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_HISTORY");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_HISTORY");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_HISTORY");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_HISTORY");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_GROUP");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_GROUP");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_GROUP");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_GROUP");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_DISTRICT");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_DISTRICT");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_DISTRICT");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_DISTRICT");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_CONTACT_PHONE");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CONTACT_PHONE");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_CONTACT_PHONE");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CONTACT_PHONE");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CONTACT_ADDRESS");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_CITY");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CITY");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_CITY");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CITY");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_CCWJURISDICTION");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CCWJURISDICTION");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_CCWJURISDICTION");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CCWJURISDICTION");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "CREATED_BY_ID",
                table: "SBI_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "CREATED_TIMESTAMP",
                table: "SBI_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY_ID",
                table: "SBI_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_ATTACHMENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_USER_ROLE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_USER_ROLE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_USER_ROLE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_USER_ROLE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_USER_FAVOURITE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_USER_FAVOURITE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_USER_FAVOURITE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_USER_FAVOURITE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_USER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_USER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_USER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_USER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_SERVICE_AREA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SERVICE_AREA",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_SERVICE_AREA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SERVICE_AREA",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_SCHOOL_DISTRICT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SCHOOL_DISTRICT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_SCHOOL_DISTRICT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SCHOOL_DISTRICT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_SCHOOL_BUS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_ROLE_PERMISSION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_ROLE_PERMISSION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_ROLE_PERMISSION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_ROLE_PERMISSION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_ROLE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_ROLE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_ROLE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_ROLE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_REGION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_REGION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_REGION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_REGION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_PERMISSION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_PERMISSION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_PERMISSION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_PERMISSION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_NOTIFICATION_EVENT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_NOTIFICATION_EVENT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_NOTIFICATION_EVENT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_NOTIFICATION_EVENT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_NOTIFICATION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_NOTIFICATION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_NOTIFICATION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_NOTIFICATION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_NOTE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_NOTE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_NOTE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_NOTE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_INSPECTION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_INSPECTION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_HISTORY",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_HISTORY",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_HISTORY",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_HISTORY",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_GROUP_MEMBERSHIP",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_GROUP_MEMBERSHIP",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_GROUP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_GROUP",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_GROUP",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_GROUP",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_DISTRICT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_DISTRICT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_DISTRICT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_DISTRICT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_CONTACT_PHONE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CONTACT_PHONE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_CONTACT_PHONE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CONTACT_PHONE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CONTACT_ADDRESS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_CONTACT_ADDRESS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CONTACT_ADDRESS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_CONTACT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CONTACT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_CONTACT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CONTACT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_CITY",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CITY",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_CITY",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CITY",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_CCWJURISDICTION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CCWJURISDICTION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_CCWJURISDICTION",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CCWJURISDICTION",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_CCWDATA",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_CCWDATA",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_CCWDATA",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY_ID",
                table: "SBI_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_TIMESTAMP",
                table: "SBI_ATTACHMENT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_BY_ID",
                table: "SBI_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_TIMESTAMP",
                table: "SBI_ATTACHMENT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
