using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class dec30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CITY_REGION_REGION_ID",
                table: "CITY");

            migrationBuilder.DropForeignKey(
                name: "FK_GROUP_MEMBERSHIP_GROUP_GROUP_ID",
                table: "GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_GROUP_MEMBERSHIP_USER_USER_ID",
                table: "GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTION_USER_INSPECTOR_ID",
                table: "INSPECTION");

            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTION_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "INSPECTION");

            migrationBuilder.DropForeignKey(
                name: "FK_LOCAL_AREA_REGION_REGION_ID",
                table: "LOCAL_AREA");

            migrationBuilder.DropForeignKey(
                name: "FK_NOTIFICATION_NOTIFICATION_EVENT_EVENT2_ID",
                table: "NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_NOTIFICATION_NOTIFICATION_EVENT_EVENT_ID",
                table: "NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_NOTIFICATION_USER_USER_ID",
                table: "NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_NOTIFICATION_EVENT_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "NOTIFICATION_EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_ROLE_PERMISSION_PERMISSION_PERMISION_ID",
                table: "ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_ROLE_PERMISSION_ROLE_ROLE_ID",
                table: "ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_CCWDATA_CCWDATA_ID",
                table: "SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_HISTORY_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_NOTE_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_NOTE");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_CITY_CITY_ID",
                table: "SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_LOCAL_AREA_LOCAL_AREA_ID",
                table: "SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_DISTRICT_REGION_REGION_ID",
                table: "SCHOOL_DISTRICT");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "USER_FAVOURITE");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_ROLE_ROLE_ROLE_ID",
                table: "USER_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_ROLE_USER_USER_ID",
                table: "USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER_ROLE",
                table: "USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER_FAVOURITE",
                table: "USER_FAVOURITE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                table: "USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_DISTRICT",
                table: "SCHOOL_DISTRICT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_NOTE",
                table: "SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_HISTORY",
                table: "SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                table: "SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                table: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_CONTACT",
                table: "SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_ATTACHMENT",
                table: "SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER",
                table: "SCHOOL_BUS_OWNER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_NOTE",
                table: "SCHOOL_BUS_NOTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_HISTORY",
                table: "SCHOOL_BUS_HISTORY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS_ATTACHMENT",
                table: "SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCHOOL_BUS",
                table: "SCHOOL_BUS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ROLE_PERMISSION",
                table: "ROLE_PERMISSION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ROLE",
                table: "ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_REGION",
                table: "REGION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PERMISSION",
                table: "PERMISSION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NOTIFICATION_EVENT",
                table: "NOTIFICATION_EVENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NOTIFICATION",
                table: "NOTIFICATION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LOCAL_AREA",
                table: "LOCAL_AREA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_INSPECTION",
                table: "INSPECTION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GROUP_MEMBERSHIP",
                table: "GROUP_MEMBERSHIP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GROUP",
                table: "GROUP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FAVOURITE_CONTEXT_TYPE",
                table: "FAVOURITE_CONTEXT_TYPE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CITY",
                table: "CITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CCWDATA",
                table: "CCWDATA");

            migrationBuilder.RenameTable(
                name: "USER_ROLE",
                newName: "SBI_USER_ROLE");

            migrationBuilder.RenameTable(
                name: "USER_FAVOURITE",
                newName: "SBI_USER_FAVOURITE");

            migrationBuilder.RenameTable(
                name: "USER",
                newName: "SBI_USER");

            migrationBuilder.RenameTable(
                name: "SCHOOL_DISTRICT",
                newName: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_OWNER_NOTE",
                newName: "SBI_SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_OWNER_HISTORY",
                newName: "SBI_SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_OWNER_CONTACT",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_OWNER",
                newName: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_NOTE",
                newName: "SBI_SCHOOL_BUS_NOTE");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_HISTORY",
                newName: "SBI_SCHOOL_BUS_HISTORY");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS_ATTACHMENT",
                newName: "SBI_SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.RenameTable(
                name: "SCHOOL_BUS",
                newName: "SBI_SCHOOL_BUS");

            migrationBuilder.RenameTable(
                name: "ROLE_PERMISSION",
                newName: "SBI_ROLE_PERMISSION");

            migrationBuilder.RenameTable(
                name: "ROLE",
                newName: "SBI_ROLE");

            migrationBuilder.RenameTable(
                name: "REGION",
                newName: "SBI_REGION");

            migrationBuilder.RenameTable(
                name: "PERMISSION",
                newName: "SBI_PERMISSION");

            migrationBuilder.RenameTable(
                name: "NOTIFICATION_EVENT",
                newName: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.RenameTable(
                name: "NOTIFICATION",
                newName: "SBI_NOTIFICATION");

            migrationBuilder.RenameTable(
                name: "LOCAL_AREA",
                newName: "SBI_LOCAL_AREA");

            migrationBuilder.RenameTable(
                name: "INSPECTION",
                newName: "SBI_INSPECTION");

            migrationBuilder.RenameTable(
                name: "GROUP_MEMBERSHIP",
                newName: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.RenameTable(
                name: "GROUP",
                newName: "SBI_GROUP");

            migrationBuilder.RenameTable(
                name: "FAVOURITE_CONTEXT_TYPE",
                newName: "SBI_FAVOURITE_CONTEXT_TYPE");

            migrationBuilder.RenameTable(
                name: "CITY",
                newName: "SBI_CITY");

            migrationBuilder.RenameTable(
                name: "CCWDATA",
                newName: "SBI_CCWDATA");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_USER_ROLE",
                newName: "SBI_USER_ROLE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_USER_ROLE_USER_ID",
                table: "SBI_USER_ROLE",
                newName: "IX_SBI_USER_ROLE_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_USER_ROLE_ROLE_ID",
                table: "SBI_USER_ROLE",
                newName: "IX_SBI_USER_ROLE_ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_USER_FAVOURITE",
                newName: "SBI_USER_FAVOURITE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE",
                newName: "IX_SBI_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_USER",
                newName: "SBI_USER_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_DISTRICT",
                newName: "SBI_SCHOOL_DISTRICT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_DISTRICT_REGION_ID",
                table: "SBI_SCHOOL_DISTRICT",
                newName: "IX_SBI_SCHOOL_DISTRICT_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "SBI_SCHOOL_BUS_OWNER_NOTE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "SBI_SCHOOL_BUS_OWNER_HISTORY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SBI_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_LOCAL_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_LOCAL_AREA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_CITY_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CITY_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "SBI_SCHOOL_BUS_NOTE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_NOTE_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "SBI_SCHOOL_BUS_HISTORY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_HISTORY_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                newName: "SBI_SCHOOL_BUS_ATTACHMENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                newName: "IX_SBI_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SBI_SCHOOL_BUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_CCWDATA_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "SBI_ROLE_PERMISSION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ROLE_PERMISSION_ROLE_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_ROLE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ROLE_PERMISSION_PERMISION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_PERMISION_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_ROLE",
                newName: "SBI_ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_REGION",
                newName: "SBI_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_PERMISSION",
                newName: "SBI_PERMISSION_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "SBI_NOTIFICATION_EVENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_NOTIFICATION_EVENT_SCHOOL_BUS_ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "IX_SBI_NOTIFICATION_EVENT_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_NOTIFICATION",
                newName: "SBI_NOTIFICATION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_NOTIFICATION_USER_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_NOTIFICATION_EVENT_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_NOTIFICATION_EVENT2_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT2_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_LOCAL_AREA",
                newName: "SBI_LOCAL_AREA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_LOCAL_AREA_REGION_ID",
                table: "SBI_LOCAL_AREA",
                newName: "IX_SBI_LOCAL_AREA_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_INSPECTION",
                newName: "SBI_INSPECTION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_INSPECTION_SCHOOL_BUS_ID",
                table: "SBI_INSPECTION",
                newName: "IX_SBI_INSPECTION_SCHOOL_BUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_INSPECTION_INSPECTOR_ID",
                table: "SBI_INSPECTION",
                newName: "IX_SBI_INSPECTION_INSPECTOR_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "SBI_GROUP_MEMBERSHIP_ID");

            migrationBuilder.RenameIndex(
                name: "IX_GROUP_MEMBERSHIP_USER_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "IX_SBI_GROUP_MEMBERSHIP_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_GROUP_MEMBERSHIP_GROUP_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "IX_SBI_GROUP_MEMBERSHIP_GROUP_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_GROUP",
                newName: "SBI_GROUP_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_FAVOURITE_CONTEXT_TYPE",
                newName: "SBI_FAVOURITE_CONTEXT_TYPE_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_CITY",
                newName: "SBI_CITY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CITY_REGION_ID",
                table: "SBI_CITY",
                newName: "IX_SBI_CITY_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SBI_CCWDATA",
                newName: "SBI_CCWDATA_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_USER_ROLE",
                table: "SBI_USER_ROLE",
                column: "SBI_USER_ROLE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_USER_FAVOURITE",
                table: "SBI_USER_FAVOURITE",
                column: "SBI_USER_FAVOURITE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_USER",
                table: "SBI_USER",
                column: "SBI_USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_DISTRICT",
                table: "SBI_SCHOOL_DISTRICT",
                column: "SBI_SCHOOL_DISTRICT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_NOTE",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                column: "SBI_SCHOOL_BUS_OWNER_NOTE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_HISTORY",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                column: "SBI_SCHOOL_BUS_OWNER_HISTORY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_CONTACT",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                column: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SBI_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_NOTE",
                table: "SBI_SCHOOL_BUS_NOTE",
                column: "SBI_SCHOOL_BUS_NOTE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_HISTORY",
                table: "SBI_SCHOOL_BUS_HISTORY",
                column: "SBI_SCHOOL_BUS_HISTORY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_ATTACHMENT",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                column: "SBI_SCHOOL_BUS_ATTACHMENT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS",
                table: "SBI_SCHOOL_BUS",
                column: "SBI_SCHOOL_BUS_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_ROLE_PERMISSION",
                table: "SBI_ROLE_PERMISSION",
                column: "SBI_ROLE_PERMISSION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_ROLE",
                table: "SBI_ROLE",
                column: "SBI_ROLE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_REGION",
                table: "SBI_REGION",
                column: "SBI_REGION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_PERMISSION",
                table: "SBI_PERMISSION",
                column: "SBI_PERMISSION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_NOTIFICATION_EVENT",
                table: "SBI_NOTIFICATION_EVENT",
                column: "SBI_NOTIFICATION_EVENT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_NOTIFICATION",
                table: "SBI_NOTIFICATION",
                column: "SBI_NOTIFICATION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_LOCAL_AREA",
                table: "SBI_LOCAL_AREA",
                column: "SBI_LOCAL_AREA_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_INSPECTION",
                table: "SBI_INSPECTION",
                column: "SBI_INSPECTION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_GROUP_MEMBERSHIP",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "SBI_GROUP_MEMBERSHIP_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_GROUP",
                table: "SBI_GROUP",
                column: "SBI_GROUP_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_FAVOURITE_CONTEXT_TYPE",
                table: "SBI_FAVOURITE_CONTEXT_TYPE",
                column: "SBI_FAVOURITE_CONTEXT_TYPE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_CITY",
                table: "SBI_CITY",
                column: "SBI_CITY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBI_CCWDATA",
                table: "SBI_CCWDATA",
                column: "SBI_CCWDATA_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_CITY_SBI_REGION_REGION_ID",
                table: "SBI_CITY",
                column: "REGION_ID",
                principalTable: "SBI_REGION",
                principalColumn: "SBI_REGION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "GROUP_ID",
                principalTable: "SBI_GROUP",
                principalColumn: "SBI_GROUP_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "USER_ID",
                principalTable: "SBI_USER",
                principalColumn: "SBI_USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_INSPECTION_SBI_USER_INSPECTOR_ID",
                table: "SBI_INSPECTION",
                column: "INSPECTOR_ID",
                principalTable: "SBI_USER",
                principalColumn: "SBI_USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_INSPECTION_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_INSPECTION",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SBI_SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_LOCAL_AREA_SBI_REGION_REGION_ID",
                table: "SBI_LOCAL_AREA",
                column: "REGION_ID",
                principalTable: "SBI_REGION",
                principalColumn: "SBI_REGION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT2_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "SBI_NOTIFICATION_EVENT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "SBI_NOTIFICATION_EVENT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_USER_USER_ID",
                table: "SBI_NOTIFICATION",
                column: "USER_ID",
                principalTable: "SBI_USER",
                principalColumn: "SBI_USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_EVENT_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_NOTIFICATION_EVENT",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SBI_SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISION_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "PERMISION_ID",
                principalTable: "SBI_PERMISSION",
                principalColumn: "SBI_PERMISSION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_ROLE_ROLE_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "ROLE_ID",
                principalTable: "SBI_ROLE",
                principalColumn: "SBI_ROLE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWDATA_ID",
                principalTable: "SBI_CCWDATA",
                principalColumn: "SBI_CCWDATA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SBI_SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_ATTACHMENT_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SBI_SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SBI_SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SBI_SCHOOL_BUS_ID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SBI_SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SBI_SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SBI_SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_DISTRICT_SBI_REGION_REGION_ID",
                table: "SBI_SCHOOL_DISTRICT",
                column: "REGION_ID",
                principalTable: "SBI_REGION",
                principalColumn: "SBI_REGION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_FAVOURITE_CONTEXT_TYPE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE",
                column: "FAVOURITE_CONTEXT_TYPE_ID",
                principalTable: "SBI_FAVOURITE_CONTEXT_TYPE",
                principalColumn: "SBI_FAVOURITE_CONTEXT_TYPE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_ROLE_ROLE_ID",
                table: "SBI_USER_ROLE",
                column: "ROLE_ID",
                principalTable: "SBI_ROLE",
                principalColumn: "SBI_ROLE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_USER_USER_ID",
                table: "SBI_USER_ROLE",
                column: "USER_ID",
                principalTable: "SBI_USER",
                principalColumn: "SBI_USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_CITY_SBI_REGION_REGION_ID",
                table: "SBI_CITY");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_INSPECTION_SBI_USER_INSPECTOR_ID",
                table: "SBI_INSPECTION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_INSPECTION_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_INSPECTION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_LOCAL_AREA_SBI_REGION_REGION_ID",
                table: "SBI_LOCAL_AREA");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_USER_USER_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_EVENT_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISION_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_ROLE_ROLE_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_ATTACHMENT_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_NOTE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CITY_CITY_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_LOCAL_AREA_LOCAL_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_DISTRICT_SBI_REGION_REGION_ID",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_FAVOURITE_CONTEXT_TYPE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_ROLE_ROLE_ID",
                table: "SBI_USER_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_USER_USER_ID",
                table: "SBI_USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_USER_ROLE",
                table: "SBI_USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_USER_FAVOURITE",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_USER",
                table: "SBI_USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_DISTRICT",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_NOTE",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_HISTORY",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_CONTACT",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_OWNER",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_NOTE",
                table: "SBI_SCHOOL_BUS_NOTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_HISTORY",
                table: "SBI_SCHOOL_BUS_HISTORY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS_ATTACHMENT",
                table: "SBI_SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_SCHOOL_BUS",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_ROLE_PERMISSION",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_ROLE",
                table: "SBI_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_REGION",
                table: "SBI_REGION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_PERMISSION",
                table: "SBI_PERMISSION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_NOTIFICATION_EVENT",
                table: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_NOTIFICATION",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_LOCAL_AREA",
                table: "SBI_LOCAL_AREA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_INSPECTION",
                table: "SBI_INSPECTION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_GROUP_MEMBERSHIP",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_GROUP",
                table: "SBI_GROUP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_FAVOURITE_CONTEXT_TYPE",
                table: "SBI_FAVOURITE_CONTEXT_TYPE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_CITY",
                table: "SBI_CITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBI_CCWDATA",
                table: "SBI_CCWDATA");

            migrationBuilder.RenameTable(
                name: "SBI_USER_ROLE",
                newName: "USER_ROLE");

            migrationBuilder.RenameTable(
                name: "SBI_USER_FAVOURITE",
                newName: "USER_FAVOURITE");

            migrationBuilder.RenameTable(
                name: "SBI_USER",
                newName: "USER");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_DISTRICT",
                newName: "SCHOOL_DISTRICT");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_OWNER",
                newName: "SCHOOL_BUS_OWNER");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_NOTE",
                newName: "SCHOOL_BUS_NOTE");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_HISTORY",
                newName: "SCHOOL_BUS_HISTORY");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS_ATTACHMENT",
                newName: "SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.RenameTable(
                name: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS");

            migrationBuilder.RenameTable(
                name: "SBI_ROLE_PERMISSION",
                newName: "ROLE_PERMISSION");

            migrationBuilder.RenameTable(
                name: "SBI_ROLE",
                newName: "ROLE");

            migrationBuilder.RenameTable(
                name: "SBI_REGION",
                newName: "REGION");

            migrationBuilder.RenameTable(
                name: "SBI_PERMISSION",
                newName: "PERMISSION");

            migrationBuilder.RenameTable(
                name: "SBI_NOTIFICATION_EVENT",
                newName: "NOTIFICATION_EVENT");

            migrationBuilder.RenameTable(
                name: "SBI_NOTIFICATION",
                newName: "NOTIFICATION");

            migrationBuilder.RenameTable(
                name: "SBI_LOCAL_AREA",
                newName: "LOCAL_AREA");

            migrationBuilder.RenameTable(
                name: "SBI_INSPECTION",
                newName: "INSPECTION");

            migrationBuilder.RenameTable(
                name: "SBI_GROUP_MEMBERSHIP",
                newName: "GROUP_MEMBERSHIP");

            migrationBuilder.RenameTable(
                name: "SBI_GROUP",
                newName: "GROUP");

            migrationBuilder.RenameTable(
                name: "SBI_FAVOURITE_CONTEXT_TYPE",
                newName: "FAVOURITE_CONTEXT_TYPE");

            migrationBuilder.RenameTable(
                name: "SBI_CITY",
                newName: "CITY");

            migrationBuilder.RenameTable(
                name: "SBI_CCWDATA",
                newName: "CCWDATA");

            migrationBuilder.RenameColumn(
                name: "SBI_USER_ROLE_ID",
                table: "USER_ROLE",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_ROLE_USER_ID",
                table: "USER_ROLE",
                newName: "IX_USER_ROLE_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_ROLE_ROLE_ID",
                table: "USER_ROLE",
                newName: "IX_USER_ROLE_ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_USER_FAVOURITE_ID",
                table: "USER_FAVOURITE",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "USER_FAVOURITE",
                newName: "IX_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_USER_ID",
                table: "USER",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_DISTRICT_ID",
                table: "SCHOOL_DISTRICT",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_DISTRICT_REGION_ID",
                table: "SCHOOL_DISTRICT",
                newName: "IX_SCHOOL_DISTRICT_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_NOTE_ID",
                table: "SCHOOL_BUS_OWNER_NOTE",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_NOTE",
                newName: "IX_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_HISTORY_ID",
                table: "SCHOOL_BUS_OWNER_HISTORY",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_HISTORY",
                newName: "IX_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "IX_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "IX_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT_ID",
                table: "SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "IX_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER",
                newName: "IX_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_LOCAL_AREA_ID",
                table: "SCHOOL_BUS_OWNER",
                newName: "IX_SCHOOL_BUS_OWNER_LOCAL_AREA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CITY_ID",
                table: "SCHOOL_BUS_OWNER",
                newName: "IX_SCHOOL_BUS_OWNER_CITY_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_NOTE_ID",
                table: "SCHOOL_BUS_NOTE",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_NOTE",
                newName: "IX_SCHOOL_BUS_NOTE_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_HISTORY_ID",
                table: "SCHOOL_BUS_HISTORY",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_HISTORY",
                newName: "IX_SCHOOL_BUS_HISTORY_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_ATTACHMENT_ID",
                table: "SCHOOL_BUS_ATTACHMENT",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_ATTACHMENT",
                newName: "IX_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS",
                newName: "IX_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWDATA_ID",
                table: "SCHOOL_BUS",
                newName: "IX_SCHOOL_BUS_CCWDATA_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_ROLE_PERMISSION_ID",
                table: "ROLE_PERMISSION",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_ROLE_ID",
                table: "ROLE_PERMISSION",
                newName: "IX_ROLE_PERMISSION_ROLE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_PERMISION_ID",
                table: "ROLE_PERMISSION",
                newName: "IX_ROLE_PERMISSION_PERMISION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_ROLE_ID",
                table: "ROLE",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SBI_REGION_ID",
                table: "REGION",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SBI_PERMISSION_ID",
                table: "PERMISSION",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SBI_NOTIFICATION_EVENT_ID",
                table: "NOTIFICATION_EVENT",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_SCHOOL_BUS_ID",
                table: "NOTIFICATION_EVENT",
                newName: "IX_NOTIFICATION_EVENT_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_NOTIFICATION_ID",
                table: "NOTIFICATION",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_USER_ID",
                table: "NOTIFICATION",
                newName: "IX_NOTIFICATION_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_ID",
                table: "NOTIFICATION",
                newName: "IX_NOTIFICATION_EVENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT2_ID",
                table: "NOTIFICATION",
                newName: "IX_NOTIFICATION_EVENT2_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_LOCAL_AREA_ID",
                table: "LOCAL_AREA",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_LOCAL_AREA_REGION_ID",
                table: "LOCAL_AREA",
                newName: "IX_LOCAL_AREA_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_INSPECTION_ID",
                table: "INSPECTION",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_INSPECTION_SCHOOL_BUS_ID",
                table: "INSPECTION",
                newName: "IX_INSPECTION_SCHOOL_BUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_INSPECTION_INSPECTOR_ID",
                table: "INSPECTION",
                newName: "IX_INSPECTION_INSPECTOR_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_GROUP_MEMBERSHIP_ID",
                table: "GROUP_MEMBERSHIP",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_USER_ID",
                table: "GROUP_MEMBERSHIP",
                newName: "IX_GROUP_MEMBERSHIP_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_GROUP_ID",
                table: "GROUP_MEMBERSHIP",
                newName: "IX_GROUP_MEMBERSHIP_GROUP_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_GROUP_ID",
                table: "GROUP",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SBI_FAVOURITE_CONTEXT_TYPE_ID",
                table: "FAVOURITE_CONTEXT_TYPE",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SBI_CITY_ID",
                table: "CITY",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_CITY_REGION_ID",
                table: "CITY",
                newName: "IX_CITY_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_CCWDATA_ID",
                table: "CCWDATA",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER_ROLE",
                table: "USER_ROLE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER_FAVOURITE",
                table: "USER_FAVOURITE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                table: "USER",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_DISTRICT",
                table: "SCHOOL_DISTRICT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_NOTE",
                table: "SCHOOL_BUS_OWNER_NOTE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_HISTORY",
                table: "SCHOOL_BUS_OWNER_HISTORY",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                table: "SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                table: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_CONTACT",
                table: "SCHOOL_BUS_OWNER_CONTACT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER_ATTACHMENT",
                table: "SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_OWNER",
                table: "SCHOOL_BUS_OWNER",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_NOTE",
                table: "SCHOOL_BUS_NOTE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_HISTORY",
                table: "SCHOOL_BUS_HISTORY",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS_ATTACHMENT",
                table: "SCHOOL_BUS_ATTACHMENT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCHOOL_BUS",
                table: "SCHOOL_BUS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ROLE_PERMISSION",
                table: "ROLE_PERMISSION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ROLE",
                table: "ROLE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_REGION",
                table: "REGION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PERMISSION",
                table: "PERMISSION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NOTIFICATION_EVENT",
                table: "NOTIFICATION_EVENT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NOTIFICATION",
                table: "NOTIFICATION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LOCAL_AREA",
                table: "LOCAL_AREA",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_INSPECTION",
                table: "INSPECTION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GROUP_MEMBERSHIP",
                table: "GROUP_MEMBERSHIP",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GROUP",
                table: "GROUP",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FAVOURITE_CONTEXT_TYPE",
                table: "FAVOURITE_CONTEXT_TYPE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CITY",
                table: "CITY",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CCWDATA",
                table: "CCWDATA",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CITY_REGION_REGION_ID",
                table: "CITY",
                column: "REGION_ID",
                principalTable: "REGION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GROUP_MEMBERSHIP_GROUP_GROUP_ID",
                table: "GROUP_MEMBERSHIP",
                column: "GROUP_ID",
                principalTable: "GROUP",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GROUP_MEMBERSHIP_USER_USER_ID",
                table: "GROUP_MEMBERSHIP",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTION_USER_INSPECTOR_ID",
                table: "INSPECTION",
                column: "INSPECTOR_ID",
                principalTable: "USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTION_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "INSPECTION",
                column: "SCHOOL_BUS_ID",
                principalTable: "SCHOOL_BUS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LOCAL_AREA_REGION_REGION_ID",
                table: "LOCAL_AREA",
                column: "REGION_ID",
                principalTable: "REGION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NOTIFICATION_NOTIFICATION_EVENT_EVENT2_ID",
                table: "NOTIFICATION",
                column: "EVENT2_ID",
                principalTable: "NOTIFICATION_EVENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NOTIFICATION_NOTIFICATION_EVENT_EVENT_ID",
                table: "NOTIFICATION",
                column: "EVENT_ID",
                principalTable: "NOTIFICATION_EVENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NOTIFICATION_USER_USER_ID",
                table: "NOTIFICATION",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NOTIFICATION_EVENT_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "NOTIFICATION_EVENT",
                column: "SCHOOL_BUS_ID",
                principalTable: "SCHOOL_BUS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ROLE_PERMISSION_PERMISSION_PERMISION_ID",
                table: "ROLE_PERMISSION",
                column: "PERMISION_ID",
                principalTable: "PERMISSION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ROLE_PERMISSION_ROLE_ROLE_ID",
                table: "ROLE_PERMISSION",
                column: "ROLE_ID",
                principalTable: "ROLE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_CCWDATA_CCWDATA_ID",
                table: "SCHOOL_BUS",
                column: "CCWDATA_ID",
                principalTable: "CCWDATA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SCHOOL_BUS_OWNER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_ATTACHMENT",
                column: "SCHOOL_BUS_ID",
                principalTable: "SCHOOL_BUS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_HISTORY_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_HISTORY",
                column: "SCHOOL_BUS_ID",
                principalTable: "SCHOOL_BUS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_NOTE_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_NOTE",
                column: "SCHOOL_BUS_ID",
                principalTable: "SCHOOL_BUS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_CITY_CITY_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "CITY_ID",
                principalTable: "CITY",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_LOCAL_AREA_LOCAL_AREA_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "LOCAL_AREA_ID",
                principalTable: "LOCAL_AREA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SCHOOL_BUS_OWNER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_HISTORY",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SCHOOL_BUS_OWNER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_NOTE",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SCHOOL_BUS_OWNER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_DISTRICT_REGION_REGION_ID",
                table: "SCHOOL_DISTRICT",
                column: "REGION_ID",
                principalTable: "REGION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "USER_FAVOURITE",
                column: "FAVOURITE_CONTEXT_TYPE_ID",
                principalTable: "FAVOURITE_CONTEXT_TYPE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ROLE_ROLE_ROLE_ID",
                table: "USER_ROLE",
                column: "ROLE_ID",
                principalTable: "ROLE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ROLE_USER_USER_ID",
                table: "USER_ROLE",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
