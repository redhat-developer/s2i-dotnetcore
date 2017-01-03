using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class jan03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISION_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.RenameColumn(
                name: "PERMISION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "PERMISSION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_PERMISION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_PERMISSION_ID");

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "SBI_LOCAL_AREA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "SBI_CITY",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "PERMISSION_ID",
                principalTable: "SBI_PERMISSION",
                principalColumn: "SBI_PERMISSION_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION");

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "SBI_LOCAL_AREA");

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "SBI_CITY");

            migrationBuilder.RenameColumn(
                name: "PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "PERMISION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_ROLE_PERMISSION_PERMISSION_ID",
                table: "SBI_ROLE_PERMISSION",
                newName: "IX_SBI_ROLE_PERMISSION_PERMISION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_ROLE_PERMISSION_SBI_PERMISSION_PERMISION_ID",
                table: "SBI_ROLE_PERMISSION",
                column: "PERMISION_ID",
                principalTable: "SBI_PERMISSION",
                principalColumn: "SBI_PERMISSION_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
