﻿using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class ReferralDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int SpecialistId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
