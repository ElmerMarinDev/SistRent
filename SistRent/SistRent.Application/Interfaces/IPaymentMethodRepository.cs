using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetAsync();
        Task<IEnumerable<PaymentMethod>> GetAsync(DateOnly startDate, DateOnly endDate);
        Task<PaymentMethod?> GetByIdAsync(int id);
        Task AddAsync(PaymentMethod payment);
        Task EditAsync(PaymentMethod payment);
        Task DeleteAsync(int id);
    }
}
