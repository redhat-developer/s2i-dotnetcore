using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB1051181 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "INSPECTOR_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_USER_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "INSPECTOR_REF_ID",
                principalTable: "SBI_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_USER_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "INSPECTOR_REF_ID",
                table: "SBI_SCHOOL_BUS");
        }
    }
}
