using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Dtos
{
    public class FeedbackDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int PatientId { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }
    }
}
