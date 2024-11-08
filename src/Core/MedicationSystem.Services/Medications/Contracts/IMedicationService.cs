using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Services.Medications.Contracts.Dtos;

namespace MedicationSystem.Services.Medications.Contracts
{
    public interface IMedicationService : IService
    {
        Task AddAsync(AddMedicationDto dto);
        Task<IList<GetAllMedicationDto>> GetAllMedications ();
    }
}