using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB1181112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SERVICE_AREA_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.AddColumn<int>(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_REF_ID");

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
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SERVICE_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.AddColumn<int>(
                name: "SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_DISTRICT_ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SERVICE_AREA_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
