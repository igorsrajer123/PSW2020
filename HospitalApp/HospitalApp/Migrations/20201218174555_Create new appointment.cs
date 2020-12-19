﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class Createnewappointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingDays",
                value: "2020-12-18 03 PM,2020-12-21 10 AM,2020-12-20 01 PM,2020-12-26 11 AM,2021-01-03 12 PM,2021-01-06 02 PM,2021-01-05 02 PM,2021-01-11 10 AM,2021-01-10 02 PM,2021-01-31 04 PM,2021-01-01 11 AM,2021-01-14 03 PM,2021-01-28 10 AM,2021-01-21 04 PM,2021-01-21 03 PM,2021-01-30 11 AM,2021-02-06 02 PM,2021-01-25 10 AM,2021-02-18 10 AM,2021-01-28 03 PM,2021-01-31 02 PM,2021-02-09 10 AM,2021-02-10 04 PM,2021-02-26 04 PM,2021-03-03 11 AM,2021-03-09 04 PM,2021-03-03 01 PM,2021-03-04 03 PM,2021-03-18 02 PM,2021-03-10 04 PM,2021-03-14 12 PM,2021-03-13 01 PM,2021-03-15 01 PM,2021-03-18 10 AM,2021-03-10 12 PM,2021-03-22 02 PM,2021-04-10 12 PM,2021-04-01 11 AM,2021-04-07 11 AM,2021-03-31 03 PM,2021-04-05 02 PM,2021-04-23 12 PM,2021-04-15 01 PM,2021-04-07 03 PM,2021-04-23 04 PM,2021-04-06 02 PM,2021-04-25 11 AM,2021-04-21 10 AM,2021-04-24 02 PM,2021-05-05 02 PM,2021-04-29 01 PM,2021-04-29 04 PM,2021-05-19 11 AM,2021-05-11 11 AM,2021-05-18 01 PM,2021-05-17 02 PM,2021-05-20 02 PM,2021-05-31 01 PM,2021-06-04 03 PM,2021-05-31 11 AM,2021-06-01 11 AM,2021-05-29 04 PM,2021-06-11 01 PM,2021-06-09 02 PM,2021-06-11 11 AM,2021-06-13 12 PM,2021-06-15 01 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingDays",
                value: "2020-12-19 12 PM,2020-12-25 12 PM,2020-12-24 12 PM,2021-01-01 03 PM,2020-12-28 04 PM,2020-12-27 01 PM,2021-01-02 01 PM,2020-12-30 04 PM,2021-01-03 12 PM,2021-01-13 12 PM,2021-01-14 03 PM,2021-01-22 10 AM,2021-02-06 01 PM,2021-01-26 02 PM,2021-01-23 11 AM,2021-01-28 11 AM,2021-02-01 01 PM,2021-01-23 10 AM,2021-02-01 03 PM,2021-02-10 10 AM,2021-02-09 10 AM,2021-02-17 01 PM,2021-02-19 04 PM,2021-02-24 01 PM,2021-02-18 04 PM,2021-02-19 11 AM,2021-02-14 01 PM,2021-03-07 12 PM,2021-03-15 10 AM,2021-03-06 01 PM,2021-03-02 03 PM,2021-03-08 01 PM,2021-03-05 03 PM,2021-03-02 11 AM,2021-04-12 11 AM,2021-03-30 02 PM,2021-03-11 03 PM,2021-03-27 10 AM,2021-03-25 12 PM,2021-04-13 10 AM,2021-03-23 02 PM,2021-03-30 04 PM,2021-04-07 04 PM,2021-04-15 01 PM,2021-04-07 02 PM,2021-04-11 10 AM,2021-04-29 01 PM,2021-04-13 04 PM,2021-05-06 10 AM,2021-04-21 11 AM,2021-05-05 03 PM,2021-05-16 11 AM,2021-04-24 11 AM,2021-05-04 04 PM,2021-05-13 10 AM,2021-05-06 10 AM,2021-05-30 01 PM,2021-05-24 11 AM,2021-05-29 10 AM,2021-05-21 01 PM,2021-06-03 11 AM,2021-05-27 02 PM,2021-06-08 10 AM,2021-06-14 02 PM,2021-06-08 11 AM,2021-06-15 12 PM,2021-06-15 10 AM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkingDays",
                value: "2020-12-19 11 AM,2020-12-19 04 PM,2020-12-20 10 AM,2020-12-22 02 PM,2021-01-01 12 PM,2020-12-23 01 PM,2021-01-03 01 PM,2021-01-09 04 PM,2021-01-09 11 AM,2021-01-20 10 AM,2021-01-21 02 PM,2021-02-02 03 PM,2021-01-13 04 PM,2021-01-25 01 PM,2021-01-10 04 PM,2021-01-29 04 PM,2021-01-31 01 PM,2021-02-02 04 PM,2021-02-06 03 PM,2021-02-12 10 AM,2021-02-17 11 AM,2021-02-05 12 PM,2021-02-01 03 PM,2021-03-09 04 PM,2021-02-18 12 PM,2021-03-16 11 AM,2021-02-12 02 PM,2021-02-22 01 PM,2021-03-04 12 PM,2021-03-03 04 PM,2021-02-23 02 PM,2021-03-30 04 PM,2021-04-02 10 AM,2021-02-23 11 AM,2021-03-30 12 PM,2021-03-04 10 AM,2021-03-19 10 AM,2021-03-26 12 PM,2021-03-25 03 PM,2021-04-03 01 PM,2021-04-12 10 AM,2021-03-22 12 PM,2021-04-21 03 PM,2021-04-20 12 PM,2021-04-15 12 PM,2021-04-23 12 PM,2021-04-16 03 PM,2021-04-08 12 PM,2021-04-24 12 PM,2021-05-07 11 AM,2021-04-28 04 PM,2021-05-15 02 PM,2021-05-10 10 AM,2021-05-27 03 PM,2021-05-11 01 PM,2021-05-16 12 PM,2021-05-23 02 PM,2021-05-22 11 AM,2021-05-16 02 PM,2021-06-01 11 AM,2021-05-24 04 PM,2021-06-02 04 PM,2021-06-11 02 PM,2021-06-04 04 PM,2021-06-10 03 PM,2021-06-04 10 AM,2021-06-13 03 PM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Appointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Appointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingDays",
                value: "2020-12-19 11 AM,2020-12-28 02 PM,2020-12-28 12 PM,2020-12-21 11 AM,2020-12-29 01 PM,2021-01-12 03 PM,2021-01-01 10 AM,2021-01-08 04 PM,2021-01-07 03 PM,2021-01-07 02 PM,2021-01-13 02 PM,2021-01-28 04 PM,2021-01-18 04 PM,2021-01-21 11 AM,2021-02-01 01 PM,2021-01-15 01 PM,2021-01-24 01 PM,2021-02-01 10 AM,2021-02-14 10 AM,2021-01-26 03 PM,2021-02-13 02 PM,2021-02-12 03 PM,2021-02-25 12 PM,2021-02-03 04 PM,2021-02-24 12 PM,2021-02-20 03 PM,2021-03-15 01 PM,2021-03-29 04 PM,2021-02-27 02 PM,2021-02-23 03 PM,2021-03-26 01 PM,2021-03-07 01 PM,2021-03-15 12 PM,2021-03-20 03 PM,2021-03-03 04 PM,2021-03-16 03 PM,2021-03-24 03 PM,2021-03-31 12 PM,2021-03-23 03 PM,2021-04-15 12 PM,2021-04-15 12 PM,2021-04-06 03 PM,2021-04-04 03 PM,2021-04-18 04 PM,2021-04-19 12 PM,2021-04-15 01 PM,2021-05-01 04 PM,2021-04-04 03 PM,2021-04-26 01 PM,2021-04-25 03 PM,2021-05-04 12 PM,2021-05-16 10 AM,2021-04-30 03 PM,2021-05-11 04 PM,2021-04-25 04 PM,2021-05-01 11 AM,2021-04-27 12 PM,2021-05-21 01 PM,2021-05-29 11 AM,2021-05-25 12 PM,2021-05-20 02 PM,2021-06-02 12 PM,2021-05-22 04 PM,2021-06-06 02 PM,2021-06-11 10 AM,2021-06-08 03 PM,2021-06-12 12 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingDays",
                value: "2020-12-25 10 AM,2020-12-19 11 AM,2020-12-22 04 PM,2021-01-07 03 PM,2020-12-29 01 PM,2021-01-03 10 AM,2021-01-16 02 PM,2021-01-20 03 PM,2021-01-11 02 PM,2021-01-15 11 AM,2021-01-04 12 PM,2021-01-17 04 PM,2021-01-29 12 PM,2021-01-13 02 PM,2021-02-05 02 PM,2021-01-29 12 PM,2021-01-20 03 PM,2021-02-13 04 PM,2021-02-11 12 PM,2021-01-31 02 PM,2021-02-13 11 AM,2021-02-24 11 AM,2021-02-08 12 PM,2021-03-08 04 PM,2021-01-31 03 PM,2021-02-20 03 PM,2021-02-23 10 AM,2021-03-08 12 PM,2021-03-01 04 PM,2021-03-13 12 PM,2021-02-21 11 AM,2021-03-18 01 PM,2021-03-05 10 AM,2021-02-28 12 PM,2021-03-28 01 PM,2021-04-03 12 PM,2021-03-27 02 PM,2021-03-04 11 AM,2021-04-13 11 AM,2021-04-09 01 PM,2021-04-04 10 AM,2021-04-21 02 PM,2021-04-30 02 PM,2021-04-08 01 PM,2021-04-15 03 PM,2021-04-18 10 AM,2021-05-04 12 PM,2021-04-30 10 AM,2021-04-18 04 PM,2021-04-21 11 AM,2021-04-19 04 PM,2021-05-17 04 PM,2021-05-08 02 PM,2021-05-06 10 AM,2021-05-23 01 PM,2021-05-18 04 PM,2021-05-05 04 PM,2021-05-21 03 PM,2021-05-19 03 PM,2021-05-29 01 PM,2021-06-02 04 PM,2021-05-13 01 PM,2021-05-28 01 PM,2021-06-02 02 PM,2021-06-07 02 PM,2021-06-10 04 PM,2021-06-09 11 AM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkingDays",
                value: "2020-12-18 11 AM,2020-12-25 01 PM,2020-12-24 04 PM,2021-01-03 03 PM,2020-12-28 03 PM,2021-01-15 03 PM,2021-01-14 12 PM,2021-01-04 04 PM,2021-01-14 11 AM,2021-01-02 10 AM,2021-01-23 04 PM,2021-01-06 12 PM,2021-01-29 02 PM,2021-01-26 02 PM,2021-02-21 12 PM,2021-02-04 10 AM,2021-02-21 02 PM,2021-01-22 12 PM,2021-02-04 02 PM,2021-02-13 03 PM,2021-02-07 11 AM,2021-02-10 12 PM,2021-02-19 01 PM,2021-02-20 01 PM,2021-02-09 11 AM,2021-02-27 12 PM,2021-03-27 03 PM,2021-02-18 10 AM,2021-03-12 10 AM,2021-03-01 03 PM,2021-02-26 10 AM,2021-03-19 11 AM,2021-03-22 04 PM,2021-03-15 03 PM,2021-04-03 10 AM,2021-03-19 12 PM,2021-04-02 12 PM,2021-04-05 12 PM,2021-03-22 12 PM,2021-03-31 01 PM,2021-04-10 02 PM,2021-03-27 04 PM,2021-04-18 12 PM,2021-04-17 01 PM,2021-04-08 03 PM,2021-05-08 11 AM,2021-04-15 03 PM,2021-05-02 03 PM,2021-04-18 04 PM,2021-04-11 04 PM,2021-05-03 10 AM,2021-05-19 12 PM,2021-05-01 03 PM,2021-05-17 02 PM,2021-05-30 10 AM,2021-05-17 11 AM,2021-05-08 01 PM,2021-05-13 02 PM,2021-06-02 10 AM,2021-06-02 11 AM,2021-05-26 04 PM,2021-05-19 03 PM,2021-06-07 01 PM,2021-06-01 12 PM,2021-06-12 11 AM,2021-06-10 12 PM,2021-06-15 03 PM");
        }
    }
}
