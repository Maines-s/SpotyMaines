namespace SpotyMaines.Domain.Shared
{
    public interface IPersistenceContext
    {
        Task<bool> SaveData();

        void UndoChanges();
    }
}
