using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB951131 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_REF_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_REF2_ID",
                table: "SBI_NOTIFICATION");

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
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_ID");

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
                name: "EVENT_REF2_ID",
                table: "SBI_NOTIFICATION",
                newName: "EVENT2_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT_REF2_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT2_REF_ID");

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

            migrationBuilder.AddColumn<string>(
                name: "HOME_TERMINAL_COMMENT",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INSPECTION_TYPE",
                table: "SBI_INSPECTION",
                nullable: true);

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
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_REF_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT2_REF_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "NOTIFICATION_EVENT_ID",
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
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_GROUP_GROUP_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_GROUP_MEMBERSHIP_SBI_USER_USER_ID",
                table: "SBI_GROUP_MEMBERSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT2_REF_ID",
                table: "SBI_NOTIFICATION");

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
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropColumn(
                name: "HOME_TERMINAL_COMMENT",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "INSPECTION_TYPE",
                table: "SBI_INSPECTION");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_REF_ID");

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
                name: "EVENT2_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "EVENT_REF2_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_NOTIFICATION_EVENT2_REF_ID",
                table: "SBI_NOTIFICATION",
                newName: "IX_SBI_NOTIFICATION_EVENT_REF2_ID");

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
                name: "FK_SBI_NOTIFICATION_SBI_NOTIFICATION_EVENT_EVENT_REF2_ID",
                table: "SBI_NOTIFICATION",
                column: "EVENT_REF2_ID",
                principalTable: "SBI_NOTIFICATION_EVENT",
                principalColumn: "NOTIFICATION_EVENT_ID",
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
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
