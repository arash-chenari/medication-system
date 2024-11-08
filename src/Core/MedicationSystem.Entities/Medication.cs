using System;
using MedicationSystem.Contracts.Interfaces;
using MedicationSystem.Entities.Enums;

namespace MedicationSystem.Entities
{
    public class Medication : IEntity
    {
        public Medication()
        {
            CreationDate = DateTime.UtcNow;
        }
        
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MedicationType Type { get; set; }
        public DateTime CreationDate { get; set; }
        public int Quantity { get; set; }
    }
}