using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    [Table("Patient")]
    public class Patient : User
    {
        public int Age { get; set; }

        [MaxLength(15)]
        public string Gender { get; set; }

        public virtual List<Appointment> Appointments { get; set; }

        public virtual Feedback Feedback { get; set; }

        public int? GeneralPractitionerId { get; set; }

        public virtual Doctor GeneralPractitioner { get; set; }

        public virtual Referral Referral { get; set; }

        public int CancelledAppointments { get; set; }
    }
}
