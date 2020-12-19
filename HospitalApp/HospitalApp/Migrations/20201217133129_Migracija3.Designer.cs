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
    [Migration("20201217133129_Migracija3")]
    partial class Migracija3
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

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
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
                            WorkingDays = "2020-12-28 10 AM,2020-12-30 02 PM,2020-12-30 03 PM,2021-01-01 11 AM,2021-01-02 02 PM,2021-01-03 03 PM,2021-01-04 10 AM,2021-01-09 01 PM,2021-01-22 10 AM,2021-01-22 01 PM,2021-01-22 02 PM,2021-01-24 02 PM,2021-01-31 10 AM,2021-02-05 01 PM,2021-02-05 02 PM,2021-02-05 03 PM,2021-02-09 11 AM,2021-02-09 01 PM,2021-02-09 04 PM,2021-02-14 01 PM,2021-02-20 11 AM,2021-02-21 04 PM,2021-02-22 10 AM,2021-02-24 01 PM,2021-02-24 03 PM,2021-03-03 10 AM,2021-03-04 10 AM,2021-03-07 03 PM,2021-03-08 04 PM,2021-03-14 02 PM,2021-03-17 10 AM,2021-03-20 01 PM,2021-03-22 03 PM,2021-03-23 11 AM,2021-03-23 01 PM,2021-03-23 03 PM,2021-03-27 04 PM,2021-03-28 11 AM,2021-03-28 12 PM,2021-03-29 10 AM,2021-04-07 10 AM,2021-04-08 12 PM,2021-04-09 02 PM,2021-04-12 01 PM,2021-04-12 02 PM,2021-04-13 12 PM,2021-04-17 01 PM,2021-04-19 01 PM,2021-04-21 12 PM,2021-04-24 01 PM,2021-04-24 02 PM,2021-05-04 12 PM,2021-05-06 12 PM,2021-05-08 11 AM,2021-05-09 01 PM,2021-05-12 10 AM,2021-05-14 04 PM,2021-05-17 10 AM,2021-05-19 11 AM,2021-05-19 03 PM,2021-05-31 01 PM,2021-05-31 02 PM,2021-06-04 11 AM,2021-06-11 04 PM,2021-06-12 03 PM"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Dimitrije",
                            IsDeleted = false,
                            LastName = "Mijatovic",
                            Type = 1,
                            WorkingDays = "2020-12-18 12 PM,2020-12-19 12 PM,2020-12-23 03 PM,2020-12-26 04 PM,2020-12-27 02 PM,2020-12-29 11 AM,2020-12-30 12 PM,2020-12-31 12 PM,2021-01-07 02 PM,2021-01-08 12 PM,2021-01-13 10 AM,2021-01-14 11 AM,2021-01-15 10 AM,2021-01-15 02 PM,2021-01-16 10 AM,2021-01-16 11 AM,2021-01-16 12 PM,2021-01-16 03 PM,2021-01-23 12 PM,2021-01-24 03 PM,2021-02-02 01 PM,2021-02-09 10 AM,2021-02-14 01 PM,2021-02-16 01 PM,2021-02-24 01 PM,2021-02-25 11 AM,2021-02-25 03 PM,2021-03-01 04 PM,2021-03-08 02 PM,2021-03-14 12 PM,2021-03-17 12 PM,2021-03-19 01 PM,2021-03-20 11 AM,2021-03-21 11 AM,2021-03-22 11 AM,2021-03-23 01 PM,2021-03-25 01 PM,2021-03-25 04 PM,2021-03-27 11 AM,2021-03-31 01 PM,2021-04-01 04 PM,2021-04-02 12 PM,2021-04-07 03 PM,2021-04-13 12 PM,2021-04-18 02 PM,2021-04-19 10 AM,2021-04-22 10 AM,2021-04-23 03 PM,2021-04-28 03 PM,2021-04-30 12 PM,2021-05-02 12 PM,2021-05-05 02 PM,2021-05-07 01 PM,2021-05-07 02 PM,2021-05-09 12 PM,2021-05-11 04 PM,2021-05-14 03 PM,2021-05-16 10 AM,2021-05-18 10 AM,2021-05-18 02 PM,2021-05-25 02 PM,2021-05-25 03 PM,2021-06-03 12 PM,2021-06-05 12 PM,2021-06-09 12 PM"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Srdjan",
                            IsDeleted = false,
                            LastName = "Tepavcevic",
                            Type = 0,
                            WorkingDays = "2020-12-19 12 PM,2020-12-25 10 AM,2020-12-26 11 AM,2020-12-26 04 PM,2020-12-27 04 PM,2020-12-31 12 PM,2021-01-10 12 PM,2021-01-10 02 PM,2021-01-10 04 PM,2021-01-11 01 PM,2021-01-14 12 PM,2021-01-20 11 AM,2021-01-22 02 PM,2021-01-24 02 PM,2021-01-25 02 PM,2021-01-25 03 PM,2021-01-29 04 PM,2021-01-30 01 PM,2021-01-30 02 PM,2021-02-01 11 AM,2021-02-05 04 PM,2021-02-10 10 AM,2021-02-11 10 AM,2021-02-15 12 PM,2021-02-24 12 PM,2021-02-24 02 PM,2021-02-27 11 AM,2021-02-27 02 PM,2021-02-28 01 PM,2021-02-28 03 PM,2021-03-01 03 PM,2021-03-04 12 PM,2021-03-06 02 PM,2021-03-07 10 AM,2021-03-09 01 PM,2021-03-18 12 PM,2021-03-21 01 PM,2021-03-25 01 PM,2021-04-05 12 PM,2021-04-09 10 AM,2021-04-09 01 PM,2021-04-12 12 PM,2021-04-13 04 PM,2021-04-18 12 PM,2021-04-21 11 AM,2021-04-22 04 PM,2021-04-23 02 PM,2021-04-27 01 PM,2021-04-28 02 PM,2021-05-02 01 PM,2021-05-11 10 AM,2021-05-11 12 PM,2021-05-12 10 AM,2021-05-14 02 PM,2021-05-15 02 PM,2021-05-15 03 PM,2021-05-21 01 PM,2021-05-24 04 PM,2021-06-02 02 PM,2021-06-02 04 PM,2021-06-05 10 AM,2021-06-07 10 AM,2021-06-09 01 PM,2021-06-11 01 PM,2021-06-14 11 AM"
                        });
                });

            modelBuilder.Entity("HospitalApp.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

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

                    b.Property<bool>("IsDeleted")
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
                            IsDeleted = false,
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

                    b.Property<string>("Gender")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("GeneralPractitionerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("GeneralPractitionerId");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Tomiceva 22, Zrenjanin",
                            FirstName = "Marko",
                            IsDeleted = false,
                            LastName = "Simonovic",
                            Password = "123",
                            PhoneNumber = "+38122555333",
                            Role = "Patient",
                            Username = "maki",
                            Age = 15,
                            Gender = "male",
                            GeneralPractitionerId = 2,
                            IsBlocked = false
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