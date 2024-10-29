using MedicationSystem.Contracts.Interfaces;

namespace MedicationSystem.Entities
{
    public class Medication : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
    }
}