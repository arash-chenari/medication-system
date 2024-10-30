using MedicationSystem.Application.Abstractions;

namespace MedicationSystem.Application.Medications.Commands;

public class DeleteMedicationCommand : ICommand
{
    public int Id { get; set; }
}