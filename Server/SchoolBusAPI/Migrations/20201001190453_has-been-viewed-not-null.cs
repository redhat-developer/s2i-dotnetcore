using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class hasbeenviewednotnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HAS_BEEN_VIEWED",
                table: "SBI_CCWNOTIFICATION",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HAS_BEEN_VIEWED",
                table: "SBI_CCWNOTIFICATION",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
