using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public bool IsDone { get; set; }

        public bool IsCancelled { get; set; }
    }
}
