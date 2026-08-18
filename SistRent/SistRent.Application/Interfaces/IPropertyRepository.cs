using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAsync();
        Task<IEnumerable<Property>> GetByParameterAsync(string parameter);
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(Property Property);
        Task EditAsync(Property Property);
        Task DeleteAsync(int id);
    }
}
