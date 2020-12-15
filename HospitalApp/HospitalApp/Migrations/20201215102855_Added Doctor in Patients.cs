using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class AddedDoctorinPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneralPractitionerId",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GeneralPractitionerId",
                table: "Patient",
                column: "GeneralPractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_GeneralPractitionerId",
                table: "Patient",
                column: "GeneralPractitionerId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_GeneralPractitionerId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_GeneralPractitionerId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "GeneralPractitionerId",
                table: "Patient");
        }
    }
}
