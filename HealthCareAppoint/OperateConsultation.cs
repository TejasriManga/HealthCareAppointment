using Microsoft.EntityFrameworkCore;

namespace HealthCareAppoint
{
    public class OperateConsultation
    {

        HealthcareContext obj = new HealthcareContext();

        public List<Consultation> ViewConsultation()
        {
            return obj.Consultations.ToList();

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

            obj.Consultations.Add(consultations);
            obj.SaveChanges();
            Console.WriteLine("record saved");

        }
        public void print()
        {
            var ans = obj.Consultations.ToList();
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
            obj.Consultations.Where(q => q.ConsultationId == id).ExecuteDelete();
            obj.SaveChanges();


        }
        public void UpdateConsultation()
        {
            Console.WriteLine("Enter ConsultationId to update: ");
            int id = int.Parse(Console.ReadLine());

            var consultation = obj.Consultations.Find(id);
            if (consultation != null)
            {
                Console.WriteLine("Enter new AppointmentId: ");
                consultation.AppointmentId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Notes: ");
                consultation.Notes = Console.ReadLine();

                Console.WriteLine("Enter new Prescription: ");
                consultation.Prescription = Console.ReadLine();

                obj.Consultations.Update(consultation);
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
