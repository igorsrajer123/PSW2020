using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    [Table("Administrator")]
    public class Administrator
    {
        [ForeignKey(nameof(User))]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Patient> BlockedUsers { get; set; }
    }
}
