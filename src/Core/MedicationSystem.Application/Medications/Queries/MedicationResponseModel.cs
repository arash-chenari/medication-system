using MedicationSystem.Domain.Entities.Enums;

namespace MedicationSystem.Application.Medications.Queries;

public class MedicationResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public MedicationType Type { get; set; }
    public DateTime CreationDate { get; set; }
    public int Quantity { get; set; }
}