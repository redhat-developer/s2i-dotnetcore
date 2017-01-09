using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_CITY_SBI_REGION_REGION_ID",
                table: "SBI_CITY");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_DISTRICT_SBI_REGION_REGION_ID",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_DISTRICT_REGION_ID",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropIndex(
                name: "IX_SBI_CITY_REGION_ID",
                table: "SBI_CITY");

            migrationBuilder.DropColumn(
                name: "REGION_ID",
                table: "SBI_SCHOOL_DISTRICT");

            migrationBuilder.DropColumn(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_INSPECTION");

            migrationBuilder.DropColumn(
                name: "REGION_ID",
                table: "SBI_CITY");

            migrationBuilder.RenameColumn(
                name: "EXPIRED",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "IS_NO_LONGER_RELEVANT");

            migrationBuilder.RenameColumn(
                name: "EXPIRED",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "IS_NO_LONGER_RELEVANT");

            migrationBuilder.RenameColumn(
                name: "NEXT_INSPECTION",
                table: "SBI_SCHOOL_BUS",
                newName: "NEXT_INSPECTION_DATE");

            migrationBuilder.RenameColumn(
                name: "INDEPENDENT_SCHOOL",
                table: "SBI_SCHOOL_BUS",
                newName: "IS_INDEPENDENT_SCHOOL");

            migrationBuilder.RenameColumn(
                name: "ICBCMICBCAKE",
                table: "SBI_CCWDATA",
                newName: "ICBCMAKE");

            migrationBuilder.AddColumn<string>(
                name: "NEXT_INSPECTION_TYPE",
                table: "SBI_SCHOOL_BUS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NEXT_INSPECTION_TYPE",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.RenameColumn(
                name: "IS_NO_LONGER_RELEVANT",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                newName: "EXPIRED");

            migrationBuilder.RenameColumn(
                name: "IS_NO_LONGER_RELEVANT",
                table: "SBI_SCHOOL_BUS_NOTE",
                newName: "EXPIRED");

            migrationBuilder.RenameColumn(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_SCHOOL_BUS",
                newName: "NEXT_INSPECTION");

            migrationBuilder.RenameColumn(
                name: "IS_INDEPENDENT_SCHOOL",
                table: "SBI_SCHOOL_BUS",
                newName: "INDEPENDENT_SCHOOL");

            migrationBuilder.RenameColumn(
                name: "ICBCMAKE",
                table: "SBI_CCWDATA",
                newName: "ICBCMICBCAKE");

            migrationBuilder.AddColumn<int>(
                name: "REGION_ID",
                table: "SBI_SCHOOL_DISTRICT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "REGION_ID",
                table: "SBI_CITY",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_DISTRICT_REGION_ID",
                table: "SBI_SCHOOL_DISTRICT",
                column: "REGION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CITY_REGION_ID",
                table: "SBI_CITY",
                column: "REGION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_CITY_SBI_REGION_REGION_ID",
                table: "SBI_CITY",
                column: "REGION_ID",
                principalTable: "SBI_REGION",
                principalColumn: "SBI_REGION_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_DISTRICT_SBI_REGION_REGION_ID",
                table: "SBI_SCHOOL_DISTRICT",
                column: "REGION_ID",
                principalTable: "SBI_REGION",
                principalColumn: "SBI_REGION_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
