using FluentAssertions;
using MedicationSystem.Application.Abstractions;
using MedicationSystem.Application.Abstractions.Medications;
using MedicationSystem.Application.Medications.Commands;
using MedicationSystem.Domain.Entities;
using MedicationSystem.Domain.Entities.Enums;
using MedicationSystem.Domain.Exceptions.Medications;
using MedicationSystem.Infrastructure.Test;
using MedicationSystem.Persistence.EF;
using MedicationSystem.Persistence.EF.Medications;

namespace MedicationSystem.Application.Tests.Unit.Medications.Commands;

public class CreateMedicationTests
{
    private readonly ICommandHandler<CreateMedicationCommand> _sut;
    private readonly EFWriteDbContext _dbContext;
    public CreateMedicationTests()
    {
         _dbContext = new EFInMemoryDatabase()
                            .CreateDataContext<EFWriteDbContext>();
        IUnitOfWork unitOfWork = new EFUnitOfWork(_dbContext);
        IMedicationWriteRepository repository = 
                            new EFMedicationWriteRepository(_dbContext);
        _sut = new CreateMedicationCommandHandler(repository, unitOfWork);
    }

    [Fact]
    public async void CreateMedicationCommandHandler_Creates_New_Medication()
    {
        var command = new CreateMedicationCommand
        {
            Code = "Dummy",
            Name = "Dummy",
            Quantity = 3,
            Type = MedicationType.Capsules
        };

        await _sut.Handle(command,new CancellationToken());

        var expected = _dbContext.Medications
            .SingleOrDefault(_ => _.Code == command.Code);
        expected.Should().NotBeNull();
        expected.Code.Should().Be(command.Code);
        expected.Name.Should().Be(command.Name);
        expected.Type.Should().Be(command.Type);
        expected.Quantity.Should().Be(command.Quantity);
        expected.CreationDate.Date.Should().Be(DateTime.UtcNow.Date);
    }

    [Fact]
    public async void CreateMedicationHandler_Throws_QuantityShouldBeGreaterThanZeroException_When_Quantity_is_Zero()
    {
        var quantity = 0;
        var command = new CreateMedicationCommand
        {
            Code = "abc",
            Name = "dummy",
            Quantity =quantity,
            Type = MedicationType.Drops
        };

        Func<Task> expected = () => _sut.Handle(command,new CancellationToken());

        await expected.Should().ThrowExactlyAsync<QuantityShouldBeGreaterThanZeroException>();
    }

    [Fact]
    public async void CreateMedicationHandler_Throws_MedicationCodeShouldNotBeDuplicatedException_when_medication_with_given_Code_is_exist()
    {
        string medicationCode = "abc";
        AddMedicationWithGivenCodeToDatabase(medicationCode);
        var command = new CreateMedicationCommand
        {
            Code =  medicationCode,
            Name = "dummy",
            Quantity = 3,
            Type = MedicationType.Drops
        };

       Func<Task> expected = () => _sut.Handle(command, new CancellationToken());

       await expected.Should()
           .ThrowExactlyAsync<MedicationCodeShouldNotBeDuplicatedException>();
    }

    private void AddMedicationWithGivenCodeToDatabase(string medicationCode)
    {
        var medication = new Medication(medicationCode, "dummy",
            MedicationType.Capsules, 10);
        _dbContext.Manipulate(_=> _.Medications.Add(medication));
    }
}