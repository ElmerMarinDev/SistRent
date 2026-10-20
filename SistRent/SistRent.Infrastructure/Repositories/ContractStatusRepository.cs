using Microsoft.EntityFrameworkCore;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class ContractStatusRepository(AppDBContext _dbcontext) : IContractStatusRepository
    {

        public async Task<IEnumerable<ContractStatus>> GetAsync()
        {
            return await _dbcontext.ContractStatus.ToListAsync();
        }

        public async Task<ContractStatus?> GetByIdAsync(int id)
        {
            return await _dbcontext.ContractStatus.FirstOrDefaultAsync(u => u.IdContractStatus == id);
        }

        public async Task AddAsync(ContractStatus contract)
        {
            await _dbcontext.ContractStatus.AddAsync(contract);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var user = await _dbcontext.ContractStatus.FindAsync(Id);
            _dbcontext.ContractStatus.Remove(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(ContractStatus contract)
        {
            _dbcontext.ContractStatus.Update(contract);
            await _dbcontext.SaveChangesAsync();
        }


    }
}
