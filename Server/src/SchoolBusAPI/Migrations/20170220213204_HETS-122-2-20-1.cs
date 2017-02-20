using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class HETS1222201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EXTERNAL_FILE_NAME",
                table: "SBI_ATTACHMENT");

            migrationBuilder.RenameColumn(
                name: "INTERNAL_FILE_NAME",
                table: "SBI_ATTACHMENT",
                newName: "FILE_NAME");

            migrationBuilder.AddColumn<byte[]>(
                name: "FILE_CONTENTS",
                table: "SBI_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TYPE",
                table: "SBI_ATTACHMENT",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FILE_CONTENTS",
                table: "SBI_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "TYPE",
                table: "SBI_ATTACHMENT");

            migrationBuilder.RenameColumn(
                name: "FILE_NAME",
                table: "SBI_ATTACHMENT",
                newName: "INTERNAL_FILE_NAME");

            migrationBuilder.AddColumn<string>(
                name: "EXTERNAL_FILE_NAME",
                table: "SBI_ATTACHMENT",
                maxLength: 2048,
                nullable: true);
        }
    }
}
