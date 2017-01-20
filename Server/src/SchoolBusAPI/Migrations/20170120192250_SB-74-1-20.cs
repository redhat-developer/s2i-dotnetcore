using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB74120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "USER_REF_ID",
                table: "SBI_USER_FAVOURITE",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_USER_FAVOURITE_USER_REF_ID",
                table: "SBI_USER_FAVOURITE",
                column: "USER_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_USER_USER_REF_ID",
                table: "SBI_USER_FAVOURITE",
                column: "USER_REF_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_USER_USER_REF_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropIndex(
                name: "IX_SBI_USER_FAVOURITE_USER_REF_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropColumn(
                name: "USER_REF_ID",
                table: "SBI_USER_FAVOURITE");
        }
    }
}
