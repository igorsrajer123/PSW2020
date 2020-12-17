using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DoctorType Type { get; set; }

        public List<Appointment> Appointments { get; set; }

        public List<Patient> Patients { get; set; }

        public bool IsDeleted { get; set; }

        public string[] WorkingDays { get; set; }

        public List<Referral> Referrals { get; set; }
    }
}
