using System.Threading.Tasks;
using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Services.Medications.Contracts.Dtos;

namespace MedicationSystem.Services.Medications.Contracts
{
    public interface IMedicationService : IService
    {
        public Task AddAsync(AddMedicationDto dto);
    }
}