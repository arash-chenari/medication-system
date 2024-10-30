using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Entities;
using MedicationSystem.Services.Medications.Contracts.Dtos;

namespace MedicationSystem.Services.Medications.Contracts
{
    public interface IMedicationRepository : IRepository
    {
        public void Add(Medication medication);
        Task<IList<GetAllMedicationDto>> GetAllMedications();
    }
}