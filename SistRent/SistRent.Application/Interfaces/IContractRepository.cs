using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> GetAsync();
        Task<IEnumerable<Contract>> GetAsync(DateOnly startDate,DateOnly endDate);
        Task<Contract?> GetByIdAsync(int id);
        Task AddAsync(Contract room);
        Task EditAsync(Contract room);
        Task DeleteAsync(int id);
    }
}
