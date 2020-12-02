using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class DoctorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DoctorType Type { get; set; }

        public ICollection<Examination> Examinations { get; set; }

        public bool IsDeleted { get; set; }
    }
}
