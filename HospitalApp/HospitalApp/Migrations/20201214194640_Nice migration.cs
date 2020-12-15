using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class Nicemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examination_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "Type" },
                values: new object[] { 1, "Misa", false, "Simonovic", 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "FirstName", "IsDeleted", "LastName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { 5, "Visnjiceva 32, Beograd", "admin", false, "administratovic", "admin", "+3811233212", "Administrator", "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "FirstName", "IsDeleted", "LastName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { 1, "Tomiceva 22, Zrenjanin", "Marko", false, "Simonovic", "123", "+38122555333", "Patient", "maki" });

            migrationBuilder.InsertData(
                table: "Administrator",
                column: "Id",
                value: 5);

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "AdministratorId", "Age", "Gender", "IsBlocked" },
                values: new object[] { 1, null, 15, "male", false });

            migrationBuilder.CreateIndex(
                name: "IX_Examination_DoctorId",
                table: "Examination",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PatientId",
                table: "Examination",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PatientId",
                table: "Feedback",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AdministratorId",
                table: "Patient",
                column: "AdministratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
