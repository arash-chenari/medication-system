using MedicationSystem.Application.Abstractions;

namespace MedicationSystem.Application.Medications.Queries;

public class GetAllMedicationsQuery : IQuery<IList<MedicationResponseModel>>
{
}