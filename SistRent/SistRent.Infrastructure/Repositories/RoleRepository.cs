using Microsoft.EntityFrameworkCore;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class RoleRepository(AppDBContext _dbcontext) : IRoleRepository
    {
        public async Task AddAsync(Role role)
        {
            await _dbcontext.Role.AddAsync(role);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _dbcontext.Role.FindAsync(id);
            _dbcontext.Role.Remove(role);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(Role role)
        {
            _dbcontext.Role.Update(role);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAsync()
        {
            return await _dbcontext.Role.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _dbcontext.Role.FirstOrDefaultAsync(u => u.IdRole == id);
        }

        public async Task<IEnumerable<Role>> GetByParameterAsync(string parameter)
        {
            return await _dbcontext.Role.
                Where(p => p.Name.Contains(parameter) || p.Description.Contains(parameter)).ToListAsync();
        }
    }
}
