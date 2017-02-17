using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB1932161 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWDATA_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWDATA_REF_ID",
                principalTable: "SBI_CCWDATA",
                principalColumn: "CCWDATA_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWDATA_CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "CCWDATA_REF_ID",
                table: "SBI_SCHOOL_BUS");
        }
    }
}
