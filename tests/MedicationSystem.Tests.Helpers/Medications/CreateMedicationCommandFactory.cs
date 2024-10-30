using MedicationSystem.Application.Medications.Commands;
using MedicationSystem.Domain.Entities.Enums;

namespace MedicationSystem.Tests.Helpers.Medications;

public static class CreateMedicationCommandFactory
{
   public static CreateMedicationCommand Create(
      string code = "abc",
      string name = "dummy",
      MedicationType type = MedicationType.Capsules,
      int quantity = 5)
   {
      return new CreateMedicationCommand
      {
         Code = code,
         Quantity = quantity,
         Type = type,
         Name = name
      };
   }
}