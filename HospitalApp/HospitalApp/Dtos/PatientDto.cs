using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class PatientDto : UserDto
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public bool IsBlocked { get; set; }

        public virtual List<Examination> Examinations { get; set; }

        public Administrator BlockedBy { get; set; }

        public Feedback Feedback { get; set; }
    }
}
