using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Entities.Enums;

namespace MedicationSystem.Entities
{
    public class Medication : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MedicationType Type { get; set; }
        public int Quantity { get; set; }
    }
}