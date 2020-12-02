using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB190281 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ICBCLICENCE_PLATE_NUMBER",
                table: "SBI_CCWDATA",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICBCVEHICLE_IDENTIFICATION_NUMBER",
                table: "SBI_CCWDATA",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ICBCLICENCE_PLATE_NUMBER",
                table: "SBI_CCWDATA");

            migrationBuilder.DropColumn(
                name: "ICBCVEHICLE_IDENTIFICATION_NUMBER",
                table: "SBI_CCWDATA");
        }
    }
}
