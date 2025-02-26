using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HealthCareAppoint
{
    public class OperateDoctor
    {
        HealthcareContext obj = new HealthcareContext();

        public List<Doctor> ViewDoctors()
        {
            return obj.Doctors.ToList();
        }

        public void Insert()
        {
            Doctor d1 = new Doctor();
            Console.WriteLine("Enter DoctorId: ");
            d1.DoctorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter DoctorName: ");
            d1.DoctorName = Console.ReadLine();
            Console.WriteLine("Enter DoctorSpecialization: ");
            d1.DoctorSpecialization = Console.ReadLine();
            Console.WriteLine("Enter Entry Date (yyyy-MM-dd):");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime entryDate))
            {
                d1.EntryDate = entryDate;
                Console.WriteLine($"Entry Date set to: {d1.EntryDate}");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
            }
            obj.Doctors.Add(d1);
            obj.SaveChanges();
            Console.WriteLine("recordsSaved");
        }

        public void Print()
        {
            var ans = obj.Doctors.ToList();
            foreach (var d in ans)
            {
                Console.WriteLine(d.DoctorId);
                Console.WriteLine(d.DoctorName);
                Console.WriteLine(d.DoctorSpecialization);
                Console.WriteLine(d.EntryDate);
            }
        }

        public void DeleteConsultation()
        {
            Console.WriteLine("Enter ConsultationId: ");
            int id = int.Parse(Console.ReadLine());
            obj.Doctors.Where(q => q.DoctorId == id).ExecuteDelete();
            obj.SaveChanges();
        }

        public void UpdateDoctor()
        {
            Console.WriteLine("Enter DoctorId: ");
            int id = int.Parse(Console.ReadLine());
            var doctor = obj.Doctors.FirstOrDefault(q => q.DoctorId == id);
            if (doctor != null)
            {
                Console.WriteLine("Enter new DoctorName: ");
                doctor.DoctorName = Console.ReadLine();
                Console.WriteLine("Enter new DoctorSpecialization: ");
                doctor.DoctorSpecialization = Console.ReadLine();
                obj.Doctors.Update(doctor);
                obj.SaveChanges();
                Console.WriteLine("Doctor updated successfully.");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }
    }
}