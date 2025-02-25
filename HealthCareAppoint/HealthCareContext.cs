using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareAppoint;
using Microsoft.EntityFrameworkCore;



namespace HealthCareAppoint
{
    public class HealthcareContext:DbContext
    {

        public HealthcareContext() { }
        public HealthcareContext(DbContextOptions<HealthcareContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Consultation> Consultations { get; set; }

        

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Medical;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Appointment)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Change to NoAction

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Appointment)
                .WithOne(a => a.Consultation)
                .HasForeignKey<Appointment>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointment)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId); //Doctor appointment table relation



        }



    }
}
