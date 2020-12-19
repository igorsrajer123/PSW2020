using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    public enum AppointmentStatus
    {
        Done,
        Active,
        Cancelled
    }

    [Table("Appointment")]
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public AppointmentStatus Status { get; set; }
    }
}
