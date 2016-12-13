using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CCWDATA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BODY = table.Column<string>(nullable: true),
                    CVIPDECAL = table.Column<string>(nullable: true),
                    CVIPEXPIRY = table.Column<DateTime>(nullable: true),
                    COLOUR = table.Column<string>(nullable: true),
                    FLEET_UNIT_NO = table.Column<int>(nullable: true),
                    FUEL = table.Column<string>(nullable: true),
                    GVW = table.Column<int>(nullable: true),
                    MODEL = table.Column<string>(nullable: true),
                    MODEL_YEAR = table.Column<int>(nullable: true),
                    NET_WT = table.Column<int>(nullable: true),
                    RATE_CLASS = table.Column<string>(nullable: true),
                    REBUILT_STATUS = table.Column<string>(nullable: true),
                    SEATING_CAPACITY = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCWDATA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAVORITE_CONTEXT_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORITE_CONTEXT_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REGION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EMAIL = table.Column<string>(nullable: true),
                    GIVEN_NAME = table.Column<string>(nullable: true),
                    SM_USER_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_FAVORITE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    JSON_DATA = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_FAVORITE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    REGION_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CITY_REGION_REGION_ID",
                        column: x => x.REGION_ID,
                        principalTable: "REGION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOCAL_AREA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    REGION_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL_AREA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOCAL_AREA_REGION_REGION_ID",
                        column: x => x.REGION_ID,
                        principalTable: "REGION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_DISTRICT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LOCAL_AREA_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_DISTRICT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_DISTRICT_LOCAL_AREA_LOCAL_AREA_ID",
                        column: x => x.LOCAL_AREA_ID,
                        principalTable: "LOCAL_AREA",
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
                name: "SCHOOL_BUS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CCWDATA_ID = table.Column<int>(nullable: true),
                    CRNO = table.Column<string>(nullable: true),
                    LAST_UPDATE = table.Column<DateTime>(nullable: true),
                    LESSEE_NUMBER = table.Column<int>(nullable: true),
                    LICENSE_EXPIRY_DATE = table.Column<DateTime>(nullable: true),
                    MCCAP = table.Column<string>(nullable: true),
                    MAN_YEAR = table.Column<int>(nullable: true),
                    NEXT_INSPECTION_DATE = table.Column<DateTime>(nullable: true),
                    OWNER_ID = table.Column<int>(nullable: true),
                    PERMIT_EXPIRY_DATE = table.Column<DateTime>(nullable: true),
                    PLATE = table.Column<string>(nullable: true),
                    SBCAP = table.Column<string>(nullable: true),
                    WCCAP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_CCWDATA_CCWDATA_ID",
                        column: x => x.CCWDATA_ID,
                        principalTable: "CCWDATA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_OWNER_OWNER_ID",
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
                name: "INSPECTION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    INSPECTOR_ID = table.Column<int>(nullable: true),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INSPECTION_USER_INSPECTOR_ID",
                        column: x => x.INSPECTOR_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSPECTION_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SCHOOL_BUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_ATTACHMENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_ATTACHMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SCHOOL_BUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_HISTORY_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SCHOOL_BUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_BUS_NOTE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_BUS_NOTE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_BUS_NOTE_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SCHOOL_BUS",
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

            migrationBuilder.CreateIndex(
                name: "IX_BUS_NOTIFICATION_SCHOOL_BUS_ID",
                table: "BUS_NOTIFICATION",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CITY_REGION_ID",
                table: "CITY",
                column: "REGION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_INSPECTOR_ID",
                table: "INSPECTION",
                column: "INSPECTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_SCHOOL_BUS_ID",
                table: "INSPECTION",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCAL_AREA_REGION_ID",
                table: "LOCAL_AREA",
                column: "REGION_ID");

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
                name: "IX_SCHOOL_BUS_CCWDATA_ID",
                table: "SCHOOL_BUS",
                column: "CCWDATA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_OWNER_ID",
                table: "SCHOOL_BUS",
                column: "OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_ATTACHMENT_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_ATTACHMENT",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_HISTORY_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_HISTORY",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_BUS_NOTE_SCHOOL_BUS_ID",
                table: "SCHOOL_BUS_NOTE",
                column: "SCHOOL_BUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_DISTRICT_LOCAL_AREA_ID",
                table: "SCHOOL_DISTRICT",
                column: "LOCAL_AREA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_NOTIFICATIONS_BUS_NOTIFICATION_ID",
                table: "USER_NOTIFICATIONS",
                column: "BUS_NOTIFICATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_NOTIFICATIONS_USER_ID",
                table: "USER_NOTIFICATIONS",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAVORITE_CONTEXT_TYPE");

            migrationBuilder.DropTable(
                name: "INSPECTION");

            migrationBuilder.DropTable(
                name: "OWNER_ATTACHMENTS");

            migrationBuilder.DropTable(
                name: "OWNER_CONTACT_ADDRESS");

            migrationBuilder.DropTable(
                name: "OWNER_CONTACT_PHONE");

            migrationBuilder.DropTable(
                name: "OWNER_NOTES");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_HISTORY");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS_NOTE");

            migrationBuilder.DropTable(
                name: "USER_FAVORITE");

            migrationBuilder.DropTable(
                name: "USER_NOTIFICATIONS");

            migrationBuilder.DropTable(
                name: "OWNER_CONTACT");

            migrationBuilder.DropTable(
                name: "BUS_NOTIFICATION");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "SCHOOL_BUS");

            migrationBuilder.DropTable(
                name: "CCWDATA");

            migrationBuilder.DropTable(
                name: "OWNER");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "SCHOOL_DISTRICT");

            migrationBuilder.DropTable(
                name: "LOCAL_AREA");

            migrationBuilder.DropTable(
                name: "REGION");
        }
    }
}
