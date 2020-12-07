using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class AdministratorDto : UserDto
    {
        public int Id { get; set; }

        public List<Patient> BlockedUsers { get; set; }
    }
}
