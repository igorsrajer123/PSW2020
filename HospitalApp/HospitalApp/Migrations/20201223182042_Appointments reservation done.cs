﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class Appointmentsreservationdone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingDays",
                value: "2020-12-25 12 PM,2020-12-30 01 PM,2020-12-27 03 PM,2020-12-27 04 PM,2021-01-13 01 PM,2020-12-27 02 PM,2021-01-06 02 PM,2021-01-19 12 PM,2021-01-08 12 PM,2021-01-06 02 PM,2021-01-22 01 PM,2021-01-27 03 PM,2021-01-25 02 PM,2021-01-24 02 PM,2021-01-31 01 PM,2021-02-11 12 PM,2021-02-07 12 PM,2021-02-06 02 PM,2021-02-15 03 PM,2021-02-13 12 PM,2021-02-04 01 PM,2021-02-23 03 PM,2021-03-05 12 PM,2021-03-16 03 PM,2021-03-05 01 PM,2021-03-06 04 PM,2021-02-20 04 PM,2021-03-02 10 AM,2021-03-13 03 PM,2021-03-19 01 PM,2021-03-16 01 PM,2021-03-20 02 PM,2021-03-16 04 PM,2021-03-19 03 PM,2021-03-13 03 PM,2021-03-15 03 PM,2021-03-20 03 PM,2021-04-04 10 AM,2021-04-13 10 AM,2021-03-16 04 PM,2021-04-14 10 AM,2021-04-20 01 PM,2021-04-21 04 PM,2021-04-09 10 AM,2021-04-12 02 PM,2021-03-23 01 PM,2021-04-28 10 AM,2021-05-13 12 PM,2021-05-09 11 AM,2021-05-04 10 AM,2021-05-09 04 PM,2021-04-27 04 PM,2021-05-22 10 AM,2021-05-20 03 PM,2021-05-20 02 PM,2021-05-31 02 PM,2021-06-03 02 PM,2021-05-23 10 AM,2021-05-29 01 PM,2021-06-03 04 PM,2021-06-04 02 PM,2021-06-08 11 AM,2021-06-05 12 PM,2021-06-09 11 AM,2021-06-07 03 PM,2021-06-16 12 PM,2021-06-21 12 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingDays",
                value: "2020-12-23 04 PM,2020-12-28 12 PM,2020-12-26 12 PM,2020-12-27 11 AM,2020-12-30 04 PM,2020-12-30 02 PM,2021-01-01 03 PM,2021-01-19 10 AM,2021-01-16 03 PM,2021-01-27 02 PM,2021-01-20 11 AM,2021-01-24 12 PM,2021-01-29 03 PM,2021-01-24 12 PM,2021-02-07 03 PM,2021-02-03 12 PM,2021-02-22 11 AM,2021-01-31 04 PM,2021-01-30 04 PM,2021-02-11 04 PM,2021-02-26 02 PM,2021-02-16 11 AM,2021-02-22 03 PM,2021-03-12 03 PM,2021-03-05 11 AM,2021-03-07 12 PM,2021-03-12 01 PM,2021-03-09 10 AM,2021-03-04 03 PM,2021-03-14 11 AM,2021-03-20 04 PM,2021-04-01 04 PM,2021-03-30 03 PM,2021-03-20 04 PM,2021-04-02 03 PM,2021-04-05 03 PM,2021-03-03 02 PM,2021-03-30 03 PM,2021-03-25 03 PM,2021-03-24 03 PM,2021-04-23 10 AM,2021-04-22 03 PM,2021-03-29 11 AM,2021-04-30 11 AM,2021-04-23 11 AM,2021-04-17 12 PM,2021-04-14 01 PM,2021-05-07 03 PM,2021-04-18 11 AM,2021-05-12 04 PM,2021-05-07 01 PM,2021-04-22 04 PM,2021-05-25 10 AM,2021-05-24 11 AM,2021-05-28 11 AM,2021-06-06 04 PM,2021-06-04 12 PM,2021-05-29 12 PM,2021-06-08 10 AM,2021-06-09 02 PM,2021-06-14 03 PM,2021-06-11 02 PM,2021-06-15 11 AM,2021-06-12 03 PM,2021-06-12 02 PM,2021-06-18 10 AM,2021-06-18 12 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkingDays",
                value: "2020-12-24 04 PM,2020-12-31 10 AM,2020-12-25 04 PM,2020-12-28 03 PM,2020-12-29 11 AM,2021-01-15 02 PM,2021-01-08 11 AM,2021-01-14 01 PM,2021-01-13 01 PM,2021-01-18 01 PM,2021-01-15 01 PM,2021-01-27 03 PM,2021-01-25 01 PM,2021-01-23 04 PM,2021-01-28 11 AM,2021-02-08 12 PM,2021-03-01 10 AM,2021-02-06 01 PM,2021-03-04 02 PM,2021-02-22 10 AM,2021-02-18 12 PM,2021-02-22 04 PM,2021-02-21 03 PM,2021-03-01 12 PM,2021-03-12 03 PM,2021-03-06 01 PM,2021-02-26 01 PM,2021-02-26 03 PM,2021-02-24 11 AM,2021-04-02 02 PM,2021-02-27 04 PM,2021-03-09 12 PM,2021-04-05 03 PM,2021-03-29 12 PM,2021-04-05 11 AM,2021-03-24 12 PM,2021-04-01 10 AM,2021-04-21 10 AM,2021-04-27 04 PM,2021-03-30 01 PM,2021-04-21 11 AM,2021-04-14 02 PM,2021-04-07 10 AM,2021-04-24 01 PM,2021-04-30 04 PM,2021-04-13 01 PM,2021-05-01 11 AM,2021-05-09 11 AM,2021-04-25 02 PM,2021-05-13 11 AM,2021-05-17 01 PM,2021-05-02 01 PM,2021-05-08 02 PM,2021-05-14 12 PM,2021-05-22 02 PM,2021-05-17 03 PM,2021-05-10 10 AM,2021-05-13 01 PM,2021-05-25 11 AM,2021-06-09 01 PM,2021-06-03 10 AM,2021-06-14 10 AM,2021-06-14 12 PM,2021-06-08 11 AM,2021-06-14 01 PM,2021-06-06 04 PM,2021-06-19 04 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 4,
                column: "WorkingDays",
                value: "2020-12-25 10 AM,2020-12-30 12 PM,2020-12-29 02 PM,2021-01-09 04 PM,2021-01-02 04 PM,2021-01-29 11 AM,2021-01-14 11 AM,2021-01-08 12 PM,2021-01-08 10 AM,2021-01-17 02 PM,2021-01-23 01 PM,2021-01-16 04 PM,2021-01-18 02 PM,2021-01-28 12 PM,2021-02-03 01 PM,2021-02-04 02 PM,2021-02-05 12 PM,2021-02-09 04 PM,2021-02-12 11 AM,2021-02-02 11 AM,2021-02-18 04 PM,2021-02-21 10 AM,2021-02-10 02 PM,2021-02-12 02 PM,2021-02-25 04 PM,2021-04-01 10 AM,2021-03-08 03 PM,2021-03-15 04 PM,2021-03-17 12 PM,2021-02-28 04 PM,2021-03-24 11 AM,2021-03-15 10 AM,2021-03-30 02 PM,2021-03-26 10 AM,2021-03-30 10 AM,2021-04-02 11 AM,2021-03-28 10 AM,2021-04-09 01 PM,2021-03-14 12 PM,2021-04-25 12 PM,2021-04-06 04 PM,2021-04-19 04 PM,2021-03-29 10 AM,2021-04-24 11 AM,2021-05-04 10 AM,2021-04-21 02 PM,2021-04-10 11 AM,2021-05-05 01 PM,2021-05-05 04 PM,2021-05-04 02 PM,2021-05-08 11 AM,2021-05-20 04 PM,2021-05-02 03 PM,2021-05-08 01 PM,2021-06-02 01 PM,2021-05-13 10 AM,2021-05-23 10 AM,2021-05-24 11 AM,2021-06-08 11 AM,2021-05-31 12 PM,2021-06-06 11 AM,2021-06-02 12 PM,2021-06-08 01 PM,2021-06-11 01 PM,2021-06-18 10 AM,2021-06-14 03 PM,2021-06-20 01 PM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingDays",
                value: "2020-12-23 12 PM,2020-12-30 12 PM,2020-12-24 01 PM,2020-12-30 12 PM,2021-01-04 02 PM,2021-01-08 10 AM,2021-01-11 11 AM,2021-01-14 02 PM,2021-02-01 11 AM,2021-01-07 11 AM,2021-01-18 02 PM,2021-01-28 01 PM,2021-01-17 01 PM,2021-02-04 03 PM,2021-01-25 02 PM,2021-01-30 10 AM,2021-02-12 10 AM,2021-02-19 02 PM,2021-02-10 10 AM,2021-02-05 11 AM,2021-02-17 12 PM,2021-03-09 01 PM,2021-02-08 12 PM,2021-02-22 10 AM,2021-03-18 12 PM,2021-03-17 12 PM,2021-03-19 11 AM,2021-03-21 04 PM,2021-03-22 11 AM,2021-03-21 12 PM,2021-03-04 11 AM,2021-03-23 12 PM,2021-04-09 01 PM,2021-04-06 10 AM,2021-03-17 03 PM,2021-03-31 03 PM,2021-03-29 03 PM,2021-04-08 11 AM,2021-03-26 03 PM,2021-04-07 10 AM,2021-04-19 12 PM,2021-04-24 10 AM,2021-05-09 04 PM,2021-05-03 04 PM,2021-04-27 12 PM,2021-05-12 01 PM,2021-05-18 04 PM,2021-05-04 02 PM,2021-05-31 10 AM,2021-05-19 10 AM,2021-05-24 01 PM,2021-05-20 04 PM,2021-06-07 01 PM,2021-06-01 04 PM,2021-06-05 02 PM,2021-06-06 03 PM,2021-06-08 12 PM,2021-06-06 03 PM,2021-06-10 11 AM,2021-06-17 04 PM,2021-06-19 02 PM,2021-06-19 12 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingDays",
                value: "2020-12-24 12 PM,2020-12-30 03 PM,2020-12-30 03 PM,2021-01-05 12 PM,2021-01-07 02 PM,2021-01-04 10 AM,2021-01-03 02 PM,2021-01-07 10 AM,2021-01-08 12 PM,2021-01-20 02 PM,2021-01-28 04 PM,2021-01-31 11 AM,2021-01-28 02 PM,2021-02-03 12 PM,2021-01-30 04 PM,2021-02-08 12 PM,2021-02-08 02 PM,2021-02-13 11 AM,2021-02-10 10 AM,2021-02-21 12 PM,2021-02-25 04 PM,2021-02-28 01 PM,2021-02-17 10 AM,2021-03-14 12 PM,2021-03-10 11 AM,2021-03-08 04 PM,2021-03-15 01 PM,2021-04-02 12 PM,2021-03-27 03 PM,2021-03-02 11 AM,2021-04-09 10 AM,2021-03-24 11 AM,2021-03-29 03 PM,2021-03-26 03 PM,2021-03-22 04 PM,2021-03-25 10 AM,2021-03-27 02 PM,2021-04-01 10 AM,2021-05-03 11 AM,2021-04-11 10 AM,2021-04-16 03 PM,2021-04-19 04 PM,2021-04-26 03 PM,2021-04-28 01 PM,2021-05-22 10 AM,2021-04-29 03 PM,2021-04-27 11 AM,2021-05-18 04 PM,2021-05-11 04 PM,2021-05-22 10 AM,2021-05-21 11 AM,2021-05-11 10 AM,2021-06-04 04 PM,2021-05-13 04 PM,2021-05-24 10 AM,2021-05-30 02 PM,2021-06-05 03 PM,2021-06-10 10 AM,2021-06-14 01 PM,2021-06-08 10 AM,2021-06-18 10 AM,2021-06-04 04 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkingDays",
                value: "2020-12-28 03 PM,2021-01-10 11 AM,2021-01-04 02 PM,2020-12-28 01 PM,2020-12-31 11 AM,2021-01-09 01 PM,2021-01-14 01 PM,2021-01-07 04 PM,2021-01-13 12 PM,2021-01-29 10 AM,2021-01-10 01 PM,2021-01-16 03 PM,2021-01-24 11 AM,2021-01-22 01 PM,2021-02-02 04 PM,2021-02-17 01 PM,2021-02-07 12 PM,2021-02-01 10 AM,2021-02-25 04 PM,2021-02-12 03 PM,2021-02-18 11 AM,2021-02-24 01 PM,2021-03-11 02 PM,2021-02-27 11 AM,2021-02-24 10 AM,2021-03-08 04 PM,2021-03-02 04 PM,2021-03-13 02 PM,2021-03-21 12 PM,2021-03-25 12 PM,2021-03-08 10 AM,2021-03-25 02 PM,2021-03-13 04 PM,2021-03-23 02 PM,2021-04-03 11 AM,2021-04-12 02 PM,2021-04-05 04 PM,2021-04-21 11 AM,2021-04-22 03 PM,2021-04-01 01 PM,2021-04-14 11 AM,2021-04-08 11 AM,2021-04-29 12 PM,2021-04-21 10 AM,2021-04-29 12 PM,2021-04-26 01 PM,2021-04-24 02 PM,2021-05-09 02 PM,2021-05-08 02 PM,2021-05-21 03 PM,2021-05-06 03 PM,2021-05-27 01 PM,2021-05-19 01 PM,2021-05-30 10 AM,2021-05-23 02 PM,2021-05-21 01 PM,2021-06-06 12 PM,2021-06-08 02 PM,2021-06-10 01 PM,2021-06-10 04 PM,2021-06-16 03 PM,2021-06-20 03 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 4,
                column: "WorkingDays",
                value: "2021-01-03 11 AM,2020-12-25 11 AM,2020-12-28 12 PM,2020-12-29 11 AM,2021-01-07 11 AM,2021-01-07 12 PM,2021-01-01 12 PM,2021-01-06 02 PM,2021-01-22 02 PM,2021-01-19 02 PM,2021-01-19 12 PM,2021-01-25 12 PM,2021-01-22 12 PM,2021-01-26 02 PM,2021-02-14 03 PM,2021-02-08 11 AM,2021-01-25 12 PM,2021-02-05 12 PM,2021-02-19 01 PM,2021-02-11 01 PM,2021-02-24 03 PM,2021-03-07 01 PM,2021-02-28 12 PM,2021-03-05 01 PM,2021-03-18 11 AM,2021-03-12 12 PM,2021-03-14 02 PM,2021-02-21 04 PM,2021-03-16 04 PM,2021-03-09 11 AM,2021-03-18 03 PM,2021-03-23 10 AM,2021-03-31 03 PM,2021-03-29 04 PM,2021-04-09 11 AM,2021-03-22 04 PM,2021-04-01 04 PM,2021-03-25 10 AM,2021-04-02 12 PM,2021-04-22 01 PM,2021-04-09 12 PM,2021-04-09 02 PM,2021-04-26 02 PM,2021-05-08 10 AM,2021-04-28 10 AM,2021-05-09 02 PM,2021-04-24 10 AM,2021-05-06 02 PM,2021-05-09 12 PM,2021-05-18 02 PM,2021-05-07 11 AM,2021-05-23 03 PM,2021-05-10 02 PM,2021-05-31 10 AM,2021-06-11 02 PM,2021-06-05 02 PM,2021-06-04 03 PM,2021-05-25 03 PM,2021-06-15 03 PM,2021-06-13 11 AM,2021-06-20 01 PM,2021-06-19 12 PM");
        }
    }
}
