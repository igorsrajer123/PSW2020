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

        public List<Examination> Examinations { get; set; }

        public bool IsDeleted { get; set; }
    }
}
