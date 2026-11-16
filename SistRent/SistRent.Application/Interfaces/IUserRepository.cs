using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByRole(int id);
        Task<User?> LoginAsync(string Email, string password);
        Task AddAsync (User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
