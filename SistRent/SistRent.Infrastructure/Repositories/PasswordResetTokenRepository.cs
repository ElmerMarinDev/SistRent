using Microsoft.EntityFrameworkCore;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Repositories
{
    public class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {
        private readonly AppDBContext _context;

        public PasswordResetTokenRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<PasswordResetToken?> GetValidTokenAsync(string email,string tokenHash)
        {
            return await _context.PasswordResetTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.TokenHash == tokenHash &&
                    x.User.Email == email &&
                    x.UsedAt == null &&
                    x.ExpiresAt > DateTimeOffset.UtcNow);
        }

        public async Task AddAsync(PasswordResetToken resetToken)
        {
            await _context.PasswordResetTokens.AddAsync(resetToken);
        }

        public Task UpdateAsync(PasswordResetToken resetToken)
        {
            _context.PasswordResetTokens.Update(resetToken);
            return Task.CompletedTask;
        }
    }
}
