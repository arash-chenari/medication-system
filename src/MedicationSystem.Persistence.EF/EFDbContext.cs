using MedicationSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicationSystem.Persistence.EF
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<DbContext> options) : base(options) 
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDbContext).Assembly);
        }

        public DbSet<Entities.Medication> Medications { get; set; }
    }
}