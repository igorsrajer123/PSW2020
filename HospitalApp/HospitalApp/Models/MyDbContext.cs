using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Examination> Examinations { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { Id = 5, FirstName = "admin", LastName = "administratovic", Username = "admin", Password = "admin", BlockedUsers = null, IsDeleted = false}
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FirstName = "Misa", LastName = "Simonovic", Type = DoctorType.GeneralPractitioner, Examinations = null, IsDeleted = false}
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FirstName = "Marko", LastName = "Simonovic", IsDeleted = false, Username = "maki",
                              Password = "123", Age = 15, Gender = "male", IsBlocked = false, AdministratorId = null}
                );

            modelBuilder.Entity<Doctor>()
                        .HasMany(e => e.Examinations)
                        .WithOne(d => d.Doctor);

            modelBuilder.Entity<Patient>()
                        .HasMany(e => e.Examinations)
                        .WithOne(p => p.Patient);

            modelBuilder.Entity<Administrator>()
                        .HasMany(p => p.BlockedUsers)
                        .WithOne(b => b.BlockedBy);

            modelBuilder.Entity<Patient>()
                        .HasOne(f => f.Feedback)
                        .WithOne(p => p.Patient)
                        .HasForeignKey<Feedback>(f => f.PatientId);

            modelBuilder.Entity<Patient>()
                        .Property(b => b.AdministratorId)
                        .IsRequired(false);
        }

    }
}
