using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolBusAPI.Migrations
{
    public partial class dec21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SM_USERID",
                table: "USER",
                newName: "SM_USER_ID");

            migrationBuilder.AddColumn<bool>(
                name: "ACTIVE",
                table: "USER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INITIALS",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SM_AUTHORIZATION_DIRECTORY",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SURNAME",
                table: "USER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "REGION",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GROUP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CODE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GROUP_MEMBERSHIP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ACTIVE = table.Column<bool>(nullable: false),
                    GROUP_ID = table.Column<int>(nullable: true),
                    USER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_MEMBERSHIP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GROUP_MEMBERSHIP_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GROUP_MEMBERSHIP_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_PERMISSION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PERMISION_ID = table.Column<int>(nullable: true),
                    ROLE_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_PERMISSION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSION_PERMISSION_PERMISION_ID",
                        column: x => x.PERMISION_ID,
                        principalTable: "PERMISSION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSION_ROLE_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EFFECTIVE_DATE = table.Column<DateTime>(nullable: false),
                    EXPIRY_DATE = table.Column<DateTime>(nullable: true),
                    ROLE_ID = table.Column<int>(nullable: true),
                    USER_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ROLE_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_MEMBERSHIP_GROUP_ID",
                table: "GROUP_MEMBERSHIP",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_MEMBERSHIP_USER_ID",
                table: "GROUP_MEMBERSHIP",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSION_PERMISION_ID",
                table: "ROLE_PERMISSION",
                column: "PERMISION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSION_ROLE_ID",
                table: "ROLE_PERMISSION",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ROLE_ID",
                table: "USER_ROLE",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_USER_ID",
                table: "USER_ROLE",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GROUP_MEMBERSHIP");

            migrationBuilder.DropTable(
                name: "ROLE_PERMISSION");

            migrationBuilder.DropTable(
                name: "USER_ROLE");

            migrationBuilder.DropTable(
                name: "GROUP");

            migrationBuilder.DropTable(
                name: "PERMISSION");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropColumn(
                name: "ACTIVE",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "GUID",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "INITIALS",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "SM_AUTHORIZATION_DIRECTORY",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "SURNAME",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "REGION");

            migrationBuilder.RenameColumn(
                name: "SM_USER_ID",
                table: "USER",
                newName: "SM_USERID");
        }
    }
}
