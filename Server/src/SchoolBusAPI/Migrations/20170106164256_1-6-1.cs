using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class _161 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SBI_NOTIFICATION_VIEW_MODEL");

            migrationBuilder.DropTable(
                name: "SBI_USER_FAVOURITE_VIEW_MODEL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SBI_NOTIFICATION_VIEW_MODEL",
                columns: table => new
                {
                    NOTIFICATION_VIEW_MODEL_ID = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_SBI_NOTIFICATION_VIEW_MODEL", x => x.NOTIFICATION_VIEW_MODEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_USER_FAVOURITE_VIEW_MODEL",
                columns: table => new
                {
                    USER_FAVOURITE_VIEW_MODEL_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FAVOURITE_CONTEXT_TYPE_ID = table.Column<int>(nullable: true),
                    IS_DEFAULT = table.Column<bool>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    VALUE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_USER_FAVOURITE_VIEW_MODEL", x => x.USER_FAVOURITE_VIEW_MODEL_ID);
                });
        }
    }
}
