using MedicationSystem.Application.Abstractions;
using MedicationSystem.Application.Abstractions.Medications;
using MedicationSystem.Domain.Entities;
using MedicationSystem.Domain.Exceptions.Medications;

namespace MedicationSystem.Application.Medications.Commands;

public class DeleteMedicationCommandHandler : ICommandHandler<DeleteMedicationCommand>
{
    private readonly IMedicationWriteRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMedicationCommandHandler(
                    IMedicationWriteRepository repository,
                     IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await _repository.GetMedicationById(request.Id);
         
        CheckForMedicationExistance(medication);

        _repository.Delete(medication);
        await _unitOfWork.CompleteAsync();
    }

    private void CheckForMedicationExistance(Medication medication)
    {
        if(medication is null)
            throw new MedicationNotFoundException();
    }
}