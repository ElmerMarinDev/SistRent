using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAsync();
        Task<IEnumerable<Payment>> GetAsync(DateOnly startDate, DateOnly endDate);
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task EditAsync(Payment payment);
        Task DeleteAsync(int id);
    }
}
