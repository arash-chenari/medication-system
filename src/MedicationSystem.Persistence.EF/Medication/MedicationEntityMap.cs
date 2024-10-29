using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicationSystem.Persistence.EF.Medication;

public class MedicationEntityMap : IEntityTypeConfiguration<Entities.Medication>
{
    public void Configure(EntityTypeBuilder<Entities.Medication> _)
    {
        _.ToTable("Medication");
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).UseIdentityColumn().IsRequired();
        _.Property(_ => _.Code).IsRequired().HasMaxLength(30);
        _.Property(_ => _.Name).IsRequired().HasMaxLength(30);
        _.Property(_ => _.Type).IsRequired();
        _.Property(_ => _.Quantity).IsRequired();
    }
}