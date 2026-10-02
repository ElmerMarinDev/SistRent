using Microsoft.EntityFrameworkCore;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class UserRepository(AppDBContext _dbcontext) : IUserRepository
    {

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _dbcontext.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbcontext.User.FirstOrDefaultAsync(u=>u.IdUser==id);
        }

        public async Task<User?> LoginAsync(string Email, string password)
        {
            return await _dbcontext.User.FirstOrDefaultAsync(u => u.Email == Email && u.PasswordHash==password);
        }

        public async Task AddAsync(User user)
        {
            await _dbcontext.User.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var user = await _dbcontext.User.FindAsync(Id);
            _dbcontext.User.Remove(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(User user)
        {
            _dbcontext.User.Update(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<User?> GetByRole(int id)
        {
            return await _dbcontext.User.FirstOrDefaultAsync(u => u.IdRole == id);
        }


    }
}
