
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex8.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
        

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(e => e.IdDoctor);
                d.Property(e => e.FristName).IsRequired().HasMaxLength(100);
                d.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                d.Property(e => e.Email).IsRequired().HasMaxLength(100);

                d.HasData(
                        new Doctor { IdDoctor = 1, FristName = "Jaroslaw", LastName = "Andrzejewski", Email = "jandrzejewski@wp.pl"},
                        new Doctor { IdDoctor = 2, FristName = "Zbigniew", LastName = "Gieremek", Email = "zgieremek@onet.pl"}
                );
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FristName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.BirthDate).IsRequired();

                p.HasData(
                        new Patient { IdPatient = 1, FristName = "Jan", LastName = "Łośborodo", BirthDate = DateTime.Parse("1967-03-23")},
                        new Patient { IdPatient = 2, FristName = "Krzysztof", LastName = "Kononowicz", BirthDate = DateTime.Parse("1963-04-11")},
                        new Patient { IdPatient = 3, FristName = "Wojciech", LastName = "Suchodolski", BirthDate = DateTime.Parse("1977-09-20")}
                );
            });

            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(e => e.IdMedicament);
                m.Property(e => e.Name).IsRequired().HasMaxLength(100);
                m.Property(e => e.Description).IsRequired().HasMaxLength(100);
                m.Property(e => e.Type).IsRequired().HasMaxLength(100);

                m.HasData(
                        new Medicament { IdMedicament = 1, Name = "LekNaWszystko", Description = "Potezny Lek", Type = "na wszystko"},
                        new Medicament { IdMedicament = 2, Name = "APAP Noc", Description = "Nie brac w dzien", Type = "na bol glowy"}
                );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();
                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

                p.HasData(
                        new Prescription { IdPrescription = 1, Date = DateTime.Parse("2022-01-01"), DueDate = DateTime.Parse("2022-01-02"), IdPatient = 1, IdDoctor = 1},
                        new Prescription { IdPrescription = 2, Date = DateTime.Parse("2022-02-03"), DueDate = DateTime.Parse("2022-02-05"), IdPatient = 2, IdDoctor = 2}
                );

            });

            modelBuilder.Entity<PrescriptionMedicament>(p =>
            {
                p.HasKey(e => new { e.IdPrescription, e.IdMedicament });
                p.Property(e => e.Dose);
                p.Property(e => e.Detalis).IsRequired().HasMaxLength(100);
                p.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdPrescription);
                p.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdMedicament);

                p.HasData(
                        new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 2, Detalis = "pomoze" },
                        new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 5, Detalis = "moze pomoc"}
                );

            });
        }
    }
}
