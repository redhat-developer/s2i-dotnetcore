using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB2142201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS"
                );

            migrationBuilder.AddColumn<int>(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PERMIT_ISSUE_DATE",
                table: "SBI_SCHOOL_BUS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PERMIT_ISSUE_DATE",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS"
                );

            migrationBuilder.AddColumn<string>(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 20,
                nullable: true);            
        }
    }
}
