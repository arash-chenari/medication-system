using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicationSystem.Services.Medications.Contracts;
using MedicationSystem.Services.Medications.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IList<GetAllMedicationDto>> GetAllMedications()
    {
        return await _dbContext.Medications.Select(_ => new GetAllMedicationDto
        {
            Code = _.Code,
            Id = _.Id,
            Name = _.Name,
            Quantity = _.Quantity,
            Type = _.Type,
            CreationDate = _.CreationDate
        }).ToListAsync();
    }
}