using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    [Table("Referral")]
    public class Referral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SpecialistId { get; set; }

        public virtual Doctor Specialist { get; set; }

        public virtual int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public bool IsDeleted { get; set; }
    }
}
