using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(Payment payment)
        {
            await _dbcontext.Payment.AddAsync(payment);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await _dbcontext.Payment.FindAsync(id);
            _dbcontext.Payment.Remove(payment);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(Payment payment)
        {
            _dbcontext.Payment.Update(payment);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetAsync()
        {
            return await _dbcontext.Payment.ToListAsync();
        }

        public Task<IEnumerable<Payment>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _dbcontext.Payment.FirstOrDefaultAsync(u => u.IdPayment== id);
        }
    }
}
