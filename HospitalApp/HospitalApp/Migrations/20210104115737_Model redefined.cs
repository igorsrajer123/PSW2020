﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class Modelredefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Administrator_AdministratorId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_AdministratorId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Patient");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingDays",
                value: "2021-01-10 01 PM,2021-01-06 11 AM,2021-01-08 02 PM,2021-01-15 12 PM,2021-01-20 04 PM,2021-01-21 03 PM,2021-01-25 02 PM,2021-01-26 02 PM,2021-02-06 11 AM,2021-01-24 01 PM,2021-02-07 01 PM,2021-02-03 03 PM,2021-02-01 11 AM,2021-02-13 03 PM,2021-02-19 02 PM,2021-02-23 10 AM,2021-01-29 03 PM,2021-03-07 01 PM,2021-03-04 10 AM,2021-03-02 10 AM,2021-02-27 02 PM,2021-03-01 01 PM,2021-03-16 01 PM,2021-03-03 02 PM,2021-04-06 10 AM,2021-03-18 03 PM,2021-04-03 02 PM,2021-03-28 02 PM,2021-04-14 12 PM,2021-03-28 12 PM,2021-03-23 10 AM,2021-04-22 10 AM,2021-03-29 12 PM,2021-04-17 03 PM,2021-04-14 03 PM,2021-04-19 12 PM,2021-04-30 03 PM,2021-04-02 10 AM,2021-05-02 12 PM,2021-05-02 04 PM,2021-04-28 11 AM,2021-05-12 12 PM,2021-05-13 04 PM,2021-05-03 04 PM,2021-05-21 11 AM,2021-05-30 10 AM,2021-05-29 12 PM,2021-06-05 10 AM,2021-06-09 10 AM,2021-05-25 01 PM,2021-06-10 03 PM,2021-05-29 04 PM,2021-06-03 04 PM,2021-06-10 01 PM,2021-06-22 02 PM,2021-06-19 10 AM,2021-06-21 11 AM,2021-06-25 02 PM,2021-06-18 10 AM,2021-07-02 12 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingDays",
                value: "2021-01-06 04 PM,2021-01-08 11 AM,2021-01-07 04 PM,2021-01-26 11 AM,2021-01-08 02 PM,2021-01-15 11 AM,2021-01-19 03 PM,2021-02-14 10 AM,2021-02-03 04 PM,2021-01-24 10 AM,2021-02-12 01 PM,2021-02-04 01 PM,2021-02-06 11 AM,2021-02-12 01 PM,2021-03-03 02 PM,2021-02-11 11 AM,2021-02-04 01 PM,2021-02-23 02 PM,2021-03-22 03 PM,2021-03-10 01 PM,2021-02-22 02 PM,2021-03-13 03 PM,2021-03-08 03 PM,2021-03-29 03 PM,2021-03-28 10 AM,2021-03-14 03 PM,2021-04-06 10 AM,2021-04-01 12 PM,2021-03-15 01 PM,2021-04-09 11 AM,2021-04-12 01 PM,2021-04-13 03 PM,2021-04-06 10 AM,2021-04-07 03 PM,2021-04-08 12 PM,2021-05-01 12 PM,2021-04-25 01 PM,2021-04-27 02 PM,2021-04-26 11 AM,2021-05-13 04 PM,2021-05-03 11 AM,2021-04-29 02 PM,2021-05-14 03 PM,2021-05-08 10 AM,2021-05-25 04 PM,2021-05-25 12 PM,2021-06-02 01 PM,2021-06-09 11 AM,2021-05-27 01 PM,2021-06-09 12 PM,2021-06-03 11 AM,2021-06-08 12 PM,2021-06-17 03 PM,2021-06-19 12 PM,2021-06-14 02 PM,2021-06-27 03 PM,2021-06-14 04 PM,2021-06-27 02 PM,2021-06-27 12 PM,2021-07-02 11 AM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkingDays",
                value: "2021-01-04 04 PM,2021-01-14 10 AM,2021-01-17 04 PM,2021-01-14 12 PM,2021-01-29 12 PM,2021-01-19 04 PM,2021-01-27 01 PM,2021-01-21 01 PM,2021-01-23 12 PM,2021-01-29 03 PM,2021-01-28 10 AM,2021-02-01 04 PM,2021-02-21 02 PM,2021-02-02 12 PM,2021-02-08 02 PM,2021-03-01 12 PM,2021-03-05 11 AM,2021-03-12 02 PM,2021-03-06 03 PM,2021-02-18 10 AM,2021-04-06 11 AM,2021-03-02 12 PM,2021-03-11 03 PM,2021-04-08 02 PM,2021-04-22 11 AM,2021-03-25 03 PM,2021-03-17 12 PM,2021-03-28 02 PM,2021-04-20 12 PM,2021-03-12 02 PM,2021-04-05 10 AM,2021-04-15 10 AM,2021-03-28 11 AM,2021-04-03 04 PM,2021-04-24 11 AM,2021-05-05 10 AM,2021-04-20 11 AM,2021-04-02 11 AM,2021-05-04 03 PM,2021-04-30 01 PM,2021-05-07 10 AM,2021-05-12 12 PM,2021-06-01 10 AM,2021-05-12 12 PM,2021-04-26 01 PM,2021-05-12 01 PM,2021-05-05 01 PM,2021-05-02 10 AM,2021-05-29 11 AM,2021-05-29 02 PM,2021-06-08 12 PM,2021-06-18 02 PM,2021-06-08 12 PM,2021-06-12 01 PM,2021-06-02 11 AM,2021-06-17 01 PM,2021-06-22 04 PM,2021-06-20 11 AM,2021-06-29 04 PM,2021-07-01 10 AM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 4,
                column: "WorkingDays",
                value: "2021-01-08 03 PM,2021-01-21 11 AM,2021-01-06 12 PM,2021-01-26 01 PM,2021-01-16 12 PM,2021-02-03 11 AM,2021-01-17 02 PM,2021-01-24 04 PM,2021-01-29 01 PM,2021-01-26 03 PM,2021-02-02 12 PM,2021-01-29 03 PM,2021-02-16 11 AM,2021-02-06 02 PM,2021-02-15 04 PM,2021-02-28 12 PM,2021-02-18 03 PM,2021-03-12 01 PM,2021-03-05 10 AM,2021-02-14 01 PM,2021-03-14 02 PM,2021-03-15 03 PM,2021-03-02 12 PM,2021-03-07 12 PM,2021-03-24 01 PM,2021-04-05 04 PM,2021-03-13 02 PM,2021-03-29 01 PM,2021-03-29 04 PM,2021-04-11 12 PM,2021-03-25 03 PM,2021-04-04 03 PM,2021-04-16 10 AM,2021-04-16 10 AM,2021-04-02 04 PM,2021-04-12 01 PM,2021-05-03 03 PM,2021-04-21 01 PM,2021-04-27 01 PM,2021-05-05 03 PM,2021-04-29 01 PM,2021-05-11 03 PM,2021-05-02 10 AM,2021-05-19 11 AM,2021-05-12 12 PM,2021-05-14 03 PM,2021-05-18 02 PM,2021-05-29 02 PM,2021-05-30 02 PM,2021-05-30 02 PM,2021-06-12 04 PM,2021-06-04 01 PM,2021-06-16 12 PM,2021-06-13 01 PM,2021-06-18 04 PM,2021-06-20 10 AM,2021-06-20 01 PM,2021-06-25 04 PM,2021-06-27 04 PM,2021-06-26 01 PM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministratorId",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingDays",
                value: "2021-01-01 12 PM,2021-01-10 10 AM,2021-01-03 04 PM,2021-01-23 02 PM,2021-01-03 03 PM,2021-01-14 11 AM,2021-01-11 03 PM,2021-01-19 03 PM,2021-01-16 11 AM,2021-01-19 03 PM,2021-01-31 12 PM,2021-01-19 11 AM,2021-01-30 03 PM,2021-02-26 03 PM,2021-02-27 12 PM,2021-01-30 03 PM,2021-02-08 04 PM,2021-02-19 03 PM,2021-02-10 01 PM,2021-03-26 01 PM,2021-03-03 11 AM,2021-02-23 10 AM,2021-03-18 04 PM,2021-02-25 10 AM,2021-03-31 11 AM,2021-03-25 01 PM,2021-03-17 03 PM,2021-04-08 12 PM,2021-03-28 04 PM,2021-03-17 02 PM,2021-04-04 10 AM,2021-03-27 10 AM,2021-04-14 10 AM,2021-04-13 02 PM,2021-03-21 12 PM,2021-04-17 02 PM,2021-03-28 01 PM,2021-04-23 10 AM,2021-04-18 02 PM,2021-04-23 01 PM,2021-05-04 04 PM,2021-04-13 02 PM,2021-05-06 04 PM,2021-05-19 03 PM,2021-05-26 11 AM,2021-05-12 11 AM,2021-05-01 12 PM,2021-05-07 11 AM,2021-06-04 11 AM,2021-05-04 04 PM,2021-05-24 10 AM,2021-06-05 12 PM,2021-06-03 10 AM,2021-05-28 04 PM,2021-06-13 03 PM,2021-06-03 02 PM,2021-06-08 02 PM,2021-06-21 10 AM,2021-06-23 11 AM,2021-06-23 04 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingDays",
                value: "2020-12-28 04 PM,2020-12-31 02 PM,2021-01-04 10 AM,2021-01-10 02 PM,2021-01-08 12 PM,2021-01-19 10 AM,2021-01-12 04 PM,2021-01-19 12 PM,2021-01-28 10 AM,2021-02-05 04 PM,2021-01-20 01 PM,2021-01-30 03 PM,2021-02-01 04 PM,2021-02-16 11 AM,2021-03-07 02 PM,2021-02-17 01 PM,2021-02-16 12 PM,2021-02-19 12 PM,2021-02-16 01 PM,2021-02-24 02 PM,2021-02-23 04 PM,2021-03-10 04 PM,2021-03-08 02 PM,2021-03-12 11 AM,2021-03-10 03 PM,2021-02-21 02 PM,2021-03-19 02 PM,2021-04-03 10 AM,2021-04-04 11 AM,2021-04-07 12 PM,2021-04-01 01 PM,2021-03-24 11 AM,2021-04-12 10 AM,2021-03-29 10 AM,2021-04-19 12 PM,2021-04-19 11 AM,2021-03-28 12 PM,2021-04-17 10 AM,2021-04-02 04 PM,2021-04-28 11 AM,2021-04-24 01 PM,2021-04-18 10 AM,2021-05-04 11 AM,2021-05-01 10 AM,2021-05-04 04 PM,2021-04-23 03 PM,2021-05-12 02 PM,2021-05-17 01 PM,2021-05-15 11 AM,2021-05-25 02 PM,2021-06-15 03 PM,2021-06-05 03 PM,2021-05-24 10 AM,2021-06-18 02 PM,2021-06-17 10 AM,2021-06-12 12 PM,2021-06-20 12 PM,2021-06-19 12 PM,2021-06-17 02 PM,2021-06-24 03 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkingDays",
                value: "2021-01-03 01 PM,2020-12-30 03 PM,2021-01-11 03 PM,2021-01-11 11 AM,2021-01-04 11 AM,2021-01-10 01 PM,2021-01-15 01 PM,2021-01-25 03 PM,2021-02-13 04 PM,2021-01-21 01 PM,2021-01-23 01 PM,2021-01-17 04 PM,2021-02-08 11 AM,2021-01-29 01 PM,2021-02-14 10 AM,2021-02-18 01 PM,2021-03-14 01 PM,2021-02-06 01 PM,2021-02-19 03 PM,2021-03-06 04 PM,2021-02-15 10 AM,2021-03-17 01 PM,2021-03-11 10 AM,2021-02-17 12 PM,2021-03-19 01 PM,2021-03-19 04 PM,2021-03-30 02 PM,2021-04-01 02 PM,2021-04-08 03 PM,2021-03-26 02 PM,2021-03-13 11 AM,2021-04-24 02 PM,2021-03-19 10 AM,2021-04-05 12 PM,2021-03-29 02 PM,2021-04-18 01 PM,2021-04-15 02 PM,2021-04-29 03 PM,2021-04-22 03 PM,2021-04-23 12 PM,2021-05-10 11 AM,2021-05-03 10 AM,2021-05-03 11 AM,2021-05-12 03 PM,2021-05-22 01 PM,2021-05-21 04 PM,2021-05-25 02 PM,2021-05-12 02 PM,2021-05-28 03 PM,2021-05-21 02 PM,2021-05-20 12 PM,2021-05-23 01 PM,2021-06-14 02 PM,2021-06-04 11 AM,2021-06-11 02 PM,2021-06-08 12 PM,2021-06-14 12 PM,2021-06-13 12 PM,2021-06-23 03 PM,2021-06-24 11 AM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 4,
                column: "WorkingDays",
                value: "2020-12-31 11 AM,2021-01-11 12 PM,2021-01-03 11 AM,2021-01-14 03 PM,2021-01-27 11 AM,2021-01-06 03 PM,2021-01-19 03 PM,2021-01-20 12 PM,2021-01-15 01 PM,2021-01-29 04 PM,2021-01-26 12 PM,2021-01-26 10 AM,2021-01-27 12 PM,2021-01-23 12 PM,2021-02-11 11 AM,2021-03-01 03 PM,2021-02-14 11 AM,2021-02-21 10 AM,2021-02-23 02 PM,2021-02-24 04 PM,2021-03-17 10 AM,2021-03-03 12 PM,2021-02-21 04 PM,2021-03-13 02 PM,2021-03-27 01 PM,2021-02-28 11 AM,2021-03-14 11 AM,2021-04-12 12 PM,2021-03-03 10 AM,2021-04-02 11 AM,2021-04-21 02 PM,2021-04-10 10 AM,2021-04-05 10 AM,2021-04-17 01 PM,2021-04-10 01 PM,2021-04-14 02 PM,2021-04-21 02 PM,2021-05-09 11 AM,2021-04-12 02 PM,2021-04-11 04 PM,2021-04-17 12 PM,2021-04-21 03 PM,2021-05-07 11 AM,2021-04-25 10 AM,2021-05-06 11 AM,2021-05-18 11 AM,2021-05-09 01 PM,2021-05-16 04 PM,2021-06-04 02 PM,2021-05-10 02 PM,2021-05-30 01 PM,2021-06-02 10 AM,2021-06-05 02 PM,2021-06-03 11 AM,2021-06-03 02 PM,2021-06-08 03 PM,2021-06-16 03 PM,2021-06-16 04 PM,2021-06-14 03 PM,2021-06-24 11 AM");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AdministratorId",
                table: "Patient",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Administrator_AdministratorId",
                table: "Patient",
                column: "AdministratorId",
                principalTable: "Administrator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
