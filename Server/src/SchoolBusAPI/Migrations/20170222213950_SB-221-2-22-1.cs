using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class SB2212221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SBI_CONTACT_ADDRESS");

            migrationBuilder.DropTable(
                name: "SBI_CONTACT_PHONE");

            migrationBuilder.AddColumn<string>(
                name: "ADDRESS1",
                table: "SBI_CONTACT",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ADDRESS2",
                table: "SBI_CONTACT",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CITY",
                table: "SBI_CONTACT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL_ADDRESS",
                table: "SBI_CONTACT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FAX_PHONE_NUMBER",
                table: "SBI_CONTACT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MOBILE_PHONE_NUMBER",
                table: "SBI_CONTACT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ORGANIZATION_NAME",
                table: "SBI_CONTACT",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POSTAL_CODE",
                table: "SBI_CONTACT",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PROVINCE",
                table: "SBI_CONTACT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WORK_PHONE_NUMBER",
                table: "SBI_CONTACT",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ADDRESS1",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "ADDRESS2",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "CITY",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "EMAIL_ADDRESS",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "FAX_PHONE_NUMBER",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "MOBILE_PHONE_NUMBER",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "ORGANIZATION_NAME",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "POSTAL_CODE",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "PROVINCE",
                table: "SBI_CONTACT");

            migrationBuilder.DropColumn(
                name: "WORK_PHONE_NUMBER",
                table: "SBI_CONTACT");

            migrationBuilder.CreateTable(
                name: "SBI_CONTACT_ADDRESS",
                columns: table => new
                {
                    CONTACT_ADDRESS_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ADDRESS1 = table.Column<string>(maxLength: 80, nullable: true),
                    ADDRESS2 = table.Column<string>(maxLength: 80, nullable: true),
                    CITY = table.Column<string>(maxLength: 100, nullable: true),
                    CONTACT_ID = table.Column<int>(nullable: true),
                    CREATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    CREATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    LAST_UPDATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    LAST_UPDATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    POSTAL_CODE = table.Column<string>(maxLength: 15, nullable: true),
                    PROVINCE = table.Column<string>(maxLength: 50, nullable: true),
                    TYPE = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CONTACT_ADDRESS", x => x.CONTACT_ADDRESS_ID);
                    table.ForeignKey(
                        name: "FK_SBI_CONTACT_ADDRESS_SBI_CONTACT_CONTACT_ID",
                        column: x => x.CONTACT_ID,
                        principalTable: "SBI_CONTACT",
                        principalColumn: "CONTACT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_CONTACT_PHONE",
                columns: table => new
                {
                    CONTACT_PHONE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CONTACT_ID = table.Column<int>(nullable: true),
                    CREATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    CREATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    LAST_UPDATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    LAST_UPDATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    PHONE_NUMBER = table.Column<string>(maxLength: 20, nullable: true),
                    TYPE = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CONTACT_PHONE", x => x.CONTACT_PHONE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_CONTACT_PHONE_SBI_CONTACT_CONTACT_ID",
                        column: x => x.CONTACT_ID,
                        principalTable: "SBI_CONTACT",
                        principalColumn: "CONTACT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CONTACT_ADDRESS_CONTACT_ID",
                table: "SBI_CONTACT_ADDRESS",
                column: "CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CONTACT_PHONE_CONTACT_ID",
                table: "SBI_CONTACT_PHONE",
                column: "CONTACT_ID");
        }
    }
}
