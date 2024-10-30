using System.Threading.Tasks;
using MedicationSystem.Application.Abstractions.Medications;
using MedicationSystem.Domain.Abstractions;
using MedicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicationSystem.Persistence.EF.Medications;

public class EFMedicationWriteRepository : IMedicationWriteRepository
{
    private readonly EFWriteDbContext _writeDbContext;
    
    public EFMedicationWriteRepository(EFWriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
    }

    public void Add(Medication medication)
    {
        _writeDbContext.Medications.Add(medication);
    }

    public async Task<bool> IsMedicationWithSameCodeExist(string code)
    {
        return await _writeDbContext.Medications
                        .AnyAsync(_ => _.Code == code);
    }

    public async Task<Medication> GetMedicationById(int id)
    {
        return await _writeDbContext.Medications
                      .FirstOrDefaultAsync(_ => _.Id == id);
    }

    public void Delete(Medication medication)
    {
        _writeDbContext.Medications.Remove(medication);
    }
}