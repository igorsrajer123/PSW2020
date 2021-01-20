using Microsoft.EntityFrameworkCore;
using HospitalApp.DateTimeLogic;
using System;

namespace HospitalApp.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Referral> Referrals { get; set; }

        public DbSet<Medication> Medications { get; set; }

        private readonly DateLogic _dt = new DateLogic();

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //prvo ubaciti admina i doktore, pa tek onda pacijente zbog stranih kljuceva!
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { Id = 5, FirstName = "admin", LastName = "administratovic", Username = "admin",
                                    Password = "admin", Role = "Administrator", Address = "Visnjiceva 32, Beograd",
                                    PhoneNumber = "+3811233212" , IsBlocked = false, IsMalicious = false}
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 10, FirstName = "Aleksandar", LastName = "Simonovic", Address = "Marka Kraljevica 22",
                             Type = DoctorType.GeneralPractitioner, Appointments = null, WorkingDays = _dt.DiscardRandomHoursString(),
                             IsBlocked = false, IsMalicious = false, Password = "123", PhoneNumber = "555-333", Role = "Doctor", Username = "doca1"},

                new Doctor { Id = 11, FirstName = "Dimitrije", LastName = "Mijatovic", Address = "Visnjiceva 2",
                             Type = DoctorType.GeneralPractitioner, Appointments = null, WorkingDays = _dt.DiscardRandomHoursString(),
                             IsBlocked = false, IsMalicious = false, Password = "1234", PhoneNumber = "55-44-33", Role = "Doctor", Username = "doca2"},

                new Doctor { Id = 12, FirstName = "Srdjan", LastName = "Tepavcevic", Address = "Nikole Tesle 5",
                             Type = DoctorType.Specialist, Appointments = null, WorkingDays = _dt.DiscardRandomHoursString(),
                             IsBlocked = false, IsMalicious = false, Password = "12345", PhoneNumber = "55-42-4-21", Role = "Doctor", Username = "doca3"},

                new Doctor { Id = 13, FirstName = "Neven", LastName = "Milakovic", Address = "Vukasinova 69",
                            Type = DoctorType.Specialist, Appointments = null, WorkingDays = _dt.DiscardRandomHoursString(),
                            IsBlocked = false, IsMalicious = false, Password = "1234567", PhoneNumber = "7766-65-64", Role = "Doctor", Username = "doca66"}
            );

            modelBuilder.Entity<Medication>().HasData(
                new Medication { Id = 1, Name = "Rivotril", Quantity = 132 },
                new Medication { Id = 2, Name = "Vicodin", Quantity = 32 },
                new Medication { Id = 3, Name = "Xodol", Quantity = 212 },
                new Medication { Id = 4, Name = "Norco", Quantity = 55 },
                new Medication { Id = 5, Name = "Levoxyl", Quantity = 69 },
                new Medication { Id = 6, Name = "Delasone", Quantity = 11 },
                new Medication { Id = 7, Name = "Neurontin ", Quantity = 43 },
                new Medication { Id = 8, Name = "Glucophage ", Quantity = 177 }
            );
           
            modelBuilder.Entity<Doctor>()
                        .Property(w => w.WorkingDays)
                        .HasConversion(
                            v => string.Join(',', v),
                            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Doctor>()
                        .HasMany(e => e.Appointments)
                        .WithOne(d => d.Doctor);

            modelBuilder.Entity<Doctor>()
                        .HasMany(p => p.Patients)
                        .WithOne(g => g.GeneralPractitioner);

            modelBuilder.Entity<Referral>()
                        .HasOne(s => s.Specialist)
                        .WithMany(r => r.Referrals)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Referral>()
                        .HasOne(p => p.Patient)
                        .WithOne(r => r.Referral)
                         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                        .HasMany(e => e.Appointments)
                        .WithOne(p => p.Patient);

            modelBuilder.Entity<Patient>()
                        .HasOne(f => f.Feedback)
                        .WithOne(p => p.Patient)
                        .HasForeignKey<Feedback>(f => f.PatientId);
        }
    }
}
