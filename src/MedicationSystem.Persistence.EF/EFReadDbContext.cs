using System;
using System.Threading;
using System.Threading.Tasks;
using MedicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedicationSystem.Persistence.EF;

public class EFReadDbContext : DbContext
{
    public EFReadDbContext(DbContextOptions<EFReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFReadDbContext).Assembly);
    }

    public DbSet<Medication> Medications { get; set; }

    public override int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}