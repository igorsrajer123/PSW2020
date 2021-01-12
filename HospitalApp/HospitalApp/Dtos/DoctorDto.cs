﻿using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class DoctorDto : UserDto
    {
        public DoctorType Type { get; set; }

        public string[] WorkingDays { get; set; }
    }
}
