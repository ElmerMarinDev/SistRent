using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SistRent.Infrastructure.Repositories
{
    public class RefreshTokenRepository:IRefreshTokenRepository
    {
        private readonly AppDBContext _context;

        public RefreshTokenRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public Task<RefreshToken?> GetByHashAsync(string tokenHash)
        {
            return _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.TokenHash == tokenHash);
        }

        public Task<List<RefreshToken>> GetActiveByUserIdAsync(int userId)
        {
            return _context.RefreshTokens
                .Where(x =>
                    x.IdUser == userId &&
                    x.RevokedAt == null &&
                    x.ExpiresAt > DateTimeOffset.UtcNow)
                .ToListAsync();
        }

        public Task UpdateAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);
            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<RefreshToken> refreshTokens)
        {
            _context.RefreshTokens.UpdateRange(refreshTokens);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
