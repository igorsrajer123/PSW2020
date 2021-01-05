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

        private readonly DateLogic _dt = new DateLogic();

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { Id = 5, FirstName = "admin", LastName = "administratovic", Username = "admin",
                                    Password = "admin", Role = "Administrator", Address = "Visnjiceva 32, Beograd",
                                    PhoneNumber = "+3811233212" , IsBlocked = false, IsMalicious = false}
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FirstName = "Aleksandar", LastName = "Simonovic", Type = DoctorType.GeneralPractitioner, Appointments = null, IsDeleted = false, WorkingDays = _dt.DiscardRandomHoursString()},
                new Doctor { Id = 2, FirstName = "Dimitrije", LastName = "Mijatovic", Type = DoctorType.GeneralPractitioner, Appointments = null, IsDeleted = false, WorkingDays = _dt.DiscardRandomHoursString()},
                new Doctor { Id = 3, FirstName = "Srdjan", LastName = "Tepavcevic", Type = DoctorType.Specialist, Appointments = null, IsDeleted = false, WorkingDays = _dt.DiscardRandomHoursString() },
                new Doctor { Id = 4, FirstName = "Neven", LastName = "Milakovic", Type = DoctorType.Specialist, Appointments = null, IsDeleted = false, WorkingDays = _dt.DiscardRandomHoursString() }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FirstName = "Marko", LastName = "Simonovic", Role = "Patient",
                                Username = "maki", Password = "123", Address = "Tomiceva 22, Zrenjanin", Age = 15, Gender = "male",
                                PhoneNumber = "+38122555333", IsBlocked = false, GeneralPractitionerId = 2, CancelledAppointments = 0, IsMalicious = false}
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
                        .WithMany(r => r.Referrals);

            modelBuilder.Entity<Referral>()
                        .HasOne(p => p.Patient)
                        .WithOne(r => r.Referral);

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
