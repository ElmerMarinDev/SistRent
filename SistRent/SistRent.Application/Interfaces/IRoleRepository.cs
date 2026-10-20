using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<IEnumerable<Role>> GetByParameterAsync(string parameter);
        Task AddAsync(Role user);
        Task EditAsync(Role user);
        Task DeleteAsync(int id);
    }
}
