using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareAppoint
{
    public class Demo
    {
        HealthcareContext context = new HealthcareContext();

        public List<Appointment> GetAppoint()
        {
            List<Appointment> bk = context.Appointments.FromSqlRaw("exec Appoint").ToList();
            return bk;


        }
    }
}
