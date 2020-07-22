using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class SB2082171 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SBI_CCWJURISDICTION",
                columns: table => new
                {
                    CCWJURISDICTION_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ACTIVE_FLAG = table.Column<bool>(nullable: true),
                    CODE = table.Column<string>(maxLength: 10, nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 50, nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(nullable: true),
                    JURISDICTION_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_CCWJURISDICTION", x => x.CCWJURISDICTION_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWJURISDICTION_REF_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWJURISDICTION_CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS",
                column: "CCWJURISDICTION_REF_ID",
                principalTable: "SBI_CCWJURISDICTION",
                principalColumn: "CCWJURISDICTION_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SBI_SCHOOL_BUS_SBI_CCWJURISDICTION_CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropTable(
                name: "SBI_CCWJURISDICTION");

            migrationBuilder.DropIndex(
                name: "IX_SBI_SCHOOL_BUS_CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS");

            migrationBuilder.DropColumn(
                name: "CCWJURISDICTION_REF_ID",
                table: "SBI_SCHOOL_BUS");
        }
    }
}
