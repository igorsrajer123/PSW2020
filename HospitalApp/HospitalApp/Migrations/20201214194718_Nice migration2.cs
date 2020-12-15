using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class Nicemigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examination_Doctor_DoctorId",
                table: "Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_Examination_Patient_PatientId",
                table: "Examination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examination",
                table: "Examination");

            migrationBuilder.RenameTable(
                name: "Examination",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Examination_PatientId",
                table: "Appointment",
                newName: "IX_Appointment_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Examination_DoctorId",
                table: "Appointment",
                newName: "IX_Appointment_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientId",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Examination");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PatientId",
                table: "Examination",
                newName: "IX_Examination_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_DoctorId",
                table: "Examination",
                newName: "IX_Examination_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examination",
                table: "Examination",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Doctor_DoctorId",
                table: "Examination",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Patient_PatientId",
                table: "Examination",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
