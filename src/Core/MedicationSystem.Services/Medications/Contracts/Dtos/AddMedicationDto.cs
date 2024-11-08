using MedicationSystem.Entities.Enums;

namespace MedicationSystem.Services.Medications.Contracts.Dtos
{
    public class AddMedicationDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public MedicationType Type { get; set; }
        public int Quantity { get; set; }
    }
}