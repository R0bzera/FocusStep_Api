using Data.DAL;

namespace Business.Interfaces.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserDAL>> GetAllUsersAsync();
        Task<UserDAL?> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDAL usuario);
        Task UpdateUserAsync(UserDAL usuario);
        Task DeleteUserAsync(int id);
    }
}