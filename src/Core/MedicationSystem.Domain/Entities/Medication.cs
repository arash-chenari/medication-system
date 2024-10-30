using System;
using MedicationSystem.Domain.Abstractions;
using MedicationSystem.Domain.Entities.Enums;
using MedicationSystem.Domain.Exceptions.Medications;

namespace MedicationSystem.Domain.Entities
{
    public class Medication : Entity
    {
        public Medication(string code,
                            string name,
                            MedicationType type,
                            int quantity )
        {
            if (quantity <= 0)
            {
                throw new QuantityShouldBeGreaterThanZeroException();
            }

            Code = code;
            Name = name;
            Type = type;
            Quantity = quantity;
            CreationDate = DateTime.UtcNow;
        }
        
        public string Code { get; private set; }
        public string Name { get; private set; }
        public MedicationType Type { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int Quantity { get; private set; }
    }
}