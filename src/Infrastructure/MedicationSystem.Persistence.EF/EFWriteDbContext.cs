using MedicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicationSystem.Persistence.EF
{
    public class EFWriteDbContext(DbContextOptions<EFWriteDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFWriteDbContext).Assembly);
        }

        public DbSet<Medication> Medications { get; set; }
    }
}