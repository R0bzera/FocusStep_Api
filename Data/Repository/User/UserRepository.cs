using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.DAL;
using Data.Interfaces.User;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDAL>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<UserDAL?> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task AddAsync(UserDAL usuario)
        {
            _context.User.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDAL usuario)
        {
            _context.User.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.User.FindAsync(id);
            if (usuario != null)
            {
                _context.User.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
