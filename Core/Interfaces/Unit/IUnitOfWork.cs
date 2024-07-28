using Core.Entities.DataModels;


namespace Core.Interfaces.Unit
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseTable;
        Task<int> Complete();
    }
}
