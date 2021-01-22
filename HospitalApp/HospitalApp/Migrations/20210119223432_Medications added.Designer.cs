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
    [Migration("20210119223432_Medications added")]
    partial class Medicationsadded
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

                    b.Property<string>("CancellationDate")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("HospitalApp.Models.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Medication");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rivotril",
                            Quantity = 132
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vicodin",
                            Quantity = 32
                        },
                        new
                        {
                            Id = 3,
                            Name = "Xodol",
                            Quantity = 212
                        },
                        new
                        {
                            Id = 4,
                            Name = "Norco",
                            Quantity = 55
                        },
                        new
                        {
                            Id = 5,
                            Name = "Levoxyl",
                            Quantity = 69
                        },
                        new
                        {
                            Id = 6,
                            Name = "Delasone",
                            Quantity = 11
                        },
                        new
                        {
                            Id = 7,
                            Name = "Neurontin ",
                            Quantity = 43
                        },
                        new
                        {
                            Id = 8,
                            Name = "Glucophage ",
                            Quantity = 177
                        });
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

            modelBuilder.Entity("HospitalApp.Models.Doctor", b =>
                {
                    b.HasBaseType("HospitalApp.Models.User");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("WorkingDays")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Address = "Marka Kraljevica 22",
                            FirstName = "Aleksandar",
                            IsBlocked = false,
                            IsMalicious = false,
                            LastName = "Simonovic",
                            Password = "123",
                            PhoneNumber = "555-333",
                            Role = "Doctor",
                            Username = "doca1",
                            Type = 1,
                            WorkingDays = "2021-01-19 12 PM,2021-01-25 01 PM,2021-02-01 10 AM,2021-01-25 02 PM,2021-02-02 10 AM,2021-02-09 11 AM,2021-02-15 04 PM,2021-02-06 03 PM,2021-02-11 11 AM,2021-02-18 10 AM,2021-02-14 10 AM,2021-02-22 12 PM,2021-03-02 12 PM,2021-03-06 12 PM,2021-03-12 11 AM,2021-03-14 03 PM,2021-03-08 10 AM,2021-03-14 04 PM,2021-03-28 03 PM,2021-03-21 11 AM,2021-03-31 11 AM,2021-03-09 01 PM,2021-04-12 11 AM,2021-04-16 03 PM,2021-04-08 01 PM,2021-03-20 10 AM,2021-05-02 12 PM,2021-04-13 12 PM,2021-04-17 02 PM,2021-04-26 03 PM,2021-04-22 03 PM,2021-04-25 02 PM,2021-04-21 01 PM,2021-05-17 02 PM,2021-05-20 12 PM,2021-04-26 04 PM,2021-05-26 04 PM,2021-06-12 04 PM,2021-05-11 10 AM,2021-06-04 04 PM,2021-05-27 01 PM,2021-06-02 02 PM,2021-06-14 10 AM,2021-06-30 01 PM,2021-06-19 03 PM,2021-06-17 03 PM,2021-06-26 03 PM,2021-06-27 03 PM,2021-07-09 10 AM,2021-07-11 02 PM,2021-07-13 03 PM,2021-07-10 02 PM,2021-07-10 12 PM"
                        },
                        new
                        {
                            Id = 11,
                            Address = "Visnjiceva 2",
                            FirstName = "Dimitrije",
                            IsBlocked = false,
                            IsMalicious = false,
                            LastName = "Mijatovic",
                            Password = "1234",
                            PhoneNumber = "55-44-33",
                            Role = "Doctor",
                            Username = "doca2",
                            Type = 1,
                            WorkingDays = "2021-01-24 03 PM,2021-02-12 11 AM,2021-01-29 12 PM,2021-01-31 02 PM,2021-01-30 01 PM,2021-02-11 02 PM,2021-02-13 01 PM,2021-02-16 01 PM,2021-01-28 04 PM,2021-03-01 11 AM,2021-02-14 02 PM,2021-02-21 12 PM,2021-03-06 11 AM,2021-03-02 04 PM,2021-03-06 02 PM,2021-03-10 11 AM,2021-03-31 10 AM,2021-03-25 10 AM,2021-04-02 10 AM,2021-03-27 03 PM,2021-04-07 10 AM,2021-04-08 12 PM,2021-04-02 03 PM,2021-04-01 12 PM,2021-04-20 11 AM,2021-05-04 02 PM,2021-04-26 11 AM,2021-05-01 03 PM,2021-04-15 10 AM,2021-04-19 10 AM,2021-05-08 12 PM,2021-05-14 10 AM,2021-05-23 12 PM,2021-04-30 03 PM,2021-06-03 12 PM,2021-05-08 04 PM,2021-05-10 12 PM,2021-05-19 02 PM,2021-05-26 03 PM,2021-06-06 10 AM,2021-05-04 03 PM,2021-06-09 03 PM,2021-06-15 03 PM,2021-06-02 12 PM,2021-06-16 02 PM,2021-06-24 03 PM,2021-07-02 02 PM,2021-06-09 11 AM,2021-06-29 03 PM,2021-06-30 12 PM,2021-07-16 10 AM,2021-07-13 12 PM,2021-07-12 04 PM"
                        },
                        new
                        {
                            Id = 12,
                            Address = "Nikole Tesle 5",
                            FirstName = "Srdjan",
                            IsBlocked = false,
                            IsMalicious = false,
                            LastName = "Tepavcevic",
                            Password = "12345",
                            PhoneNumber = "55-42-4-21",
                            Role = "Doctor",
                            Username = "doca3",
                            Type = 0,
                            WorkingDays = "2021-01-19 12 PM,2021-01-26 11 AM,2021-02-01 02 PM,2021-01-29 02 PM,2021-02-10 10 AM,2021-01-26 03 PM,2021-02-09 11 AM,2021-02-17 02 PM,2021-02-25 11 AM,2021-02-07 11 AM,2021-03-12 11 AM,2021-02-12 04 PM,2021-03-01 02 PM,2021-02-23 01 PM,2021-03-25 03 PM,2021-03-10 02 PM,2021-03-21 11 AM,2021-03-27 02 PM,2021-03-20 01 PM,2021-03-31 12 PM,2021-03-25 03 PM,2021-04-04 11 AM,2021-03-26 02 PM,2021-04-06 11 AM,2021-04-16 10 AM,2021-04-20 03 PM,2021-05-04 02 PM,2021-04-10 01 PM,2021-04-21 10 AM,2021-04-25 02 PM,2021-05-08 01 PM,2021-04-25 02 PM,2021-05-07 01 PM,2021-04-24 01 PM,2021-05-02 12 PM,2021-05-04 12 PM,2021-05-21 01 PM,2021-05-27 02 PM,2021-06-04 02 PM,2021-05-31 01 PM,2021-06-03 01 PM,2021-06-12 11 AM,2021-05-23 10 AM,2021-06-16 04 PM,2021-06-12 01 PM,2021-07-04 12 PM,2021-06-09 02 PM,2021-06-27 11 AM,2021-06-25 04 PM,2021-07-11 11 AM,2021-07-10 01 PM,2021-07-13 10 AM,2021-07-13 01 PM"
                        },
                        new
                        {
                            Id = 13,
                            Address = "Vukasinova 69",
                            FirstName = "Neven",
                            IsBlocked = false,
                            IsMalicious = false,
                            LastName = "Milakovic",
                            Password = "1234567",
                            PhoneNumber = "7766-65-64",
                            Role = "Doctor",
                            Username = "doca66",
                            Type = 0,
                            WorkingDays = "2021-01-21 04 PM,2021-01-27 01 PM,2021-01-29 11 AM,2021-01-22 02 PM,2021-02-06 12 PM,2021-02-07 02 PM,2021-02-15 10 AM,2021-02-03 12 PM,2021-02-19 10 AM,2021-02-03 12 PM,2021-02-23 01 PM,2021-03-02 11 AM,2021-03-06 03 PM,2021-02-28 02 PM,2021-03-29 12 PM,2021-03-07 04 PM,2021-04-01 10 AM,2021-03-15 10 AM,2021-04-05 01 PM,2021-03-18 04 PM,2021-04-27 02 PM,2021-03-25 04 PM,2021-04-05 12 PM,2021-03-19 02 PM,2021-04-13 11 AM,2021-05-05 12 PM,2021-04-27 01 PM,2021-04-04 12 PM,2021-05-04 03 PM,2021-05-02 11 AM,2021-04-29 01 PM,2021-05-07 11 AM,2021-05-25 12 PM,2021-05-11 03 PM,2021-05-10 11 AM,2021-06-03 11 AM,2021-05-19 02 PM,2021-05-25 03 PM,2021-05-20 04 PM,2021-06-03 03 PM,2021-05-28 04 PM,2021-05-23 11 AM,2021-06-01 01 PM,2021-06-11 01 PM,2021-06-29 01 PM,2021-07-02 04 PM,2021-07-06 11 AM,2021-06-30 12 PM,2021-06-30 04 PM,2021-06-29 12 PM,2021-07-11 10 AM,2021-06-21 10 AM,2021-07-12 03 PM"
                        });
                });

            modelBuilder.Entity("HospitalApp.Models.Patient", b =>
                {
                    b.HasBaseType("HospitalApp.Models.User");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CancelledAppointments")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("GeneralPractitionerId")
                        .HasColumnType("int");

                    b.HasIndex("GeneralPractitionerId");

                    b.ToTable("Patient");
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

            modelBuilder.Entity("HospitalApp.Models.Doctor", b =>
                {
                    b.HasOne("HospitalApp.Models.User", null)
                        .WithOne()
                        .HasForeignKey("HospitalApp.Models.Doctor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalApp.Models.Patient", b =>
                {
                    b.HasOne("HospitalApp.Models.Doctor", "GeneralPractitioner")
                        .WithMany("Patients")
                        .HasForeignKey("GeneralPractitionerId");

                    b.HasOne("HospitalApp.Models.User", null)
                        .WithOne()
                        .HasForeignKey("HospitalApp.Models.Patient", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("GeneralPractitioner");
                });

            modelBuilder.Entity("HospitalApp.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Patients");

                    b.Navigation("Referrals");
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