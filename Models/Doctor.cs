using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Specialization { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
