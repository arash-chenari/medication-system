using MedicationSystem.Application.Medications.Queries;

namespace MedicationSystem.Application.Abstractions.Medications
{
    public interface IMedicationReadRepository
    {
        Task<IList<MedicationResponseModel>> GetAllMedications();
    }
}