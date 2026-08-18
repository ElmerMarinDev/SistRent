using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Tenant>> GetAsync();
        Task<Tenant?> GetByIdAsync();
        Task<IEnumerable<Tenant>> GetByParameterAsync(string parameter);
        Task AddAsync(Tenant Tenant);
        Task EditAsync(Tenant Tenant);
        Task DeleteAsync(Tenant Tenant);
    }
}
