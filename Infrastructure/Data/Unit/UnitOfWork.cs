using Core.Entities.DataModels;
using Core.Interfaces;
using Core.Interfaces.Unit;
using Infrastructure.Data.Repositories;
using studentadminportal_API.DataModels;
using System.Collections;


namespace Infrastructure.Data.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentAdminContext _context;
        private Hashtable _repositories;
        public UnitOfWork(StudentAdminContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseTable
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
