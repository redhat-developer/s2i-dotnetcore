using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class _153 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SBI_USER_ROLE_ID",
                table: "SBI_USER_ROLE",
                newName: "USER_ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_USER_FAVOURITE_VIEW_MODEL_ID",
                table: "SBI_USER_FAVOURITE_VIEW_MODEL",
                newName: "USER_FAVOURITE_VIEW_MODEL_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_USER_FAVOURITE_ID",
                table: "SBI_USER_FAVOURITE",
                newName: "USER_FAVOURITE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_USER_ID",
                table: "SBI_USER",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SERVICE_AREA_ID",
                table: "SBI_SERVICE_AREA",
                newName: "SERVICE_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_DISTRICT_ID",
                table: "SBI_SCHOOL_DISTRICT",
                newName: "SCHOOL_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_NOTE_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "SCHOOL_BUS_OWNER_NOTE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_HISTORY_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "SCHOOL_BUS_OWNER_HISTORY_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SCHOOL_BUS_OWNER_CONTACT_PHONE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "SCHOOL_BUS_OWNER_ATTACHMENT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_NOTE_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "SCHOOL_BUS_NOTE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_HISTORY_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "SCHOOL_BUS_HISTORY_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_ATTACHMENT_ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                newName: "SCHOOL_BUS_ATTACHMENT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_ROLE_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "ROLE_PERMISSION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_ROLE_ID",
                table: "SBI_ROLE",
                newName: "ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_REGION_ID",
                table: "SBI_REGION",
                newName: "REGION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_PERMISSION_ID",
                table: "SBI_PERMISSION",
                newName: "PERMISSION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_NOTIFICATION_VIEW_MODEL_ID",
                table: "SBI_NOTIFICATION_VIEW_MODEL",
                newName: "NOTIFICATION_VIEW_MODEL_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_NOTIFICATION_EVENT_ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "NOTIFICATION_EVENT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_NOTIFICATION_ID",
                table: "SBI_NOTIFICATION",
                newName: "NOTIFICATION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_INSPECTION_ID",
                table: "SBI_INSPECTION",
                newName: "INSPECTION_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_GROUP_MEMBERSHIP_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "GROUP_MEMBERSHIP_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_GROUP_ID",
                table: "SBI_GROUP",
                newName: "GROUP_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_FAVOURITE_CONTEXT_TYPE",
                newName: "FAVOURITE_CONTEXT_TYPE_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_DISTRICT_ID",
                table: "SBI_DISTRICT",
                newName: "DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_CITY_ID",
                table: "SBI_CITY",
                newName: "CITY_ID");

            migrationBuilder.RenameColumn(
                name: "SBI_CCWDATA_ID",
                table: "SBI_CCWDATA",
                newName: "CCWDATA_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "USER_ROLE_ID",
                table: "SBI_USER_ROLE",
                newName: "SBI_USER_ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "USER_FAVOURITE_VIEW_MODEL_ID",
                table: "SBI_USER_FAVOURITE_VIEW_MODEL",
                newName: "SBI_USER_FAVOURITE_VIEW_MODEL_ID");

            migrationBuilder.RenameColumn(
                name: "USER_FAVOURITE_ID",
                table: "SBI_USER_FAVOURITE",
                newName: "SBI_USER_FAVOURITE_ID");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "SBI_USER",
                newName: "SBI_USER_ID");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_ID",
                table: "SBI_SERVICE_AREA",
                newName: "SBI_SERVICE_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_DISTRICT_ID",
                table: "SBI_SCHOOL_DISTRICT",
                newName: "SBI_SCHOOL_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_NOTE_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "SBI_SCHOOL_BUS_OWNER_NOTE_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_HISTORY_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "SBI_SCHOOL_BUS_OWNER_HISTORY_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_PHONE_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "SBI_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ATTACHMENT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SBI_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_NOTE_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "SBI_SCHOOL_BUS_NOTE_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_HISTORY_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "SBI_SCHOOL_BUS_HISTORY_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_ATTACHMENT_ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                newName: "SBI_SCHOOL_BUS_ATTACHMENT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SBI_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "ROLE_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "SBI_ROLE_PERMISSION_ID");

            migrationBuilder.RenameColumn(
                name: "ROLE_ID",
                table: "SBI_ROLE",
                newName: "SBI_ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "REGION_ID",
                table: "SBI_REGION",
                newName: "SBI_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "PERMISSION_ID",
                table: "SBI_PERMISSION",
                newName: "SBI_PERMISSION_ID");

            migrationBuilder.RenameColumn(
                name: "NOTIFICATION_VIEW_MODEL_ID",
                table: "SBI_NOTIFICATION_VIEW_MODEL",
                newName: "SBI_NOTIFICATION_VIEW_MODEL_ID");

            migrationBuilder.RenameColumn(
                name: "NOTIFICATION_EVENT_ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "SBI_NOTIFICATION_EVENT_ID");

            migrationBuilder.RenameColumn(
                name: "NOTIFICATION_ID",
                table: "SBI_NOTIFICATION",
                newName: "SBI_NOTIFICATION_ID");

            migrationBuilder.RenameColumn(
                name: "INSPECTION_ID",
                table: "SBI_INSPECTION",
                newName: "SBI_INSPECTION_ID");

            migrationBuilder.RenameColumn(
                name: "GROUP_MEMBERSHIP_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "SBI_GROUP_MEMBERSHIP_ID");

            migrationBuilder.RenameColumn(
                name: "GROUP_ID",
                table: "SBI_GROUP",
                newName: "SBI_GROUP_ID");

            migrationBuilder.RenameColumn(
                name: "FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_FAVOURITE_CONTEXT_TYPE",
                newName: "SBI_FAVOURITE_CONTEXT_TYPE_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_ID",
                table: "SBI_DISTRICT",
                newName: "SBI_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "CITY_ID",
                table: "SBI_CITY",
                newName: "SBI_CITY_ID");

            migrationBuilder.RenameColumn(
                name: "CCWDATA_ID",
                table: "SBI_CCWDATA",
                newName: "SBI_CCWDATA_ID");
        }
    }
}
