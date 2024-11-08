using System.Threading.Tasks;
using MedicationSystem.Contracts.Interfaces;

namespace MedicationSystem.Persistence.EF;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly EFDbContext _dbContext;
    
    public EFUnitOfWork(EFDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Begin()
    {
        _dbContext.Database.BeginTransaction();
    }

    public async Task CommitAsync()
    {
       await  _dbContext.Database.CommitTransactionAsync();
    }

    public void RollBack()
    {
        _dbContext.Database.RollbackTransaction();
    }

    public async Task CompleteAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}