using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class NewDatabaseinitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsMalicious = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_User_Id",
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
                    GeneralPractitionerId = table.Column<int>(type: "int", nullable: true),
                    CancelledAppointments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Doctor_GeneralPractitionerId",
                        column: x => x.GeneralPractitionerId,
                        principalTable: "Doctor",
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
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CancellationDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
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
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialistId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referral_Doctor_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referral_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "FirstName", "IsBlocked", "IsMalicious", "LastName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 5, "Visnjiceva 32, Beograd", "admin", false, false, "administratovic", "admin", "+3811233212", "Administrator", "admin" },
                    { 10, "Marka Kraljevica 22", "Aleksandar", false, false, "Simonovic", "123", "555-333", "Doctor", "doca1" },
                    { 11, "Visnjiceva 2", "Dimitrije", false, false, "Mijatovic", "1234", "55-44-33", "Doctor", "doca2" },
                    { 12, "Nikole Tesle 5", "Srdjan", false, false, "Tepavcevic", "12345", "55-42-4-21", "Doctor", "doca3" },
                    { 13, "Vukasinova 69", "Neven", false, false, "Milakovic", "1234567", "7766-65-64", "Doctor", "doca66" }
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                column: "Id",
                value: 5);

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "Type", "WorkingDays" },
                values: new object[,]
                {
                    { 10, 1, "2021-01-16 12 PM,2021-01-17 03 PM,2021-01-18 03 PM,2021-01-19 04 PM,2021-01-22 11 AM,2021-02-06 02 PM,2021-01-30 01 PM,2021-02-18 04 PM,2021-02-09 11 AM,2021-02-06 11 AM,2021-02-07 10 AM,2021-02-14 03 PM,2021-02-11 11 AM,2021-02-18 04 PM,2021-02-18 03 PM,2021-02-16 01 PM,2021-03-02 01 PM,2021-02-27 10 AM,2021-03-18 12 PM,2021-03-02 04 PM,2021-03-04 10 AM,2021-02-26 11 AM,2021-03-16 04 PM,2021-03-22 12 PM,2021-03-25 02 PM,2021-04-02 10 AM,2021-04-12 11 AM,2021-04-13 02 PM,2021-03-23 02 PM,2021-03-29 11 AM,2021-03-24 11 AM,2021-04-15 10 AM,2021-04-13 12 PM,2021-04-19 04 PM,2021-04-22 01 PM,2021-05-02 12 PM,2021-04-30 12 PM,2021-04-22 10 AM,2021-04-27 12 PM,2021-04-15 01 PM,2021-04-28 10 AM,2021-05-15 10 AM,2021-05-30 10 AM,2021-05-17 11 AM,2021-05-12 02 PM,2021-05-05 03 PM,2021-05-27 12 PM,2021-05-29 04 PM,2021-05-19 11 AM,2021-04-29 12 PM,2021-06-15 01 PM,2021-06-06 04 PM,2021-06-01 02 PM,2021-06-11 12 PM,2021-06-30 01 PM,2021-06-06 02 PM,2021-06-18 12 PM,2021-06-14 03 PM,2021-06-22 01 PM,2021-06-21 10 AM,2021-06-30 04 PM,2021-07-06 02 PM,2021-06-28 12 PM,2021-07-01 04 PM,2021-07-08 10 AM,2021-07-10 02 PM,2021-07-13 10 AM" },
                    { 11, 1, "2021-01-17 11 AM,2021-01-17 10 AM,2021-01-16 03 PM,2021-01-26 04 PM,2021-01-26 02 PM,2021-02-02 04 PM,2021-01-24 03 PM,2021-02-09 10 AM,2021-02-02 10 AM,2021-02-01 11 AM,2021-02-15 02 PM,2021-02-23 04 PM,2021-02-21 11 AM,2021-02-10 12 PM,2021-03-15 10 AM,2021-03-06 11 AM,2021-03-06 10 AM,2021-03-02 10 AM,2021-03-07 11 AM,2021-02-17 10 AM,2021-03-06 02 PM,2021-03-22 10 AM,2021-03-19 11 AM,2021-03-30 12 PM,2021-02-26 11 AM,2021-03-27 03 PM,2021-03-22 03 PM,2021-04-04 11 AM,2021-03-18 02 PM,2021-03-14 02 PM,2021-04-19 03 PM,2021-04-14 10 AM,2021-04-18 12 PM,2021-05-07 02 PM,2021-04-05 01 PM,2021-04-29 12 PM,2021-04-13 02 PM,2021-04-27 01 PM,2021-04-07 10 AM,2021-04-25 03 PM,2021-05-24 04 PM,2021-05-05 12 PM,2021-04-12 04 PM,2021-04-19 11 AM,2021-05-19 12 PM,2021-05-09 03 PM,2021-05-12 04 PM,2021-05-12 02 PM,2021-05-23 02 PM,2021-05-08 10 AM,2021-05-27 11 AM,2021-06-07 01 PM,2021-06-07 02 PM,2021-06-07 11 AM,2021-05-28 10 AM,2021-06-10 04 PM,2021-06-18 10 AM,2021-06-20 03 PM,2021-06-27 03 PM,2021-06-25 04 PM,2021-06-25 02 PM,2021-06-21 01 PM,2021-06-24 11 AM,2021-07-03 01 PM,2021-07-02 10 AM,2021-07-10 10 AM,2021-07-13 11 AM" },
                    { 12, 0, "2021-01-17 11 AM,2021-01-15 11 AM,2021-01-24 03 PM,2021-01-24 01 PM,2021-01-30 10 AM,2021-01-22 04 PM,2021-01-23 10 AM,2021-01-31 02 PM,2021-02-09 03 PM,2021-02-15 02 PM,2021-02-13 02 PM,2021-02-23 10 AM,2021-02-27 10 AM,2021-02-27 01 PM,2021-02-18 01 PM,2021-03-01 12 PM,2021-02-25 04 PM,2021-03-11 04 PM,2021-03-01 03 PM,2021-02-27 03 PM,2021-03-20 01 PM,2021-03-12 11 AM,2021-03-14 04 PM,2021-03-21 04 PM,2021-03-16 01 PM,2021-03-22 10 AM,2021-04-12 04 PM,2021-03-15 12 PM,2021-04-10 12 PM,2021-03-31 01 PM,2021-03-30 12 PM,2021-04-17 03 PM,2021-04-07 10 AM,2021-04-11 02 PM,2021-04-17 02 PM,2021-04-22 04 PM,2021-04-13 01 PM,2021-04-17 02 PM,2021-04-22 12 PM,2021-05-12 03 PM,2021-05-04 02 PM,2021-05-09 10 AM,2021-04-28 02 PM,2021-05-19 12 PM,2021-05-22 11 AM,2021-05-09 04 PM,2021-05-27 03 PM,2021-05-20 12 PM,2021-06-09 12 PM,2021-05-25 12 PM,2021-05-17 10 AM,2021-06-14 12 PM,2021-05-30 03 PM,2021-05-30 10 AM,2021-06-18 02 PM,2021-05-31 12 PM,2021-06-13 01 PM,2021-05-29 04 PM,2021-06-18 03 PM,2021-06-24 03 PM,2021-06-28 12 PM,2021-06-20 11 AM,2021-07-06 10 AM,2021-07-07 04 PM,2021-07-09 11 AM,2021-07-08 04 PM,2021-07-12 11 AM" },
                    { 13, 0, "2021-01-16 04 PM,2021-01-17 10 AM,2021-01-19 12 PM,2021-01-26 10 AM,2021-01-18 10 AM,2021-01-22 02 PM,2021-01-31 02 PM,2021-02-03 11 AM,2021-02-04 01 PM,2021-02-22 10 AM,2021-02-13 10 AM,2021-02-11 01 PM,2021-03-13 12 PM,2021-02-11 11 AM,2021-02-16 10 AM,2021-03-04 03 PM,2021-02-12 12 PM,2021-03-19 01 PM,2021-03-11 04 PM,2021-03-10 01 PM,2021-02-28 04 PM,2021-02-24 11 AM,2021-03-12 12 PM,2021-03-28 01 PM,2021-03-13 04 PM,2021-03-18 02 PM,2021-03-19 11 AM,2021-04-11 04 PM,2021-03-25 01 PM,2021-04-13 10 AM,2021-03-31 11 AM,2021-04-16 03 PM,2021-04-03 04 PM,2021-04-19 03 PM,2021-04-24 01 PM,2021-04-10 04 PM,2021-04-13 04 PM,2021-04-23 10 AM,2021-04-25 12 PM,2021-05-27 03 PM,2021-04-25 12 PM,2021-04-30 01 PM,2021-05-08 03 PM,2021-05-18 01 PM,2021-05-21 04 PM,2021-05-28 12 PM,2021-05-31 04 PM,2021-05-24 10 AM,2021-06-06 03 PM,2021-05-11 02 PM,2021-05-27 12 PM,2021-06-04 10 AM,2021-06-06 01 PM,2021-05-27 03 PM,2021-05-29 04 PM,2021-05-23 01 PM,2021-06-14 03 PM,2021-06-05 03 PM,2021-06-22 04 PM,2021-06-18 03 PM,2021-06-30 04 PM,2021-07-03 02 PM,2021-06-28 01 PM,2021-07-06 01 PM,2021-07-08 01 PM,2021-07-10 03 PM,2021-07-11 01 PM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PatientId",
                table: "Feedback",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GeneralPractitionerId",
                table: "Patient",
                column: "GeneralPractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_PatientId",
                table: "Referral",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referral_SpecialistId",
                table: "Referral",
                column: "SpecialistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
