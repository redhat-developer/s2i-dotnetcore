using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class _19foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_NOTE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_ID",
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

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SCHOOL_BUS_OWNER_CONTACT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SCHOOL_BUS_OWNER_CONTACT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SERVICE_AREA_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "SCHOOL_BUS_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "SCHOOL_BUS_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_REF_ID");

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
                newName: "EVENT_REF2_ID");

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
                newName: "IX_SBI_NOTIFICATION_EVENT_REF2_ID");

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

            migrationBuilder.AddColumn<int>(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID");

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
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_REF2_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT_REF2_ID",
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
                name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                column: "SCHOOL_BUS_REF_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                column: "SCHOOL_BUS_REF_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SERVICE_AREA_REF_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                column: "SCHOOL_BUS_OWNER_REF_ID",
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
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_REF2_ID",
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
                name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_NOTE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SERVICE_AREA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "SCHOOL_BUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "SCHOOL_BUS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                newName: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_ID");

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
                name: "EVENT_REF2_ID",
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
                name: "IX_SBI_NOTIFICATION_EVENT_REF2_ID",
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

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                unique: true);

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
                name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                column: "SCHOOL_BUS_ID",
                principalTable: "SBI_SCHOOL_BUS",
                principalColumn: "SCHOOL_BUS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SERVICE_AREA_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
