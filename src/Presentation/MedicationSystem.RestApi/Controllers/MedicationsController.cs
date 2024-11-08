using MedicationSystem.Services.Medications.Contracts;
using MedicationSystem.Services.Medications.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicationSystem.RestApi.Controllers
{
    [Route("api/medications")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationService _service;
        
        public MedicationsController(IMedicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Add(AddMedicationDto dto)
        {
            await _service.AddAsync(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllMedicationDto>> GetAllMedication()
        {
            return await _service.GetAllMedications();
        }
    }
}
