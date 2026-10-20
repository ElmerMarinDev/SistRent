using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class PaymentMethodRepository(AppDBContext _dbcontext) : IPaymentMethodRepository
    {
        public Task AddAsync(PaymentMethod payment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(PaymentMethod payment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentMethod>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentMethod>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethod?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
