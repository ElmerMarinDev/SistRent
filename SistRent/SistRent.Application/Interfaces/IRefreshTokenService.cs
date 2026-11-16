using SistRent.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenResponseDto> CreateAsync(int userId);

        Task<RefreshTokenResponseDto> RefreshAsync(string refreshToken);

        Task RevokeAsync(string refreshToken);

        Task RevokeAllAsync(int userId);

    }
}
