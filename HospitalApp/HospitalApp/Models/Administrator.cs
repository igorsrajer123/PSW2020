using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApp.Models
{
    [Table("Administrator")]
    public class Administrator : User
    {
        public virtual List<Patient>? BlockedUsers { get; set; }
    }
}
