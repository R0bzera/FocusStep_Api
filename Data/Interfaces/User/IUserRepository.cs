using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL;

namespace Data.Interfaces.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDAL>> GetAllAsync();
        Task<UserDAL?> GetByIdAsync(int id);
        Task AddAsync(UserDAL user);
        Task UpdateAsync(UserDAL user);
        Task DeleteAsync(int id);
    }
}
