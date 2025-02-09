using Business.Interfaces.User;
using Data.DAL;
using Data.Interfaces.User;

namespace Business.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDAL>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserDAL?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddUserAsync(UserDAL usuario)
        {
            await _userRepository.AddAsync(usuario);
        }

        public async Task UpdateUserAsync(UserDAL usuario)
        {
            await _userRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
