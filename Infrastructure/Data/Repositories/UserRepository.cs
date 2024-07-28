using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppIdentityDbContext _appIdentityDbContext;

        public UserRepository(AppIdentityDbContext appIdentityDbContext)
        {
            _appIdentityDbContext = appIdentityDbContext;
        }
        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _appIdentityDbContext.Users.ToListAsync();
        }

        public async Task<AppUser?> GetById(string id)
        {
            return await _appIdentityDbContext.Users.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    }
}
