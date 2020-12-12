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
    [Migration("20201211173807_Address added1")]
    partial class Addressadded1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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

                    b.HasKey("Id");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Misa",
                            IsDeleted = false,
                            LastName = "Simonovic",
                            Type = 1
                        });
                });

            modelBuilder.Entity("HospitalApp.Models.Examination", b =>
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

                    b.ToTable("Examination");
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

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.HasIndex("AdministratorId");

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
                            Role = "Patient",
                            Username = "maki",
                            Age = 15,
                            Gender = "male",
                            IsBlocked = false
                        });
                });

            modelBuilder.Entity("HospitalApp.Models.Examination", b =>
                {
                    b.HasOne("HospitalApp.Models.Doctor", "Doctor")
                        .WithMany("Examinations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Models.Patient", "Patient")
                        .WithMany("Examinations")
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

                    b.HasOne("HospitalApp.Models.User", null)
                        .WithOne()
                        .HasForeignKey("HospitalApp.Models.Patient", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("BlockedBy");
                });

            modelBuilder.Entity("HospitalApp.Models.Doctor", b =>
                {
                    b.Navigation("Examinations");
                });

            modelBuilder.Entity("HospitalApp.Models.Administrator", b =>
                {
                    b.Navigation("BlockedUsers");
                });

            modelBuilder.Entity("HospitalApp.Models.Patient", b =>
                {
                    b.Navigation("Examinations");

                    b.Navigation("Feedback");
                });
#pragma warning restore 612, 618
        }
    }
}
