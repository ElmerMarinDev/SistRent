using SistRent.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginUserDto request);

        Task ChangePasswordAsync(
            int userId,
            ChangePasswordDto request);

        Task ResetPasswordAsync(
            int userId,
            ResetPasswordDto request);
    }
}
