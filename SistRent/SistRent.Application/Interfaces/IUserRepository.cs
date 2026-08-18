using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User?> GetByIdAsync();
        Task<User?> LoginAsync(string Email, string password);
        Task AddAsync (User user);
        Task EditAsync(User user);
        Task DeleteAsync(User user);
    }
}
