﻿// <auto-generated />
using System;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalApp.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201228193241_Malicious users added")]
    partial class Malicioususersadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HospitalApp.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("HospitalApp.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("WorkingDays")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Aleksandar",
                            IsDeleted = false,
                            LastName = "Simonovic",
                            Type = 1,
                            WorkingDays = "2020-12-31 04 PM,2021-01-11 02 PM,2020-12-31 02 PM,2021-01-15 03 PM,2021-01-16 10 AM,2021-01-16 04 PM,2021-01-14 12 PM,2021-01-10 11 AM,2021-01-23 03 PM,2021-01-21 11 AM,2021-01-19 10 AM,2021-01-27 10 AM,2021-01-23 01 PM,2021-02-19 12 PM,2021-01-24 10 AM,2021-02-24 02 PM,2021-02-20 11 AM,2021-02-17 04 PM,2021-01-29 01 PM,2021-02-09 03 PM,2021-02-28 11 AM,2021-02-06 02 PM,2021-02-28 11 AM,2021-03-01 01 PM,2021-02-27 01 PM,2021-04-10 01 PM,2021-03-31 10 AM,2021-03-24 01 PM,2021-03-15 02 PM,2021-03-27 10 AM,2021-04-03 10 AM,2021-04-10 10 AM,2021-04-18 12 PM,2021-04-18 04 PM,2021-04-09 01 PM,2021-04-09 10 AM,2021-03-18 12 PM,2021-04-19 10 AM,2021-04-27 10 AM,2021-04-26 01 PM,2021-04-26 02 PM,2021-05-17 10 AM,2021-05-03 12 PM,2021-05-15 10 AM,2021-05-14 02 PM,2021-05-22 01 PM,2021-05-27 10 AM,2021-05-13 11 AM,2021-05-09 03 PM,2021-05-29 11 AM,2021-05-29 11 AM,2021-06-09 04 PM,2021-05-23 04 PM,2021-06-04 11 AM,2021-06-05 12 PM,2021-06-19 01 PM,2021-06-16 02 PM,2021-06-13 11 AM,2021-06-21 02 PM,2021-06-24 10 AM"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Dimitrije",
                            IsDeleted = false,
                            LastName = "Mijatovic",
                            Type = 1,
                            WorkingDays = "2020-12-28 12 PM,2021-01-09 03 PM,2021-01-09 12 PM,2021-01-06 02 PM,2021-01-14 02 PM,2021-01-02 04 PM,2021-01-17 12 PM,2021-01-15 01 PM,2021-01-25 12 PM,2021-01-31 11 AM,2021-01-27 03 PM,2021-01-16 04 PM,2021-01-23 12 PM,2021-01-24 03 PM,2021-02-10 10 AM,2021-02-20 04 PM,2021-02-14 11 AM,2021-02-26 03 PM,2021-02-23 03 PM,2021-03-12 12 PM,2021-03-07 04 PM,2021-03-15 02 PM,2021-03-10 01 PM,2021-03-02 02 PM,2021-03-10 03 PM,2021-03-30 01 PM,2021-03-22 01 PM,2021-03-03 04 PM,2021-03-30 02 PM,2021-03-18 01 PM,2021-04-07 01 PM,2021-03-15 02 PM,2021-04-10 02 PM,2021-04-17 11 AM,2021-03-29 10 AM,2021-04-07 04 PM,2021-04-12 02 PM,2021-04-23 11 AM,2021-04-10 03 PM,2021-04-16 04 PM,2021-04-28 12 PM,2021-04-26 01 PM,2021-04-22 11 AM,2021-05-14 12 PM,2021-05-09 02 PM,2021-05-07 11 AM,2021-05-23 01 PM,2021-05-23 03 PM,2021-05-24 01 PM,2021-05-29 11 AM,2021-05-19 11 AM,2021-06-10 01 PM,2021-06-05 04 PM,2021-06-02 04 PM,2021-06-17 12 PM,2021-06-14 02 PM,2021-06-10 03 PM,2021-06-24 03 PM,2021-06-21 02 PM,2021-06-24 03 PM"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Srdjan",
                            IsDeleted = false,
                            LastName = "Tepavcevic",
                            Type = 0,
                            WorkingDays = "2020-12-28 12 PM,2020-12-28 01 PM,2020-12-31 03 PM,2021-01-13 04 PM,2021-01-24 01 PM,2021-02-03 04 PM,2021-01-22 03 PM,2021-01-21 03 PM,2021-01-28 11 AM,2021-01-13 02 PM,2021-01-25 12 PM,2021-01-30 02 PM,2021-02-23 02 PM,2021-01-30 04 PM,2021-02-08 02 PM,2021-02-03 04 PM,2021-02-10 01 PM,2021-02-23 02 PM,2021-02-12 02 PM,2021-03-19 10 AM,2021-03-11 01 PM,2021-02-16 11 AM,2021-02-16 04 PM,2021-03-09 11 AM,2021-02-28 10 AM,2021-03-03 03 PM,2021-03-19 04 PM,2021-03-08 02 PM,2021-03-06 02 PM,2021-03-09 04 PM,2021-03-31 12 PM,2021-03-20 12 PM,2021-04-08 02 PM,2021-04-19 12 PM,2021-03-17 12 PM,2021-04-07 03 PM,2021-04-22 03 PM,2021-04-18 01 PM,2021-04-29 01 PM,2021-04-13 12 PM,2021-04-30 02 PM,2021-05-17 02 PM,2021-05-02 12 PM,2021-05-17 12 PM,2021-05-12 11 AM,2021-05-13 12 PM,2021-05-21 01 PM,2021-05-21 10 AM,2021-05-27 11 AM,2021-05-14 10 AM,2021-05-13 01 PM,2021-05-28 10 AM,2021-06-12 11 AM,2021-06-08 10 AM,2021-06-10 01 PM,2021-06-18 12 PM,2021-06-11 10 AM,2021-06-22 03 PM,2021-06-16 02 PM,2021-06-23 01 PM"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Neven",
                            IsDeleted = false,
                            LastName = "Milakovic",
                            Type = 0,
                            WorkingDays = "2020-12-28 02 PM,2020-12-29 12 PM,2020-12-31 01 PM,2021-01-11 03 PM,2021-01-04 11 AM,2021-01-21 04 PM,2021-01-11 11 AM,2021-01-14 02 PM,2021-01-13 03 PM,2021-02-07 01 PM,2021-01-28 01 PM,2021-02-04 11 AM,2021-01-25 04 PM,2021-02-01 04 PM,2021-02-02 03 PM,2021-02-01 10 AM,2021-02-27 11 AM,2021-02-09 12 PM,2021-03-07 04 PM,2021-02-09 01 PM,2021-02-22 03 PM,2021-02-25 03 PM,2021-03-09 12 PM,2021-03-06 11 AM,2021-03-02 01 PM,2021-03-15 02 PM,2021-03-27 02 PM,2021-04-04 11 AM,2021-03-13 10 AM,2021-03-29 01 PM,2021-03-24 10 AM,2021-04-23 03 PM,2021-04-21 11 AM,2021-04-05 02 PM,2021-04-02 10 AM,2021-04-02 03 PM,2021-04-06 03 PM,2021-04-14 12 PM,2021-05-14 02 PM,2021-04-25 03 PM,2021-04-24 10 AM,2021-04-19 12 PM,2021-05-02 04 PM,2021-05-10 10 AM,2021-05-25 11 AM,2021-05-07 11 AM,2021-05-29 11 AM,2021-05-28 02 PM,2021-05-22 11 AM,2021-05-25 01 PM,2021-05-27 01 PM,2021-05-18 10 AM,2021-06-16 10 AM,2021-06-02 01 PM,2021-06-11 10 AM,2021-06-18 02 PM,2021-06-14 01 PM,2021-06-20 04 PM,2021-06-15 04 PM,2021-06-23 01 PM"
                        });
                });

            modelBuilder.Entity("HospitalApp.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("HospitalApp.Models.Referral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.HasIndex("SpecialistId");

                    b.ToTable("Referral");
                });

            modelBuilder.Entity("HospitalApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMalicious")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HospitalApp.Models.Administrator", b =>
                {
                    b.HasBaseType("HospitalApp.Models.User");

                    b.ToTable("Administrator");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Address = "Visnjiceva 32, Beograd",
                            FirstName = "admin",
                            IsBlocked = false,
                            IsMalicious = false,
                            LastName = "administratovic",
                            Password = "admin",
                            PhoneNumber = "+3811233212",
                            Role = "Administrator",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("HospitalApp.Models.Patient", b =>
                {
                    b.HasBaseType("HospitalApp.Models.User");

                    b.Property<int?>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CancelledAppointments")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("GeneralPractitionerId")
                        .HasColumnType("int");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("GeneralPractitionerId");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Tomiceva 22, Zrenjanin",
                            FirstName = "Marko",
                            IsBlocked = false,
                            IsMalicious = false,
                            LastName = "Simonovic",
                            Password = "123",
                            PhoneNumber = "+38122555333",
                            Role = "Patient",
                            Username = "maki",
                            Age = 15,
                            CancelledAppointments = 0,
                            Gender = "male",
                            GeneralPractitionerId = 2
                        });
                });

            modelBuilder.Entity("HospitalApp.Models.Appointment", b =>
                {
                    b.HasOne("HospitalApp.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalApp.Models.Feedback", b =>
                {
                    b.HasOne("HospitalApp.Models.Patient", "Patient")
                        .WithOne("Feedback")
                        .HasForeignKey("HospitalApp.Models.Feedback", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalApp.Models.Referral", b =>
                {
                    b.HasOne("HospitalApp.Models.Patient", "Patient")
                        .WithOne("Referral")
                        .HasForeignKey("HospitalApp.Models.Referral", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Models.Doctor", "Specialist")
                        .WithMany("Referrals")
                        .HasForeignKey("SpecialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Specialist");
                });

            modelBuilder.Entity("HospitalApp.Models.Administrator", b =>
                {
                    b.HasOne("HospitalApp.Models.User", null)
                        .WithOne()
                        .HasForeignKey("HospitalApp.Models.Administrator", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalApp.Models.Patient", b =>
                {
                    b.HasOne("HospitalApp.Models.Administrator", "BlockedBy")
                        .WithMany("BlockedUsers")
                        .HasForeignKey("AdministratorId");

                    b.HasOne("HospitalApp.Models.Doctor", "GeneralPractitioner")
                        .WithMany("Patients")
                        .HasForeignKey("GeneralPractitionerId");

                    b.HasOne("HospitalApp.Models.User", null)
                        .WithOne()
                        .HasForeignKey("HospitalApp.Models.Patient", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("BlockedBy");

                    b.Navigation("GeneralPractitioner");
                });

            modelBuilder.Entity("HospitalApp.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Patients");

                    b.Navigation("Referrals");
                });

            modelBuilder.Entity("HospitalApp.Models.Administrator", b =>
                {
                    b.Navigation("BlockedUsers");
                });

            modelBuilder.Entity("HospitalApp.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Feedback");

                    b.Navigation("Referral");
                });
#pragma warning restore 612, 618
        }
    }
}