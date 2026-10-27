using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(RoomType room)
        {
            await _dbcontext.RoomType.AddAsync(room);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roomType = await _dbcontext.RoomType.FindAsync(id);
            _dbcontext.RoomType.Remove(roomType);
            await _dbcontext.SaveChangesAsync();

        }

        public async Task EditAsync(RoomType roomType)
        {
            _dbcontext.RoomType.Update(roomType);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomType>> GetAsync()
        {
            return await _dbcontext.RoomType.ToListAsync();
        }

        public async Task<RoomType?> GetByIdAsync(int id)
        {
            return await _dbcontext.RoomType.FirstOrDefaultAsync(u => u.IdRoomType == id);
        }

        public Task<IEnumerable<RoomType>> GetByParameterAsync(string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
