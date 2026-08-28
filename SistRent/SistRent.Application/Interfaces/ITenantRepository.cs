using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Role>> GetAsync();
        Task<Role?> GetByIdAsync();
        Task<IEnumerable<Role>> GetByParameterAsync(string parameter);
        Task AddAsync(Role Tenant);
        Task EditAsync(Role Tenant);
        Task DeleteAsync(Role Tenant);
    }
}
