using System;
using MedicationSystem.Entities.Enums;

namespace MedicationSystem.Services.Medications.Contracts.Dtos
{
    public class GetAllMedicationDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MedicationType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}