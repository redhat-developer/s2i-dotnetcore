using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB931101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_LOCATION_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SERVICE_AREA_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameColumn(
                name: "LOCATION_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "BUS_LOCATION_PROV",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_PROVINCE");

            migrationBuilder.RenameColumn(
                name: "BUS_LOCATION_POST_CODE",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_POSTAL_CODE");

            migrationBuilder.RenameColumn(
                name: "BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_CITY_ID");

            migrationBuilder.RenameColumn(
                name: "BUS_LOCATION_ADDR2",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_ADDR2");

            migrationBuilder.RenameColumn(
                name: "BUS_LOCATION_ADDR1",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_ADDR1");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_LOCATION_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_HOME_TERMINAL_CITY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                column: "HOME_TERMINAL_CITY_ID",
                principalTable: "SBI_CITY",
                principalColumn: "CITY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_DISTRICT_REF_ID",
                principalTable: "SBI_SCHOOL_DISTRICT",
                principalColumn: "SCHOOL_DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SERVICE_AREA_REF_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_DISTRICT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "LOCATION_ID");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_PROVINCE",
                table: "SBI_SCHOOL_BUS",
                newName: "BUS_LOCATION_PROV");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_POSTAL_CODE",
                table: "SBI_SCHOOL_BUS",
                newName: "BUS_LOCATION_POST_CODE");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "BUS_LOCATION_CITY_ID");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_ADDR2",
                table: "SBI_SCHOOL_BUS",
                newName: "BUS_LOCATION_ADDR2");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_ADDR1",
                table: "SBI_SCHOOL_BUS",
                newName: "BUS_LOCATION_ADDR1");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_LOCATION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_HOME_TERMINAL_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_BUS_LOCATION_CITY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CITY_BUS_LOCATION_CITY_ID",
                table: "SBI_SCHOOL_BUS",
                column: "BUS_LOCATION_CITY_ID",
                principalTable: "SBI_CITY",
                principalColumn: "CITY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_LOCATION_ID",
                table: "SBI_SCHOOL_BUS",
                column: "LOCATION_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_DISTRICT_ID",
                principalTable: "SBI_SCHOOL_DISTRICT",
                principalColumn: "SCHOOL_DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER",
                principalColumn: "SCHOOL_BUS_OWNER_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
