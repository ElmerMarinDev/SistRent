using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAsync();
        Task<IEnumerable<Room>>GetByParameterAsync(string parameter);
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(Room room);
        Task EditAsync(Room room);
        Task DeleteAsync(int id);
    }
}
