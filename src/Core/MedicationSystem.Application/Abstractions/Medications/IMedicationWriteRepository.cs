
using MedicationSystem.Domain.Entities;

namespace MedicationSystem.Application.Abstractions.Medications
{
    public interface IMedicationWriteRepository 
    {
        public void Add(Medication medication);
        Task<Boolean> IsMedicationWithSameCodeExist(string code);
    }
}