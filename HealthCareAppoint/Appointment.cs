using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareAppoint;

namespace HealthCareAppoint
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppointmentId { get; set; }

        [Required]

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public string DateTime { get; set; }
        [Required]

        public string Status { get; set; }

        public User User { get; set; }

        public Consultation Consultation { get; set; }
        
        public Doctor Doctor { get; set; }
    }
}

