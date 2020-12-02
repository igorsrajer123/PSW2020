using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    [Table("Patient")]
    public class Patient : User
    {
        [MaxLength(3)]
        public int Age { get; set; }

        [MaxLength(15)]
        public string Gender { get; set; }

        public bool IsBlocked { get; set; }

        public virtual ICollection<Examination> Examinations { get; set; }

        public int AdministratorId { get; set; }

        public virtual Administrator BlockedBy { get; set; }

        public virtual Feedback? Feedback { get; set; }
    }
}
