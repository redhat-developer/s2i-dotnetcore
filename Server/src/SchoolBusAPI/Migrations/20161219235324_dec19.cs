using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class dec19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_OWNER_ID",
                table: "SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_DISTRICT_LOCAL_AREA_LOCAL_AREA_ID",
                table: "SCHOOL_DISTRICT");

            migrationBuilder.DropTable(
                name: "OWNER_ATTACHMENTS");

            migrationBuilder.DropTable(
                name: "OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropTable(
                name: "OWNER_CONTACT_PHONE");

            migrationBuilder.DropTable(
                name: "OWNER_NOTES");

            migrationBuilder.DropTable(
                name: "USER_NOTIFICATIONS");

            migrationBuilder.DropTable(
                name: "OWNER_CONTACT");

            migrationBuilder.DropTable(
                name: "BUS_NOTIFICATION");

            migrationBuilder.DropTable(
                name: "OWNER");

            migrationBuilder.DropColumn(
                name: "LAST_UPDATE",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "LESSEE_NUMBER",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "LICENSE_EXPIRY_DATE",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "MCCAP",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "MAN_YEAR",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "NEXT_INSPECTION_DATE",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "PLATE",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "SBCAP",
                table: "SCHOOL_BUS");

            migrationBuilder.RenameColumn(
                name: "JSON_DATA",
                table: "USER_FAVOURITE",
                newName: "VALUE");

            migrationBuilder.RenameColumn(
                name: "LOCAL_AREA_ID",
                table: "SCHOOL_DISTRICT",
                newName: "REGION_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_DISTRICT_LOCAL_AREA_ID",
                table: "SCHOOL_DISTRICT",
                newName: "IX_SCHOOL_DISTRICT_REGION_ID");

            migrationBuilder.RenameColumn(
                name: "WCCAP",
                table: "SCHOOL_BUS",
                newName: "NAME_OF_INDEPENDENT_SCHOOL");

            migrationBuilder.RenameColumn(
                name: "PERMIT_EXPIRY_DATE",
                table: "SCHOOL_BUS",
                newName: "NEXT_INSPECTION");

            migrationBuilder.RenameColumn(
                name: "OWNER_ID",
                table: "SCHOOL_BUS",
                newName: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS",
                newName: "IX_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.AddColumn<bool>(
                name: "IS_DEFAULT",
                table: "USER_FAVOURITE",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXPIRED",
                table: "SCHOOL_BUS_NOTE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VALUE",
                table: "SCHOOL_BUS_NOTE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EXTERNAL_FILE_NAME",
                table: "SCHOOL_BUS_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INTERNAL_FILE_NAME",
                table: "SCHOOL_BUS_ATTACHMENT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IS_OUT_OF_PROVINCE",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NOTIFICATION_EVENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EVENT_SUB_TYPE_CODE = table.Column<string>(nullable: true),
                    EVENT_TIME = table.Column<string>(nullable: true),
                    EVENT_TYPE_CODE = table.Column<string>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    NOTIFICATION_GENERATED = table.Column<bool>(nullable: true),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION_EVENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_EVENT_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SCHOOL_BUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_OWNER_CONTACT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_OWNER_CONTACT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EVENT2_ID = table.Column<int>(nullable: true),
                    EVENT_ID = table.Column<int>(nullable: true),
                    HAS_BEEN_VIEWED = table.Column<bool>(nullable: true),
                    IS_ALL_DAY = table.Column<bool>(nullable: true),
                    IS_EXPIRED = table.Column<bool>(nullable: true),
                    IS_WATCH_NOTIFICATION = table.Column<bool>(nullable: true),
                    PRIORITY_CODE = table.Column<string>(nullable: true),
                    USER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_NOTIFICATION_EVENT_EVENT2_ID",
                        column: x => x.EVENT2_ID,
                        principalTable: "NOTIFICATION_EVENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_NOTIFICATION_EVENT_EVENT_ID",
                        column: x => x.EVENT_ID,
                        principalTable: "NOTIFICATION_EVENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_OWNER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CITY_ID = table.Column<int>(nullable: true),
                    DATE_CREATED = table.Column<DateTime>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(nullable: true),
                    LOCAL_AREA_ID = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    PRIMARY_CONTACT_REF_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_OWNER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_LOCAL_AREA_LOCAL_AREA_ID",
                        column: x => x.LOCAL_AREA_ID,
                        principalTable: "LOCAL_AREA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_CONTACT_PRIMARY_CONTACT_REF_ID",
                        column: x => x.PRIMARY_CONTACT_REF_ID,
                        principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_OWNER_CONTACT_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                        column: x => x.SCHOOL_BUS_OWNER_CONTACT_ID,
                        principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_OWNER_CONTACT_PHONE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_OWNER_CONTACT_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_OWNER_CONTACT_PHONE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_SCHOOL_BUS_OWNER_CONTACT_ID",
                        column: x => x.SCHOOL_BUS_OWNER_CONTACT_ID,
                        principalTable: "SCHOOL_BUS_OWNER_CONTACT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_OWNER_ATTACHMENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_OWNER_ATTACHMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SCHOOL_BUS_OWNER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_OWNER_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_OWNER_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SCHOOL_BUS_OWNER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_OWNER_NOTE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EXPIRED = table.Column<bool>(nullable: true),
                    SCHOOL_BUS_OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_OWNER_NOTE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                        column: x => x.SCHOOL_BUS_OWNER_ID,
                        principalTable: "SCHOOL_BUS_OWNER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_EVENT2_ID",
                table: "NOTIFICATION",
                column: "EVENT2_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_EVENT_ID",
                table: "NOTIFICATION",
                column: "EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_USER_ID",
                table: "NOTIFICATION",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_EVENT_SCHOOL_BUS_ID",
                table: "NOTIFICATION_EVENT",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_CITY_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_LOCAL_AREA_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "LOCAL_AREA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_PRIMARY_CONTACT_REF_ID",
                table: "SCHOOL_BUS_OWNER",
                column: "PRIMARY_CONTACT_REF_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_ATTACHMENT_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_ATTACHMENT",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_CONTACT_ADDRESS_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_CONTACT_PHONE_SCHOOL_BUS_OWNER_CONTACT_ID",
                table: "SCHOOL_BUS_OWNER_CONTACT_PHONE",
                column: "SCHOOL_BUS_OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_HISTORY_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_HISTORY",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_NOTE_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS_OWNER_NOTE",
                column: "SCHOOL_BUS_OWNER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS",
                column: "SCHOOL_BUS_OWNER_ID",
                principalTable: "SCHOOL_BUS_OWNER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_DISTRICT_REGION_REGION_ID",
                table: "SCHOOL_DISTRICT",
                column: "REGION_ID",
                principalTable: "REGION",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_BUS_SCHOOL_BUS_OWNER_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS");

            migrationBuilder.DropForeignKey(
                name: "FK_SCHOOL_DISTRICT_REGION_REGION_ID",
                table: "SCHOOL_DISTRICT");

            migrationBuilder.DropTable(
                name: "NOTIFICATION");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_OWNER_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_OWNER_CONTACT_PHONE");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_OWNER_HISTORY");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_OWNER_NOTE");

            migrationBuilder.DropTable(
                name: "NOTIFICATION_EVENT");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_OWNER");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_OWNER_CONTACT");

            migrationBuilder.DropColumn(
                name: "IS_DEFAULT",
                table: "USER_FAVOURITE");

            migrationBuilder.DropColumn(
                name: "EXPIRED",
                table: "SCHOOL_BUS_NOTE");

            migrationBuilder.DropColumn(
                name: "VALUE",
                table: "SCHOOL_BUS_NOTE");

            migrationBuilder.DropColumn(
                name: "EXTERNAL_FILE_NAME",
                table: "SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "INTERNAL_FILE_NAME",
                table: "SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "IS_OUT_OF_PROVINCE",
                table: "SCHOOL_BUS");

            migrationBuilder.RenameColumn(
                name: "VALUE",
                table: "USER_FAVOURITE",
                newName: "JSON_DATA");

            migrationBuilder.RenameColumn(
                name: "REGION_ID",
                table: "SCHOOL_DISTRICT",
                newName: "LOCAL_AREA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_DISTRICT_REGION_ID",
                table: "SCHOOL_DISTRICT",
                newName: "IX_SCHOOL_DISTRICT_LOCAL_AREA_ID");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS",
                newName: "OWNER_ID");

            migrationBuilder.RenameColumn(
                name: "NEXT_INSPECTION",
                table: "SCHOOL_BUS",
                newName: "PERMIT_EXPIRY_DATE");

            migrationBuilder.RenameColumn(
                name: "NAME_OF_INDEPENDENT_SCHOOL",
                table: "SCHOOL_BUS",
                newName: "WCCAP");

            migrationBuilder.RenameIndex(
                name: "IX_SCHOOL_BUS_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS",
                newName: "IX_SCHOOL_BUS_OWNER_ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "LAST_UPDATE",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LESSEE_NUMBER",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LICENSE_EXPIRY_DATE",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MCCAP",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MAN_YEAR",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NEXT_INSPECTION_DATE",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PLATE",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SBCAP",
                table: "SCHOOL_BUS",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BUS_NOTIFICATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUS_NOTIFICATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BUS_NOTIFICATION_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SCHOOL_BUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OWNER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CITY_ID = table.Column<int>(nullable: true),
                    DIFF = table.Column<string>(nullable: true),
                    FLEET_NUM = table.Column<int>(nullable: true),
                    FLEET_SIZE = table.Column<string>(nullable: true),
                    HAS_BUSES = table.Column<int>(nullable: true),
                    HAS_DUPS = table.Column<int>(nullable: true),
                    LEASE_SIZE = table.Column<string>(nullable: true),
                    MCCODE = table.Column<string>(nullable: true),
                    SCHOOL_DISTRICT_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OWNER_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OWNER_SCHOOL_DISTRICT_SCHOOL_DISTRICT_ID",
                        column: x => x.SCHOOL_DISTRICT_ID,
                        principalTable: "SCHOOL_DISTRICT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_NOTIFICATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BUS_NOTIFICATION_ID = table.Column<int>(nullable: true),
                    USER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_NOTIFICATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_NOTIFICATIONS_BUS_NOTIFICATION_BUS_NOTIFICATION_ID",
                        column: x => x.BUS_NOTIFICATION_ID,
                        principalTable: "BUS_NOTIFICATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_NOTIFICATIONS_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OWNER_ATTACHMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER_ATTACHMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OWNER_ATTACHMENTS_OWNER_OWNER_ID",
                        column: x => x.OWNER_ID,
                        principalTable: "OWNER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OWNER_CONTACT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER_CONTACT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OWNER_CONTACT_OWNER_OWNER_ID",
                        column: x => x.OWNER_ID,
                        principalTable: "OWNER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OWNER_NOTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OWNER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER_NOTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OWNER_NOTES_OWNER_OWNER_ID",
                        column: x => x.OWNER_ID,
                        principalTable: "OWNER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OWNER_CONTACT_ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OWNER_CONTACT_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER_CONTACT_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OWNER_CONTACT_ADDRESS_OWNER_CONTACT_OWNER_CONTACT_ID",
                        column: x => x.OWNER_CONTACT_ID,
                        principalTable: "OWNER_CONTACT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OWNER_CONTACT_PHONE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OWNER_CONTACT_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER_CONTACT_PHONE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OWNER_CONTACT_PHONE_OWNER_CONTACT_OWNER_CONTACT_ID",
                        column: x => x.OWNER_CONTACT_ID,
                        principalTable: "OWNER_CONTACT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BUS_NOTIFICATION_SCHOOL_BUS_ID",
                table: "BUS_NOTIFICATION",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNER_CITY_ID",
                table: "OWNER",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNER_SCHOOL_DISTRICT_ID",
                table: "OWNER",
                column: "SCHOOL_DISTRICT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNER_ATTACHMENTS_OWNER_ID",
                table: "OWNER_ATTACHMENTS",
                column: "OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNER_CONTACT_OWNER_ID",
                table: "OWNER_CONTACT",
                column: "OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNER_CONTACT_ADDRESS_OWNER_CONTACT_ID",
                table: "OWNER_CONTACT_ADDRESS",
                column: "OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNER_CONTACT_PHONE_OWNER_CONTACT_ID",
                table: "OWNER_CONTACT_PHONE",
                column: "OWNER_CONTACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNER_NOTES_OWNER_ID",
                table: "OWNER_NOTES",
                column: "OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_NOTIFICATIONS_BUS_NOTIFICATION_ID",
                table: "USER_NOTIFICATIONS",
                column: "BUS_NOTIFICATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_NOTIFICATIONS_USER_ID",
                table: "USER_NOTIFICATIONS",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_BUS_OWNER_OWNER_ID",
                table: "SCHOOL_BUS",
                column: "OWNER_ID",
                principalTable: "OWNER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SCHOOL_DISTRICT_LOCAL_AREA_LOCAL_AREA_ID",
                table: "SCHOOL_DISTRICT",
                column: "LOCAL_AREA_ID",
                principalTable: "LOCAL_AREA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
