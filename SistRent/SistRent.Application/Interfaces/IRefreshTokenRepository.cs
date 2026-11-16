using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);

        Task<RefreshToken?> GetByHashAsync(string tokenHash);

        Task<List<RefreshToken>> GetActiveByUserIdAsync(int userId);

        Task UpdateAsync(RefreshToken refreshToken);

        Task UpdateRangeAsync(IEnumerable<RefreshToken> refreshTokens);

        Task SaveChangesAsync();
    }
}
