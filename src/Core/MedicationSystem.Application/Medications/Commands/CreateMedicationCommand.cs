using MedicationSystem.Application.Abstractions;
using MedicationSystem.Domain.Entities.Enums;

namespace MedicationSystem.Application.Medications.Commands;

public class CreateMedicationCommand : ICommand
{
    public string Name { get; set; }
    public string Code { get; set; }
    public MedicationType Type { get; set; }
    public int Quantity { get; set; }
} 