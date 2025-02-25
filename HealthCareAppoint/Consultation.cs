using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareAppoint
{
    public class Consultation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsultationId { get; set; }

        [ForeignKey("Appointment")]

        public int AppointmentId { get; set; }

        public string Notes { get; set; }

        public string Prescription { get; set; }

        public Appointment Appointment {get; set;}


    }
}
