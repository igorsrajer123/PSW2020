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
    public class Doctor : User
    {
        public DoctorType Type { get; set; }

        public virtual List<Appointment> Appointments { get; set; }

        public virtual List<Patient> Patients { get; set; }

        public string[] WorkingDays { get; set; }

        public virtual List<Referral> Referrals { get; set; }
    }
}
