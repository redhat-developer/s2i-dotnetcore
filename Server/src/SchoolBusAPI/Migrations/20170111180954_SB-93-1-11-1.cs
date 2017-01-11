using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB931111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_CITY",
                table: "SBI_CITY",
                newName: "NAME");

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "SBI_SCHOOL_DISTRICT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SHORT_NAME",
                table: "SBI_SCHOOL_DISTRICT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NAME",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropColumn(
                name: "SHORT_NAME",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "SBI_CITY",
                newName: "_CITY");
        }
    }
}
