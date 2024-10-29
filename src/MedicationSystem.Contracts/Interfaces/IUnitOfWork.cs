using System.Threading.Tasks;

namespace MedicationSystem.Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        public void Begin();
        public Task CommitAsync();
        public void RollBack();
        public Task CompleteAsync();
    }
}