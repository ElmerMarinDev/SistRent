using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(Room room)
        {
            await _dbcontext.Room.AddAsync(room);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _dbcontext.Room.FindAsync(id);
            _dbcontext.Room.Remove(room);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(Room room)
        {
            _dbcontext.Room.Update(room);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAsync()
        {
            return await _dbcontext.Room.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _dbcontext.Room.FirstOrDefaultAsync(u => u.IdRoom == id);
        }

        public async Task<IEnumerable<Room>> GetByParameterAsync(string parameter)
        {
            return await _dbcontext.Room.
                Where(p => p.Description.Contains(parameter) || p.RoomNumber.Contains(parameter)).ToListAsync();
        }
    }
}
