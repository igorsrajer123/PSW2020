﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("PatientId")]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public virtual Patient Patient { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }
    }
}
