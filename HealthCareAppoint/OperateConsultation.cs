using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using HealthCareAppoint;

namespace HealthCareAppointment
{
    public class OperateConsultation
    {

        HealthCareContext obj = Consultation();

        public List<Consultation> ViewConsultation()
        {
            return obj.consultations.ToList();

        }
        public void InsertConsultation()
        {
            Consultation consultations = new Consultation();
            Console.WriteLine("Enter consultationId: ");
            consultations.ConsultationId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter AppointmentId: ");
            consultations.AppointmentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Notes: ");
            consultations.Notes = Console.ReadLine();

            Console.WriteLine("Enter Prescription: ");
            consultations.Prescription = Console.ReadLine();

            obj.consultations.Add(consultations);
            obj.SaveChanges();
            Console.WriteLine("record saved");

        }
        public void print()
        {
            var ans = obj.consultations.ToList();
            foreach (var con in ans)
            {
                Console.WriteLine(con.ConsultationId);
                Console.WriteLine(con.AppointmentId);
                Console.WriteLine(con.Notes);
                Console.WriteLine(con.Prescription);

            }
        }
        public void DeleteConsultation()
        {
            Console.WriteLine("Enter ConsultationId: ");
            int id = int.Parse(Console.ReadLine());
            obj.consultations.Where(q => q.ConsultationId == id).ExecuteDelete();
            obj.SaveChanges();


        }
        public void UpdateConsultation()
        {
            Console.WriteLine("Enter ConsultationId to update: ");
            int id = int.Parse(Console.ReadLine());

            var consultation = obj.consultations.Find(id);
            if (consultation != null)
            {
                Console.WriteLine("Enter new AppointmentId: ");
                consultation.AppointmentId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Notes: ");
                consultation.Notes = Console.ReadLine();

                Console.WriteLine("Enter new Prescription: ");
                consultation.Prescription = Console.ReadLine();

                obj.consultations.Update(consultation);
                obj.SaveChanges();
                Console.WriteLine("Consultation updated");
            }
            else
            {
                Console.WriteLine("Consultation not found");
            }
        }
    }
}
