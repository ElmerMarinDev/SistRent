using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class PaymentRepository(AppDBContext _dbcontext) : IPaymentRepository
    {
        public Task AddAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
