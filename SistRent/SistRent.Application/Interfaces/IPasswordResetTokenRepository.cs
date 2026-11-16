using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IPasswordResetTokenRepository
    {
        Task<PasswordResetToken?> GetValidTokenAsync(string email,string tokenHash);

        Task AddAsync(PasswordResetToken resetToken);

        Task UpdateAsync(PasswordResetToken resetToken);
    }
}
