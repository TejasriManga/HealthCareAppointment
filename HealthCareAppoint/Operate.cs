using System;
using System.Collections.Generic;
using HealthCareAppoint;

namespace HealthCareAppoint
{
    public class Operate
    {
        private List<Appointment> appointments;

        public Operate()
        {
            appointments = new List<Appointment>();
        }

        public void Insert(Appointment appointment)
        {
            appointments.Add(appointment);
            Console.WriteLine("Appointment booked successfully!");
        }

        public void Update(Appointment updatedAppointment)
        {
            var appointment = appointments.Find(a => a.AppointmentId == updatedAppointment.AppointmentId);
            if (appointment != null)
            {
                appointment.UserId = updatedAppointment.UserId;
                appointment.DateTime = updatedAppointment.DateTime;
                appointment.Status = updatedAppointment.Status;
                Console.WriteLine("Appointment updated successfully!");
            }
            else
            {
                Console.WriteLine("Appointment not found!");
            }
        }

        public void Delete(Appointment appointmentToDelete)
        {
            var appointment = appointments.Find(a => a.AppointmentId == appointmentToDelete.AppointmentId);
            if (appointment != null)
            {
                appointments.Remove(appointment);
                Console.WriteLine("Appointment cancelled successfully!");

            }
            else
            {
                Console.WriteLine("Appointment not found!");
            }
        }

        public List<Appointment> ViewAppointments()
        {
            return appointments;
        }
    }
}