using Microsoft.EntityFrameworkCore;
using System;

namespace API_MedicoPaciente.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Property Configurations
            modelBuilder.Entity<Medico>()
                        .HasMany(c => c.Pacientes)
                        .WithOne(e => e.Medico);

            modelBuilder.Entity<Paciente>()
                     .HasOne(e => e.Medico);

             // OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}