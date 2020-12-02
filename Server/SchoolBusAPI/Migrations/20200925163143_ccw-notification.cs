using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class ccwnotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SBI_CCWNOTIFICATION",
                columns: table => new
                {
                    CCWNOTIFICATION_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CREATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    CREATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    LAST_UPDATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    LAST_UPDATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    NOTES = table.Column<string>(maxLength: 2048, nullable: true),
                    HAS_BEEN_VIEWED = table.Column<bool>(nullable: true),
                    SCHOOL_BUS_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CCWNOTIFICATION", x => x.CCWNOTIFICATION_ID);
                    table.ForeignKey(
                        name: "FK_SBI_CCWNOTIFICATION_SBI_SCHOOL_BUS_SCHOOL_BUS_ID",
                        column: x => x.SCHOOL_BUS_ID,
                        principalTable: "SBI_SCHOOL_BUS",
                        principalColumn: "SCHOOL_BUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_CCWNOTIFICATION_SCHOOL_BUS_ID",
                table: "SBI_CCWNOTIFICATION",
                column: "SCHOOL_BUS_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SBI_CCWNOTIFICATION");
        }
    }
}
