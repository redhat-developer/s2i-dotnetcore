using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB190283 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DISTRICT_REF_ID",
                table: "SBI_USER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_USER_DISTRICT_REF_ID",
                table: "SBI_USER",
                column: "DISTRICT_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_USER",
                column: "DISTRICT_REF_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_USER");

            migrationBuilder.DropIndex(
                name: "IX_SBI_USER_DISTRICT_REF_ID",
                table: "SBI_USER");

            migrationBuilder.DropColumn(
                name: "DISTRICT_REF_ID",
                table: "SBI_USER");
        }
    }
}
