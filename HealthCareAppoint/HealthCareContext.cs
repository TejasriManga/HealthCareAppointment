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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Appointment)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Change to NoAction

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Consultation)
                .WithOne(c => c.Appointment)
                .HasForeignKey<Consultation>(c => c.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);

        }



    }
}
