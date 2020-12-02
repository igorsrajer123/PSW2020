using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class Administrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "Password", "Username" },
                values: new object[] { 5, "admin", false, "administratovic", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Administrator",
                column: "Id",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "Type" },
                values: new object[] { 5, "Doca", false, "Docic", 1 });
        }
    }
}
