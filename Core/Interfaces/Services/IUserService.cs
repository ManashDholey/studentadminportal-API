

using Core.Entities.Identity;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        //Task<AppUser?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser?> GetById(string id);
        //Task<AppUser?> AddAndUpdateUser(AppUser userObj);
    }
}
