using MedicationSystem.Services.Medications.Contracts;

namespace MedicationSystem.Persistence.EF.Medications;

public class EFMedicationRepository : IMedicationRepository
{
    private readonly EFDbContext _dbContext;
    
    public EFMedicationRepository(EFDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Entities.Medication medication)
    {
        _dbContext.Medications.Add(medication);
    }
}