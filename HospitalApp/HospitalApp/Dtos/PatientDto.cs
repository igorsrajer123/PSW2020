using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class PatientDto : UserDto
    {
        public int Age { get; set; }

        public string Gender { get; set; }

        public int? GeneralPractitionerId { get; set; }

        public int CancelledAppointments { get; set; }
    }
}
