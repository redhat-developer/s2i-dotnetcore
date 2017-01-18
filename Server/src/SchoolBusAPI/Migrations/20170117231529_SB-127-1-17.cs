using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB127117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_FAVOURITE_CONTEXT_TYPE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropIndex(
                name: "IX_SBI_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.DropColumn(
                name: "FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.AddColumn<string>(
                name: "TYPE",
                table: "SBI_USER_FAVOURITE",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TYPE",
                table: "SBI_USER_FAVOURITE");

            migrationBuilder.AddColumn<int>(
                name: "FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_USER_FAVOURITE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE",
                column: "FAVOURITE_CONTEXT_TYPE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_USER_FAVOURITE_SBI_FAVOURITE_CONTEXT_TYPE_FAVOURITE_CONTEXT_TYPE_ID",
                table: "SBI_USER_FAVOURITE",
                column: "FAVOURITE_CONTEXT_TYPE_ID",
                principalTable: "SBI_FAVOURITE_CONTEXT_TYPE",
                principalColumn: "FAVOURITE_CONTEXT_TYPE_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
