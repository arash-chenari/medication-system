using FluentAssertions;
using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Domain.Abstractions;
using MedicationSystem.Entities.Enums;
using MedicationSystem.Infrastructure.Test;
using MedicationSystem.Persistence.EF;
using MedicationSystem.Persistence.EF.Medications;
using MedicationSystem.Services.Medications;
using MedicationSystem.Services.Medications.Contracts;
using MedicationSystem.Services.Medications.Contracts.Dtos;

namespace MedicationSystem.Services.Tests.Unit.Medication;

public class MedicationServiceTests
{
    private readonly EFDbContext _dbContext;
    private readonly IMedicationService _sut;
    
    public MedicationServiceTests()
    {
        var db = new EFInMemoryDatabase();
        _dbContext = db.CreateDataContext<EFDbContext>();
        IMedicationRepository medicationRepository = new EFMedicationRepository(_dbContext);
        IUnitOfWork unitOfWork = new EFUnitOfWork(_dbContext);
         _sut = new MedicationAppService(unitOfWork, medicationRepository);
    }

    [Fact]
    public async void AddAsync_Add_Medication()
    {
        var dto = new AddMedicationDto
        {
            Code = "123Dummy",
            Name = "Dummy",
            Type = MedicationType.Capsules,
            Quantity = 2
        };

        await _sut.AddAsync(dto);

        var expected = _dbContext.Medications
                            .SingleOrDefault(_ => _.Code == dto.Code);
        expected.Should().NotBeNull();
        expected!.Name.Should().Be(dto.Name);
        expected!.Type.Should().Be(dto.Type);
        expected!.Quantity.Should().Be(dto.Quantity);
    }
}