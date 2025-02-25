using System;
using Microsoft.EntityFrameworkCore;
using HealthCareAppoint;

namespace HealthCareApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HealthcareContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Medical;Encrypt=False");

            using (var context = new HealthcareContext(optionsBuilder.Options))
            {
                // Ensure database is created
                context.Database.EnsureCreated();

                // Example usage of Operate and OperateConsultation classes
                var operate = new Operate();
                var operateConsultation = new OperateConsultation();
                var operateDoctor = new OperateDoctor();
                var operateUser = new Operateuser(context);

                // Interactive user input
                while (true)
                {
                    Console.WriteLine("Choose an operation:");
                    Console.WriteLine("1. Insert User");
                    Console.WriteLine("2. View Users");
                    Console.WriteLine("3. Insert Appointment");
                    Console.WriteLine("4. View Appointments");
                    Console.WriteLine("5. Insert Consultation");
                    Console.WriteLine("6. View Consultations");
                    Console.WriteLine("7. Insert Doctor");
                    Console.WriteLine("8. View Doctors");
                    Console.WriteLine("9. Exit");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            InsertUser(operateUser);
                            break;
                        case "2":
                            ViewUsers(operateUser);
                            break;
                        case "3":
                            InsertAppointment(operate);
                            break;
                        case "4":
                            ViewAppointments(operate);
                            break;
                        case "5":
                            operateConsultation.InsertConsultation();
                            break;
                        case "6":
                            ViewConsultations(operateConsultation);
                            break;
                        case "7":
                            operateDoctor.Insert();
                            break;
                        case "8":
                            ViewDoctors(operateDoctor);
                            break;
                        case "9":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
        }

        private static void InsertUser(Operateuser operateUser)
        {
            var newUser = new User();
            Console.WriteLine("Enter UserId: ");
            newUser.UserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            newUser.Name = Console.ReadLine();
            Console.WriteLine("Enter Phone: ");
            newUser.Phone = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            newUser.Email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            newUser.Password = Console.ReadLine();
            operateUser.InsertUser(newUser);
        }

        private static void ViewUsers(Operateuser operateUser)
        {
            var users = operateUser.ViewUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"UserId: {user.UserId}, Name: {user.Name}, Phone: {user.Phone}, Email: {user.Email}");
            }
        }

        private static void InsertAppointment(Operate operate)
        {
            var newAppointment = new Appointment();
            Console.WriteLine("Enter AppointmentId: ");
            newAppointment.AppointmentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter UserId: ");
            newAppointment.UserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter DoctorId: ");
            newAppointment.DoctorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter DateTime: ");
            newAppointment.DateTime = Console.ReadLine();
            Console.WriteLine("Enter Status: ");
            newAppointment.Status = Console.ReadLine();
            operate.Insert(newAppointment);
        }

        private static void ViewAppointments(Operate operate)
        {
            var appointments = operate.ViewAppointments();
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"AppointmentId: {appointment.AppointmentId}, UserId: {appointment.UserId}, DoctorId: {appointment.DoctorId}, DateTime: {appointment.DateTime}, Status: {appointment.Status}");
            }
        }

        private static void ViewConsultations(OperateConsultation operateConsultation)
        {
            var consultations = operateConsultation.ViewConsultation();
            foreach (var consultation in consultations)
            {
                Console.WriteLine($"ConsultationId: {consultation.ConsultationId}, AppointmentId: {consultation.AppointmentId}, Notes: {consultation.Notes}, Prescription: {consultation.Prescription}");
            }
        }

        private static void ViewDoctors(OperateDoctor operateDoctor)
        {
            var doctors = operateDoctor.ViewDoctors();
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"DoctorId: {doctor.DoctorId}, Name: {doctor.DoctorName}, Specialization: {doctor.DoctorSpecialization}, EntryDate: {doctor.EntryDate}");
            }
        }
    }
}