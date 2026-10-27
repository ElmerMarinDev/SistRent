using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(PaymentMethod payment)
        {
            await _dbcontext.PaymentMethod.AddAsync(payment);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paymentMethod = await _dbcontext.User.FindAsync(id);
            _dbcontext.User.Remove(paymentMethod);
            await _dbcontext.SaveChangesAsync();

        }

        public async Task EditAsync(PaymentMethod payment)
        {
            _dbcontext.PaymentMethod.Update(payment);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PaymentMethod>> GetAsync()
        {
            return await _dbcontext.PaymentMethod.ToListAsync();
        }

        public Task<IEnumerable<PaymentMethod>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentMethod?> GetByIdAsync(int id)
        {
            return await _dbcontext.PaymentMethod.FirstOrDefaultAsync(u => u.IdPaymentMethod == id);
        }
    }
}
