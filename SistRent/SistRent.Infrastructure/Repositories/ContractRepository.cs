using Microsoft.EntityFrameworkCore;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class ContractRepository(AppDBContext _dbcontext) : IContractRepository
    {
        public async Task<IEnumerable<Contract>> GetAsync()
        {
            return await _dbcontext.Contract.ToListAsync();
        }

        public async Task<Contract?> GetByIdAsync(int id)
        {
            return await _dbcontext.Contract.FirstOrDefaultAsync(u => u.IdContract == id);
        }

        public async Task AddAsync(Contract contract)
        {
            await _dbcontext.Contract.AddAsync(contract);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var contract = await _dbcontext.Contract.FindAsync(Id);
            _dbcontext.Contract.Remove(contract);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(Contract contract)
        {
            _dbcontext.Contract.Update(contract);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Contract?> GetByRole(int id)
        {
            return await _dbcontext.Contract.FirstOrDefaultAsync(u => u.IdContract == id);
        }

        public Task<IEnumerable<Contract>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }
    }
}
