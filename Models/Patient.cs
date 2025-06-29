using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        public string PatientName { get; set; }

        public int Age { get; set; }

        public string ContactNumber { get; set; }


    }
}
