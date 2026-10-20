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
        public Task AddAsync(Property Property)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Property Property)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Property?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetByParameterAsync(string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
