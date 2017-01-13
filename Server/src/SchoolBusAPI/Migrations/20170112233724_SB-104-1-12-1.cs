using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB1041121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SCHOOL_BUS_OWNER_CONTACT_ID");
            
            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                newName: "SCHOOL_BUS_OWNER_CONTACT_REF_ID");            

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                newName: "SCHOOL_BUS_OWNER_CONTACT_REF_ID");
            
            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
