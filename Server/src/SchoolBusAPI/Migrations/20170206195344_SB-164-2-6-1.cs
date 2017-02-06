using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBusAPI.Migrations
{
    public partial class SB164261 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ICBCREG_OWNER_POOL",
                table: "SBI_CCWDATA",
                newName: "ICBCREG_OWNER_PODL");

            migrationBuilder.AlterColumn<string>(
                name: "SURNAME",
                table: "SBI_USER",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INITIALS",
                table: "SBI_USER",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MINISTRY_SERVICE_AREA_ID",
                table: "SBI_SERVICE_AREA",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS_OWNER",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SBI_SCHOOL_BUS_OWNER",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_CREATED",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UNIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SCHOOL_BUS_SEATING_CAPACITY",
                table: "SBI_SCHOOL_BUS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PERMIT_CLASS_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NEXT_INSPECTION_TYPE_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LICENCE_PLATE_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INDEPENDENT_SCHOOL_NAME",
                table: "SBI_SCHOOL_BUS",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ICBCREGISTRATION_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_PROVINCE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_POSTAL_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_ADDRESS2",
                table: "SBI_SCHOOL_BUS",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_ADDRESS1",
                table: "SBI_SCHOOL_BUS",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BODY_TYPE_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MINISTRY_REGION_ID",
                table: "SBI_REGION",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "INSPECTION_DATE",
                table: "SBI_INSPECTION",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_DATE",
                table: "SBI_INSPECTION",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MINISTRY_DISTRICT_ID",
                table: "SBI_DISTRICT",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TYPE",
                table: "SBI_CONTACT_PHONE",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE_NUMBER",
                table: "SBI_CONTACT_PHONE",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TYPE",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROVINCE",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSTAL_CODE",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CITY",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS2",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS1",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SURNAME",
                table: "SBI_CONTACT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                table: "SBI_CONTACT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "SBI_CONTACT",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GIVEN_NAME",
                table: "SBI_CONTACT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ICBCREG_OWNER_PODL",
                table: "SBI_CCWDATA",
                newName: "ICBCREG_OWNER_POOL");

            migrationBuilder.AlterColumn<string>(
                name: "SURNAME",
                table: "SBI_USER",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INITIALS",
                table: "SBI_USER",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MINISTRY_SERVICE_AREA_ID",
                table: "SBI_SERVICE_AREA",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS_OWNER",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "SBI_SCHOOL_BUS_OWNER",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_CREATED",
                table: "SBI_SCHOOL_BUS_OWNER",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "UNIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SCHOOL_BUS_SEATING_CAPACITY",
                table: "SBI_SCHOOL_BUS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PERMIT_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PERMIT_CLASS_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NEXT_INSPECTION_TYPE_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LICENCE_PLATE_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INDEPENDENT_SCHOOL_NAME",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ICBCREGISTRATION_NUMBER",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_PROVINCE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_POSTAL_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_ADDRESS2",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HOME_TERMINAL_ADDRESS1",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BODY_TYPE_CODE",
                table: "SBI_SCHOOL_BUS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MINISTRY_REGION_ID",
                table: "SBI_REGION",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "INSPECTION_DATE",
                table: "SBI_INSPECTION",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_DATE",
                table: "SBI_INSPECTION",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "MINISTRY_DISTRICT_ID",
                table: "SBI_DISTRICT",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TYPE",
                table: "SBI_CONTACT_PHONE",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE_NUMBER",
                table: "SBI_CONTACT_PHONE",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TYPE",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROVINCE",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSTAL_CODE",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CITY",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS2",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS1",
                table: "SBI_CONTACT_ADDRESS",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SURNAME",
                table: "SBI_CONTACT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                table: "SBI_CONTACT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "SBI_CONTACT",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GIVEN_NAME",
                table: "SBI_CONTACT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
