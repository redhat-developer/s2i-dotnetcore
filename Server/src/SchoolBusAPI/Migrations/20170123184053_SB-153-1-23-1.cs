using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class SB1531231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_HISTORY");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_NOTE");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropColumn(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "NUMBER_OF_BUSES",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropColumn(
                name: "HOME_TERMINAL_ADDR1",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "INSPECTION_RESULT",
                table: "SBI_INSPECTION");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "VIN",
                table: "SBI_SCHOOL_BUS",
                newName: "VEHICLE_IDENTIFICATION_NUMBER");

            migrationBuilder.RenameColumn(
                name: "SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_UNIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                newName: "UNIT_NUMBER");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_CLASS",
                table: "SBI_SCHOOL_BUS",
                newName: "RESTRICTIONS_TEXT");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_BODY_TYPE_OTHER",
                table: "SBI_SCHOOL_BUS",
                newName: "PERMIT_CLASS_CODE");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_BODY_TYPE",
                table: "SBI_SCHOOL_BUS",
                newName: "NEXT_INSPECTION_TYPE_CODE");

            migrationBuilder.RenameColumn(
                name: "RESTRICTIONS",
                table: "SBI_SCHOOL_BUS",
                newName: "LICENCE_PLATE_NUMBER");

            migrationBuilder.RenameColumn(
                name: "REGI",
                table: "SBI_SCHOOL_BUS",
                newName: "INDEPENDENT_SCHOOL_NAME");

            migrationBuilder.RenameColumn(
                name: "PLATE",
                table: "SBI_SCHOOL_BUS",
                newName: "ICBCREGISTRATION_NUMBER");

            migrationBuilder.RenameColumn(
                name: "NEXT_INSPECTION_TYPE",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_ADDRESS2");

            migrationBuilder.RenameColumn(
                name: "NAME_OF_INDEPENDENT_SCHOOL",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_ADDRESS1");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_ADDR2",
                table: "SBI_SCHOOL_BUS",
                newName: "BODY_TYPE_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_DISTRICT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "RESTRICTIONS",
                table: "SBI_INSPECTION",
                newName: "INSPECTION_TYPE_CODE");

            migrationBuilder.RenameColumn(
                name: "INSPECTION_TYPE",
                table: "SBI_INSPECTION",
                newName: "INSPECTION_RESULT_CODE");

            migrationBuilder.RenameColumn(
                name: "ICBCREGI",
                table: "SBI_CCWDATA",
                newName: "ICBCREGISTRATION_NUMBER");

            migrationBuilder.CreateTable(
                name: "SBI_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    EXTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    INTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_ATTACHMENT", x => x.ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_ATTACHMENT_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_CONTACT",
                columns: table => new
                {
                    CONTACT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GIVEN_NAME = table.Column<string>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    ROLE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true),
                    SURNAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CONTACT", x => x.CONTACT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_HISTORY",
                columns: table => new
                {
                    HISTORY_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HISTORY_TEXT = table.Column<string>(nullable: true),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_HISTORY", x => x.HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_SBI_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_NOTE",
                columns: table => new
                {
                    NOTE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IS_NO_LONGER_RELEVANT = table.Column<bool>(nullable: true),
                    NOTE_TEXT = table.Column<string>(nullable: true),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_NOTE", x => x.NOTE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SBI_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_CONTACT_ADDRESS",
                columns: table => new
                {
                    CONTACT_ADDRESS_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ADDRESS1 = table.Column<string>(nullable: true),
                    ADDRESS2 = table.Column<string>(nullable: true),
                    CITY = table.Column<string>(nullable: true),
                    CONTACT_ID = table.Column<int>(nullable: true),
                    POSTAL_CODE = table.Column<string>(nullable: true),
                    PROVINCE = table.Column<string>(nullable: true),
                    TYPE = table.Column<string>(nullable: true)
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
                    PHONE_NUMBER = table.Column<string>(nullable: true),
                    TYPE = table.Column<string>(nullable: true)
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
                name: "IX_SBI_ATTACHMENT_SCHOOL_BUS_ID",
                table: "SBI_ATTACHMENT",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_ATTACHMENT_SCHOOL_BUS_OWNER_ID",
                table: "SBI_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CONTACT_SCHOOL_BUS_OWNER_ID",
                table: "SBI_CONTACT",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CONTACT_ADDRESS_CONTACT_ID",
                table: "SBI_CONTACT_ADDRESS",
                column: "CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CONTACT_PHONE_CONTACT_ID",
                table: "SBI_CONTACT_PHONE",
                column: "CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_HISTORY_SCHOOL_BUS_ID",
                table: "SBI_HISTORY",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_HISTORY_SCHOOL_BUS_OWNER_ID",
                table: "SBI_HISTORY",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_NOTE_SCHOOL_BUS_ID",
                table: "SBI_NOTE",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_NOTE_SCHOOL_BUS_OWNER_ID",
                table: "SBI_NOTE",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "DISTRICT_REF_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_DISTRICT_REF_ID",
                principalTable: "SBI_SCHOOL_DISTRICT",
                principalColumn: "SCHOOL_DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "DISTRICT_REF_ID",
                principalTable: "SBI_DISTRICT",
                principalColumn: "DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                principalTable: "SBI_CONTACT",
                principalColumn: "CONTACT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_DISTRICT_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER");

            migrationBuilder.DropTable(
                name: "SBI_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SBI_CONTACT_ADDRESS");

            migrationBuilder.DropTable(
                name: "SBI_CONTACT_PHONE");

            migrationBuilder.DropTable(
                name: "SBI_HISTORY");

            migrationBuilder.DropTable(
                name: "SBI_NOTE");

            migrationBuilder.DropTable(
                name: "SBI_CONTACT");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "SERVICE_AREA_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                newName: "IX_SBI_SCHOOL_BUS_OWNER_SERVICE_AREA_REF_ID");

            migrationBuilder.RenameColumn(
                name: "VEHICLE_IDENTIFICATION_NUMBER",
                table: "SBI_SCHOOL_BUS",
                newName: "VIN");

            migrationBuilder.RenameColumn(
                name: "UNIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_UNIT_NUMBER");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SERVICE_AREA_REF_ID");

            migrationBuilder.RenameColumn(
                name: "RESTRICTIONS_TEXT",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_CLASS");

            migrationBuilder.RenameColumn(
                name: "PERMIT_CLASS_CODE",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_BODY_TYPE_OTHER");

            migrationBuilder.RenameColumn(
                name: "NEXT_INSPECTION_TYPE_CODE",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_BODY_TYPE");

            migrationBuilder.RenameColumn(
                name: "LICENCE_PLATE_NUMBER",
                table: "SBI_SCHOOL_BUS",
                newName: "RESTRICTIONS");

            migrationBuilder.RenameColumn(
                name: "INDEPENDENT_SCHOOL_NAME",
                table: "SBI_SCHOOL_BUS",
                newName: "REGI");

            migrationBuilder.RenameColumn(
                name: "ICBCREGISTRATION_NUMBER",
                table: "SBI_SCHOOL_BUS",
                newName: "PLATE");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_ADDRESS2",
                table: "SBI_SCHOOL_BUS",
                newName: "NEXT_INSPECTION_TYPE");

            migrationBuilder.RenameColumn(
                name: "HOME_TERMINAL_ADDRESS1",
                table: "SBI_SCHOOL_BUS",
                newName: "NAME_OF_INDEPENDENT_SCHOOL");

            migrationBuilder.RenameColumn(
                name: "DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "BODY_TYPE_CODE",
                table: "SBI_SCHOOL_BUS",
                newName: "HOME_TERMINAL_ADDR2");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_SCHOOL_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SERVICE_AREA_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SBI_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                newName: "IX_SBI_SCHOOL_BUS_SCHOOL_BUS_DISTRICT_REF_ID");

            migrationBuilder.RenameColumn(
                name: "INSPECTION_TYPE_CODE",
                table: "SBI_INSPECTION",
                newName: "RESTRICTIONS");

            migrationBuilder.RenameColumn(
                name: "INSPECTION_RESULT_CODE",
                table: "SBI_INSPECTION",
                newName: "INSPECTION_TYPE");

            migrationBuilder.RenameColumn(
                name: "ICBCREGISTRATION_NUMBER",
                table: "SBI_CCWDATA",
                newName: "ICBCREGI");

            migrationBuilder.AddColumn<DateTime>(
                name: "NEXT_INSPECTION_DATE",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NUMBER_OF_BUSES",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HOME_TERMINAL_ADDR1",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INSPECTION_RESULT",
                table: "SBI_INSPECTION",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_ATTACHMENT",
                columns: table => new
                {
                    SCHOOL_BUS_ATTACHMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    EXTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    INTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_ATTACHMENT", x => x.SCHOOL_BUS_ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_ATTACHMENT_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_HISTORY",
                columns: table => new
                {
                    SCHOOL_BUS_HISTORY_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_HISTORY", x => x.SCHOOL_BUS_HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_HISTORY_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_NOTE",
                columns: table => new
                {
                    SCHOOL_BUS_NOTE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IS_NO_LONGER_RELEVANT = table.Column<bool>(nullable: true),
                    NOTE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_NOTE", x => x.SCHOOL_BUS_NOTE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_NOTE_SBI_SCHOOL_BUS_SCHOOL_BUS_REF_ID",
                        column: x => x.SCHOOL_BUS_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_ATTACHMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    EXTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    INTERNAL_FILE_NAME = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT", x => x.SCHOOL_BUS_OWNER_ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                        column: x => x.SCHOOL_BUS_OWNER_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GIVEN_NAME = table.Column<string>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    ROLE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true),
                    SURNAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_CONTACT", x => x.SCHOOL_BUS_OWNER_CONTACT_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_HISTORY_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_OWNER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_HISTORY", x => x.SCHOOL_BUS_OWNER_HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_HISTORY_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                        column: x => x.SCHOOL_BUS_OWNER_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_NOTE",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_NOTE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IS_NO_LONGER_RELEVANT = table.Column<bool>(nullable: true),
                    NOTE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_REF_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_NOTE", x => x.SCHOOL_BUS_OWNER_NOTE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_NOTE_SBI_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_REF_ID",
                        column: x => x.SCHOOL_BUS_OWNER_REF_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER",
                        principalColumn: "SCHOOL_BUS_OWNER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ADDR1 = table.Column<string>(nullable: true),
                    ADDR2 = table.Column<string>(nullable: true),
                    CITY = table.Column<string>(nullable: true),
                    POSTAL_CODE = table.Column<string>(nullable: true),
                    PROVINCE = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: true),
                    TYPE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS", x => x.SCHOOL_BUS_OWNER_CONTACT_ADDRESS_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                        column: x => x.SCHOOL_BUS_OWNER_CONTACT_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                columns: table => new
                {
                    SCHOOL_BUS_OWNER_CONTACT_PHONE_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PHONE_NUMBER = table.Column<string>(nullable: true),
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: true),
                    TYPE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE", x => x.SCHOOL_BUS_OWNER_CONTACT_PHONE_ID);
                    table.ForeignKey(
                        name: "FK_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                        column: x => x.SCHOOL_BUS_OWNER_CONTACT_ID,
                        principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_ATTACHMENT",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_HISTORY_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_HISTORY",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_NOTE_SCHOOL_BUS_REF_ID",
                table: "SBI_SCHOOL_BUS_NOTE",
                column: "SCHOOL_BUS_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SBI_SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_HISTORY",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER_NOTE",
                column: "SCHOOL_BUS_OWNER_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SCHOOL_DISTRICT_SCHOOL_BUS_DISTRICT_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SCHOOL_BUS_DISTRICT_REF_ID",
                principalTable: "SBI_SCHOOL_DISTRICT",
                principalColumn: "SCHOOL_DISTRICT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "SERVICE_AREA_REF_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                principalTable: "SBI_SCHOOL_BUS_OWNER_CONTACT",
                principalColumn: "SCHOOL_BUS_OWNER_CONTACT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_OWNER_SBI_SERVICE_AREA_SERVICE_AREA_REF_ID",
                table: "SBI_SCHOOL_BUS_OWNER",
                column: "SERVICE_AREA_REF_ID",
                principalTable: "SBI_SERVICE_AREA",
                principalColumn: "SERVICE_AREA_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
