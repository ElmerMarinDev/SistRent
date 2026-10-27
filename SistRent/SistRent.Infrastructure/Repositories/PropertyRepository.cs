using Microsoft.EntityFrameworkCore;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class PropertyRepository(AppDBContext _dbcontext) : IPropertyRepository
    {
        public async Task AddAsync(Property property)
        {
            await _dbcontext.Property.AddAsync(property);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var property = await _dbcontext.Property.FindAsync(id);
            _dbcontext.Property.Remove(property);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(Property property)
        {
            _dbcontext.Property.Update(property);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Property>> GetAsync()
        {
            return await _dbcontext.Property.ToListAsync();
        }

        public async Task<Property?> GetByIdAsync(int id)
        {
            return await _dbcontext.Property.FirstOrDefaultAsync(u => u.IdProperty == id);
        }

        public Task<IEnumerable<Property>> GetByParameterAsync(string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
