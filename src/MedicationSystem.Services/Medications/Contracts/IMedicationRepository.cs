using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Entities;

namespace MedicationSystem.Services.Medications.Contracts
{
    public interface IMedicationRepository : IRepository
    {
        public void Add(Medication medication);
    }
}