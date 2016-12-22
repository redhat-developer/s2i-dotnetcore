using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class dec212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER");

            migrationBuilder.AlterColumn<int>(
                name: "PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER");

            migrationBuilder.AlterColumn<int>(
                name: "PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
