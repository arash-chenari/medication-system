using MediatR;
using MedicationSystem.Application.Medications.Commands;
using MedicationSystem.Application.Medications.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MedicationSystem.RestApi.Controllers
{
    [Route("api/medications")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly ISender _sender;
        
        public MedicationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task CreateMedication(CreateMedicationCommand command)
        {
            await _sender.Send(command);
        }

        [HttpGet]
        public async Task<IList<MedicationResponseModel>> GetAllMedications()
        {
            var query = new GetAllMedicationsQuery();
            return await _sender.Send(query);
        }
    }
}
