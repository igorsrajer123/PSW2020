using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class NewDoctorsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "Type" },
                values: new object[] { 2, "Igor", false, "Mijatovic", 1 });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "Type" },
                values: new object[] { 3, "Srdjan", false, "Tepavcevic", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
