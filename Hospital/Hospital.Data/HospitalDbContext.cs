using Hospital.Data.ConfigurationClasses;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
        {

        }

        public HospitalDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DiagnosisConfiguration());
            builder.ApplyConfiguration(new MedicamentConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new PatientMedicamentConfiguration());
            builder.ApplyConfiguration(new VisitationConfiguration());
        }
    }
}
