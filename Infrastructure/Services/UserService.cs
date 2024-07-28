using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.Services;
using Infrastructure.Data.Identity;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly AppIdentityDbContext _appIdentityDbContext;
        private readonly IUserRepository _userRepository;

        public UserService(IOptions<AppSettings> appSettings, AppIdentityDbContext appIdentityDbContext, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _appIdentityDbContext = appIdentityDbContext;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<AppUser?> GetById(string id)
        {
            return await _userRepository.GetById(id);
        }
    }
}
