using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class _191 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SERVICE_AREA_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SERVICE_AREA_REF_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SERVICE_AREA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SERVICE_AREA_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
