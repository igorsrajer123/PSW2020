using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Examination> Examinations { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id=1, FirstName = "Šilja", LastName = "Pajić", Type = DoctorType.Specialist},
                new Doctor { Id=5, FirstName = "Konan", LastName = "Varvarin", Type = DoctorType.Specialist }
            );*/

            
        }

    }
}
