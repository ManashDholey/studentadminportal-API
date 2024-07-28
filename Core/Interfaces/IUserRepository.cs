using Core.Entities.Identity;

namespace Core.Interfaces
{
    public  interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser?> GetById(string id);
    }
}
