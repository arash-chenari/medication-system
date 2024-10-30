using MedicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicationSystem.Persistence.EF.Medications;

public class MedicationEntityMap : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> _)
    {
        _.ToTable("Medications");
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).UseIdentityColumn().IsRequired();
        _.Property(_ => _.Code).IsRequired().HasMaxLength(30);
        _.Property(_ => _.Name).IsRequired().HasMaxLength(30);
        _.Property(_ => _.Type).IsRequired();
        _.Property(_ => _.Quantity).IsRequired();
    }
}