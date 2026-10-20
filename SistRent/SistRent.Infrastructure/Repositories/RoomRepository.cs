using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class RoomRepository(AppDBContext _dbcontext) : IRoomRepository
    {
        public Task AddAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Room?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetByParameterAsync(string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
