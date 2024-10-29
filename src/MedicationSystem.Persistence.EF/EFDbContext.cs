using MedicationSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicationSystem.Persistence.EF
{
    public class EFDbContext(DbContextOptions<EFDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDbContext).Assembly);
        }

        public DbSet<Entities.Medication> Medications { get; set; }
    }
}