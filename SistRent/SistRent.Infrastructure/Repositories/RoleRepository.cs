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
        public Task AddAsync(Role user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Role user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetByParameterAsync(string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
