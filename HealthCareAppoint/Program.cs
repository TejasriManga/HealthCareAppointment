using System;
using System.Collections.Generic;
using HealthCareAppoint;


namespace HealthCareAppoint
{
    //appcare new
    class Program
    {
        static void Main(string[] args)
        { 
            using (var context = new HealthcareContext())
            {
                // Ensure database is created
                context.Database.EnsureCreated();

                Operate operate = new Operate();
                Appointment appointment = new Appointment();

                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("Select the operation to perform:");
                    Console.WriteLine("1. Insert");
                    Console.WriteLine("2. Update");
                    Console.WriteLine("3. Delete");
                    Console.WriteLine("4. Read");
                    Console.WriteLine("5. Exit");
                    int num = int.Parse(Console.ReadLine());

                    switch (num)
                    {
                        case 1: // Insert
                            Console.WriteLine("Enter Appointment ID:");
                            appointment.AppointmentId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter User ID:");
                            appointment.UserId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Date and Time (yyyy-MM-dd HH:mm):");
                            appointment.DateTime = Console.ReadLine();

                            Console.WriteLine("Enter Status:");
                            appointment.Status = Console.ReadLine();

                            context.Appointments.Add(appointment);
                            context.SaveChanges(); // Save changes to the database
                            Console.WriteLine("Appointment booked successfully!");
                            break;

                        case 2: // Update
                            Console.WriteLine("Enter Appointment ID:");
                            int appointmentId = int.Parse(Console.ReadLine());

                            var existingAppointment = context.Appointments.Find(appointmentId);
                            if (existingAppointment != null)
                            {
                                Console.WriteLine("Enter User ID:");
                                existingAppointment.UserId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter Date and Time (yyyy-MM-dd HH:mm):");
                                existingAppointment.DateTime = Console.ReadLine()
                                    ;

                                Console.WriteLine("Enter Status:");
                                existingAppointment.Status = Console.ReadLine();

                                context.SaveChanges(); // Save changes to the database
                                Console.WriteLine("Appointment updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Appointment not found!");
                            }
                            break;

                        case 3: // Delete
                            Console.WriteLine("Enter Appointment ID:");
                            appointmentId = int.Parse(Console.ReadLine());

                            var appointmentToDelete = context.Appointments.Find(appointmentId);
                            if (appointmentToDelete != null)
                            {
                                context.Appointments.Remove(appointmentToDelete);
                                context.SaveChanges(); // Save changes to the database
                                Console.WriteLine("Appointment cancelled successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Appointment not found!");
                            }
                            break;

                        case 4: // Read
                            List<Appointment> list = context.Appointments.ToList();
                            foreach (Appointment a in list)
                            {
                                Console.WriteLine($"{a.AppointmentId} {a.UserId} {a.DateTime} {a.Status}");
                            }
                            break;

                        case 5: // Exit
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}