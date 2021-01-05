using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsMalicious { get; set; }
    }
}
