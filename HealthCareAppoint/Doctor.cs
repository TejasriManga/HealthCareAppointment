using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareAppoint
{
    public class Doctor
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int DoctorId { get; set; }

        [Required]

        public String DoctorName { get; set; } 

        [Required]

        public String DoctorSpecilization { get; set; } 

        [Required]

        public DateTime DateTime { get; set; }
    }
}
