using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class GeneralPractitioneradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkingDays",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingDays",
                value: "2020-12-15 11 AM,2020-12-15 12 PM,2020-12-15 01 PM,2020-12-15 02 PM,2020-12-15 03 PM,2020-12-15 04 PM,2020-12-16 09 AM,2020-12-16 10 AM,2020-12-16 11 AM,2020-12-16 12 PM,2020-12-16 01 PM,2020-12-16 02 PM,2020-12-16 03 PM,2020-12-16 04 PM,2020-12-17 09 AM,2020-12-17 10 AM,2020-12-17 11 AM,2020-12-17 12 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingDays",
                value: "2020-12-15 11 AM,2020-12-15 12 PM,2020-12-15 01 PM,2020-12-15 02 PM,2020-12-15 03 PM,2020-12-15 04 PM,2020-12-16 09 AM,2020-12-16 10 AM,2020-12-16 11 AM,2020-12-16 12 PM,2020-12-16 01 PM,2020-12-16 02 PM,2020-12-16 03 PM,2020-12-16 04 PM,2020-12-17 09 AM,2020-12-17 10 AM,2020-12-17 11 AM,2020-12-17 12 PM");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkingDays",
                value: "2020-12-15 11 AM,2020-12-15 12 PM,2020-12-15 01 PM,2020-12-15 02 PM,2020-12-15 03 PM,2020-12-15 04 PM,2020-12-16 09 AM,2020-12-16 10 AM,2020-12-16 11 AM,2020-12-16 12 PM,2020-12-16 01 PM,2020-12-16 02 PM,2020-12-16 03 PM,2020-12-16 04 PM,2020-12-17 09 AM,2020-12-17 10 AM,2020-12-17 11 AM,2020-12-17 12 PM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingDays",
                table: "Doctor");
        }
    }
}
