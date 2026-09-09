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
            return await _dbcontext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(u=>u.IdUser==id);
        }

        public async Task<User?> LoginAsync(string Email, string password)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(u => u.Email == Email && u.PasswordHash==password);
        }

        public async Task AddAsync(User user)
        {
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(User user)
        {
            throw new NotImplementedException();
        }






    }
}
