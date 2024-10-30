using System.Collections;
using MedicationSystem.Application.Abstractions;
using MedicationSystem.Application.Abstractions.Medications;
using MedicationSystem.Domain.Abstractions;

namespace MedicationSystem.Application.Medications.Queries;

public class GetAllMedicationQueryHandler: IQueryHandler<GetAllMedicationsQuery,IList<MedicationResponseModel>>
{
    private readonly IMedicationReadRepository _repository;

    public GetAllMedicationQueryHandler(IMedicationReadRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IList<MedicationResponseModel>> Handle(GetAllMedicationsQuery request, CancellationToken cancellationToken)
    {
        return  await _repository.GetAllMedications();
    }
}