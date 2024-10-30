using MedicationSystem.Application.Abstractions;
using MedicationSystem.Application.Abstractions.Medications;
using MedicationSystem.Domain.Abstractions;
using MedicationSystem.Domain.Entities;
using MedicationSystem.Domain.Exceptions.Medications;

namespace MedicationSystem.Application.Medications.Commands;

public class CreateMedicationCommandHandler : ICommandHandler<CreateMedicationCommand>
{
    private readonly IMedicationWriteRepository _writeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMedicationCommandHandler(
                IMedicationWriteRepository writeRepository,
                IUnitOfWork unitOfWork)
    {
        _writeRepository = writeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CreateMedicationCommand request,
                            CancellationToken cancellationToken)
    {
        await PreventToCreateMedicationWithDuplicateCode(request.Code);

        var medication = new Medication(
                             request.Code,
                             request.Name,
                             request.Type,
                             request.Quantity);
        
        _writeRepository.Add(medication);
        await _unitOfWork.CompleteAsync();
    }

    private async Task PreventToCreateMedicationWithDuplicateCode(string code)
    {
        var isMedicationWithSameCodeExist =
            await _writeRepository.IsMedicationWithSameCodeExist(code);
       
        if (isMedicationWithSameCodeExist)
        {
            throw new MedicationCodeShouldNotBeDuplicatedException();
        }
    }
}