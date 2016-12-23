using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class dec213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VALUE",
                table: "SCHOOL_BUS_OWNER_NOTE",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VALUE",
                table: "SCHOOL_BUS_OWNER_NOTE");
        }
    }
}
