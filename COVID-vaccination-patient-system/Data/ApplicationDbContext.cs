using COVID_vaccination_patient_system.Models;
using Microsoft.EntityFrameworkCore;

namespace COVID_vaccination_patient_system.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient {PatientID = 1, Name = "Umair Khan", Age = 32, Gender = "Male", VaccinationStatus = "Unvaccinated" },
                new Patient { PatientID = 2, Name = "Harry Brown", Age = 42, Gender = "Male", VaccinationStatus = "Unvaccinated" },
                new Patient { PatientID = 3, Name = "Margaret Taylor", Age = 28, Gender = "Female", VaccinationStatus = "Unvaccinated" }
                );
        }
    }
}
