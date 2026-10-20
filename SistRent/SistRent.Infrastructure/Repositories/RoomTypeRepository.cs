using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class RoomTypeRepository(AppDBContext _dbcontext) : IRoomTypeRepository
    {
        public Task AddAsync(RoomType room)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(RoomType room)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomType>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomType?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomType>> GetByParameterAsync(string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
