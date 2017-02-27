using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class HETS2271 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_DISTRICT_SBI_REGION_REGION_REF_ID",
                table: "SBI_DISTRICT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_INSPECTION_SBI_USER_INSPECTOR_REF_ID",
                table: "SBI_INSPECTION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_INSPECTION_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_INSPECTION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_REF_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_REF_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_USER_USER_REF_ID",
                table: "SBI_NOTIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_EVENT_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_NOTIFICATION_EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISSION_REF_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_ROLE_ROLE_REF_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWJURISDICTION_CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_HOME_TERMINAL_CITY_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_USER_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SERVICE_AREA_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SERVICE_AREA");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_USER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_USER_USER_REF_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_ROLE_ROLE_REF_ID",
                table: "SBI_USER_ROLE");

            migrationBuilder.RenameColumn(
                name: "ROLE_REF_ID",
                table: "SBI_USER_ROLE",
                newName: "ROLE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_ROLE_ROLE_REF_ID",
                table: "SBI_USER_ROLE",
                newName: "IX_SBI_USER_ROLE_ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "USER_REF_ID",
                table: "SBI_USER_FAVOURITE",
                newName: "USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_FAVOURITE_USER_REF_ID",
                table: "SBI_USER_FAVOURITE",
                newName: "IX_SBI_USER_FAVOURITE_USER_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_REF_ID",
                table: "SBI_USER",
                newName: "DISTRICT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_DISTRICT_REF_ID",
                table: "SBI_USER",
                newName: "IX_SBI_USER_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_REF_ID",
                table: "SBI_SERVICE_AREA",
                newName: "DISTRICT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SERVICE_AREA_DISTRICT_REF_ID",
                table: "SBI_SERVICE_AREA",
                newName: "IX_SBI_SERVICE_AREA_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "PRIMARY_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "DISTRICT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "INSPECTOR_ID");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_CITY_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_CITY_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "CCWJURISDICTION_ID");

            migrationBuilder.RenameColumn(
                name: "CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "CCWDATA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_DISTRICT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_INSPECTOR_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_HOME_TERMINAL_CITY_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_HOME_TERMINAL_CITY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_DISTRICT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_CCWJURISDICTION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_CCWDATA_ID");

            migrationBuilder.RenameColumn(
                name: "ROLE_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "ROLE_ID");

            migrationBuilder.RenameColumn(
                name: "PERMISSION_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "PERMISSION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_ROLE_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_ROLE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_PERMISSION_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_PERMISSION_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_REF_ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "SCHOOL_BUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_SCHOOL_BUS_REF_ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "IX_SBI_NOTIFICATION_EVENT_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "USER_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "EVENT_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "EVENT_ID");

            migrationBuilder.RenameColumn(
                name: "EVENT2_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "EVENT2_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_USER_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT2_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT2_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_REF_ID",
                table: "SBI_INSPECTION",
                newName: "SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "INSPECTOR_REF_ID",
                table: "SBI_INSPECTION",
                newName: "INSPECTOR_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_INSPECTION_SCHOOL_BUS_REF_ID",
                table: "SBI_INSPECTION",
                newName: "IX_SBI_INSPECTION_SCHOOL_BUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_INSPECTION_INSPECTOR_REF_ID",
                table: "SBI_INSPECTION",
                newName: "IX_SBI_INSPECTION_INSPECTOR_ID");

            migrationBuilder.RenameColumn(
                name: "USER_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "GROUP_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "GROUP_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_USER_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "IX_SBI_GROUP_MEMBERSHIP_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_GROUP_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "IX_SBI_GROUP_MEMBERSHIP_GROUP_ID");

            migrationBuilder.RenameColumn(
                name: "REGION_REF_ID",
                table: "SBI_DISTRICT",
                newName: "REGION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_DISTRICT_REGION_REF_ID",
                table: "SBI_DISTRICT",
                newName: "IX_SBI_DISTRICT_REGION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_DISTRICT_SBI_REGION_REGION_ID",
                table: "SBI_DISTRICT",
                column: "REGION_ID",
                principalTable: "SBI_REGION",
                principalColumn: "REGION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "GROUP_ID",
                principalTable: "SBI_GROUP",
                principalColumn: "GROUP_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "USER_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_INSPECTION_SBI_USER_INSPECTOR_ID",
                table: "SBI_INSPECTION",
                column: "INSPECTOR_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_INSPECTION_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_INSPECTION",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT2_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "NOTIFICATION_EVENT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "NOTIFICATION_EVENT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_USER_USER_ID",
                table: "SBI_NOTIFICATION",
                column: "USER_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_EVENT_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_NOTIFICATION_EVENT",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "PERMISSION_ID",
                principalTable: "SBI_PERMISSION",
                principalColumn: "PERMISSION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_ROLE_ROLE_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "ROLE_ID",
                principalTable: "SBI_ROLE",
                principalColumn: "ROLE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWDATA_ID",
                principalTable: "SBI_CCWDATA",
                principalColumn: "CCWDATA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWJURISDICTION_CCWJURISDICTION_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWJURISDICTION_ID",
                principalTable: "SBI_CCWJURISDICTION",
                principalColumn: "CCWJURISDICTION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                column: "DISTRICT_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                column: "HOME_TERMINAL_CITY_ID",
                principalTable: "SBI_CITY",
                principalColumn: "CITY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_USER_INSPECTOR_ID",
                table: "SBI_SCHOOL_BUS",
                column: "INSPECTOR_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_DISTRICT_ID",
                principalTable: "SBI_SCHOOL_DISTRICT",
                principalColumn: "SCHOOL_DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "DISTRICT_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CONTACT_PRIMARY_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_ID",
                principalTable: "SBI_CONTACT",
                principalColumn: "CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SERVICE_AREA_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_SERVICE_AREA",
                column: "DISTRICT_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_USER",
                column: "DISTRICT_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_USER_USER_ID",
                table: "SBI_USER_FAVOURITE",
                column: "USER_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_ROLE_ROLE_ID",
                table: "SBI_USER_ROLE",
                column: "ROLE_ID",
                principalTable: "SBI_ROLE",
                principalColumn: "ROLE_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_DISTRICT_SBI_REGION_REGION_ID",
                table: "SBI_DISTRICT");

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
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_ROLE_ROLE_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWJURISDICTION_CCWJURISDICTION_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_USER_INSPECTOR_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CONTACT_PRIMARY_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SERVICE_AREA_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_SERVICE_AREA");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_SBI_DISTRICT_DISTRICT_ID",
                table: "SBI_USER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_USER_USER_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_ROLE_ROLE_ID",
                table: "SBI_USER_ROLE");

            migrationBuilder.RenameColumn(
                name: "ROLE_ID",
                table: "SBI_USER_ROLE",
                newName: "ROLE_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_ROLE_ROLE_ID",
                table: "SBI_USER_ROLE",
                newName: "IX_SBI_USER_ROLE_ROLE_REF_ID");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "SBI_USER_FAVOURITE",
                newName: "USER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_FAVOURITE_USER_ID",
                table: "SBI_USER_FAVOURITE",
                newName: "IX_SBI_USER_FAVOURITE_USER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_ID",
                table: "SBI_USER",
                newName: "DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_USER_DISTRICT_ID",
                table: "SBI_USER",
                newName: "IX_SBI_USER_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_ID",
                table: "SBI_SERVICE_AREA",
                newName: "DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SERVICE_AREA_DISTRICT_ID",
                table: "SBI_SERVICE_AREA",
                newName: "IX_SBI_SERVICE_AREA_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "PRIMARY_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "PRIMARY_CONTACT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "INSPECTOR_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "INSPECTOR_REF_ID");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_CITY_REF_ID");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "CCWJURISDICTION_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "CCWJURISDICTION_REF_ID");

            migrationBuilder.RenameColumn(
                name: "CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "CCWDATA_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_INSPECTOR_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_INSPECTOR_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_HOME_TERMINAL_CITY_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWJURISDICTION_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_CCWJURISDICTION_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWDATA_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_CCWDATA_REF_ID");

            migrationBuilder.RenameColumn(
                name: "ROLE_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "ROLE_REF_ID");

            migrationBuilder.RenameColumn(
                name: "PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "PERMISSION_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_ROLE_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_ROLE_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_PERMISSION_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "SCHOOL_BUS_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_SCHOOL_BUS_ID",
                table: "SBI_NOTIFICATION_EVENT",
                newName: "IX_SBI_NOTIFICATION_EVENT_SCHOOL_BUS_REF_ID");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "SBI_NOTIFICATION",
                newName: "USER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "EVENT_ID",
                table: "SBI_NOTIFICATION",
                newName: "EVENT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "EVENT2_ID",
                table: "SBI_NOTIFICATION",
                newName: "EVENT2_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_USER_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_USER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT2_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT2_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_ID",
                table: "SBI_INSPECTION",
                newName: "SCHOOL_BUS_REF_ID");

            migrationBuilder.RenameColumn(
                name: "INSPECTOR_ID",
                table: "SBI_INSPECTION",
                newName: "INSPECTOR_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_INSPECTION_SCHOOL_BUS_ID",
                table: "SBI_INSPECTION",
                newName: "IX_SBI_INSPECTION_SCHOOL_BUS_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_INSPECTION_INSPECTOR_ID",
                table: "SBI_INSPECTION",
                newName: "IX_SBI_INSPECTION_INSPECTOR_REF_ID");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "USER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "GROUP_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "GROUP_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_USER_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "IX_SBI_GROUP_MEMBERSHIP_USER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_GROUP_MEMBERSHIP_GROUP_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                newName: "IX_SBI_GROUP_MEMBERSHIP_GROUP_REF_ID");

            migrationBuilder.RenameColumn(
                name: "REGION_ID",
                table: "SBI_DISTRICT",
                newName: "REGION_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_DISTRICT_REGION_ID",
                table: "SBI_DISTRICT",
                newName: "IX_SBI_DISTRICT_REGION_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_DISTRICT_SBI_REGION_REGION_REF_ID",
                table: "SBI_DISTRICT",
                column: "REGION_REF_ID",
                principalTable: "SBI_REGION",
                principalColumn: "REGION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "GROUP_REF_ID",
                principalTable: "SBI_GROUP",
                principalColumn: "GROUP_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP",
                column: "USER_REF_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_INSPECTION_SBI_USER_INSPECTOR_REF_ID",
                table: "SBI_INSPECTION",
                column: "INSPECTOR_REF_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_INSPECTION_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_INSPECTION",
                column: "SCHOOL_BUS_REF_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_REF_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT2_REF_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "NOTIFICATION_EVENT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_REF_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT_REF_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "NOTIFICATION_EVENT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_USER_USER_REF_ID",
                table: "SBI_NOTIFICATION",
                column: "USER_REF_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_NOTIFICATION_EVENT_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_NOTIFICATION_EVENT",
                column: "SCHOOL_BUS_REF_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISSION_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "PERMISSION_REF_ID",
                principalTable: "SBI_PERMISSION",
                principalColumn: "PERMISSION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_ROLE_ROLE_REF_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "ROLE_REF_ID",
                principalTable: "SBI_ROLE",
                principalColumn: "ROLE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWDATA_REF_ID",
                principalTable: "SBI_CCWDATA",
                principalColumn: "CCWDATA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWJURISDICTION_CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWJURISDICTION_REF_ID",
                principalTable: "SBI_CCWJURISDICTION",
                principalColumn: "CCWJURISDICTION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "DISTRICT_REF_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_HOME_TERMINAL_CITY_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "HOME_TERMINAL_CITY_REF_ID",
                principalTable: "SBI_CITY",
                principalColumn: "CITY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_USER_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "INSPECTOR_REF_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_DISTRICT_REF_ID",
                principalTable: "SBI_SCHOOL_DISTRICT",
                principalColumn: "SCHOOL_DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "DISTRICT_REF_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                principalTable: "SBI_CONTACT",
                principalColumn: "CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SERVICE_AREA_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SERVICE_AREA",
                column: "DISTRICT_REF_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_USER",
                column: "DISTRICT_REF_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_USER_USER_REF_ID",
                table: "SBI_USER_FAVOURITE",
                column: "USER_REF_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_ROLE_SBI_ROLE_ROLE_REF_ID",
                table: "SBI_USER_ROLE",
                column: "ROLE_REF_ID",
                principalTable: "SBI_ROLE",
                principalColumn: "ROLE_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
