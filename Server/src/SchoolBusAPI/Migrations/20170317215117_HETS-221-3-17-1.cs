using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class HETS2213171 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SBI_AUDIT",
                columns: table => new
                {
                    AUDIT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    APP_CREATE_TIMESTAMP = table.Column<DateTime>(nullable: true),
                    APP_CREATE_USER_DIRECTORY = table.Column<string>(nullable: true),
                    APP_CREATE_USER_GUID = table.Column<string>(nullable: true),
                    APP_CREATE_USERID = table.Column<string>(nullable: true),
                    APP_LAST_UPDATE_TIMESTAMP = table.Column<DateTime>(nullable: true),
                    APP_LAST_UPDATE_USER_DIRECTORY = table.Column<string>(nullable: true),
                    APP_LAST_UPDATE_USER_GUID = table.Column<string>(nullable: true),
                    APP_LAST_UPDATE_USERID = table.Column<string>(nullable: true),
                    CREATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    CREATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    ENTITY_NAME = table.Column<string>(nullable: true),
                    IS_DELETE = table.Column<bool>(nullable: true),
                    LAST_UPDATE_TIMESTAMP = table.Column<DateTime>(nullable: false),
                    LAST_UPDATE_USERID = table.Column<string>(maxLength: 50, nullable: true),
                    NEW_VALUE = table.Column<string>(nullable: true),
                    OLD_VALUE = table.Column<string>(nullable: true),
                    PROPERTY_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_AUDIT", x => x.AUDIT_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SBI_AUDIT");
        }
    }
}
