using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> GetAsync();
        Task<IEnumerable<RoomType>> GetByParameterAsync(string parameter);
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(RoomType room);
        Task EditAsync(RoomType room);
        Task DeleteAsync(int id);
    }
}
