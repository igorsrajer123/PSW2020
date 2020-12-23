using System;
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
        public int Id { get; set; }

        [MaxLength(150)]
        public string Text { get; set; }

        public string Date { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }
    }
}
