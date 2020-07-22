using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB2963101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PREVIOUS_NEXT_INSPECTION_DATE",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PREVIOUS_NEXT_INSPECTION_TYPE_CODE",
                table: "SBI_INSPECTION",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PREVIOUS_NEXT_INSPECTION_DATE",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "PREVIOUS_NEXT_INSPECTION_TYPE_CODE",
                table: "SBI_INSPECTION");
        }
    }
}
