using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IContractStatusRepository
    {
        Task<IEnumerable<ContractStatus>> GetAsync();
        Task<ContractStatus?> GetByIdAsync(int id);
        Task AddAsync(ContractStatus ContractStatus);
        Task EditAsync(ContractStatus ContractStatus);
        Task DeleteAsync(int id);
    }
}
