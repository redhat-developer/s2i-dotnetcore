using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class ccwnotificationdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NOTES",
                table: "SBI_CCWNOTIFICATION");

            migrationBuilder.CreateTable(
                name: "SBI_CCWNOTIFICATION_DETAIL",
                columns: table => new
                {
                    CCWNOTIFICATION_DETAIL_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CREATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    CREATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    LAST_UPDATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    LAST_UPDATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    COL_NAME = table.Column<string>(nullable: true),
                    COL_DESCRIPTION = table.Column<string>(nullable: true),
                    VALUE_FROM = table.Column<string>(maxLength: 512, nullable: true),
                    VALUE_TO = table.Column<string>(maxLength: 512, nullable: true),
                    CCWNOTIFICATION_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CCWNOTIFICATION_DETAIL", x => x.CCWNOTIFICATION_DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_SBI_CCWNOTIFICATION_DETAIL_SBI_CCWNOTIFICATION_CCWNOTIFICAT~",
                        column: x => x.CCWNOTIFICATION_ID,
                        principalTable: "SBI_CCWNOTIFICATION",
                        principalColumn: "CCWNOTIFICATION_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CCWNOTIFICATION_DETAIL_CCWNOTIFICATION_ID",
                table: "SBI_CCWNOTIFICATION_DETAIL",
                column: "CCWNOTIFICATION_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SBI_CCWNOTIFICATION_DETAIL");

            migrationBuilder.AddColumn<string>(
                name: "NOTES",
                table: "SBI_CCWNOTIFICATION",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true);
        }
    }
}
