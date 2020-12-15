using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    public enum DoctorType
    {
        Specialist,
        GeneralPractitioner
    }

    [Table("Doctor")]
    public class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        public DoctorType Type { get; set; }

        public bool IsDeleted { get; set; } 

        public virtual List<Appointment> Appointments { get; set; }

        public virtual List<Patient> Patients { get; set; }

        public string[] WorkingDays { get; set; }
    }
}
