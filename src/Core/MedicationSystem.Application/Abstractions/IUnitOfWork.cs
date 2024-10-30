namespace MedicationSystem.Application.Abstractions
{
    public interface IUnitOfWork
    {
        public void Begin();
        public Task CommitAsync();
        public void RollBack();
        public Task CompleteAsync();
    }
}