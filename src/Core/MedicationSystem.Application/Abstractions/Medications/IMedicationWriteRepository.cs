
using MedicationSystem.Domain.Entities;

namespace MedicationSystem.Application.Abstractions.Medications
{
    public interface IMedicationWriteRepository 
    {   void Add(Medication medication);
        Task<Boolean> IsMedicationWithSameCodeExist(string code);
        Task<Medication> GetMedicationById(int id);
        void Delete(Medication medication);
    }
}