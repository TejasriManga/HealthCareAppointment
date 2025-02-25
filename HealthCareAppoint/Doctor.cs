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
        public int DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string DoctorSpecialization { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
