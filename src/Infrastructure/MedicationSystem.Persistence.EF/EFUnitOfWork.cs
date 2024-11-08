using System.Threading.Tasks;
using MedicationSystem.Application.Abstractions;
using MedicationSystem.Domain.Abstractions;

namespace MedicationSystem.Persistence.EF;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly EFWriteDbContext _writeDbContext;
    
    public EFUnitOfWork(EFWriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
    }
    
    public void Begin()
    {
        _writeDbContext.Database.BeginTransaction();
    }

    public async Task CommitAsync()
    {
       await  _writeDbContext.Database.CommitTransactionAsync();
    }

    public void RollBack()
    {
        _writeDbContext.Database.RollbackTransaction();
    }

    public async Task CompleteAsync()
    {
        await _writeDbContext.SaveChangesAsync();
    }
}